using System;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Customer
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
