using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Program
    {
        // 腾讯游戏订阅号类
        public class TenxunGame
        {
            // 订阅者对象
            public Subscriber Subscriber { get; set; }

            public String Symbol { get; set; }

            public string Info { get; set; }

            public void Update()
            {
                if (Subscriber != null)
                {
                    // 调用订阅者对象来通知订阅者
                    Subscriber.ReceiveAndPrintData(this);
                }
            }

        }

        // 订阅者类
        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            public void ReceiveAndPrintData(TenxunGame txGame)
            {
                Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, txGame.Symbol, txGame.Info);
            }
        }
        static void Main(string[] args)
        {
            // 实例化订阅者和订阅号对象
            Subscriber LearningHardSub = new Subscriber("LearningHard");
            TenxunGame txGame = new TenxunGame();

            txGame.Subscriber = LearningHardSub;
            txGame.Symbol = "TenXun Game";
            txGame.Info = "Have a new game published ....";

            txGame.Update();

            Console.ReadLine();
        }
    }
}
