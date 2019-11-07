using DemoCleanArchitecture.Application.UseCases.Customer.Save;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using DemoCleanArchitecture.WebApi.UseCases.Customer.Add;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Customer.Add
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.Charge.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Charge.Tests")]
    public class CustomerControllerTests
    {
        private readonly ICustomerSaveUseCase customerSaveUseCase;
        private readonly CustomerPresenter presenter;

        public CustomerControllerTests(ICustomerSaveUseCase customerSaveUseCase, CustomerPresenter presenter)
        {
            this.customerSaveUseCase = customerSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldCreateCustomer()
        {
            var input = new InputCustomer() { Name = "CustomerTest", Age = 50, Email = "customer@email.com.br" };
            var controller = new CustomerController(presenter, customerSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.CreateCustomer(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotCreateAndGetError()
        {
            var input = new InputCustomer() { Name = "", Age = 50, Email = "customer@email.com.br" };
            var controller = new CustomerController(presenter, customerSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.CreateCustomer(input);
            output.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
