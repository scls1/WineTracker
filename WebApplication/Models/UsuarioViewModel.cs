using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class LoginUsuarioViewModel
    {
        [Display(Prompt = "Correo del usuario", Description = "Correo del usuario", Name = "Correo ")]
        [Required(ErrorMessage = "Debe introducir el correo del usuario")]
        public string Correo { get; set; }

        [Display(Prompt = "Password del usuario", Description = "Password del usuario", Name = "Password ")]
        [Required(ErrorMessage = "El password es obligatorio")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }

    public class RegisterUsuarioViewModel
    {
        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe introducir un nombre")]
        public string Nombre { get; set; }

        [Display(Prompt = "Correo del usuario", Description = "Correo del usuario", Name = "Correo ")]
        [Required(ErrorMessage = "Debe introducir el correo del usuario")]
        public string Correo { get; set; }

        [Display(Prompt = "Password del usuario", Description = "Password del usuario", Name = "Password ")]
        [Required(ErrorMessage = "El password es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Prompt = "Foto del usuario", Description = "Foto del usuario", Name = "Foto")]
        public string Foto { get; set; }

        [Display(Prompt = "Provincia del usuario", Description = "Provincia del usuario", Name = "Provincia")]
        public string Provincia { get; set; }
    }
}
