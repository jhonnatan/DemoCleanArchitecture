using System.Collections.Generic;
using DemoCleanArchitecture.Domain.Bank;

namespace DemoCleanArchitecture.Application.Repositories
{
    public interface IBankWriteOnlyRepository
    {
        int Save(Bank bank);

        int Add(Bank bank);

        int Add(List<Bank> banks);
    }
}
