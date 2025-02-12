using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Models
{
    public class MisVinosViewModel
    {
        [ScaffoldColumn(false)]

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el producto")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero")]
        public float Precio { get; set; }

        [Display(Prompt = "Stock del producto", Description = "Stock del producto", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un stock para el producto")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero")]
        public int Stock { get; set; }
        public float ValoracionMedia { get; set; }

    }
}
