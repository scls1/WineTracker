using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class PerfilViewModel
    {
        public string Correo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        public string Password { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "La provincia es obligatoria.")]
        public string Provincia { get; set; }
    }
}
