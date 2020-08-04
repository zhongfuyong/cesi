using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 线程的开启_任务;

namespace 线程问题__争用条件
{
    class Program
    {
        static void ChangeState(object o) 
        {
            MyThreadObject m = o as MyThreadObject;
            while (true)
            {
                lock (m)//向系统申请可不可以锁定m对象，如果没有被锁定就可以，否之就暂停，直到申请到
                {
                    m.ChangeState();//在同一时刻只有一个线程在执行这个方法
                }//释放锁
                
            }
        }
        static void Main(string[] args)
        {
            MyThreadObject m = new MyThreadObject();
            Thread t = new Thread(ChangeState);
            t.Start(m);

            Thread t2 = new Thread(ChangeState);
            t2.Start(m);
            Console.ReadKey();
        }
    }
}
