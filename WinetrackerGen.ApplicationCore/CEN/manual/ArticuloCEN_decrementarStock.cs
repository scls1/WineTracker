
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Articulo_decrementarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class ArticuloCEN
{
public void DecrementarStock (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Articulo_decrementarStock) ENABLED START*/

        ArticuloEN articuloEN = _IArticuloRepository.ReadOID (p_oid);


        if (articuloEN.Stock < p_cantidad)
                throw new ModelException ("El decremento es mayor que el stock actual.");

        articuloEN.Stock -= p_cantidad;

        _IArticuloRepository.Modify (articuloEN);


        /*PROTECTED REGION END*/
}
}
}
