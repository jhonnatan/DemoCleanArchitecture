using DemoCleanArchitecture.Domain.Bank;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoCleanArchitecture.Application.Repositories
{
    public interface IBankReadOnlyRepository
    {
        Bank GetById(Guid id);

        IList<Bank> GetByFilter(Expression<Func<Bank, bool>> filter);

        IList<Bank> GetAll();
    }
}
