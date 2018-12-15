using Models.Entities;
using Models.Enums;
using Models.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeData
{
    public class RentalFakeData
    {
        public List<RentalRequest> GetRentalRequestsWithoutDiscount()
        {
            var customers = GetCustomersWithoutDiscount();
            var requests = new List<RentalRequest>();

            foreach (var customer in customers)
            {
                requests.Add(GetRentalRequestOk(customer, 2, RentalType.Hour));
            }

            return requests;
        }

        public List<RentalRequest> GetRentalRequestsWithDiscount()
        {
            var customers = GetCustomersWithDiscount();
            var requests = new List<RentalRequest>();

            foreach (var customer in customers)
            {
                requests.Add(GetRentalRequestOk(customer, 1, RentalType.Day));
            }

            return requests;
        }

        public RentalRequest GetRentalRequestOk(Customer customer, int quantity, RentalType type)
        {
            return new RentalRequest
            {
                Customer = customer,
                Quantity = quantity,
                RentalType = type
            };
        }

        public Customer GetCustomerByIndetificationType(IdentificationType type)
        {
            return GetCustomersWithoutDiscount().Where(c => c.IdentificationType == type).Single();
        }

        public List<Customer> GetCustomersWithoutDiscount()
        {
            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Pablo",
                    LastName = "Mendez",
                    IdentificationNumber = "40221922",
                    IdentificationType = IdentificationType.Dni
                },
                new Customer
                {
                    FirstName = "Cristina",
                    LastName = "Perez",
                    IdentificationNumber = "123321234",
                    IdentificationType = IdentificationType.Passport
                }
            };
        }

        public List<Customer> GetCustomersWithDiscount()
        {
            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Pablo",
                    LastName = "Mendez",
                    IdentificationNumber = "40221922",
                    IdentificationType = IdentificationType.Dni
                },
                new Customer
                {
                    FirstName = "Cristina",
                    LastName = "Perez",
                    IdentificationNumber = "123321234",
                    IdentificationType = IdentificationType.Passport
                },
                new Customer
                {
                    FirstName = "Sebastian",
                    LastName = "Mendez",
                    IdentificationNumber = "22134221",
                    IdentificationType = IdentificationType.Dni
                },
                new Customer
                {
                    FirstName = "Daniela",
                    LastName = "Mendez",
                    IdentificationNumber = "50332121",
                    IdentificationType = IdentificationType.Dni
                }
            };
        }
    }
}
