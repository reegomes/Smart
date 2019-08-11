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
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Cliente>().HasKey(c => c.CPF);
            mb.Entity<Cotacao>().HasKey(t => t.ID);
        }
    }
}