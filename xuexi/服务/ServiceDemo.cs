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

namespace 服务
{
    public partial class ServiceDemo : ServiceBase
    {
        public ServiceDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            string startStr = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "程序启动");
            Log(startStr);
        }

        /// <summary>
        /// 停止
        /// </summary>
        protected override void OnStop()
        {
            string stopStr = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "程序停止");
            Log(stopStr);
        }
        void Log(string str)
        {
            string path = "D://logFile.log";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
        }
    }
}
