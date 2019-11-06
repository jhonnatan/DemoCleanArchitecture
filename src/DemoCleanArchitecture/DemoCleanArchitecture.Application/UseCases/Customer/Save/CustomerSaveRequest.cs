using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Save
{
    public class CustomerSaveRequest
    {
        public Domain.Customer.Customer Customer { get; private set; }

        public CustomerSaveRequest(string name, int age, string email)
        {
            Customer = new Domain.Customer.Customer(Guid.NewGuid(), name, age, email);
        }

        public CustomerSaveRequest(Guid id, string name, int age, string email)
        {
            Customer = new Domain.Customer.Customer(id, name, age, email);
        }
    }
}
