using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Models
{
    public class ArticuloViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción del producto", Description = "Descripción del producto", Name = "Descripción ")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }
        public VinosEnum TipoVino { get; set; }
        public UvasEnum TipoUva { get; set; }
        public RegionEnum Region { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el producto")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero")]
        public float Precio { get; set; }
        public MaridajeEnum Maridaje { get; set; }

        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        public string Foto { get; set; }

        [Display(Prompt = "Stock del producto", Description = "Stock del producto", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un stock para el producto")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero")]
        public int Stock { get; set; }
        public float ValoracionMedia { get; set; }
        public int NumValoraciones { get; set; }
        public float ValoracionTotal { get; set; }
        //public List<string> Comentarios { get; set; }
        public List<ComentarioViewModel> Comentarios { get; set; }

        public List<int> ComentariosLikes { get; set; } //likes

    }
}
