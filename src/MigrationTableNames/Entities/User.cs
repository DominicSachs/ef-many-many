using System.Collections.Generic;
using MigrationTableNames.Entities.Abstractions;

namespace MigrationTableNames.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}