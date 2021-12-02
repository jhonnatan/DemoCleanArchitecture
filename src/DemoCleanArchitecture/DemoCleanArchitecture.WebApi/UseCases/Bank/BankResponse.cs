using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank
{
    public class BankResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Number { get; private set; }

        public BankResponse(Guid id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;
        }
    }
}
