using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using DemoCleanArchitecture.WebApi.UseCases.Bank.Update;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Bank.Update
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerControllerTests
    {
        private readonly IBankSaveUseCase bankSaveUseCase;
        private readonly BankPresenter presenter;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;
        private static Guid BankId;

        public CustomerControllerTests(IBankSaveUseCase bankSaveUseCase, BankPresenter presenter, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankSaveUseCase = bankSaveUseCase;
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
        public void ShouldUpdateBank()
        {
            var input = new InputBank() { Id = BankId, Name = "CustomerTest", Number = "81818181818" };
            var controller = new BankController(presenter, bankSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.UpdateBank(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotUpdateAndGetError()
        {
            var input = new InputBank() { Id = BankId, Number = "8181818818" };
            var controller = new BankController(presenter, bankSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.UpdateBank(input);
            output.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
