using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Customer.Get;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using DemoCleanArchitecture.WebApi.UseCases.Customer.Get;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Customer.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerControllerTests
    {
        private readonly ICustomerGetUseCase customerGetUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private static Guid CustomerId;

        public CustomerControllerTests(ICustomerGetUseCase customerGetUseCase, CustomerPresenter presenter, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerGetUseCase = customerGetUseCase;
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
        public void ShouldGetCustomer()
        {
            var input = new InputCustomer() { CustomerId = CustomerId };
            var controller = new CustomerController(presenter, customerGetUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetCustomer(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotGetCustomerAndReturnNotFound()
        {
            var input = new InputCustomer() { CustomerId = Guid.NewGuid() };
            var controller = new CustomerController(presenter, customerGetUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetCustomer(input);
            output.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
