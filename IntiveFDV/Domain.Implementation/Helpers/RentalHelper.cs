using Domain.Implementation.Validators;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Common;
using Common.Exceptions;

namespace Domain.Implementation.Helpers
{
    public class RentalHelper
    {
        private RentalFieldValidator rentalValidator;

        public RentalHelper()
        {
            rentalValidator = new RentalFieldValidator();
        }

        public void ValidateRentalRequests(IList<RentalRequest> requests)
        {
            ValidationResult result = null;

            foreach (var request in requests)
            {
                result = rentalValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new RentalRequiredFieldException(result.Errors[0].ErrorMessage);
                }
            }
        }
    }
}
