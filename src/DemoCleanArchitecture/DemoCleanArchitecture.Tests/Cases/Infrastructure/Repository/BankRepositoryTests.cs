using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Domain.Bank;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        [TestPriority(2)]
        public void ShouldGetById()
        {
            var model = bankReadOnlyRepository.GetById(idBank);
            model.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetByExpression()
        {
            var model = bankReadOnlyRepository.GetByFilter(s => s.Id == idBank);
            model.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(3)]
        public void ShouldUpdateBank()
        {
            var model = bankReadOnlyRepository.GetById(idBank);
            model.Should().NotBeNull();
            var newModel = BankBuilder.New().WithId(model.Id).WithName("NewBank").Build();
            bankWriteOnlyRepository.Update(newModel);
        }

        [Fact]
        [TestPriority(4)]
        public void ShouldDeleteBankById()
        {
            var model = bankReadOnlyRepository.GetById(idBank);
            var ret = bankWriteOnlyRepository.Delete(model.Id);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(5)]
        public void ShouldDeleteBank()
        {
            var models = bankReadOnlyRepository.GetAll();
            var ret = bankWriteOnlyRepository.Delete(models.First());
            ret.Should().Be(1);
        }
    }
}