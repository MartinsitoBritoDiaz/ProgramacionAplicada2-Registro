using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.Models
{
    public class Personas
    {
        [Key]
        public int personaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        [StringLength(10,ErrorMessage ="Debe contener 10 digitos")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la cedula")]
        [StringLength(11, ErrorMessage = "Debe contener 11 digitos")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la direccion")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha de nacimiento")]
        public DateTime fechaNacimiento { get; set; }
    }
}
