
using System;
// Definición clase ValoracionEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class ValoracionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valoracion
 */
private int valoracion;



/**
 *	Atributo articulo_valorado
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_valorado;



/**
 *	Atributo usuario_valora
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_valora;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN Articulo_valorado {
        get { return articulo_valorado; } set { articulo_valorado = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN Usuario_valora {
        get { return usuario_valora; } set { usuario_valora = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, int valoracion, WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_valorado, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_valora
                    )
{
        this.init (Id, valoracion, articulo_valorado, usuario_valora);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.Id, valoracion.Valoracion, valoracion.Articulo_valorado, valoracion.Usuario_valora);
}

private void init (int id
                   , int valoracion, WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_valorado, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN usuario_valora)
{
        this.Id = id;


        this.Valoracion = valoracion;

        this.Articulo_valorado = articulo_valorado;

        this.Usuario_valora = usuario_valora;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
