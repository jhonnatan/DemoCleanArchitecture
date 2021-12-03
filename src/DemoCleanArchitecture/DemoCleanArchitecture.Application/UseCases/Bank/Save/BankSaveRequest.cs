using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Save
{
    public class BankSaveRequest
    {
        public Domain.Bank.Bank Bank { get; private set; }

        public BankSaveRequest(string name, string number)
        {
            Bank = new Domain.Bank.Bank(Guid.NewGuid(), name, number);
        }

        public BankSaveRequest(Guid id, string name, string number)
        {
            Bank = new Domain.Bank.Bank(id, name, number);
        }
    }
}
