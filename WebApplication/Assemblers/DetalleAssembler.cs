using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WebApplication.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication.Assemblers
{
    public class DetalleAssembler
    {
        public DetalleViewModel ConvertirENToViewModel(ArticuloEN en)
        {
            DetalleViewModel art = new DetalleViewModel();
            art.NumReferencia = en.Id;
            art.Descripcion = en.Descripcion;
            art.Precio = en.Precio;
            art.Stock = en.Stock;
            art.Foto = en.Foto;
            art.ValoracionMedia = en.ValoracionMedia;

            if (en.Comentario_pertenece != null)
            {
                art.Comentarios = en.Comentario_pertenece.Select(c => new ComentarioViewModel
                {
                    Usuario = c.Usuario_comenta != null ? c.Usuario_comenta.Nombre : "Anónimo",
                    NumLikes = c.NumLikes,
                    Texto = c.Comentario
                }).ToList();
            }

            return art;
        }

        public IList<DetalleViewModel> ConvertirListENToViewModel(IList<ArticuloEN> ens)
        {
            IList<DetalleViewModel> arts = new List<DetalleViewModel>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en));
            }
            return arts;
        }
    }
}
