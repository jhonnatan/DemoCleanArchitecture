using DemoCleanArchitecture.Application.UseCases.Customer.Save;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Customer.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerSaveUseCaseTests
    {
        private readonly ICustomerSaveUseCase customerSaveUseCase;
        private readonly CustomerPresenter presenter;
        private static Guid CustomerId;

        public CustomerSaveUseCaseTests(ICustomerSaveUseCase customerSaveUseCase, CustomerPresenter presenter)
        {
            this.customerSaveUseCase = customerSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewCustomerAndReturnOK()
        {
            var request = new CustomerSaveRequest("CustomerTest", 18, "customer@hotmail.com");
            CustomerId = request.Customer.Id;
            customerSaveUseCase.Execute(request);            
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomerAndReturnOK()
        {
            var request = new CustomerSaveRequest(CustomerId, "CustomerTestUpdated", 25, "customer@hotmail.com");
            customerSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new CustomerSaveRequest("", 18, "customer@hotmail.com");
            customerSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new CustomerSaveRequest(CustomerId, "", 18, "customer@hotmail.com");
            customerSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
