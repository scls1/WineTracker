
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Comentario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class ComentarioCEN
{
public int New_ (string p_comentario, int p_articulo_tiene, string p_usuario_comenta)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Comentario_new__customized) ENABLED START*/

        ComentarioEN comentarioEN = null;

        int oid;

        comentarioEN = new ComentarioEN ();
        comentarioEN.Comentario = p_comentario;

        comentarioEN.NumLikes = 0;


        if (p_articulo_tiene != -1) {
                comentarioEN.Articulo_tiene = new WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN ();
                comentarioEN.Articulo_tiene.Id = p_articulo_tiene;
        }


        if (p_usuario_comenta != null) {
                comentarioEN.Usuario_comenta = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                comentarioEN.Usuario_comenta.Correo = p_usuario_comenta;
        }


        oid = _IComentarioRepository.New_ (comentarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
