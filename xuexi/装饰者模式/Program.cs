using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
    class Program
    {
        public abstract class Phone 
        {
            public abstract void print();
        }
        public class ApplePhone : Phone 
        {
            public override void print()
            {
                Console.WriteLine("开始具体一台手机");
            }
        }
        public abstract class Decorator : Phone 
        {
            private Phone phone;
            public Decorator(Phone p) 
            {
                this.phone = p;
            }
            public override void print()
            {
                if (phone!=null)
                {
                    phone.print();
                }
            }
        }
        public class Sticker : Decorator 
        {
            public Sticker(Phone p) : base(p) { }
            public override void print()
            {
                base.print();

                AddSticker();
            }
            public void AddSticker()
            {
                Console.WriteLine("现在苹果手机有贴膜了");
            }
        }
        public class Accessories : Decorator 
        {
            public Accessories(Phone p) : base(p) { }
            public override void print()
            {
                base.print();

                AddAccessories();
            }
            public void AddAccessories() 
            {
                Console.WriteLine("现在有了挂件");
            }
        }
        static void Main(string[] args)
        {
            Phone p = new ApplePhone();
            Decorator decorator = new Sticker(p);
            decorator.print();


            Decorator decorator2 = new Accessories(p);
            decorator2.print();


            Console.ReadKey();

        }
    }
}
