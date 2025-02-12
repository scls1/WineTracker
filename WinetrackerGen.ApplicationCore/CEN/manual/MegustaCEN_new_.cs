
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Megusta_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class MegustaCEN
{
public int New_ (int p_usuario_pone, int p_comentario_tiene)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Megusta_new__customized) START*/

        MegustaEN megustaEN = null;

        int oid;

        //Initialized MegustaEN
        megustaEN = new MegustaEN ();

        if (p_usuario_pone != -1) {
                megustaEN.Usuario_pone = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                megustaEN.Usuario_pone.Id = p_usuario_pone;
        }


        if (p_comentario_tiene != -1) {
                megustaEN.Comentario_tiene = new WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN ();
                megustaEN.Comentario_tiene.Id = p_comentario_tiene;
        }

        //Call to MegustaRepository

        oid = _IMegustaRepository.New_ (megustaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
