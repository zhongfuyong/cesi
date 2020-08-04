using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过Thread创建线程
{
    class Program
    {
        static void DownLoadFile(object filename) 
        {
            Console.WriteLine("开始下载"+Thread.CurrentThread.ManagedThreadId+filename); //Thread.CurrentThread.ManagedThreadId获取线程ID
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
        static void Main(string[] args)
        {
            //Thread t = new Thread(DownLoadFile);//创建了一个Thread对象，这个线程并没有启动
            //Console.WriteLine("Main");



            //Thread t = new Thread(()=> 
            //{
            //    Console.WriteLine("开始下载" + Thread.CurrentThread.ManagedThreadId); //Thread.CurrentThread.ManagedThreadId获取线程ID
            //    Thread.Sleep(2000);
            //    Console.WriteLine("下载完成");
            //});

            MyThread mt = new MyThread("https://www.xxx.bbs","好东西");
            Thread t= new Thread(mt.DownFile);

            t.Start();//开始执行线程
            Console.ReadKey();

        }
    }
}
