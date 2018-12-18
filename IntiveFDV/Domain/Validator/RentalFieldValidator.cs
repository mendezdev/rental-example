using FluentValidation;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class RentalFieldValidator : AbstractValidator<RentalRequest>
    {
        private readonly string baseErrorMessage = "Need to specify";

        public RentalFieldValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage($"{baseErrorMessage} a quantity");
            RuleFor(x => x.RentalType)
                .IsInEnum().WithMessage($"{baseErrorMessage} an option rent");
            RuleFor(x => x.Customer)
                .NotNull().WithMessage("Need to provide customer information.");
            RuleFor(x => x.Customer).SetValidator(new CustomerValidator());
        }
    }
}
