using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Delete
{
    public class BankDeleteRequest
    {
        public Guid BankId { get; private set; }

        public BankDeleteRequest(Guid bankId)
        {
            BankId = bankId;
        }
    }
}