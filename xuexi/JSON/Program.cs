using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //JsonMapper.ToObject()参数是文件地址，返回值是JsonData
            //JsonData代表一个数组或者对象
            JsonData jsdata = JsonMapper.ToObject(File.ReadAllText("json.txt"));
            foreach (JsonData temp in jsdata)
            {
                JsonData idvalue = temp["id"];//通过字符串索引器可以取得键值对的值
                JsonData namevalue = temp["name"];
                JsonData damagevalue = temp["damages"];
                int id = Int32.Parse(idvalue.ToString());
                int damage = Int32.Parse(damagevalue.ToString());
                Console.WriteLine(id+":"+namevalue.ToString()+":"+damage);
            }
            Console.ReadKey();

        }
    }
}
