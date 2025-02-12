

using System;
using System.Text;
using System.Collections.Generic;

using WinetrackerGen.ApplicationCore.Exceptions;

using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
/*
 *      Definition of the class ArticuloCEN
 *
 */
public partial class ArticuloCEN
{
private IArticuloRepository _IArticuloRepository;

public ArticuloCEN(IArticuloRepository _IArticuloRepository)
{
        this._IArticuloRepository = _IArticuloRepository;
}

public IArticuloRepository get_IArticuloRepository ()
{
        return this._IArticuloRepository;
}

public void Modify (int p_Articulo_OID, string p_nombre, string p_descripcion, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum p_tipo_vino, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum p_tipo_uva, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum p_region, float p_precio, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum p_maridaje)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Id = p_Articulo_OID;
        articuloEN.Nombre = p_nombre;
        articuloEN.Descripcion = p_descripcion;
        articuloEN.Tipo_vino = p_tipo_vino;
        articuloEN.Tipo_uva = p_tipo_uva;
        articuloEN.Region = p_region;
        articuloEN.Precio = p_precio;
        articuloEN.Maridaje = p_maridaje;
        //Call to ArticuloRepository

        _IArticuloRepository.Modify (articuloEN);
}

public void Destroy (int id
                     )
{
        _IArticuloRepository.Destroy (id);
}

public ArticuloEN ReadOID (int id
                           )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloRepository.ReadOID (id);
        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> list = null;

        list = _IArticuloRepository.ReadAll (first, size);
        return list;
}
}
}
