
using System;
// Definición clase MegustaEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class MegustaEN
{
/**
 *	Atributo usuario_pone
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_pone;



/**
 *	Atributo comentario_tiene
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN comentario_tiene;



/**
 *	Atributo id
 */
private int id;






public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN Usuario_pone {
        get { return usuario_pone; } set { usuario_pone = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN Comentario_tiene {
        get { return comentario_tiene; } set { comentario_tiene = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public MegustaEN()
{
}



public MegustaEN(int id, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_pone, WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN comentario_tiene
                 )
{
        this.init (Id, usuario_pone, comentario_tiene);
}


public MegustaEN(MegustaEN megusta)
{
        this.init (megusta.Id, megusta.Usuario_pone, megusta.Comentario_tiene);
}

private void init (int id
                   , WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_pone, WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN comentario_tiene)
{
        this.Id = id;


        this.Usuario_pone = usuario_pone;

        this.Comentario_tiene = comentario_tiene;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MegustaEN t = obj as MegustaEN;
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
