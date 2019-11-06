using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Customer.Save;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using DemoCleanArchitecture.WebApi.UseCases.Customer.Update;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Customer.Update
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerControllerTests
    {
        private readonly ICustomerSaveUseCase customerSaveUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private static Guid CustomerId;

        public CustomerControllerTests(ICustomerSaveUseCase customerSaveUseCase, CustomerPresenter presenter, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerSaveUseCase = customerSaveUseCase;
            this.presenter = presenter;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            CustomerId = Guid.NewGuid();
            var model = CustomerBuilder.New().WithId(CustomerId).Build();
            var ret = customerWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomer()
        {
            var input = new InputCustomer(CustomerId, "CustomerTest", 50, "customer@email.com.br");
            var controller = new CustomerController(presenter, customerSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.UpdateCustomer(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotUpdateAndGetError()
        {
            var input = new InputCustomer(CustomerId, "", 50, "customer@email.com.br");
            var controller = new CustomerController(presenter, customerSaveUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.UpdateCustomer(input);
            output.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
