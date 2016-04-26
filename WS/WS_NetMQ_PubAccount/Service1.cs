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
            Log(start);

        }

        protected override void OnStop()
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "服务停止了");
            Log(start);
        }

        protected override void OnShutdown()
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "电脑关闭了");
            Log(start);
        }

        void Log(string str)
        {

            string path = "E:6.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
        }
    }
}
