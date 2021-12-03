using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Save
{
    public interface IBankSaveUseCase
    {
        void Execute(BankSaveRequest request);
    }
}
