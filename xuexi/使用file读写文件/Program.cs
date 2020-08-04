using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用file读写文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取文件:

            //string[] strArray = File.ReadAllLines("xxx");//读取文件，
            ////把每一个行文本读取成一个字符串，最后组成一个字符串的数组
            //foreach (var item in strArray)
            //{
            //    Console.WriteLine(item);
            //}

            //string s= File.ReadAllText("xxx");//把所有的内容读取成一个字符串
            //Console.WriteLine(s);

            //byte[] byteArray= File.ReadAllBytes("xxx");
            //foreach (var item in byteArray)
            //{
            //    Console.WriteLine(item);
            //}

            //写入文件:

            //File.WriteAllText("xxx","xxx");

            File.WriteAllLines("xxx", new string[] { "xxx", "xxx" });
            //写入一个集合

            //File.WriteAllBytes();写入字节

            Console.ReadKey();
        }
    }
}
