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
        public void GetRental_Ok()
        {
            var requests = fakeData.GetRentalRequests();
            var contractResponse = rentalDomain.Rent(requests);

            Assert.IsNotNull(contractResponse);
            Assert.IsNotNull(contractResponse.Details);
            Assert.IsNotNull(contractResponse.Details[0].Customer);
            Assert.IsTrue(contractResponse.Details[0].Customer.FirstName == "Pablo");
        }
    }
}
