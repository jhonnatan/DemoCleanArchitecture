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
                Name = "Lemmy Kilsmister",
                Number = "001252452425"
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

        public BankBuilder WithEmail(string number)
        {
            Number = number;
            return this;
        }

        public Bank Build()
        {
            return new Bank(Id, Name, Number);
        }

        internal object WithNumber(object number)
        {
            throw new NotImplementedException();
        }
    }
}
