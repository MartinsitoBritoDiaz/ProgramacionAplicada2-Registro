using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.Models
{
    public class MorasDetalle
    {
        [Key]
        public int morasDetalleId { get; set; }
        public int moraId { get; set; }
        public int prestamoId { get; set; }
        public DateTime fecha { get; set; }
        public double  valor { get; set; }

    }
}
