using System;
using DemoCleanArchitecture.Application.UseCases.Bank.Save;
using DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers;
using FluentAssertions;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Application.Bank.Save.Handlers
{
    [UseAutofacTestFramework]
    public class SaveHandlersTests
    {
        private readonly SaveHandler saveHandler;

        public SaveHandlersTests(SaveHandler saveHandler)
        {
            this.saveHandler = saveHandler;
        }

        [Fact]
        public void ShouldSave()
        {
            var request = new BankSaveRequest("BankTest", "asdasdasdsad");
            Action act = () => saveHandler.ProcessRequest(request);
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
