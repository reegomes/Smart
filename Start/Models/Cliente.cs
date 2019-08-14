using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Start.Models
{
    public class Cliente
    {
        [Key()]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Cotacao> Cotacao { get; set; }
        public virtual ICollection<Residencial> Residencial { get; set; }

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
    }
}