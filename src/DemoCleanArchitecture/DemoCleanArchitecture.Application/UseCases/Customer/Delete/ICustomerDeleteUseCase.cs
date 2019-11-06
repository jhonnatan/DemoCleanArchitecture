using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Delete
{
    public interface ICustomerDeleteUseCase
    {
        void Execute(CustomerDeleteRequest request);
    }
}
