using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace Winetracker.Assemblers
{
    public class ArticuloAssembler
    {
        public ArticuloViewModel ConvertirENToViewModel(ArticuloEN en)
        {
            ArticuloViewModel art = new ArticuloViewModel();
            art.Id = en.Id;
            art.Nombre = en.Nombre;
            art.Descripcion = en.Descripcion;
            art.Precio = en.Precio;
            art.Stock = en.Stock;
            art.TipoVino = (VinosEnum)en.Tipo_vino;
            art.TipoUva = (UvasEnum)en.Tipo_uva;
            art.Region = (RegionEnum)en.Region;
            art.Maridaje = (MaridajeEnum)en.Maridaje;
            art.ValoracionMedia = en.ValoracionMedia;
            art.NumValoraciones = en.NumValoraciones;
            art.ValoracionTotal = en.ValoracionTotal;
            art.Foto = en.Foto;

            return art;
        }

        public IList<ArticuloViewModel> ConvertirListENToViewModel(IList<ArticuloEN> ens)
        {
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en));
            }
            return arts;
        }

        public static List<SelectListItem> GetTipoVinoOptions()
        {
            return Enum.GetValues(typeof(VinosEnum))
                                   .Cast<VinosEnum>()
                                   .Select(v => new SelectListItem
                                   {
                                       Value = ((int)v).ToString(),
                                       Text = v.ToString()
                                   }).ToList();
        }

        public static List<SelectListItem> GetTipoUvaOptions()
        {
            return Enum.GetValues(typeof(UvasEnum))
                                           .Cast<UvasEnum>()
                                           .Select(u => new SelectListItem
                                           {
                                               Value = ((int)u).ToString(),
                                               Text = u.ToString()
                                           }).ToList();
        }

        public static List<SelectListItem> GetMaridajeOptions()
        {
            return Enum.GetValues(typeof(MaridajeEnum))
                       .Cast<MaridajeEnum>()
                       .Select(m => new SelectListItem
                       {
                           Value = ((int)m).ToString(),
                           Text = m.ToString()
                       })
                       .ToList();
        }

        public static List<SelectListItem> GetRegionOptions()
        {

            return Enum.GetValues(typeof(RegionEnum))
                                           .Cast<RegionEnum>()
                                           .Select(r => new SelectListItem
                                           {
                                               Value = ((int)r).ToString(),
                                               Text = r.ToString()
                                           }).ToList();
        }
    }
}
