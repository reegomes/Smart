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
        public Viagem(int cEP, string logradouro, int numero, string complemento, string bairro, string cidade, string uF, int telefoneResidencial, int telefoneCelular, string motivoViagem, string dataPartida, string dataRetorno)
        {
            CEP = cEP;
            Logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            Numero = numero;
            Complemento = complemento ?? throw new ArgumentNullException(nameof(complemento));
            Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            UF = uF;
            TelefoneResidencial = telefoneResidencial;
            TelefoneCelular = telefoneCelular;
            MotivoViagem = motivoViagem;
        }
        public Viagem(int cEP, string logradouro, int numero, string complemento, string bairro, string cidade, string uF, int telefoneResidencial, int telefoneCelular, string motivoViagem, string dataPartida, string dataRetorno, Cliente cliente)
        {
            CEP = cEP;
            Logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            Numero = numero;
            Complemento = complemento ?? throw new ArgumentNullException(nameof(complemento));
            Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            UF = uF;
            TelefoneResidencial = telefoneResidencial;
            TelefoneCelular = telefoneCelular;
            MotivoViagem = motivoViagem;
            DataPartida = dataPartida;
            DataRetorno = dataRetorno;
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        }

        #region Endereço
        public int CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        #endregion
        #region Contato
        public int QtdViajantes { get; set; }
        public int TelefoneResidencial { get; set; }
        public int TelefoneCelular { get; set; }
        public string MotivoViagem { get; set; }
        public string DataPartida { get; set; }
        public string DataRetorno { get; set; }
        #endregion
        #region Relacionamento
        [Key()]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        #endregion
    }
}