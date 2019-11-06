using DemoCleanArchitecture.Application.Boundaries.Customer;
using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Get
{
    public class CustomerGetUseCase : ICustomerGetUseCase
    {
        private readonly IOutputPort output;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public CustomerGetUseCase(IOutputPort output, ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.output = output;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public void Execute(CustomerGetRequest request)
        {
            try
            {
                var customer = customerReadOnlyRepository.GetById(request.CustomerId);
                if (customer == null)
                {
                    output.NotFound($"Not found customer with id: {request.CustomerId}");
                    return;
                }
                output.Standard(customer);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");                
            }
        }
    }
}
