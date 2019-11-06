using DemoCleanArchitecture.Application.UseCases.Customer.Save;
using DemoCleanArchitecture.Application.UseCases.Customer.Save.Handlers;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Customer.Save.Handlers
{
    [UseAutofacTestFramework]
    public class SaveHandlerTests
    {
        private readonly SaveHandler saveHandler;

        public SaveHandlerTests(SaveHandler saveHandler)
        {
            this.saveHandler = saveHandler;
        }

        [Fact]
        public void ShouldSave()
        {
            var request = new CustomerSaveRequest("CustomerTest", 18, "email@email.com.br");
            Action act = () => saveHandler.ProcessRequest(request);
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
