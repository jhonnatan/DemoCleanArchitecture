using DemoCleanArchitecture.Application.UseCases.Customer.Get;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerGetUseCase customerGetUseCase;

        public CustomerController(CustomerPresenter presenter, ICustomerGetUseCase customerGetUseCase)
        {
            this.presenter = presenter;
            this.customerGetUseCase = customerGetUseCase;
        }

        [HttpPost]
        [Route("GetCustomer")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetCustomer([FromBody] InputCustomer input)
        {
            var request = new CustomerGetRequest(input.CustomerId);
            customerGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
