using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Models.Entities;

namespace Domain.Implementation.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly string baseErrorMessage = "Need to specify";     

        public CustomerValidator()
        {
            // We can add a Regex for the identification number but I keep it simple for challenge purpose
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage($"{baseErrorMessage} a name")
                .NotEmpty().WithMessage($"{baseErrorMessage} a name");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage($"{baseErrorMessage} a last name")
                .NotEmpty().WithMessage($"{baseErrorMessage} a last name");
            RuleFor(x => x.IdentificationType)
                .IsInEnum().WithMessage($"{baseErrorMessage} an identification type");
            RuleFor(x => x.IdentificationNumber)
                .NotNull().WithMessage($"{baseErrorMessage} an identification number")
                .NotEmpty().WithMessage($"{baseErrorMessage} an identification number");
        }
    }
}
