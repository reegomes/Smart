using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Start.Models
{
    public class Residencial
    {
        [Key()]
        public int Id { get; set; }
        public string CEP { get; set; }
        public string NumeroDaCasa { get; set; }
        public string Complemento { get; set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public Residencial()
        {

        }

        public Residencial(string cEP, string numeroDaCasa, string complemento, string tipo, string logradouro, Cliente cliente)
        {
            CEP = cEP;
            NumeroDaCasa = numeroDaCasa;
            Complemento = complemento;
            Tipo = tipo;
            Logradouro = logradouro;
            Cliente = cliente;
        }

        public Residencial(string cEP, string numeroDaCasa, string complemento, string tipo, string logradouro)
        {
            CEP = cEP;
            NumeroDaCasa = numeroDaCasa;
            Complemento = complemento;
            Tipo = tipo;
            Logradouro = logradouro;
        }
    }
}