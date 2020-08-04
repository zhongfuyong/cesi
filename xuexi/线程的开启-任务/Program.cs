using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程的开启_任务
{
    class Program
    {
        static void TheadMethod()
        {
            Console.WriteLine("任务开始:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("任务结束");
        }
        static void Main(string[] args)
        {
            //Task t = new Task(TheadMethod);//传递一个需要线程去执行的方法
            //t.Start();

            //TaskFactory tf = new TaskFactory();//创建任务工厂
            //Task t= tf.StartNew(TheadMethod);//调用一个方法，会返回执行
            
            Console.WriteLine("mian");
            Console.ReadKey();
        }
    }
}
