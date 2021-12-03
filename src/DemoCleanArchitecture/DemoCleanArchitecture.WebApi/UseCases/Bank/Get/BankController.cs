using DemoCleanArchitecture.Application.UseCases.Bank.Get;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankPresenter presenter;
        private readonly IBankGetUseCase bankGetUseCase;

        public BankController(BankPresenter presenter, IBankGetUseCase bankGetUseCase)
        {
            this.presenter = presenter;
            this.bankGetUseCase = bankGetUseCase;
        }

        [HttpPost]
        [Route("GetById")]
        [ProducesResponseType(typeof(BankResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetBank([FromBody] InputBank input)
        {
            var request = new BankGetRequest(input.BankId);
            bankGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}