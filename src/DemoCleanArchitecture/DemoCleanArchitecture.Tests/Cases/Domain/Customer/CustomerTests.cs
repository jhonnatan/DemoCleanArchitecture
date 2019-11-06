using DemoCleanArchitecture.Tests.Builders;
using System;
using Xunit;
using FluentAssertions;

namespace DemoCleanArchitecture.Tests.Cases.Domain.Customer
{
    public class CustomerTests
    {
        #region Create Tests
        [Fact]
        public void ShouldCreateDomain()
        {
            var model = CustomerBuilder.New().Build();
            model.IsValid.Should().BeTrue();
        }
        #endregion

        #region Null and Empty Tests
        [Fact]
        public void ShouldNotCreateDomainWithIdNullOrEmpty()
        {
            var model = CustomerBuilder.New().WithId(new Guid()).Build();
            model.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithCustomerNameNullOrEmpty(string name)
        {
            var model = CustomerBuilder.New().WithName(name).Build();
            model.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        public void ShouldNotCreateDomainWithAgeNullOrEmpty(int age)
        {
            var model = CustomerBuilder.New().WithAge(age).Build();
            model.IsValid.Should().BeFalse();
        }
        #endregion

        #region MaxLength Tests
        [Theory]
        [InlineData("Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet " +
            "Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet")]
        public void ShouldNotCreateDomainWithNameLengthBiggerThan200(string name)
        {
            var model = CustomerBuilder.New().WithName(name).Build();
            model.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet " +
            "Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet Lorem ipsum dolor sit amet")]
        public void ShouldNotCreateDomainWithEmailLengthBiggerThan100(string email)
        {
            var model = CustomerBuilder.New().WithEmail(email).Build();
            model.IsValid.Should().BeFalse();
        }

        #endregion

    }
}
