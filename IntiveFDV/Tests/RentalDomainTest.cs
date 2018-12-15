using Domain;
using Domain.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Entities;
using Models.Enums;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.FakeData;

namespace Tests
{
    [TestClass]
    public class RentalDomainTest
    {
        private IRentalDomain rentalDomain;
        private RentalFakeData fakeData;

        [TestInitialize]
        public void Initialize()
        {
            fakeData = new RentalFakeData();
            rentalDomain = new RentalDomain();
        }

        [TestMethod]
        public void GetRentalWithoutDiscount_Ok()
        {
            var requests = fakeData.GetRentalRequestsWithoutDiscount();
            var contractResponse = rentalDomain.Rent(requests);

            Assert.IsNotNull(contractResponse);
            Assert.IsNotNull(contractResponse.Details);
            Assert.IsNotNull(contractResponse.Details[0].Customer);
            Assert.IsTrue(contractResponse.Details.Any(c => c.Customer.FirstName == "Pablo"));
        }

        [TestMethod]
        public void GetRentalWithDiscount_Ok()
        {
            var requests = fakeData.GetRentalRequestsWithDiscount();
            var contractResponse = rentalDomain.Rent(requests);

            Assert.IsNotNull(contractResponse);
            Assert.IsNotNull(contractResponse.Details);
            Assert.IsNotNull(contractResponse.Details[0].Customer);
            Assert.IsTrue(contractResponse.Details.Any(c => c.Customer.FirstName == "Pablo"));
            Assert.IsTrue(contractResponse.HasFamilyDiscount);
            Assert.IsTrue(contractResponse.Discount > 0);
        }
    }
}
