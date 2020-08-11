using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INI文件
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");//在当前程序路径创建
            File.Create(filePath);//创建INI文件
            //写入节点1
            INIConfig.Write("s1", "1", "a", filePath);
            INIConfig.Write("s1", "2", "b", filePath);
            INIConfig.Write("s1", "3", "c", filePath);
            //写入节点2
            INIConfig.Write("s2", "4", "d", filePath);
            INIConfig.Write("s2", "5", "e", filePath);
            //改节点值（就是重写一遍）
            INIConfig.Write("s1", "3", "c3", filePath);


            //读取节点1中的key为1的值
            string value = INIConfig.Read("s1", "1", "789", filePath);

            INIConfig.DeleteKey("s1", "2", filePath);//删除节点s1中key为2的值
            INIConfig.DeleteSection("s1", filePath);//删除节点s2
        }
    }
}
