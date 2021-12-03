using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Application.UseCases.Bank.GetAll;
using DemoCleanArchitecture.Tests.Builders;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using DemoCleanArchitecture.WebApi.UseCases.Bank;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace DemoCleanArchitecture.Tests.Cases.WebApi.Controllers.Bank.GetAll
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering.PriorityOrderer", "DemoCleanArchitecture.Tests")]
    public class BankControllerTests : ControllerBase
    {
        private readonly IBankGetAllUseCase bankGetAllUseCase;
        private readonly BankPresenter presenter;
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;        

        public BankControllerTests(IBankGetAllUseCase bankGetAllUseCase, BankPresenter presenter, IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankGetAllUseCase = bankGetAllUseCase;
            this.presenter = presenter;
            this.bankWriteOnlyRepository = bankWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeBanks()
        {            
            var models = new List<DemoCleanArchitecture.Domain.Bank.Bank>() 
            { 
                BankBuilder.New().Build(),
                BankBuilder.New().Build(),
                BankBuilder.New().Build()
            };
            var ret = bankWriteOnlyRepository.Add(models);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAllBanks()
        {            
            var controller = new DemoCleanArchitecture.WebApi.UseCases.Bank.GetAll.BankController(presenter, bankGetAllUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetAllBanks();
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]        
        public void ShouldNotGetErrorIfDontHaveAnyBank()
        {
            var controller = new DemoCleanArchitecture.WebApi.UseCases.Bank.GetAll.BankController(presenter, bankGetAllUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.GetAllBanks();
            output.Should().BeOfType<OkObjectResult>();
        }
    }
}
