using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Customer.Get;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;
namespace DemoCleanArchitecture.Tests.Cases.Application.Customer.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class CustomerGetUseCaseTests
    {
        private readonly ICustomerGetUseCase customerGetUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private static Guid CustomerId;

        public CustomerGetUseCaseTests(ICustomerGetUseCase customerGetUseCase, CustomerPresenter presenter, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerGetUseCase = customerGetUseCase;
            this.presenter = presenter;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            var model = CustomerBuilder.New().Build();
            CustomerId = model.Id;
            var ret = customerWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetCustomerById()
        {
            var request = new CustomerGetRequest(CustomerId);
            customerGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotGetCustomerByIdAndReturnNotFound()
        {
            var request = new CustomerGetRequest(Guid.NewGuid());
            customerGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
        }

    }
}
