using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Start.Models
{
    public class Cliente
    {
        public string CPF { get; set; }
        public string IDCotacao { get; set; }
        public string Nome {get; set;}
        public string Idade { get; set; }
        public string Genero { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }
        

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente(string cpf, string idcotacao, string nome, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo) : this(nome)
        {
            CPF = cpf;
            IDCotacao = idcotacao;
            Nome = nome;
            Idade = idade;
            Genero = genero;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            
        }
    }
}