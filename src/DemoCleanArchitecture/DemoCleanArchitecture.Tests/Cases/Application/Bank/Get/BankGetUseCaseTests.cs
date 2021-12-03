using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Bank.Get;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;
namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankGetUseCaseTests
    {
        private readonly IBankGetUseCase bankGetUseCase;
        private readonly BankPresenter presenter;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;
        private static Guid BankId;

        public BankGetUseCaseTests(IBankGetUseCase bankGetUseCase, BankPresenter presenter, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankGetUseCase = bankGetUseCase;
            this.presenter = presenter;
            this.bankWriteOnlyRepository = bankWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeBank()
        {
            var model = BankBuilder.New().Build();
            BankId = model.Id;
            var ret = bankWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetBankById()
        {
            var request = new BankGetRequest(BankId);
            bankGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotGetBankByIdAndReturnNotFound()
        {
            var request = new BankGetRequest(Guid.NewGuid());
            bankGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
        }

    }
}
