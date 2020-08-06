using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        /// <summary>
        /// 饿汉式单例（方法没有同步）
        /// 优点：立即加载是天然的线程安全性高，，调用效率高
        /// 缺点：没有延时加载的优势
        /// </summary>
        //private static Program s = new Program();//类初始化时立即加载
        //private Program() {}
        //public static Program grtInstance() 
        //{
        //    return s;
        //}


        /// <summary>
        /// private Program() { }等价于：
        /// static Program()
        /// {
        ///    s= new Program();
        /// }
        /// 
        /// 利用了静态机制实现了防止多线程的问题
        /// </summary>
        /// 


        /// <summary>
        /// 懒汉式单例（方法同步）
        /// 优点：加载是天然的线程安全性高，延时加载，资源利用率高了
        /// 缺点：调用效率低了
        /// </summary>
        //private static volatile Program s;//volatile保证多线程时候不重新调整排序
        //private static object lockHelper = new object();//辅助器
        //private Program() { }
        //public static   Program grtInstance() 
        //{
        //    if (s==null)
        //    {
        //        lock (lockHelper)
        //        if (s == null)
        //        {
        //            s = new Program();
        //        }
        //    }
        //    return s;
        //}




























        static void Main(string[] args)
        {
            
        }
    }
}
