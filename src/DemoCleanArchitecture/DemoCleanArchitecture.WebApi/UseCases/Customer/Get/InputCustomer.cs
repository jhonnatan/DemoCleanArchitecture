using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Get
{
    public class InputCustomer
    {
        public Guid CustomerId { get; private set; }

        public InputCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
