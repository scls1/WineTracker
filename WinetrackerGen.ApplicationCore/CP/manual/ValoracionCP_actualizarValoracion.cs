
using System;
using System.Text;

using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;



/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CP.Winetracker_Valoracion_actualizarValoracion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CP.Winetracker
{
public partial class ValoracionCP : GenericBasicCP
{
public void ActualizarValoracion (int p_oid)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CP.Winetracker_Valoracion_actualizarValoracion) ENABLED START*/

        ValoracionCEN valoracionCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                valoracionCEN = new  ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);

                ArticuloCEN articulocen = new ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);

                ValoracionEN valoracion = valoracionCEN.ReadOID (p_oid);
                ArticuloEN articuloen = valoracion.Articulo_valorado;

                if (articuloen.NumValoraciones == 0) {
                        articuloen.ValoracionTotal = valoracion.Valoracion;
                        articuloen.ValoracionMedia = valoracion.Valoracion;
                        articuloen.NumValoraciones++;
                }
                else{
                        articuloen.NumValoraciones++;
                        articuloen.ValoracionTotal += valoracion.Valoracion;
                        articuloen.ValoracionMedia = articuloen.ValoracionTotal / articuloen.NumValoraciones;
                }




                articulocen.get_IArticuloRepository ().ModifyDefault (articuloen);


                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
