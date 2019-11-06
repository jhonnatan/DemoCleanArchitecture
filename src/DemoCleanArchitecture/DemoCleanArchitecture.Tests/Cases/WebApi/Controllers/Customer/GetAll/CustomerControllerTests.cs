using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Customer.GetAll;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Customer.GetAll
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerControllerTests : ControllerBase
    {
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;        

        public CustomerControllerTests(ICustomerGetAllUseCase customerGetAllUseCase, CustomerPresenter presenter, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerGetAllUseCase = customerGetAllUseCase;
            this.presenter = presenter;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomers()
        {            
            var models = new List<DemoCleanArchitecture.Domain.Customer.Customer>() 
            { 
                CustomerBuilder.New().Build(),
                CustomerBuilder.New().Build(),
                CustomerBuilder.New().Build()
            };
            var ret = customerWriteOnlyRepository.Add(models);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAllCustomers()
        {            
            var controller = new DemoCleanArchitecture.WebApi.UseCases.Customer.GetAll.CustomerController(presenter, customerGetAllUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetAllCustomers();
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]        
        public void ShouldNotGetErrorIfDontHaveAnyCustomer()
        {
            var controller = new DemoCleanArchitecture.WebApi.UseCases.Customer.GetAll.CustomerController(presenter, customerGetAllUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetAllCustomers();
            output.Should().BeOfType<OkObjectResult>();
        }
    }
}
