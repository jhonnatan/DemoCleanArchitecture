using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Map.Customer
{
    public class CustomerMap : IEntityTypeConfiguration<Entities.Customer.Customer>
    {
        public void Configure(EntityTypeBuilder<Entities.Customer.Customer> builder)
        {
            builder.ToTable("Customer", "DemoClean");
            builder.HasKey(s => s.Id);
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Age).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(200);
            builder.Property(d => d.Email).HasMaxLength(100);
        }
    }
}
