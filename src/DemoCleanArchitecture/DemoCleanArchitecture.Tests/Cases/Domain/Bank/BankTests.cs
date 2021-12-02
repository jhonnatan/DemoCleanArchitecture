using System;
using DemoCleanArchitecture.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace DemoCleanArchitecture.Tests.Cases.Domain.Bank
{
    public class BankTests
    {
        [Fact]
        public void ShouldCreateDomain()
        {
            var model = BankBuilder.New().Build();
            model.IsValid.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotCreateDomainWithIdNullOrEmpty()
        {
            var model = BankBuilder.New().WithId(new Guid()).Build();
            model.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithBankNameNullOrEmpty(string name)
        {
            var model = BankBuilder.New().WithName(name).Build();
            model.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithNumberNullOrEmpty(string number)
        {
            var model = BankBuilder.New().WithNumber(number).Build();
            model.IsValid.Should().BeFalse();
        }
    }
}
