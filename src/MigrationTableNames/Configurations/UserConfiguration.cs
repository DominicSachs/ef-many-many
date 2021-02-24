using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTableNames.Entities;

namespace MigrationTableNames.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        }
    }
}