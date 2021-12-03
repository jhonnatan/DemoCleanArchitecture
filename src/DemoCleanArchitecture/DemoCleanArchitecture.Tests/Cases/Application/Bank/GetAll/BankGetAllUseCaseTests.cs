using DemoCleanArchitecture.Application.UseCases.Bank.GetAll;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.GetAll
{
    [UseAutofacTestFramework]
    public class BankGetAllUseCaseTests
    {
        private readonly IBankGetAllUseCase bankGetAllUseCase;
        private readonly BankPresenter presenter;

        public BankGetAllUseCaseTests(IBankGetAllUseCase bankGetAllUseCase, BankPresenter presenter)
        {
            this.bankGetAllUseCase = bankGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldExecute()
        {
            bankGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
       }
    }
}
