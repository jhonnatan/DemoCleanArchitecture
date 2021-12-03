using DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Bank;
using DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Bank> Banks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("DEMOCLEAN_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DEMOCLEAN_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "DemoClean");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("DemoCleanInMemory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostgresDataAccess.Entities.Map.Customer.CustomerMap());
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostgresDataAccess.Entities.Map.Bank.BankMap());
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
