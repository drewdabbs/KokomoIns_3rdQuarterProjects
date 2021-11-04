using _02KomodoClaimsDept_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02KomodoClaimsDept_UnitTests
{
    [TestClass]
    public class ClaimsDept_UnitTests
    {
        private KomodoClaimsDept_Repo _claimsRepo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new KomodoClaimsDept_Repo();
            _claim = new Claim(5, ClaimType.Home, "Tree branch was blowing into a window.", 947.58, new DateTime(2021, 11, 2), new DateTime(2021, 11, 3));
            _claimsRepo.AddCLaim(_claim);
        }
        [TestMethod]
        public void Test_AddClaim()
        {
            bool claimAdded = _claimsRepo.AddCLaim(_claim);

            Assert.AreEqual(true, claimAdded);
        }
        [TestMethod]
        public void Test_SeeAllCLaims()
        {
            Queue<Claim> allQueued = _claimsRepo.SeeAllClaims();

            Assert.IsNotNull(allQueued);
        }
        [TestMethod]
        public void Test_DequeueClaim()
        {
            bool claimDeleted = _claimsRepo.DequeueClaim(_claim);

            Assert.IsTrue(claimDeleted);
        }
    }
}
