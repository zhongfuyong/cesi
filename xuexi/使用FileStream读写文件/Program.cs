using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 使用FileStream读写文件
{
    class Program
    {
        //一般使用filestream处理二进制的文件
        static void Main(string[] args)
        {
            ////1、创建文件流  用来操作问及那
            //FileStream stream = new FileStream("xxx",FileMode.Open);

            ////2、读取或写入文件数据
            //byte[] data = new byte[1024];//数据容器

            //while (true)
            //{
            //    int length = stream.Read(data, 0, 1024);
            //    if (length==0)
            //    {
            //        break;
            //    }
            //    for (int i = 0; i < length; i++)
            //    {
            //        Console.WriteLine(data[i] + "");
            //    }

            //    Console.ReadKey();
            //}


            //使用filestream完成文件复制
            FileStream readstream = new FileStream("xxx",FileMode.Open);
            FileStream writeStream = new FileStream("xxx2",FileMode.Create);
            byte[] data = new byte[1024];//数据容器
            while (true)
            {
                int length= readstream.Read(data, 0, data.Length);
                if (length==0)
                {
                    Console.WriteLine("读取结束");
                    break;
                }
                else
                {
                    writeStream.Write(data,0,length);
                }
                writeStream.Close();
                readstream.Close();
            }
        }
    }
}
