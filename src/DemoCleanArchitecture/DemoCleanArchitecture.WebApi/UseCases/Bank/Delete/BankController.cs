using DemoCleanArchitecture.Application.UseCases.Bank.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankPresenter presenter;
        private readonly IBankDeleteUseCase bankDeleteUseCase;

        public BankController(BankPresenter presenter, IBankDeleteUseCase bankDeleteUseCase)
        {
            this.presenter = presenter;
            this.bankDeleteUseCase = bankDeleteUseCase;
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteBank([FromBody] InputBank input)
        {
            var request = new BankDeleteRequest(input.BankId);
            bankDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
