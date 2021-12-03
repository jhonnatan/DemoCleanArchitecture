using DemoCleanArchitecture.Tests.Builders;
using System;
using Xunit;
using FluentAssertions;

namespace DemoCleanArchitecture.Tests.Cases.Domain.Bank
{
    public class BankTests
    {
        #region Create Tests
        [Fact]
        public void ShouldCreateDomain()
        {
            var model = BankBuilder.New().Build();
            model.IsValid.Should().BeTrue();
        }
        #endregion

        #region Null and Empty Tests
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
        public void ShouldNotCreateDomainWithBankNumberNullOrEmpty(string number)
        {
            var model = BankBuilder.New().WithName(number).Build();
            model.IsValid.Should().BeFalse();
        }
        #endregion

        #region MaxLength Tests
        [Theory]
        [InlineData("Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet " +
            "Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet")]
        public void ShouldNotCreateDomainWithNameLengthBiggerThan200(string name)
        {
            var model = BankBuilder.New().WithName(name).Build();
            model.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet " +
            "Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet ")]
        public void ShouldNotCreateDomainWithNumberLeghtBiggerThan200(string number)
        {
            var model = BankBuilder.New().WithEmail(number).Build();
            model.IsValid.Should().BeFalse();
        }

        #endregion

    }
}
