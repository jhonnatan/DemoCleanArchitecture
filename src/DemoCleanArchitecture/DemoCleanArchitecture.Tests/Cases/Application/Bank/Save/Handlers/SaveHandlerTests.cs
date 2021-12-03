using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Save.Handlers
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
            var request = new BankSaveRequest("BankTest", "123456");
            Action act = () => saveHandler.ProcessRequest(request);
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
