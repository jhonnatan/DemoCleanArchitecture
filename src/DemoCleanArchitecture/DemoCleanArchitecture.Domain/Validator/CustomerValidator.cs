using FluentValidation;
using System;

namespace DemoCleanArchitecture.Domain.Validator
{
    public class CustomerValidator : AbstractValidator<Customer.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .NotEqual(new Guid());

            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(r => r.Age)
                .NotNull()
                .GreaterThan(0);

            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

        }
    }
}
