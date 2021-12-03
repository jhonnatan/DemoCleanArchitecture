using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.Repositories;

namespace DemoCleanArchitecture.Application.UseCases.Bank.GetAll
{
    public class BankGetAllUseCase : IBankGetAllUseCase
    {
        private readonly IBankReadOnlyRepository BankReadOnlyRepository;
        private readonly IOutputPort output;

        public BankGetAllUseCase(IBankReadOnlyRepository BankReadOnlyRepository, IOutputPort output)
        {
            this.BankReadOnlyRepository = BankReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var bank = BankReadOnlyRepository.GetAll();
                output.Standard(bank);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
