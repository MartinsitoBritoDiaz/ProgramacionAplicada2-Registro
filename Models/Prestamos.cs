using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.Models
{
    public class Prestamos
    {
        [Key]
        public int prestamoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha del prestamo")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el concepto")]
        public string concepto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el monto")]
        public double monto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el balance")]
        public double balance { get; set; }
        public int personaId { get; set; }
        
        [ForeignKey("personaId")]
        public virtual Personas Persona { get; set; }

        [ForeignKey("prestamoId")]
        public virtual List<MorasDetalle> MorasDetalle { get; set; } = new List<MorasDetalle>();

    }
}
