using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 后台线程和前台线程
{
    class Program
    {
        //线程的优先级;
        //多个线程执行的时候，会根据线程的优先级来判断执行哪一个线程，如果相同，就使用一个循环调度规则
        //在Thead类中，可以设置Priority属性，以影响线程的基本优先级，Priority属性是一个ThreadPriority枚举定义的一个值。
        //定义的级别有Highest，AboveNormal，BelowNormal和Lowest。

        //使用Thread对象的Abort0方法可以停止线程  线程休眠进入WaitSleepJoin状态   抛出一个ThreadAbortException类型的异常     可以用try catch中止这个异常

        //t.join()方法可以让当前执行的线程进入睡眠，等到t线程执行完再执行

        static void DownloadFile(object filename)
        {
            Console.WriteLine("开始下载" + Thread.CurrentThread.ManagedThreadId + filename);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
        static void Main(string[] args)
        {
            //当前台线程已经运行完毕时，后台线程还有没完成将会被强制关闭
            //Thread t = new Thread(DownloadFile);
            Thread t = new Thread(DownloadFile);
            t.IsBackground = true;//设置为后台线程
            t.Start("xxx");

        }
    }
}
