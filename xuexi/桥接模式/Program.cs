using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        /// <summary>
        /// 抽象概念中的遥控器，扮演抽象化角色
        /// </summary>
        public class RemoteControl
        {
            private TV implementor;
            public TV Implementor
            {
                get { return implementor; }
                set { implementor = value; }
            }
            /// <summary>
            /// 开电视机，这里抽象类中不再提供实现了，而是调用实现类中的实现
            /// </summary>
            public virtual void On()
            {
                implementor.On();
            }
           
            public virtual void SetChannel()
            {
                implementor.tuneChannel();
            } 
            public virtual void Off()
            {
                implementor.Off();
            }
        }
        /// <summary>
        /// 具体遥控器
        /// </summary>
        public class ConcreteRemote : RemoteControl
        {
            public override void SetChannel()
            {
                Console.WriteLine("---------------------");
                base.SetChannel();
                Console.WriteLine("---------------------");
            }
        }
        /// <summary>
        /// 电视机，提供抽象方法
        /// </summary>
        public abstract class TV
        {
            public abstract void On();
            public abstract void Off();
            public abstract void tuneChannel();
        }
        /// <summary>
        /// 长虹牌电视机，重写基类的抽象方法
        /// 提供具体的实现
        /// </summary>
        public class ChangHongTV : TV 
        {
            public override void On()
            {
                Console.WriteLine("长虹电视已经打开");
            }
            public override void Off()
            {
                Console.WriteLine("长虹电视已经关闭");
            }
            public override void tuneChannel()
            {
                Console.WriteLine("长虹电视换频道");
            }
        }
        /// <summary>
        /// 三星牌电视机，重写基类的抽象方法
        /// </summary>
        public class SanxingTV : TV
        {
            public override void On()
            {
                Console.WriteLine("三星电视已经打开");
            }
            public override void Off()
            {
                Console.WriteLine("三星电视已经关闭");
            }
            public override void tuneChannel()
            {
                Console.WriteLine("三星电视换频道");
            }
        }

        static void Main(string[] args)
        {
            RemoteControl rc = new ConcreteRemote();
            rc.Implementor = new ChangHongTV();
            rc.On();
            rc.SetChannel();
            rc.Off();
            Console.ReadKey();
        }
    }
}
