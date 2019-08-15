using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Start.Models
{
    public class Viagem
    {
        public Viagem()
        {
        }

        public Viagem(DateTime patida, DateTime retorno, int qtdViajantes, string email, string destino)
        {
            Patida = patida;
            Retorno = retorno;
            QtdViajantes = qtdViajantes;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
        }

        public Viagem(DateTime patida, DateTime retorno, int qtdViajantes, string email, string destino, Cliente cliente)
        {
            Patida = patida;
            Retorno = retorno;
            QtdViajantes = qtdViajantes;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        }

        [Key()]
        public int Id { get; set; }
        public DateTime Patida { get; set; }
        public DateTime Retorno { get; set; }
        public int QtdViajantes { get; set; }
        public string Email { get; set; }
        public string Destino { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
    }
}