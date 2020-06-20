using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.Models
{
    public class Moras
    {
        [Key]
        public int moraId { get; set; }
        
        [Required(ErrorMessage = "Debe introducir la fecha")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage ="Debe introducir el total")]
        public double total { get; set; }
    }
}
