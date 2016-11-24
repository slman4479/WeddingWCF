using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWCF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WeddingWCF.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void addBookingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sumTest()
        {
            int num1 = 30;
            int num2 = 40;
            int actual  , Expect =70;
            //arrange
            Service1 cont = new Service1();
            //act
            actual = cont.sum(num1, num2); 
            //Asssert
            Assert.AreEqual(Expect, actual);


        }
    }
}
