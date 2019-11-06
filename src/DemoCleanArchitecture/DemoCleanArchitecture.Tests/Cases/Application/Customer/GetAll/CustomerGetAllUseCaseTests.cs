using DemoCleanArchitecture.Application.UseCases.Customer.GetAll;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Customer.GetAll
{
    [UseAutofacTestFramework]
    public class CustomerGetAllUseCaseTests
    {
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;
        private readonly CustomerPresenter presenter;

        public CustomerGetAllUseCaseTests(ICustomerGetAllUseCase customerGetAllUseCase, CustomerPresenter presenter)
        {
            this.customerGetAllUseCase = customerGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldExecute()
        {
            customerGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
       }
    }
}
