

using System;
using System.Text;
using System.Collections.Generic;

using WinetrackerGen.ApplicationCore.Exceptions;

using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
/*
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioRepository _IComentarioRepository;

public ComentarioCEN(IComentarioRepository _IComentarioRepository)
{
        this._IComentarioRepository = _IComentarioRepository;
}

public IComentarioRepository get_IComentarioRepository ()
{
        return this._IComentarioRepository;
}

public int New_ (int p_numLikes, string p_comentario, int p_articulo_tiene, int p_usuario_comenta)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.NumLikes = p_numLikes;

        comentarioEN.Comentario = p_comentario;


        if (p_articulo_tiene != -1) {
                // El argumento p_articulo_tiene -> Property articulo_tiene es oid = false
                // Lista de oids id
                comentarioEN.Articulo_tiene = new WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN ();
                comentarioEN.Articulo_tiene.Id = p_articulo_tiene;
        }


        if (p_usuario_comenta != -1) {
                // El argumento p_usuario_comenta -> Property usuario_comenta es oid = false
                // Lista de oids id
                comentarioEN.Usuario_comenta = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                comentarioEN.Usuario_comenta.Id = p_usuario_comenta;
        }



        oid = _IComentarioRepository.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, int p_numLikes, string p_comentario)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.NumLikes = p_numLikes;
        comentarioEN.Comentario = p_comentario;
        //Call to ComentarioRepository

        _IComentarioRepository.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioRepository.Destroy (id);
}
}
}
