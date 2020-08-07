using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 客户找到电脑城老板说要买电脑，这里要装两台电脑
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 老板叫员工去组装第一台电脑
            director.Construct(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

            Console.Read();
        }

        public class Director 
        {
            public void Construct(Builder builder) 
            {
                builder.BuildpartCPU();
                builder.BuildpartMainBoard();
            }
        }

        public class Computer 
        {
            private IList<string> parts = new List<string>();
            public void add( string prit) 
            {
                parts.Add(prit);
            }
            public void Show() 
            {
                Console.WriteLine("开始组装");
                foreach (string item in parts)
                {
                    Console.WriteLine("组件"+ item + "已经完成");
                }
                Console.WriteLine("电脑组装好了");
            }
        }

        public abstract class Builder 
        {
            public abstract void BuildpartCPU();
            public abstract void BuildpartMainBoard();
            public abstract Computer GetComputer();
        }
        public class ConcreteBuilder1 : Builder 
        {
            Computer computer = new Computer();
            public override void BuildpartCPU()
            {
                computer.add("CPU1");
            }
            public override void BuildpartMainBoard()
            {
                computer.add("MAIN Board1");
            }
            public override Computer GetComputer()
            {
                return computer;
            }
        }

        public class ConcreteBuilder2 : Builder
        {
            Computer computer = new Computer();
            public override void BuildpartCPU()
            {
                computer.add("CPU2");
            }
            public override void BuildpartMainBoard()
            {
                computer.add("MAIN Board2");
            }
            public override Computer GetComputer()
            {
                return computer;
            }
        }

    }
}
