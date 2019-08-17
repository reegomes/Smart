using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Start.Library;

namespace Start.Models
{
    public class Cliente
    {
        #region Geral
        [Key()]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        #endregion
        #region Viagem
        #region Dados Pessoais
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        #endregion
        #endregion
        #region Relacionamentos
        public virtual ICollection<Cotacao> Cotacao { get; set; }
        public virtual ICollection<Residencial> Residencial { get; set; }
        public virtual ICollection<Viagem> Viagem { get; set; }
        #endregion
        public Cliente(string cpf, string nome, ICollection<Cotacao> cotacao)
        {
            CPF = cpf;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cotacao = cotacao ?? throw new ArgumentNullException(nameof(cotacao));
        }
        public Cliente(string cpf, string nome, ICollection<Residencial> residencial)
        {
            CPF = cpf;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Residencial = residencial ?? throw new ArgumentNullException(nameof(residencial));
        }

        public Cliente(string cpf, string nome)
        {
            CPF = cpf;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

        public Cliente()
        {
        }

        public Cliente(string cPF, string nome, string email, string dataNascimento, string sexo, string estadoCivil, ICollection<Viagem> viagem) : this(cPF, nome)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            DataNascimento = dataNascimento ?? throw new ArgumentNullException(nameof(dataNascimento));
            Sexo = sexo ?? throw new ArgumentNullException(nameof(sexo));
            EstadoCivil = estadoCivil ?? throw new ArgumentNullException(nameof(estadoCivil));
            Viagem = viagem ?? throw new ArgumentNullException(nameof(viagem));
        }

        public Cliente(string cpf, string nome, string email, string dataNascimento, string sexo, string estadoCivil) : this(cpf, nome)
        {
            Email = email;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }
    }
}