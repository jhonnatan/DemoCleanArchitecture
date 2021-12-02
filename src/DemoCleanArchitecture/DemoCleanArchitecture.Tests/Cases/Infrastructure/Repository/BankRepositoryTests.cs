using System;
using System.Collections.Generic;
using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Domain.Bank;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.Infrastructure.Repository
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankRepositoryTests
    {
        private readonly IBankReadOnlyRepository bankReadOnlyRepository;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;
        private static Guid idBank;

        public BankRepositoryTests(IBankReadOnlyRepository bankReadOnlyRepository, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankReadOnlyRepository = bankReadOnlyRepository;
            this.bankWriteOnlyRepository = bankWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddBank()
        {
            idBank = Guid.NewGuid();
            var model = BankBuilder.New().WithId(idBank).Build();
            var ret = bankWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddManyBank()
        {
            var models = new List<Bank>() { BankBuilder.New().Build(), BankBuilder.New().Build(), BankBuilder.New().Build() };
            var ret = bankWriteOnlyRepository.Add(models);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAll()
        {
            var models = bankReadOnlyRepository.GetAll();
            models.Should().HaveCountGreaterThan(1);
        }
    }
}
