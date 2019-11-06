using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer
{
    public class CustomerResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }

        public CustomerResponse(Guid id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;            
        }
    }
}
