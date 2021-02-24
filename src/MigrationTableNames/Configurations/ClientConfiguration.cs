using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTableNames.Entities;

namespace MigrationTableNames.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DisplayName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Information).HasMaxLength(1000);

            builder.HasMany(b => b.Users).WithMany(b => b.Clients)
                .UsingEntity<Dictionary<string, object>>("ClientUser",
                                                         x => x.HasOne<User>().WithMany().HasForeignKey("UserId"),
                                                         x => x.HasOne<Client>().WithMany().HasForeignKey("ClientId"));

            builder.HasMany(b => b.CustomerServiceGroupings).WithMany(b => b.Clients)
                .UsingEntity<Dictionary<string, object>>("CustomerServiceClientGrouping",
                                                         x => x.HasOne<CustomerServiceGrouping>().WithMany().HasForeignKey("GroupingId"),
                                                         x => x.HasOne<Client>().WithMany().HasForeignKey("ClientId"));
        }
    }
}