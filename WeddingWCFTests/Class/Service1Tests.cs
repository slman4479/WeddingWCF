using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWCF.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WeddingWCF.Class.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoginTest()
        {
            string Emaill = "soso";
            string  passwordd = "123";
            String actual , Expect = "";
            //arrange
            User cont = new User();
            //act
            actual = cont.Login(Emaill, passwordd);
            //Asssert
            Assert.AreEqual(Expect, actual);
          
         
        }

        [TestMethod()]
        public void IsAvailableEmailTest()
        {
            string Emaill = "soso";
          
            int actual ,Expect = 0;
            //arrange
            User cont = new User();
            //act
            actual = cont.IsAvailableEmail(Emaill);
            //Asssert
            Assert.AreEqual(Expect, actual);
        }
        [TestMethod()]
        public void IsValidEmailTest()
        {
            string Emaill = "soso";
            bool actual , Expect = false;
            //arrange
            User cont = new User();
            //act
            actual = cont.IsValidEmail(Emaill);
            //Asssert
            Assert.AreEqual(Expect, actual);
        }
    }
}
