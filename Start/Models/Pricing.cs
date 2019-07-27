using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Start.Models
{
    public class Pricing
    {
        public int C { get; set; }
        public int D { get; set; }

        public Pricing(int c, int d)
        {
            this.C = c;
            this.D = d;
        }
    }
}