using System;
using DemoCleanArchitecture.Domain.Validator;

namespace DemoCleanArchitecture.Domain.Bank
{
    public class Bank : Entity
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public Bank(Guid id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;

            Validate(this, new BankValidator());
        }
    }
}
