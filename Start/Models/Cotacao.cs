using System.ComponentModel.DataAnnotations;

namespace Start.Models
{
    public class Cotacao
    {
        [Key]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Genero { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }

        public Cotacao(string nome)
        {
            this.Nome = nome;
        }

        public Cotacao(Cliente cliente, string nome, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo) : this(nome)
        {
            Cliente = cliente;
            Nome = nome;
            Idade = idade;
            Genero = genero;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;

        }

        public Cotacao(string nome, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo) : this(nome)
        {
            Idade = idade;
            Genero = genero;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
        }
    }
}