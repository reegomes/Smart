using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Start.Models
{
    public class CotacaoCompleta
    {
        public int id { get; set; }
        public Produto produto { get; set; }
        public double RCF { get; set; }
        public double APP { get; set; }
        public bool PeqReparos { get; set; }
        public bool AssAuto { get; set; }
        public bool CorbCompleta { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}