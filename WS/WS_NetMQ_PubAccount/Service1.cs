using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        }

        protected override void OnStop()
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "服务停止了");
        }

        protected override void OnShutdown()
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "电脑关闭了");
        }
    }
}
