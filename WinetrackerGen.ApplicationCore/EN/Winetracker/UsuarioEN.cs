
using System;
// Definición clase UsuarioEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo correo
 */
private string correo;



/**
 *	Atributo password
 */
private String password;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo articulo_publicado
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> articulo_publicado;



/**
 *	Atributo pedido_comprado
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN> pedido_comprado;



/**
 *	Atributo articulo_favoritos
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> articulo_favoritos;



/**
 *	Atributo valoracion_usuario
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> valoracion_usuario;



/**
 *	Atributo esPuesto
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> esPuesto;



/**
 *	Atributo megusta_0
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> megusta_0;



/**
 *	Atributo provincia
 */
private WinetrackerGen.ApplicationCore.Enumerated.Winetracker.ProvinciasEnum provincia;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Correo {
        get { return correo; } set { correo = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> Articulo_publicado {
        get { return articulo_publicado; } set { articulo_publicado = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN> Pedido_comprado {
        get { return pedido_comprado; } set { pedido_comprado = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> Articulo_favoritos {
        get { return articulo_favoritos; } set { articulo_favoritos = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> Valoracion_usuario {
        get { return valoracion_usuario; } set { valoracion_usuario = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> EsPuesto {
        get { return esPuesto; } set { esPuesto = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> Megusta_0 {
        get { return megusta_0; } set { megusta_0 = value;  }
}



public virtual WinetrackerGen.ApplicationCore.Enumerated.Winetracker.ProvinciasEnum Provincia {
        get { return provincia; } set { provincia = value;  }
}





public UsuarioEN()
{
        articulo_publicado = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
        pedido_comprado = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN>();
        articulo_favoritos = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
        valoracion_usuario = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN>();
        esPuesto = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN>();
        megusta_0 = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN>();
}



public UsuarioEN(int id, string nombre, string correo, String password, string foto, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> articulo_publicado, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN> pedido_comprado, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> articulo_favoritos, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> valoracion_usuario, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> esPuesto, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> megusta_0, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.ProvinciasEnum provincia
                 )
{
        this.init (Id, nombre, correo, password, foto, articulo_publicado, pedido_comprado, articulo_favoritos, valoracion_usuario, esPuesto, megusta_0, provincia);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Id, usuario.Nombre, usuario.Correo, usuario.Password, usuario.Foto, usuario.Articulo_publicado, usuario.Pedido_comprado, usuario.Articulo_favoritos, usuario.Valoracion_usuario, usuario.EsPuesto, usuario.Megusta_0, usuario.Provincia);
}

private void init (int id
                   , string nombre, string correo, String password, string foto, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> articulo_publicado, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN> pedido_comprado, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> articulo_favoritos, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> valoracion_usuario, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> esPuesto, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.MegustaEN> megusta_0, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.ProvinciasEnum provincia)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Correo = correo;

        this.Password = password;

        this.Foto = foto;

        this.Articulo_publicado = articulo_publicado;

        this.Pedido_comprado = pedido_comprado;

        this.Articulo_favoritos = articulo_favoritos;

        this.Valoracion_usuario = valoracion_usuario;

        this.EsPuesto = esPuesto;

        this.Megusta_0 = megusta_0;

        this.Provincia = provincia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
