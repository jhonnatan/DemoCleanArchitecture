using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Map.Bank
{
    public class BankMap : IEntityTypeConfiguration<Entities.Bank.Bank>
    {
        public void Configure(EntityTypeBuilder<Entities.Bank.Bank> builder)
        {
            builder.ToTable("Bank", "DemoClean");
            builder.HasKey(s => s.Id);
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Number).HasMaxLength(20);
        }
    }
}
