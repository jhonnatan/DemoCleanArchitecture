using FluentValidation;
using System;

namespace DemoCleanArchitecture.Domain.Validator
{
    public class BankValidator : AbstractValidator<Bank.Bank>
    {
        public BankValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .NotEqual(new Guid());

            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);


            RuleFor(r => r.Number)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

        }
    }
}
