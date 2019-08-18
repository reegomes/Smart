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
    }
}