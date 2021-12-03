using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Delete
{
    public class BankDeleteUseCase : IBankDeleteUseCase
    {
        private readonly IOutputPort output;
        private IBankWriteOnlyRepository BankWriteOnlyRepository;

        public BankDeleteUseCase(IOutputPort output, IBankWriteOnlyRepository BankWriteOnlyRepository)
        {
            this.output = output;
            this.BankWriteOnlyRepository = BankWriteOnlyRepository;
        }

        public void Execute(BankDeleteRequest request)
        {
            try
            {
                var ret = BankWriteOnlyRepository.Delete(request.BankId);
                if (ret == 0)
                {
                    output.Error($"Error on process Delete Bank");
                    return;
                }
                output.Standard(request.BankId);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
