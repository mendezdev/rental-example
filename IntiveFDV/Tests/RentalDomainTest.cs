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

namespace Tests
{
    [TestClass]
    public class RentalDomainTest
    {
        private IRentalDomain rentalDomain;

        [TestMethod]
        public void GetRental_Ok()
        {
            rentalDomain = new RentalDomain();
            var requests = new List<RentalRequest>
            {
                new RentalRequest
                {
                    Customer = new Customer
                    {
                        FirstName = "Pablo",
                        LastName = "Mendez",
                        IdentificationNumber = "34117676",
                        IdentificationType = IdentificationType.Dni
                    },
                    Quantity = 1,
                    RentalType = RentalType.Hour
                }
            };
            var contractResponse = rentalDomain.Rent(requests);

            Assert.IsNotNull(contractResponse);
            Assert.IsNotNull(contractResponse.Details);
            Assert.IsNotNull(contractResponse.Details[0].Customer);
            Assert.IsTrue(contractResponse.Details[0].Customer.FirstName == "Pablo");
        }
    }
}
