using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 孙悟空 原型
            MonkeyKingPrototype mkp = new ConcretePrototype("111");

            MonkeyKingPrototype mkp2= mkp.Clone() as ConcretePrototype;
            Console.WriteLine("mkp2"+mkp2.ID);
            Console.ReadLine();
        }
        /// <summary>
        /// 孙悟空原型
        /// </summary>
        public abstract class MonkeyKingPrototype
        {
           public string ID { get; set; }
            public MonkeyKingPrototype(string id) 
            {
                this.ID = id;
            }
            public abstract MonkeyKingPrototype Clone();
        }

        /// <summary>
        /// 创建具体原型
        /// </summary>
        public class ConcretePrototype : MonkeyKingPrototype
        {
            public ConcretePrototype(string id) : base(id) 
            {

            }
            public override MonkeyKingPrototype Clone()
            {
                return (ConcretePrototype)this.MemberwiseClone();
            }
        }
    }
}
