using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 检测委托线程的结束_通过等待句柄和回调函数
{
    class Program
    {
        static int Test(int i, string str)
        {
            Console.WriteLine("test" + i + str);
            Thread.Sleep(100);//让当前的线程休眠  单位ms
            return 100;//当它执行完时候才能获取到返回值
        }
        static void Main(string[] args)
        {
            //Func<int, string, int> a = Test;//通过委托，开启一个线程
            //IAsyncResult ar = a.BeginInvoke(100, "zhong", null, null);//开启一个新的线程去执行 a所引用的方法
            //IAsyncResult 可以取得当前线程的状态
            //可以认为线程是同时执行的(异步执行)
            Console.WriteLine("mian");
            //检查线程结束
            //bool isEnd= ar.AsyncWaitHandle.WaitOne(1000);//WaitOne方法可以等待当前线程结束再执行下面代码   
            //                                             //要一个等待时间  再时间内完成，返回true 否则false
            //if (isEnd)
            //{
            //    int res= a.EndInvoke(ar);
            //    Console.WriteLine(res);
            //}

            //通过回调 检测线程结束
            Func<int, string, int> a = Test;//通过委托，开启一个线程
            ////倒数第二个参数是一个委托类型参数，表示回调函数，当线程结束的时候会调用这个委托指向的方法
            ////倒数一个参数是给回调函数传递参数的
            //IAsyncResult ar = a.BeginInvoke(100, "zhong", OnCallBack, a);//开启一个新的线程去执行 a所引用的方法


            //在lamdba表达式中取得
            a.BeginInvoke(100, "zhong", ar =>
              {
                  int res = a.EndInvoke(ar);
                  Console.WriteLine("在lamdba表达式中取得");
              },null);

            Console.ReadKey();
        }

        static void OnCallBack(IAsyncResult ar) 
        {
            Func<int, string, int> a = ar.AsyncState as Func<int, string, int>;
            int res= a.EndInvoke(ar);
            Console.WriteLine(res);
        }
    }
}
