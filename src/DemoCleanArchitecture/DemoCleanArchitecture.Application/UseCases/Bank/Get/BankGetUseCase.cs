using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Get
{
    public class BankGetUseCase : IBankGetUseCase
    {
        private readonly IOutputPort output;
        private readonly IBankReadOnlyRepository BankReadOnlyRepository;

        public BankGetUseCase(IOutputPort output, IBankReadOnlyRepository BankReadOnlyRepository)
        {
            this.output = output;
            this.BankReadOnlyRepository = BankReadOnlyRepository;
        }

        public void Execute(BankGetRequest request)
        {
            try
            {
                var bank = BankReadOnlyRepository.GetById(request.BankId);
                if (bank == null)
                {
                    output.NotFound($"Not found customer with id: {request.BankId}");
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