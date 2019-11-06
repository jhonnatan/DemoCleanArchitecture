using DemoCleanArchitecture.Domain.Customer;
using System;
using System.Collections.Generic;

namespace DemoCleanArchitecture.Application.Repositories
{
    public interface ICustomerWriteOnlyRepository
    {
        int Save(Customer customer);

        int Add(Customer customer);

        int Add(List<Customer> customers);

        int Delete(Guid id);

        int Delete(Customer customer);

        int Update(Customer customer);
    }
}
