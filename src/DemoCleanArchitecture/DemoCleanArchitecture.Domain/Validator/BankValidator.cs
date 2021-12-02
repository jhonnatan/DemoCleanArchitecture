using System;
using FluentValidation;

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
                .NotEmpty();

            RuleFor(r => r.Number)
                .NotEmpty();

        }
    }
}
