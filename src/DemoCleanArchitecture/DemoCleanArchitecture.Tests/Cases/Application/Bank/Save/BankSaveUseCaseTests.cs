using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankSaveUseCaseTests
    {
        private readonly IBankSaveUseCase bankSaveUseCase;
        private readonly BankPresenter presenter;
        private static Guid BankId;

        public BankSaveUseCaseTests(IBankSaveUseCase bankSaveUseCase, BankPresenter presenter)
        {
            this.bankSaveUseCase = bankSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewBankAndReturnOK()
        {
            var request = new BankSaveRequest("BankTest", "1235468");
            BankId = request.Bank.Id;
            bankSaveUseCase.Execute(request);            
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateBankAndReturnOK()
        {
            var request = new BankSaveRequest(BankId, "BankTestUpdated", "321654");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewBankAndReturnError()
        {
            var request = new BankSaveRequest("", "1235468");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateBankAndReturnError()
        {
            var request = new BankSaveRequest(BankId, "", "56456456");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
