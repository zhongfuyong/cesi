﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 适配器模式
{
    class Program
    {
        /// <summary>
        /// 客户端，客户想要把2个孔的插头 转变成三个孔的插头，这个转变交给适配器就好
        /// 既然适配器需要完成这个功能，所以它必须同时具体2个孔插头和三个孔插头的特征
        /// </summary>
        static void Main(string[] args)
        {
            PowerAdapter pa = new PowerAdapter();
            pa.Request();
            Console.ReadKey();
        }

        /// <summary>
        /// 三个孔的插头，也就是适配器模式中的目标角色
        /// </summary>
        public interface IThreeHole 
        {
             void Request();
        }

        /// <summary>
        /// 两个孔的插头，源角色——需要适配的类
        /// </summary>
        public abstract class TwoHole 
        {
            public void SpecificRequest() 
            {
                Console.WriteLine("两孔插头");
            }
        }
        /// <summary>
        /// 适配器类，接口要放在类的后面
        /// 适配器类提供了三个孔插头的行为，但其本质是调用两个孔插头的方法
        /// </summary>
        public class PowerAdapter : TwoHole, IThreeHole 
        {
            /// <summary>
            /// 实现三个孔插头接口方法
            /// </summary>
            public void Request() 
            {
                // 调用两个孔插头方法
                this.SpecificRequest();
            }
        }
    }
}
