using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Bank.Delete;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankDeleteUseCaseTests
    {
        private readonly IBankDeleteUseCase bankDeleteUseCase;
        private readonly BankPresenter presenter;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;
        private static Guid BankId;

        public BankDeleteUseCaseTests(IBankDeleteUseCase bankDeleteUseCase, BankPresenter presenter, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankDeleteUseCase = bankDeleteUseCase;
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
        public void ShouldDeleteBank()
        {
            var request = new BankDeleteRequest(BankId);
            bankDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteBankAndReturnError()
        {
            var request = new BankDeleteRequest(Guid.NewGuid());
            bankDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
