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
    public class BookingTests
    {
        [TestMethod()]
        public void addBookingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void check_BookingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertNewBookingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetdistrictTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void saercHallsAvailableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHallDescriptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void updateDateBookingTest()
        {
            bool ac = true;
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateStatuesBookingTest()
        {
            int ID_BOOKINGg = 2112454;
            bool actual, Expect = false;
            //arrange
            Booking cont = new Booking();
            //act
            actual = cont.CancalBooking(ID_BOOKINGg);

            //Asssert
            Assert.AreEqual(Expect, actual);
        }

        [TestMethod()]
        public void CancalBookingTest()
        {
            int ID_BOOKING = 123434;
            bool actual, Expect = true;
            //arrange
            Booking cont = new Booking();
            //act
            actual = cont.CancalBooking(ID_BOOKING);

            //Asssert
            Assert.AreEqual(Expect, actual);
           
        }
    }
}
    

