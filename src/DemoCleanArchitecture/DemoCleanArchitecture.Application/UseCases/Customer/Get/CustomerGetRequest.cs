using System;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Get
{
    public class CustomerGetRequest
    {
        public Guid CustomerId { get; private set; }

        public CustomerGetRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
