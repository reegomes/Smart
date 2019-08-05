namespace WebCep
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextDB : DbContext
    {

        public DbSet<Endereco> Enderecos { get; set; }

        public ContextDB()
            : base("name=ContextDB")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
