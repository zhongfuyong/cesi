using Microsoft.VisualStudio.TestTools.UnitTesting;
using 单元测试;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单元测试.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void cesiTest()
        {
            Assert.IsTrue(Class1.cesi(10, 20) == 30);
        }
    }
}