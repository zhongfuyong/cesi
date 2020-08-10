using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式
{
    class Program
    {
        // 抽象牌友类
        public abstract class AbstractCardPartner
        {
            public int MoneyCount { get; set; }

            public AbstractCardPartner()
            {
                MoneyCount = 0;
            }

            public abstract void ChangeCount(int Count, AbstractCardPartner other);
        }

        // 牌友A类
        public class ParterA : AbstractCardPartner
        {
            public override void ChangeCount(int Count, AbstractCardPartner other)
            {
                this.MoneyCount += Count;
                other.MoneyCount -= Count;
            }
        }

        // 牌友B类
        public class ParterB : AbstractCardPartner
        {
            public override void ChangeCount(int Count, AbstractCardPartner other)
            {
                this.MoneyCount += Count;
                other.MoneyCount -= Count;
            }
        }

        static void Main(string[] args)
        {
            AbstractCardPartner A = new ParterA();
            A.MoneyCount = 20;
            AbstractCardPartner B = new ParterB();
            B.MoneyCount = 20;

            Console.WriteLine("A赢了B 5块钱");
            // A 赢了则B的钱就减少
            A.ChangeCount(5, B);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            Console.WriteLine("B赢了A 10块钱");
            // B赢了A的钱也减少
            B.ChangeCount(10, A);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount); // 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
            Console.Read();
        }
    }
}
