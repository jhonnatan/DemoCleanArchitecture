using DemoCleanArchitecture.Domain.Validator;
using System;

namespace DemoCleanArchitecture.Domain.Customer
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Customer(Guid id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;

            Validate(this, new CustomerValidator());
        }
    }
}
