using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Domain.Bank;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Repositories
{
    public class BankRepository : IBankReadOnlyRepository, IBankWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public BankRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Bank bank)
        {
            var model = mapper.Map<Entities.Bank.Bank>(bank);
            using (Context context = new Context())
            {
                context.Banks.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Add(List<Bank> banks)
        {
            var models = mapper.Map<List<Entities.Bank.Bank>>(banks);
            using (Context context = new Context())
            {
                context.Banks.AddRange(models);
                context.SaveChanges();
            }
            return 1;
        }

        public IList<Bank> GetAll()
        {
            var list = new List<Bank>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Bank>>(context.Banks.ToList());
            }
            return list;
        }

        public int Save(Bank bank)
        {
           
                return Add(bank);
        }
    }
}
