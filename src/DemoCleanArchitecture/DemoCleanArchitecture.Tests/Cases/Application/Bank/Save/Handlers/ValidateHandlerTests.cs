using System;
using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers;
using FluentAssertions;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Save.Handlers
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
            var request = new BankSaveRequest("BankTest", "asdasdasd");
            Action act = () => validateHandler.ProcessRequest(request);
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ShouldNotExecute()
        {
            var request = new BankSaveRequest("","asdasdasd");
            Action act = () => validateHandler.ProcessRequest(request);
            act.Should().Throw<ArgumentException>();
        }
    }
}
