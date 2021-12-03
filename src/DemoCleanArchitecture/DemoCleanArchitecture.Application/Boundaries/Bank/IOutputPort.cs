using System;
using System.Collections.Generic;

namespace DemoCleanArchitecture.Application.Boundaries.Bank
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(Domain.Bank.Bank bank);

        void Standard(IList<Domain.Bank.Bank>bank);

        void NotFound(string message);

        void Error(string message);
    }
}
