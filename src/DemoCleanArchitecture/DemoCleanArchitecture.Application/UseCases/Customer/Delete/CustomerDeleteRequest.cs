using System;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Delete
{
    public class CustomerDeleteRequest
    {
        public Guid CustomerId { get; private set; }

        public CustomerDeleteRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
