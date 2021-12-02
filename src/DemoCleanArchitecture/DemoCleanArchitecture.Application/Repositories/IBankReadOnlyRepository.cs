using System.Collections.Generic;
using DemoCleanArchitecture.Domain.Bank;

namespace DemoCleanArchitecture.Application.Repositories
{
    public interface IBankReadOnlyRepository
    {
        IList<Bank> GetAll();
    }
}
