using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.Repositories;

namespace DemoCleanArchitecture.Application.UseCases.Bank.GetAll
{
    public class BankGetAllUseCase : IBankGetAllUseCase
    {
        private readonly IBankReadOnlyRepository bankReadOnlyRepository;
        private readonly IOutputPort output;

        public BankGetAllUseCase(IBankReadOnlyRepository bankReadOnlyRepository, IOutputPort output)
        {
            this.bankReadOnlyRepository = bankReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var banks = bankReadOnlyRepository.GetAll();
                output.Standard(banks);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
