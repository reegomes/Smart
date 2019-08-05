using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Start.Models
{
    public class Cliente
    {
        public string Nome {get; set;}
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }
        public string Idade { get; set; }
        public string Genero { get; set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente(string nome, string modelo, string marca, string ano, string idade, string genero) : this(nome)
        {
            Nome = nome;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Idade = idade;
            Genero = genero;
        }
    }
}