using System.ComponentModel.DataAnnotations;

namespace Start.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        //public ICollection<Cotacao> Cotacao { get; set; }



        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente(string cpf, string nome) : this(nome)
        {
            //Cotacao.Add(cotacao);
            CPF = cpf;
            Nome = nome;
        }
    }
}