using DemoCleanArchitecture.Domain.Customer;
using System;

namespace DemoCleanArchitecture.Tests.Builders
{
    public class CustomerBuilder
    {
        public Guid Id;
        public string Name;
        public int Age;
        public string Email;

        public static CustomerBuilder New()
        {
            return new CustomerBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "Lemmy Kilsmister",
                Age = 70,
                Email = "motorhead@motorhead.com"
            };
        }

        public CustomerBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CustomerBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public CustomerBuilder WithAge(int age)
        {
            Age = age;
            return this;
        }

        public CustomerBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public Customer Build()
        {
            return new Customer(Id, Name, Age, Email);
        }
    }
}
