using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrosPrestamos.Models
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cedula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la fecha de nacimiento")]
        public DateTime Nacimiento { get; set; }
        public double Balance { get; set; }

    }
}
