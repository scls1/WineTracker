

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

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioRepository.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> DameComentarioPorArticulo (int ? p_articulo)
{
        return _IComentarioRepository.DameComentarioPorArticulo (p_articulo);
}
}
}
