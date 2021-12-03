using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Get
{
    public class BankGetRequest
    {
        public Guid BankId { get; internal set; }

        public BankGetRequest(Guid bankId)
        {
            BankId = bankId;
        }
    }
}
