using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamRead_StreamWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建文本文件读取流
            //StreamReader read = new StreamReader("xxx");

            //while (true)
            //{
            //    string str = read.ReadLine();//读取文本的一行，如果没有了返回null
            //    Console.WriteLine(str);
            //    if (str==null)
            //    {
            //        break;
            //    }
            //}

            //string str= read.ReadToEnd();//读取文本到最后结尾

            //while (true)
            //{
            //    char c = (char)read.Read();//读取文本的一个字符
            //    int res = read.Read();
            //    if (res==-1)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine(c);
            //    }
            //}


            //read.Close();
            //Console.ReadKey();


            

            StreamWriter writer = new StreamWriter("xxx");
            //如果没有此问价就会新建 ，如果存在将会被覆盖

            while (true)
            {
                string messages = Console.ReadLine();
                writer.Write(messages);
                if (messages=="q")
                {
                    break;
                }
            }

            writer.Close();
            Console.ReadKey();
        }
    }
}
