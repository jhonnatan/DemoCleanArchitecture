using DemoCleanArchitecture.Application.Boundaries.Customer;
using DemoCleanArchitecture.Application.Repositories;

namespace DemoCleanArchitecture.Application.UseCases.Customer.GetAll
{
    public class CustomerGetAllUseCase : ICustomerGetAllUseCase
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputPort output;

        public CustomerGetAllUseCase(ICustomerReadOnlyRepository customerReadOnlyRepository, IOutputPort output)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var customers = customerReadOnlyRepository.GetAll();
                output.Standard(customers);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
