
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
public int New_ (int p_valoracion, int p_articulo_valorado, string p_usuario_valora)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Valoracion_new__customized) ENABLED START*/

        ValoracionEN valoracionEN = null;

        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();

        if (p_valoracion < 0 || p_valoracion > 5) {
                throw new ArgumentException ("La valoracion tiene que comprendida entre 0 y 5");
        }
        else{
                valoracionEN.Valoracion = p_valoracion;
        }


        if (p_articulo_valorado != -1) {
                valoracionEN.Articulo_valorado = new WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN ();
                valoracionEN.Articulo_valorado.Id = p_articulo_valorado;
        }


        if (p_usuario_valora != null) {
                valoracionEN.Usuario_valora = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                valoracionEN.Usuario_valora.Correo = p_usuario_valora;
        }

        //Call to ValoracionRepository

        oid = _IValoracionRepository.New_ (valoracionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
