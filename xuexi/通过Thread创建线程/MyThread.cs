using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过Thread创建线程
{
    class MyThread
    {
        private string filename;
        private string filepath;
        public MyThread(string fileName,string filePath) 
        {
            this.filename = fileName;
            this.filepath = filePath;
        }
        public void DownFile() 
        {
            Console.WriteLine("开始下载"+filepath+filename);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
    }
}
