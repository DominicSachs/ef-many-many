using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTableNames.Entities;

namespace MigrationTableNames.Configurations
{
    public class CustomerServiceGroupingConfiguration : IEntityTypeConfiguration<CustomerServiceGrouping>
    {
        public void Configure(EntityTypeBuilder<CustomerServiceGrouping> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.HasIndex(b => b.Name).IsUnique();
        }
    }
}