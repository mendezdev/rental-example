using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Models.Entities;
using Models.Enums;
using Models.Requests;
using ViewModels;

namespace Domain.Implementation
{
    public class RentalDomain : IRentalDomain
    {
        public ContractResponse Rent(IList<RentalRequest> requests)
        {
            return new ContractResponse
            {
                CreatedAt = DateTime.Now,
                Total = Math.Round(10442m, 2),
                Details = GetDetailResponse()
            };
        }

        private IList<DetailResponse> GetDetailResponse()
        {
            var start = DateTime.Now;
            var end = start.AddHours(2);
            return new List<DetailResponse>()
            {
                new DetailResponse
                {
                    Customer = GetCustomer(),
                    Quantity = 1,
                    RentalCost = decimal.Round(20, 2),
                    RentalOption = Models.Constants.RentalDescriptionConstant.HOUR,
                    RentalStart = start,
                    RentalEnd = end
                }
            };
        }

        private Customer GetCustomer()
        {
            return new Customer()
            {
                FirstName = "Pablo",
                LastName = "Mendez",
                IdentificationNumber = "34117676",
                IdentificationType = IdentificationType.Dni
            };
        }
    }
}
