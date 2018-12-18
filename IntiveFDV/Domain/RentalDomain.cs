using Domain.Helpers;
using Models.Constants;
using Models.Enums;
using Models.Requests;
using System;
using System.Collections.Generic;
using ViewModels;

namespace Domain
{
    class RentalDomain
    {
        private IDictionary<RentalType, Func<RentalRequest, DetailResponse>> detailStrategy;

        public RentalDomain()
        {
            detailStrategy = new Dictionary<RentalType, Func<RentalRequest, DetailResponse>>
            {
                { RentalType.Hour, RentByHour },
                { RentalType.Day, RentByDay },
                { RentalType.Week, RentByWeek }
            };
        }

        private DetailResponse RentByHour(RentalRequest request)
        {
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
            var rentalHelper = new RentalHelper();
            rentalHelper.ValidateRentalRequests(requests);

            int requestCount = 0;

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
                if (!response.HasFamilyDiscount)
                {
                    requestCount++;
                    if (requestCount >= 3 && requestCount <= 5)
                    {
                        response.HasFamilyDiscount = true;
                        requestCount = 0;
                    }
                }
            }

            response.Details = details;

            if (response.HasFamilyDiscount)
            {
                var rentalDiscount = response.Total * 0.30m;
                response.Discount = rentalDiscount;
                response.Total -= rentalDiscount;
            }
            return response;
        }
    }
}
