using System.Data.Entity;

namespace WebCep
{
    public class Contexto : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
    }
}