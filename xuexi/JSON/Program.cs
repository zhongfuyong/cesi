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
            //List<Skill> skList = new List<Skill>();
            ////JsonMapper.ToObject()参数是文件，返回值是JsonData
            ////JsonData代表一个数组或者对象
            //JsonData jsdata = JsonMapper.ToObject(File.ReadAllText("json.txt"));
            //foreach (JsonData temp in jsdata)
            //{
            //    Skill skill = new Skill();
            //    JsonData idvalue = temp["id"];//通过字符串索引器可以取得键值对的值
            //    JsonData namevalue = temp["name"];
            //    JsonData damagevalue = temp["damages"];
            //    int id = Int32.Parse(idvalue.ToString());
            //    int damage = Int32.Parse(damagevalue.ToString());
            //    Console.WriteLine(id+":"+namevalue.ToString()+":"+damage);
            //    skill.id = id;
            //    skill.name = namevalue.ToString();
            //    skill.damage = damage;
            //    skList.Add(skill);
            //}
            //foreach (Skill item in skList)
            //{
            //    Console.WriteLine(item);
            //}

            //使用泛型去解析Json
            //json里面对象的键必须跟定义的类里面的字段或者属性保持一致
            Skill[] skillArray= JsonMapper.ToObject<Skill[]>(File.ReadAllText("json.txt"));
            foreach (var item in skillArray)
            {
                Console.WriteLine(item);
            }


            Skill p = new Skill();
            p.name = "傻逼";
            p.id = 100;
            p.damage = 16;
            string json =JsonMapper.ToJson(p);
            Console.WriteLine(json);

            Console.ReadKey();

        }
    }
}
