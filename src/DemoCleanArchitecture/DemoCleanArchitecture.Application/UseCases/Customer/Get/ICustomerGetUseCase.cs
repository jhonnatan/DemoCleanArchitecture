namespace DemoCleanArchitecture.Application.UseCases.Customer.Get
{
    public interface ICustomerGetUseCase
    {
        void Execute(CustomerGetRequest request);
    }
}
