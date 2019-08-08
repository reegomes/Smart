using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Start.Models;

namespace Start.Library
{
    public partial class ContextDB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }


        public ContextDB() : base("name=ContextDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ; // base.OnModelCreating(modelBuilder);
        }
    }
}