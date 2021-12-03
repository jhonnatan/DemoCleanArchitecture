using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Delete
{
    public interface IBankDeleteUseCase
    {
        void Execute(BankDeleteRequest request);
    }
}
