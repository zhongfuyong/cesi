using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建技能信息集合，用来存储所有的技能信息
            List<Skillinfo> skillList = new List<Skillinfo>();

            //解析XML文档
            XmlDataDocument xmlDoc = new XmlDataDocument();
            //选中要解析的xml文件
            //xmlDoc.Load("skillinfo.txt");
            xmlDoc.LoadXml(File.ReadAllText("skillinfo.txt")) ;//传递一个字符串，xml格式的
            //得到根节点
            XmlNode rootNode = xmlDoc.FirstChild;//获取第一个节点，返回XmlNode属性
            //获取当前结点下面的所有子节点
            XmlNodeList skillNodeList= rootNode.ChildNodes; //返回一个XmlNodeList类型
            //
            foreach (XmlNode skillNode in skillNodeList)
            {
                Skillinfo skill = new Skillinfo();
                XmlNodeList fildNodeList = skillNode.ChildNodes;
                foreach (XmlNode fieldNode in fildNodeList)
                {
                    if (fieldNode.Name=="id")
                    {
                        int id = Int32.Parse(fieldNode.InnerText);
                        skill.Id = id;
                    }
                    else if (fieldNode.Name == "name")
                    {
                        string name = fieldNode.InnerText;
                        skill.Name = name;
                        skill.Lang= fieldNode.Attributes[0].Value;
                    }
                    else
                    {
                        skill.Damage = Int32.Parse(fieldNode.InnerText);
                    }
                }
                skillList.Add(skill);
            }
            foreach (Skillinfo skill in skillList)
            {
                Console.WriteLine(skill);
            }
            Console.ReadKey();

        }
    }
}
