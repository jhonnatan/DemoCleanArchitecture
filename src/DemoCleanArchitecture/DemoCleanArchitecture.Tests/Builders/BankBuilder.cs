using DemoCleanArchitecture.Domain.Bank;
using System;

namespace DemoCleanArchitecture.Tests.Builders
{
    public class BankBuilder
    {
        public Guid Id;
        public string Name;
        public string Number;

        public static BankBuilder New()
        {
            return new BankBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "New Tech Bank",
                Number = "12468513158",
            };
        }

        public BankBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public BankBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public BankBuilder WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public Bank Build()
        {
            return new Bank(Id, Name, Number);        
        }
    }
}
