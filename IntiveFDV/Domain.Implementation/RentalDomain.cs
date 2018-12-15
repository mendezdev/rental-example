using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Models.Constants;
using Models.Entities;
using Models.Enums;
using Models.Requests;
using ViewModels;

namespace Domain.Implementation
{
    public class RentalDomain : IRentalDomain
    {
        private IDictionary<RentalType, Func<RentalRequest, DetailResponse>> detailStrategy;

        public RentalDomain()
        {
            detailStrategy = new Dictionary<RentalType, Func<RentalRequest, DetailResponse>>
            {
                { RentalType.Hour, RentByHour},
                { RentalType.Day, RentByDay },
                { RentalType.Week, RentByWeek }
            };
        }

        private DetailResponse RentByHour(RentalRequest request)
        {
            //TODO: logic to create contract by hour
            var start = DateTime.Now;
            var response = new DetailResponse()
            {
                Customer = request.Customer,
                Quantity = request.Quantity,
                RentalCost = request.Quantity * 5,
                RentalOption = RentalDescriptionConstant.HOUR,
                RentalStart = start,
                RentalEnd = start.AddHours(request.Quantity)
            };
            return response;
        }

        private DetailResponse RentByDay(RentalRequest request)
        {
            //TODO: logic to create contract by day
            var start = DateTime.Now;
            var response = new DetailResponse()
            {
                Customer = request.Customer,
                Quantity = request.Quantity,
                RentalCost = request.Quantity * 20,
                RentalOption = RentalDescriptionConstant.DAY,
                RentalStart = start,
                RentalEnd = start.AddDays(request.Quantity)
            };
            return response;
        }

        private DetailResponse RentByWeek(RentalRequest request)
        {
            //TODO: logic to create contract by week
            var start = DateTime.Now;
            var response = new DetailResponse()
            {
                Customer = request.Customer,
                Quantity = request.Quantity,
                RentalCost = request.Quantity * 60,
                RentalOption = RentalDescriptionConstant.WEEK,
                RentalStart = start,
                RentalEnd = start.AddDays(request.Quantity * 7)
            };
            return response;
        }

        public ContractResponse Rent(IList<RentalRequest> requests)
        {
            var response = new ContractResponse
            {
                CreatedAt = DateTime.Now
            };
            var details = new List<DetailResponse>();
            foreach (var request in requests)
            {
                var detail = detailStrategy[request.RentalType](request);
                response.Total += detail.RentalCost;
                details.Add(detail);
            }

            response.Details = details;
            return response;
        }
    }
}
