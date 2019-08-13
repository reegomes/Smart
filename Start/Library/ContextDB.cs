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
            modelBuilder.Entity<Cotacao>().HasRequired(c => c.Cliente).WithMany(c => c.Cotacao);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Start.Models.Residencial> Residencials { get; set; }
    }
}