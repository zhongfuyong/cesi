using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayList类
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList类长度不固定，类型随意
            ArrayList al = new ArrayList();

            //ArrayList添加元素
            string[] str = { "x", "x", "x" };
            foreach (string item in str)
            {
                al.Add(item);
            }
            Console.WriteLine("现在ArrayList有{0}个元素", al.Count);
            al.AddRange(str);//添加一个数组
            Console.WriteLine("现在ArrayList有{0}个元素", al.Count);
            foreach (object item in al)
            {
                Console.WriteLine(item + "\t");
            }


            //ArrayList删除元素
            //ArrayList变量名.Remove(值);
            //ArrayList变量名.RemoveAt(索引);
            //ArrayList变量名.RemoveRange(开始索引，要删除的个数);删除一个数组
            //ArrayList变量名.RemoveRange();  删除所有元素


            //ArrayList元素遍历和查找

            //元素的查找
            //1、IndexOf("查找的元素")--返回一个首次出现的索引整型值，如果找不到，返回-1
            //2、IndexOf("查找的元素")--返回一个最后一次出现的索引整型值，如果找不到，返回-1
            //3、BinarySearch("查找的元素")--差不多返回-1   当存储类型不一样的时候，二进制会报错

            Console.Read();
        }
    }
}
