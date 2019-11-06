using DemoCleanArchitecture.Application.Boundaries.Customer;
using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Delete
{
    public class CustomerDeleteUseCase : ICustomerDeleteUseCase
    {
        private readonly IOutputPort output;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public CustomerDeleteUseCase(IOutputPort output, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.output = output;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public void Execute(CustomerDeleteRequest request)
        {
            try
            {
                var ret = customerWriteOnlyRepository.Delete(request.CustomerId);
                if (ret == 0)
                { 
                    output.Error($"Error on process Delete Customer");
                    return;
                }
                output.Standard(request.CustomerId);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
