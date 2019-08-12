using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Start.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public double CPF { get; set; }
        public string Nome { get; set; }

        //public Cotacao Cotacao { get; set; }
        public ICollection<Cotacao> Cotacoes { get; set; }
        //public virtual IEnumerable<Cotacao> Cotacoes { get; set; }


        public Cliente(double cpf, string nome, ICollection<Cotacao> cotacao)
        {
            CPF = cpf;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cotacoes = cotacao ?? throw new ArgumentNullException(nameof(cotacao));
        }

        public Cliente(double cpf, string nome)
        {
            CPF = cpf;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

        public Cliente(int iD, double cPF, string nome, ICollection<Cotacao> cotacoes)
        {
            ID = iD;
            CPF = cPF;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cotacoes = cotacoes ?? throw new ArgumentNullException(nameof(cotacoes));
        }
    }
}