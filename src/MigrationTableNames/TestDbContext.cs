using Microsoft.EntityFrameworkCore;
using MigrationTableNames.Entities;

namespace MigrationTableNames
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CustomerServiceGrouping> CustomerServiceGroupings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UseSingularTableNames(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
        }

        private void UseSingularTableNames(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}