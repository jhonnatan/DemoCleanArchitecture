using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Customer.Delete;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using DemoCleanArchitecture.WebApi.UseCases.Customer.Delete;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Customer.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerControllerTests
    {
        private readonly ICustomerDeleteUseCase customerDeleteUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private static Guid CustomerId;

        public CustomerControllerTests(ICustomerDeleteUseCase customerDeleteUseCase, CustomerPresenter presenter, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerDeleteUseCase = customerDeleteUseCase;
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
        public void ShouldDeleteCustomer()
        {
            var input = new InputCustomer() { CustomerId = CustomerId };
            var controller = new CustomerController(presenter, customerDeleteUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.DeleteCustomer(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotDeleteAndGetError()
        {
            var input = new InputCustomer() { CustomerId = CustomerId };
            var controller = new CustomerController(presenter, customerDeleteUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.DeleteCustomer(input);
            output.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
