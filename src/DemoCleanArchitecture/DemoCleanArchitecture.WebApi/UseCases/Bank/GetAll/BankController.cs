using DemoCleanArchitecture.Application.UseCases.Bank.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankPresenter presenter;
        private readonly IBankGetAllUseCase bankGetAllUseCase;

        public BankController(BankPresenter presenter, IBankGetAllUseCase bankGetAllUseCase)
        {
            this.presenter = presenter;
            this.bankGetAllUseCase = bankGetAllUseCase;
        }        

        [HttpPost]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<BankResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllBanks()
        {            
            bankGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}
