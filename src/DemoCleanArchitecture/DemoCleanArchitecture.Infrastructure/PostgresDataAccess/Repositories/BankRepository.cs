using AutoMapper;
using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Domain.Bank;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public int Delete(Guid id)
        {
            using (var context = new Context())
            {
                var model = context.Banks.FirstOrDefault(f => f.Id == id);
                context.Banks.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Delete(Bank bank)
        {
            using (var context = new Context())
            {
                var model = context.Banks.FirstOrDefault(f => f.Id == bank.Id);
                context.Banks.Remove(model);
                return context.SaveChanges();
            }
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

        public IList<Bank> GetByFilter(Expression<Func<Bank, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<Bank>>(context.Banks.Where(mapper.Map<Expression<Func<Entities.Bank.Bank, bool>>>(filter)).ToList());
            }
        }

        public Bank GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Bank>(context.Banks.FirstOrDefault(s => s.Id == id));
            }
        }

        public int Save(Bank bank)
        {
            if (GetById(bank.Id) == null)
                return Add(bank);
            else
                return Update(bank);
        }

        public int Update(Bank bank)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Entities.Bank.Bank>(bank)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
