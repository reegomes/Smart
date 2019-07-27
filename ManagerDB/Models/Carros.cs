using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerDB.Models
{
    public class Carros
    {
        [Key]
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Obs1 { get; set; }
        public string Obs2 { get; set; }
        public string Obs3 { get; set; }
    }
}