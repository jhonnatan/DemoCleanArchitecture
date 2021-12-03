using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Domain.Customer;
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
    public class CustomerRepositoryTests
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private static Guid idCustomer;

        public CustomerRepositoryTests(ICustomerReadOnlyRepository customerReadOnlyRepository, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddCustomer()
        {
            idCustomer = Guid.NewGuid();
            var model = CustomerBuilder.New().WithId(idCustomer).Build();
            var ret = customerWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddManyCustomers()
        {
            var models = new List<Customer>() { CustomerBuilder.New().Build(), CustomerBuilder.New().Build(), CustomerBuilder.New().Build() };
            var ret = customerWriteOnlyRepository.Add(models);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAll()
        {
            var models = customerReadOnlyRepository.GetAll();
            models.Should().HaveCountGreaterThan(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetById()
        {
            var model = customerReadOnlyRepository.GetById(idCustomer);
            model.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetByExpression()
        {
            var model = customerReadOnlyRepository.GetByFilter(s => s.Id == idCustomer);
            model.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(3)]
        public void ShouldUpdateCustomer()
        {
            var model = customerReadOnlyRepository.GetById(idCustomer);
            model.Should().NotBeNull();
            var newModel = CustomerBuilder.New().WithId(model.Id).WithName("NewCustomer").Build();
            customerWriteOnlyRepository.Update(newModel);
        }

        [Fact]
        [TestPriority(4)]
        public void ShouldDeleteCustomerById()
        {
            var model = customerReadOnlyRepository.GetById(idCustomer);
            var ret = customerWriteOnlyRepository.Delete(model.Id);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(5)]
        public void ShouldDeleteCustomer()
        {
            var models = customerReadOnlyRepository.GetAll();
            var ret = customerWriteOnlyRepository.Delete(models.First());
            ret.Should().Be(1);
        }
    }
}