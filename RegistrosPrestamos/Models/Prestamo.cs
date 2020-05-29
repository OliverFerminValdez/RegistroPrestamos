using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrosPrestamos.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir el id de la persona")]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la fecha del prestamo")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el concepto del prestamo")]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el monto del prestamo")]
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}
