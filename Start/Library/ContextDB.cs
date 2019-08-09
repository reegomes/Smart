using Start.Models;
using System.Data.Entity;

namespace Start.Library
{
    public partial class ContextDB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }

        public ContextDB() : base("name=ContextDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}