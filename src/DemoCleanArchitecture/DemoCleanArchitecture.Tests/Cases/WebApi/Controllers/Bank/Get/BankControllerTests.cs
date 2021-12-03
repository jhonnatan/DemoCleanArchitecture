using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Bank.Get;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using DemoCleanArchitecture.WebApi.UseCases.Bank.Get;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Bank.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankControllerTests
    {
        private readonly IBankGetUseCase bankGetUseCase;
        private readonly BankPresenter presenter;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;
        private static Guid BankId;

        public BankControllerTests(IBankGetUseCase bankGetUseCase, BankPresenter presenter, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankGetUseCase = bankGetUseCase;
            this.presenter = presenter;
            this.bankWriteOnlyRepository = bankWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeBank()
        {
            BankId = Guid.NewGuid();
            var model = BankBuilder.New().WithId(BankId).Build();
            var ret = bankWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetBank()
        {
            var input = new InputBank() { BankId = BankId };
            var controller = new BankController(presenter, bankGetUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetBank(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotGetBankAndReturnNotFound()
        {
            var input = new InputBank() { BankId = Guid.NewGuid() };
            var controller = new BankController(presenter, bankGetUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetBank(input);
            output.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
