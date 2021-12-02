using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using DemoCleanArchitecture.WebApi.UseCases.Bank.Add;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Bank.Add
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.Charge.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Charge.Tests")]
    public class BankControllerTests
    {
        private readonly IBankSaveUseCase bankSaveUseCase;
        private readonly BankPresenter presenter;

        public BankControllerTests(IBankSaveUseCase bankSaveUseCase, BankPresenter presenter)
        {
            this.bankSaveUseCase = bankSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldCreateBank()
        {
            var input = new InputBank() { Name = "CustomerTest", Number = "64187689745asdsa" };
            var controller = new BankController(presenter, bankSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.CreateBank(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotCreateAndGetError()
        {
            var input = new InputBank() { Name = "", Number = "32156486498asdsad" };
            var controller = new BankController(presenter, bankSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.CreateBank(input);
            output.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
