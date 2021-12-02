
namespace DemoCleanArchitecture.Application.UseCases.Bank.Save
{
    public interface IBankSaveUseCase
    {
        void Execute(BankSaveRequest request);
    }
}
