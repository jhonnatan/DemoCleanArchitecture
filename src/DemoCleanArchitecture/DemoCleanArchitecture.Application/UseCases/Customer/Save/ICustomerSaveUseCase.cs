using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Save
{
    public interface ICustomerSaveUseCase
    {
        void Execute(CustomerSaveRequest request);
    }
}
