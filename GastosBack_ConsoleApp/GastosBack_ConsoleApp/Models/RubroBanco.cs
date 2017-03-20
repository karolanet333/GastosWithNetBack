using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GastosBack_ConsoleApp.Models
{
    [Table("RubrosBanco")]
    public class RubroBanco
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Rubro { get; set; }
        [RegularExpression(@"^\+|\-$", ErrorMessage = "Only + and - allowed on 'Signo' field")]
        public string Signo { get; set; }
    }
}