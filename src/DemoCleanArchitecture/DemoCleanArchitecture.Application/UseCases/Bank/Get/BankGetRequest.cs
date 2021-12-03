using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Get
{
    public class BankGetRequest
    {
        public Guid BankId { get; private set; }

        public BankGetRequest(Guid BankId)
        {
            BankId = BankId;
        }
    }
}
