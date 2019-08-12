using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Start.Models
{
    public class Cotacao
    {   
        [Key]
        public int ID { get; set; }
        //public double ClienteId { get; set; }
        
        public virtual Cliente Cliente { get; set; }
        public int ClienteID { get; set; }
        //[ForeignKey("ClienteID")]
        public string Idade { get; set; }
        public string Genero { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }

        
        public Cotacao(Cliente cliente, int clienteID, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo)
        {
            Cliente = cliente;
            ClienteID = clienteID;
            Idade = idade;
            Genero = genero;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
        }

        public Cotacao(string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo)
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