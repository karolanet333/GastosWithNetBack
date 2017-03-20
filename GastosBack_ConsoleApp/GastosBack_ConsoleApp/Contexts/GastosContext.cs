using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GastosBack_ConsoleApp.Contexts
{
    public class GastosContext: DbContext
    {
        public GastosContext() : base("GastosDB5")
        {
        }

        public DbSet<RubroBanco> RubrosBanco { get; set; }
        public DbSet<RubroEfectivo> RubrosEfectivo { get; set; }
        public DbSet<MovEfectivo> MovsEfectivo { get; set; }
    }
}