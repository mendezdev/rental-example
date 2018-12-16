using Common.Exceptions;
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
        [TestCategory("RentalContract")]
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
        [TestCategory("RentalContract")]
        public void GetRentalWithDiscount_Ok()
        {
            var requests = fakeData.GetRentalRequestsWithDiscount();
            var contractResponse = rentalDomain.Rent(requests);

            Assert.IsNotNull(contractResponse);
            Assert.IsNotNull(contractResponse.Details);
            Assert.IsNotNull(contractResponse.Details[0].Customer);
            Assert.IsTrue(contractResponse.Details.Any(c => c.Customer.FirstName == "Pablo"));
            Assert.IsTrue(contractResponse.Details.Count >= 3);
            Assert.IsTrue(contractResponse.HasFamilyDiscount);
            Assert.IsTrue(contractResponse.Discount > 0);
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_RequestQuantityLessThanZero()
        {
            var customer = fakeData.GetSimpleCustomer();
            var simpleRequest = fakeData.GetRentalRequestOk(customer, 0, RentalType.Day);

            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("quantity"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_RequestWithNullCustomer()
        {
            var simpleRequest = fakeData.GetRentalRequestOk(null, 1, RentalType.Day);

            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("customer information"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_RequestWithoutRentalType()
        {
            var customer = fakeData.GetSimpleCustomer();
            var simpleRequest = fakeData.GetRentalRequestOk(customer, 1, (RentalType)5);

            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("option rent"));
            }
        }

        [TestMethod]     
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_NullFirstName()
        {
            var customerWithNullFirstName = fakeData.GetSimpleCustomer();
            customerWithNullFirstName.FirstName = null;
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithNullFirstName, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("name"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_EmptyFirstName()
        {
            var customerWithNullFirstName = fakeData.GetSimpleCustomer();
            customerWithNullFirstName.FirstName = "";
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithNullFirstName, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("name"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_NullLastName()
        {
            var customerWithNullLastName = fakeData.GetSimpleCustomer();
            customerWithNullLastName.LastName = null;
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithNullLastName, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("last name"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_EmptyLastName()
        {
            var customerWithNullLastName = fakeData.GetSimpleCustomer();
            customerWithNullLastName.LastName = "";
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithNullLastName, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("last name"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_WithoutIdentificationType()
        {
            var customerWithoutIdentificationType = fakeData.GetSimpleCustomer();
            customerWithoutIdentificationType.IdentificationType = (IdentificationType)10;
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithoutIdentificationType, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("identification type"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_NullIdentificationNumber()
        {
            var customerWithNullIdentificationNumber = fakeData.GetSimpleCustomer();
            customerWithNullIdentificationNumber.IdentificationNumber = null;
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithNullIdentificationNumber, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("identification number"));
            }
        }

        [TestMethod]
        [TestCategory("RequiredFieldException")]
        public void GetRentalWithRetalException_Customer_EmptyIdentificationNumber()
        {
            var customerWithEmptyIdentificationNumber = fakeData.GetSimpleCustomer();
            customerWithEmptyIdentificationNumber.IdentificationNumber = "";
            var simpleRequest = fakeData.GetRentalRequestOk(customerWithEmptyIdentificationNumber, 1, RentalType.Day);
            var requests = new List<RentalRequest>
            {
                simpleRequest
            };

            try
            {
                var contractResponse = rentalDomain.Rent(requests);
            }
            catch (RentalRequiredFieldException ex)
            {
                Assert.IsTrue(ex.Message.Contains("identification number"));
            }
        }
    }
}
