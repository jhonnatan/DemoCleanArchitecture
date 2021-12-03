using DemoCleanArchitecture.Application.Boundaries.Bank;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank
{
    public class BankPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
            => ViewModel = new OkObjectResult(id);

        public void Standard(Domain.Bank.Bank bank)
            => ViewModel = new OkObjectResult(new BankResponse(bank.Id, bank.Name, bank.Number));

        public void Standard(IList<Domain.Bank.Bank> bank)
        {
            var banksResponse = new List<BankResponse>();
            bank.ToList().ForEach(s => banksResponse.Add(new BankResponse(s.Id, s.Name, s.Number)));
            ViewModel = new OkObjectResult(banksResponse);
        }
    }
}
