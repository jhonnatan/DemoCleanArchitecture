using DemoCleanArchitecture.Application.UseCases.Customer.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerDeleteUseCase customerDeleteUseCase;

        public CustomerController(CustomerPresenter presenter, ICustomerDeleteUseCase customerDeleteUseCase)
        {
            this.presenter = presenter;
            this.customerDeleteUseCase = customerDeleteUseCase;
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteCustomer([FromBody] InputCustomer input)
        {
            var request = new CustomerDeleteRequest(input.CustomerId);
            customerDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
