using DemoCleanArchitecture.Application.UseCases.Customer.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerSaveUseCase customerSaveUseCase;

        public CustomerController(CustomerPresenter presenter, ICustomerSaveUseCase customerSaveUseCase)
        {
            this.presenter = presenter;
            this.customerSaveUseCase = customerSaveUseCase;
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateCustomer([FromBody] InputCustomer input)
        {
            var request = new CustomerSaveRequest(input.Id, input.Name, input.Age, input.Email);
            customerSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
