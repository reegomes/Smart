using Start.Models;
using System.Data.Entity;

namespace Start.Library
{
    public partial class ContextDB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cobertura> Cobertura { get; set; }
        public DbSet<CotacaoCompleta> CotacaoCompleta { get; set; }
        public DbSet<Residencial> Residencials { get; set; }
        public DbSet<Viagem> Viagems { get; set; }

        public ContextDB() : base("name=ContextDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>().HasRequired(c => c.Cliente).WithMany(c => c.Cotacao);
            modelBuilder.Entity<Viagem>().HasRequired(c => c.Cliente).WithMany(c => c.Viagem);

            base.OnModelCreating(modelBuilder);
        }
    }
}