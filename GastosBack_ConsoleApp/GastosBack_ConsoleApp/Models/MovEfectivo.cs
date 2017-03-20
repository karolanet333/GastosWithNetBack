using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Models
{
    [Table("MovsEfectivo")]
    public class MovEfectivo
    {
        [Key]
        public int Id { get; set; }
        public int RubroEfectivoId { get; set; }
        public string Description { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaMov { get; set; }
        public decimal Monto { get; set; }
        public string Signo { get; set; }
        public decimal Saldo { get; set; }
    }
}
