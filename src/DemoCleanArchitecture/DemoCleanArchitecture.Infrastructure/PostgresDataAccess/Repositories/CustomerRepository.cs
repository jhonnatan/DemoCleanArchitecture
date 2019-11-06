using AutoMapper;
using DemoCleanArchitecture.Application.Repositories;
using DemoCleanArchitecture.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Repositories
{
    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Customer customer)
        {
            var model = mapper.Map<Entities.Customer.Customer>(customer);
            using (Context context = new Context())
            {
                context.Customers.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Add(List<Customer> customers)
        {
            var models = mapper.Map<List<Entities.Customer.Customer>>(customers);
            using (Context context = new Context())
            {
                context.Customers.AddRange(models);
                context.SaveChanges();
            }
            return 1;
        }

        public int Delete(Guid id)
        {
            using (var context = new Context())
            {
                var model = context.Customers.FirstOrDefault(f => f.Id == id);
                context.Customers.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Delete(Customer customer)
        {
            using (var context = new Context())
            {
                var model = context.Customers.FirstOrDefault(f => f.Id == customer.Id);
                context.Customers.Remove(model);
                return context.SaveChanges();
            }
        }

        public IList<Customer> GetAll()
        {
            var list = new List<Customer>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Customer>>(context.Customers.ToList());
            }
            return list;
        }

        public IList<Customer> GetByFilter(Expression<Func<Customer, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<Customer>>(context.Customers.Where(mapper.Map<Expression<Func<Entities.Customer.Customer, bool>>>(filter)).ToList());
            }
        }

        public Customer GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Customer>(context.Customers.FirstOrDefault(s => s.Id == id));
            }
        }

        public int Save(Customer customer)
        {
            if (GetById(customer.Id) == null)
                return Add(customer);
            else
                return Update(customer);
        }

        public int Update(Customer customer)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Entities.Customer.Customer>(customer)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
