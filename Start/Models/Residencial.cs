using System;
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
        public string Logradouro { get; set; }
        public bool AptoCasa { get; set; }
        public bool IQRE { get; set; }
        public bool FERB { get; set; }
        public bool DT { get; set; }
        public bool PPA { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public Residencial()
        {

        }

        public Residencial(string cEP, string numeroDaCasa, string complemento, string logradouro, bool aptoCasa, bool iQRE, bool fERB, bool dT, bool pPA)
        {
            CEP = cEP;
            NumeroDaCasa = numeroDaCasa;
            Complemento = complemento;
            Logradouro = logradouro;
            AptoCasa = aptoCasa;
            IQRE = iQRE;
            FERB = fERB;
            DT = dT;
            PPA = pPA;
        }

        public Residencial(int id, string cEP, string numeroDaCasa, string complemento, string logradouro, bool aptoCasa, bool iQRE, bool fERB, bool dT, bool pPA, Cliente cliente)
        {
            Id = id;
            CEP = cEP ?? throw new ArgumentNullException(nameof(cEP));
            NumeroDaCasa = numeroDaCasa ?? throw new ArgumentNullException(nameof(numeroDaCasa));
            Complemento = complemento ?? throw new ArgumentNullException(nameof(complemento));
            Logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            AptoCasa = aptoCasa;
            IQRE = iQRE;
            FERB = fERB;
            DT = dT;
            PPA = pPA;
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        }
    }
}