using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Delete
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
