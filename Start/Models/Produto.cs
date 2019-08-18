using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Start.Models
{
    public class Produto
    {
        public int id { get; set; }
        public double Valor { get; set; }
        public double ValorParcela { get; set; }

        public float ValorAuto { get; set; }
        public List<Cobertura> cobertura { get; set; }

        public override string ToString()
        {
            return string.Format("Produto ID: {0}, Valor: {1}, Parcela: {2}, Cobertura: {3}.", id, Valor, ValorParcela, cobertura);
        }
    }
}