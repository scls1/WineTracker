using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class DetalleViewModel
    {
        [ScaffoldColumn(false)]
        public int NumReferencia { get; set; }

        [Display(Prompt = "Describe el artículo", Description = "Descripción del artículo", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Introduce el precio del artículo", Description = "Precio del artículo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor que 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Introduce el stock del artículo", Description = "Stock del artículo", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar el stock del artículo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El stock debe ser mayor que cero y menor que 10000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un número entero para el stock")]
        public int Stock { get; set; }

        public float ValoracionMedia { get; set; }
        public string Foto { get; set; }
        public List<ComentarioViewModel> Comentarios { get; set; }

        public bool Valorado { get; set; }
    }

}
