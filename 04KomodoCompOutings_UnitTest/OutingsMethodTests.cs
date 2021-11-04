using _04KomodoCompOutings_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _04KomodoCompOutings_UnitTest
{
    [TestClass]
    public class OutingsMethodTests
    {
        private CompanyOutings_Repo _outingsRepo;
        private Outings _newOuting;

        [TestInitialize]
        public void Arrange()
        {
            _outingsRepo = new CompanyOutings_Repo();

            _newOuting = new Outings(EventType.Concert, 34, new DateTime(2021, 11, 4), 34.55m);

            _outingsRepo.AddAnOuting(_newOuting);
        }
        [TestMethod]
        public void Test_AddAnOuting()
        {
            bool outingAdded = _outingsRepo.AddAnOuting(_newOuting);

            Assert.IsTrue(outingAdded);
        }
        [TestMethod]
        public void Test_ListAllOutings()
        {
            List<Outings> listReturned = _outingsRepo.ListAllOutings();

            Assert.IsNotNull(listReturned);
        }
        [TestMethod]
        public void Test_ListOutingDates()
        {
            Outings datesReturned = _outingsRepo.ListAllOutingDates(_newOuting.EventDate);

            Assert.IsNotNull(datesReturned);
        }
    }
}
