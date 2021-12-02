using System;
using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankPresenter presenter;
        private readonly IBankSaveUseCase bankSaveUseCase;

        public BankController(BankPresenter presenter, IBankSaveUseCase customerSaveUseCase)
        {
            this.presenter = presenter;
            this.bankSaveUseCase = customerSaveUseCase;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateBank([FromBody] InputBank input)
        {
            var request = new BankSaveRequest(input.Name, input.Number);
            bankSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
