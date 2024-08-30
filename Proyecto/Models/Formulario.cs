using Proyecto.Conexion;
using Proyecto.Validacion;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Proyecto.Models
{
    public class Formulario
    {
        [Required(ErrorMessage = "Rut es Obligatorio.")]
        [StringLength(maximumLength: 10, ErrorMessage = "El rut tiene maximo 10 Caracteres")]
        [ValidarRut]
        public string? Rut { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe ser mayor a 3 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es Obligatorio.")]
        [MinLength(3, ErrorMessage = "El Apellido debe ser mayor a 3 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Direccion es Obligatorio.")]
        [MinLength(10, ErrorMessage = "La direccion debe ser mayor a 10 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Ciudad es Obligatorio.")]
        [MinLength(3, ErrorMessage = "La ciudad debe ser mayor a 3 caracteres")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Telefono es Obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El Telefono debe tener exactamente 8 dígitos.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Correo Electronico es Obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo Electronico Ingresado no es Valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fecha nacimiento es Obligatoria.")]
        [ValidaFecha]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Estado Civil es Obligatorio.")]
        public string EstadoCivil { get; set; }
        [Required(ErrorMessage = "Comentario es Obligatorio.")]
        [MinLength(10, ErrorMessage = "El comentario debe ser mayor a 10 caracteres")]
        public string Comentario { get; set; }
    }
    
}
