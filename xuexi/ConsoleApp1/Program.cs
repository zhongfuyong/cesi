using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //一般我们会为比较耗时的操作 开启单独的线程执行
        static int Test(int i,string str)
        {
            Console.WriteLine("test"+i+str);
            Thread.Sleep(100);//让当前的线程休眠  单位ms
            return 100;//当它执行完时候才能获取到返回值
        }
        static void Main(string[] args)
        {
            Func<int,string,int> a = Test;//通过委托，开启一个线程
            IAsyncResult ar= a.BeginInvoke(100,"zhong",null, null);//开启一个新的线程去执行 a所引用的方法
            //IAsyncResult 可以取得当前线程的状态
            //可以认为线程是同时执行的(异步执行)
            Console.WriteLine("mian");
            while (ar.IsCompleted==false)//如果当前线程没有执行完毕
            {
                Console.Write(".");
                Thread.Sleep(10);
            }
            int res= a.EndInvoke(ar);//取得异步线程的返回值
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
