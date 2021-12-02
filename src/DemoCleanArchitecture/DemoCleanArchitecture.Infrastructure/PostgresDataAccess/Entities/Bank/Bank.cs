using System;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Bank
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
