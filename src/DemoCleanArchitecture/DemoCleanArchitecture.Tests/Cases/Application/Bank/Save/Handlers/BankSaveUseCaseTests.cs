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
    public class CustomerSaveUseCaseTests
    {
        private readonly IBankSaveUseCase bankSaveUseCase;
        private readonly BankPresenter presenter;
        private static Guid BankId;

        public CustomerSaveUseCaseTests(IBankSaveUseCase bankSaveUseCase, BankPresenter presenter)
        {
            this.bankSaveUseCase = bankSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewCustomerAndReturnOK()
        {
            var request = new BankSaveRequest("BankTest", "818181818181");
            BankId = request.Bank.Id;
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomerAndReturnOK()
        {
            var request = new BankSaveRequest(BankId, "CustomerTestUpdated", "8181818181");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new BankSaveRequest("", "818181818181");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new BankSaveRequest(BankId, "", "818181818181");
            bankSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
