using System.Data.Entity;

namespace ManagerDB.Models
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Carros> Carros { get; set; }
    }
}