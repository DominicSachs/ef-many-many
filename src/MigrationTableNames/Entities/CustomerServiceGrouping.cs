using System.Collections.Generic;
using MigrationTableNames.Entities.Abstractions;

namespace MigrationTableNames.Entities
{
    public class CustomerServiceGrouping : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}