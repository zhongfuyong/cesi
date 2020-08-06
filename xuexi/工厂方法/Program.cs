using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRestaurant.IWantEatFood();//客户点菜
            Console.ReadKey();
        }
        /// <summary>
        /// 某位客户
        /// </summary>
        class CustomerRestaurant
        {
            /// <summary>
            /// 我想要吃的菜品
            /// </summary>
            public static void IWantEatFood()
            {
                RestaurantFactory scrambledEgg = new ScrambledEggFactory();//点的是炒蛋，则初始化炒蛋工厂
                Food food1 = scrambledEgg.CreateFood();//工厂创建出炒蛋这道菜
                food1.Print();

                RestaurantFactory scrambledChicken = new ScrambledchickenFactory();
                Food food2 = scrambledChicken.CreateFood();
                food2.Print();
                //////////////////////////////////////////
                ///客户还想吃炒青瓜，点了炒青瓜
                RestaurantFactory scrambledCucumber = new ScrambledCucumberFactory();
                Food food3 = scrambledCucumber.CreateFood();
                food3.Print();
                /////////////////////////////////////////

            }
        }

        /// <summary>
        /// 餐馆工厂类
        /// </summary>
        public abstract class RestaurantFactory
        {
            public abstract Food CreateFood();//餐厅工厂方法
        }
        /// <summary>
        /// 炒蛋工厂类
        /// </summary>
        public class ScrambledEggFactory : RestaurantFactory
        {
            public override Food CreateFood()//负责创建炒蛋这道菜
            {
                return new ScrambledEgg();
            }
        }
        /// <summary>
        /// 炒鸡肉工厂类
        /// </summary>
        public class ScrambledchickenFactory : RestaurantFactory
        {
            public override Food CreateFood()//负责创建炒鸡肉这道菜
            {
                return new ScrambledChicken();
            }
        }

        /////////////////////////////////////////////////////
        ///根据客户的需求，添加炒青瓜
        public class ScrambledCucumberFactory : RestaurantFactory
        {
            public override Food CreateFood()//负责创建炒青瓜这道菜
            {
                return new ScrambledCucumber();
            }
        }
        ////////////////////////////////////////////////////

        /// <summary>
        /// 菜品抽象类
        /// </summary>
        public abstract class Food
        {
            public abstract void Print();//抽象菜品方法
        }
        /// <summary>
        /// 实现炒蛋类
        /// </summary>
        public class ScrambledEgg : Food
        {
            public override void Print()//重写方法
            {
                Console.WriteLine("一份炒蛋");
            }
        }
        /// <summary>
        /// 实现炒蛋类
        /// </summary>
        public class ScrambledChicken : Food
        {
            public override void Print() //重写方法
            {
                Console.WriteLine("一份炒鸡肉");
            }
        }
        ////////////////////////////////////////////////////
        ///根据客户需求，添加炒青瓜
        /// <summary>
        /// 实现炒青瓜类
        /// </summary>
        public class ScrambledCucumber : Food
        {
            public override void Print()//重写方法
            {
                Console.WriteLine("一份炒青瓜");
            }
        }
        ////////////////////////////////////////////////////
    }
}
