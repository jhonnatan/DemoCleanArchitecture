namespace DemoCleanArchitecture.Application.UseCases.Bank.Get
{
    public interface IBankGetUseCase
    {
        void Execute(BankGetRequest request);
    }
}
