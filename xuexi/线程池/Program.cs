using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池
{
    class Program
    {
        //系统已经有一个ThreadPool类管理线程,这个类会在需要时增减池中线程的线程数,直到达到最大的线程数 也可以指定在创建线程池时应立即启动的最小线程数 
        //默认配置1023个工作线程和1000个IO线程
        //线程池创建出来的都是后台线程，且通常是小线程
        //不能把入池的线程改为前台线程，不能给入池的线程设置优先级或名称

        static void TheadMethod(object state) 
        {
            Console.WriteLine("线程开始:"+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("线程结束");
        }
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(TheadMethod);//ThreadPool.QueueUserWorkItem指的是发起一个工作线程
            ThreadPool.QueueUserWorkItem(TheadMethod);//ThreadPool.QueueUserWorkItem指的是发起一个工作线程
            ThreadPool.QueueUserWorkItem(TheadMethod);//ThreadPool.QueueUserWorkItem指的是发起一个工作线程
            ThreadPool.QueueUserWorkItem(TheadMethod);//ThreadPool.QueueUserWorkItem指的是发起一个工作线程
            Console.ReadKey();
        }
    }
}
