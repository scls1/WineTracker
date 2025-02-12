
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Valoracion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class ValoracionCEN
{
public int New_ (int p_valoracion, int p_articulo_valorado, int p_usuario_valora)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Valoracion_new__customized) START*/

        ValoracionEN valoracionEN = null;

        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Valoracion = p_valoracion;


        if (p_articulo_valorado != -1) {
                valoracionEN.Articulo_valorado = new WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN ();
                valoracionEN.Articulo_valorado.Id = p_articulo_valorado;
        }


        if (p_usuario_valora != -1) {
                valoracionEN.Usuario_valora = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                valoracionEN.Usuario_valora.Id = p_usuario_valora;
        }

        //Call to ValoracionRepository

        oid = _IValoracionRepository.New_ (valoracionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
