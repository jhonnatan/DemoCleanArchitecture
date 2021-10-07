using DemoCleanArchitecture.Application.UseCases.Customer.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;

        public CustomerController(CustomerPresenter presenter, ICustomerGetAllUseCase customerGetAllUseCase)
        {
            this.presenter = presenter;
            this.customerGetAllUseCase = customerGetAllUseCase;
        }        

        [HttpPost]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<CustomerResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllCustomers()
        {            
            customerGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}
