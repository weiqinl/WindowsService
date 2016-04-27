using NetMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WS_NetMQ_PubAccount
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "服务启动了");
            LogHelper.Log(start);

            using (NetMQContext context = NetMQContext.Create())
            {
                Server(context);
            }
        }

        protected override void OnStop()
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "服务停止了");
            LogHelper.Log(start);
        }

        protected override void OnShutdown()
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "电脑关闭了");
            LogHelper.Log(start);
        }


        internal void DebugStart()
        {
            this.ServiceStart();
        }

        private void ServiceStart()
        {
            //TODO:
            ///使用NetMQ 作为服务端，处理接收到的消息
            ///
            using (NetMQContext context = NetMQContext.Create())
            {
                Server(context);
            }
            Console.WriteLine("start");
        }

        internal void DebugStop()
        {
            this.ServiceStop();
        }

        private void ServiceStop()
        {
            //throw new NotImplementedException();
            Console.WriteLine("stop");
        }

        public void Server(NetMQContext context)
        {
            using (NetMQSocket serverSocket = context.CreateResponseSocket())
            {
                serverSocket.Bind("tcp://*:5555");
                while (true)
                {
                    string message = serverSocket.ReceiveFrameString();

                    Console.WriteLine("Receive message {0}", message);
                    serverSocket.SendFrame("World");
                    if (message == "exit")
                    {
                        break;
                    }
                }
            }
        }
    }
}
