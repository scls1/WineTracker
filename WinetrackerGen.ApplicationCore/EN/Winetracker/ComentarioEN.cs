
using System;
// Definición clase ComentarioEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo numLikes
 */
private int numLikes;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo articulo_tiene
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_tiene;



/**
 *	Atributo usuario_comenta
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_comenta;



/**
 *	Atributo megusta_1
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> megusta_1;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int NumLikes {
        get { return numLikes; } set { numLikes = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN Articulo_tiene {
        get { return articulo_tiene; } set { articulo_tiene = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN Usuario_comenta {
        get { return usuario_comenta; } set { usuario_comenta = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> Megusta_1 {
        get { return megusta_1; } set { megusta_1 = value;  }
}





public ComentarioEN()
{
        megusta_1 = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN>();
}



public ComentarioEN(int id, int numLikes, string comentario, WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_tiene, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_comenta, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> megusta_1
                    )
{
        this.init (Id, numLikes, comentario, articulo_tiene, usuario_comenta, megusta_1);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (comentario.Id, comentario.NumLikes, comentario.Comentario, comentario.Articulo_tiene, comentario.Usuario_comenta, comentario.Megusta_1);
}

private void init (int id
                   , int numLikes, string comentario, WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_tiene, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_comenta, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> megusta_1)
{
        this.Id = id;


        this.NumLikes = numLikes;

        this.Comentario = comentario;

        this.Articulo_tiene = articulo_tiene;

        this.Usuario_comenta = usuario_comenta;

        this.Megusta_1 = megusta_1;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
