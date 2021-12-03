using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Bank.Delete;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using DemoCleanArchitecture.WebApi.UseCases.Bank.Delete;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Bank.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankControllerTests
    {
        private readonly IBankDeleteUseCase bankDeleteUseCase;
        private readonly BankPresenter presenter;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;
        private static Guid BankId;

        public BankControllerTests(IBankDeleteUseCase bankDeleteUseCase, BankPresenter presenter, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankDeleteUseCase = bankDeleteUseCase;
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
        public void ShouldDeleteCustomer()
        {
            var input = new InputBank() { BankId = BankId };
            var controller = new BankController(presenter, bankDeleteUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.DeleteBank(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotDeleteAndGetError()
        {
            var input = new InputBank() { BankId = BankId };
            var controller = new BankController(presenter, bankDeleteUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.DeleteBank(input);
            output.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
