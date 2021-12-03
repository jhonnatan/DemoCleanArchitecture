using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankPresenter presenter;
        private readonly IBankSaveUseCase bankSaveUseCase;

        public BankController(BankPresenter presenter, IBankSaveUseCase bankSaveUseCase)
        {
            this.presenter = presenter;
            this.bankSaveUseCase = bankSaveUseCase;
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateBank([FromBody] InputBank input)
        {
            var request = new BankSaveRequest(input.Id, input.Name, input.Number);
            bankSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
