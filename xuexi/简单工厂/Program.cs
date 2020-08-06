using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    class Program
    {
        //工厂接口
        public abstract class IFactory
        {
            //生成抽象方法
            public abstract void Production();
        }

        public class ShoesClass : IFactory
        {
            public override void Production()
            {
                Console.WriteLine("生成了鞋子");
            }
        }

        public class ClothesClass : IFactory
        {
            public override void Production()
            {
                Console.WriteLine("生成了衣服");
            }
        }

        public class Factory 
        {
            IFactory f = null;
            public IFactory shengchang(string name) 
            {
                switch (name)
                {
                    case "xiezi":
                        f = new ShoesClass();
                        break;
                    case "yifu":
                        f = new ClothesClass();
                        break;
                }
                return f;
            }
        }

        static void Main(string[] args)
        {
            IFactory f = new Factory().shengchang("xiezi");
            f.Production();
            Console.ReadKey();
        }
    }
}
