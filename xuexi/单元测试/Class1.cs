using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单元测试
{
    public class Class1
    {
        public static double cesi(double a, double b)
        {
            double c = a + b;
            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("c等于" + cesi(10, 20));
            Console.ReadKey();
        }
    }
}
