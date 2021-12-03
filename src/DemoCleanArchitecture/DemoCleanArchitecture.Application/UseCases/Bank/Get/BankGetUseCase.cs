using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Get
{
    public class BankGetUseCase : IBankGetUseCase
    {
        private readonly IOutputPort output;
        private readonly IBankReadOnlyRepository bankReadOnlyRepository;

        public BankGetUseCase(IOutputPort output, IBankReadOnlyRepository bankReadOnlyRepository)
        {
            this.output = output;
            this.bankReadOnlyRepository = bankReadOnlyRepository;
        }

        public void Execute(BankGetRequest request)
        {
            try
            {
                var bank = bankReadOnlyRepository.GetById(request.BankId);
                if (bank == null)
                {
                    output.NotFound($"Not found Bank with id: {request.BankId}");
                    return;
                }
                output.Standard(bank);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");                
            }
        }
    }
}
