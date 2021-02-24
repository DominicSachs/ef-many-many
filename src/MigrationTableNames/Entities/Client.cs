using System.Collections.Generic;
using MigrationTableNames.Entities.Abstractions;

namespace MigrationTableNames.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Information { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<CustomerServiceGrouping> CustomerServiceGroupings { get; set; }
    }
}