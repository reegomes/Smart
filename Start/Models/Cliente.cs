using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Start.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }

        public Cliente(string cpf, string nome)
        {
            CPF = cpf;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

    }
}