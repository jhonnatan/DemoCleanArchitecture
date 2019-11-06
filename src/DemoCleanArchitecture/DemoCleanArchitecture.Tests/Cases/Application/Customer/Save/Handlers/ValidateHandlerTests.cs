using DemoCleanArchitecture.Application.UseCases.Customer.Save;
using DemoCleanArchitecture.Application.UseCases.Customer.Save.Handlers;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Customer.Save.Handlers
{
    [UseAutofacTestFramework]
    public class ValidateHandlerTests
    {
        private readonly ValidateHandler validateHandler;

        public ValidateHandlerTests(ValidateHandler validateHandler)
        {
            this.validateHandler = validateHandler;
        }

        [Fact]
        public void ShouldExecute()
        {
            var request = new CustomerSaveRequest("CustomerTest", 18, "email@email.com.br");
            Action act = () => validateHandler.ProcessRequest(request);
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ShouldNotExecute()
        {
            var request = new CustomerSaveRequest("", 18, "email@email.com.br");
            Action act = () => validateHandler.ProcessRequest(request);
            act.Should().Throw<ArgumentException>();
        }
    }
}
