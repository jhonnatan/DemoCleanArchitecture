using DemoCleanArchitecture.Domain.Bank;
using System;
using System.Collections.Generic;

namespace DemoCleanArchitecture.Application.Repositories
{
    public interface IBankWriteOnlyRepository
    {
        int Save(Bank bank);

        int Add(Bank bank);

        int Add(List<Bank> bank);

        int Delete(Guid id);

        int Delete(Bank bank);

        int Update(Bank bank);
    }
}
