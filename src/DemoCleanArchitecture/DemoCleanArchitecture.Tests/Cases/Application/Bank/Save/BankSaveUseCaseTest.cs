using System;
using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankSaveUseCaseTest
    {
        private readonly IBankSaveUseCase bankSaveUseCase;
        private readonly BankPresenter presenter;
        private static Guid BankId;

        public BankSaveUseCaseTest(IBankSaveUseCase bankSaveUseCase, BankPresenter presenter)
        {
            this.bankSaveUseCase = bankSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldAddNewBankAndReturnOK()
        {
            var request = new BankSaveRequest("BankTest", "asdasdasdasd");
            BankId = request.Bank.Id;
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewBankAndReturnError()
        {
            var request = new BankSaveRequest("", "asdasdasdasd");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
