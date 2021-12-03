using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Delete
{
    public class BankDeleteUseCase : IBankDeleteUseCase
    {
        private readonly IOutputPort output;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;

        public BankDeleteUseCase(IOutputPort output, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.output = output;
            this.bankWriteOnlyRepository = bankWriteOnlyRepository;
        }

        public void Execute(BankDeleteRequest request)
        {
            try
            {
                var ret = bankWriteOnlyRepository.Delete(request.BankId);
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
