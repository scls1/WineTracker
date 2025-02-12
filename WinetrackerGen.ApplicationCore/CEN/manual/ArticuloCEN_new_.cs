
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Articulo_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class ArticuloCEN
{
public int New_ (int p_id, string p_nombre, string p_descripcion, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum p_tipo_vino, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum p_tipo_uva, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum p_region, float p_precio, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum p_maridaje, string p_vendedor_publica, int p_stock, string p_foto)
{
            /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Articulo_new__customized) ENABLED START*/

            ArticuloEN articuloEN = null;

            int oid;

            //Initialized ArticuloEN
            articuloEN = new ArticuloEN();
            articuloEN.Id = p_id;

            articuloEN.Nombre = p_nombre;

            if (p_descripcion != null)
            {
                articuloEN.Descripcion = p_descripcion;

            }
            else
            {
                articuloEN.Descripcion = "";
            }

            articuloEN.Tipo_vino = p_tipo_vino;

            articuloEN.Tipo_uva = p_tipo_uva;

            articuloEN.Region = p_region;

            if (p_stock >= 0)
            {
                articuloEN.Stock = p_stock;
            }
            else
            {
                throw new Exception("El stock debe ser positivo");
            }


            if (p_precio > 0)
            {
                articuloEN.Precio = p_precio;
            }
            else
            {
                throw new Exception("El precio debe ser mayor que 0");
            }

            articuloEN.Maridaje = p_maridaje;
            articuloEN.ValoracionMedia = 0;
            articuloEN.NumValoraciones = 0;
            articuloEN.ValoracionTotal = 0;


            if (p_foto != null)
            {
                articuloEN.Foto = p_foto;

            }
            else
            {
                articuloEN.Foto = "vino.png";
            }

            if (p_vendedor_publica != null)
            {
                articuloEN.Vendedor_publica = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN();
                articuloEN.Vendedor_publica.Correo = p_vendedor_publica;
            }




            //Call to ArticuloRepository

            oid = _IArticuloRepository.New_ (articuloEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
