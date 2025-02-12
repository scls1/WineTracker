
using System;
// Definición clase ArticuloEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class ArticuloEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo tipo_vino
 */
private WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum tipo_vino;



/**
 *	Atributo tipo_uva
 */
private WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum tipo_uva;



/**
 *	Atributo region
 */
private WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum region;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo maridaje
 */
private WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum maridaje;



/**
 *	Atributo vendedor_publica
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN vendedor_publica;



/**
 *	Atributo comentario_pertenece
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> comentario_pertenece;



/**
 *	Atributo valoracion_articulo
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> valoracion_articulo;



/**
 *	Atributo usuarios_favoritos
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN> usuarios_favoritos;



/**
 *	Atributo lineaPedido_articulo
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> lineaPedido_articulo;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum Tipo_vino {
        get { return tipo_vino; } set { tipo_vino = value;  }
}



public virtual WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum Tipo_uva {
        get { return tipo_uva; } set { tipo_uva = value;  }
}



public virtual WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum Region {
        get { return region; } set { region = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum Maridaje {
        get { return maridaje; } set { maridaje = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN Vendedor_publica {
        get { return vendedor_publica; } set { vendedor_publica = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> Comentario_pertenece {
        get { return comentario_pertenece; } set { comentario_pertenece = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> Valoracion_articulo {
        get { return valoracion_articulo; } set { valoracion_articulo = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN> Usuarios_favoritos {
        get { return usuarios_favoritos; } set { usuarios_favoritos = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> LineaPedido_articulo {
        get { return lineaPedido_articulo; } set { lineaPedido_articulo = value;  }
}





public ArticuloEN()
{
        comentario_pertenece = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN>();
        valoracion_articulo = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN>();
        usuarios_favoritos = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN>();
        lineaPedido_articulo = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN>();
}



public ArticuloEN(int id, string nombre, string descripcion, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum tipo_vino, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum tipo_uva, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum region, float precio, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum maridaje, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN vendedor_publica, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> comentario_pertenece, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> valoracion_articulo, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN> usuarios_favoritos, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> lineaPedido_articulo
                  )
{
        this.init (Id, nombre, descripcion, tipo_vino, tipo_uva, region, precio, maridaje, vendedor_publica, comentario_pertenece, valoracion_articulo, usuarios_favoritos, lineaPedido_articulo);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (articulo.Id, articulo.Nombre, articulo.Descripcion, articulo.Tipo_vino, articulo.Tipo_uva, articulo.Region, articulo.Precio, articulo.Maridaje, articulo.Vendedor_publica, articulo.Comentario_pertenece, articulo.Valoracion_articulo, articulo.Usuarios_favoritos, articulo.LineaPedido_articulo);
}

private void init (int id
                   , string nombre, string descripcion, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum tipo_vino, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum tipo_uva, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum region, float precio, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum maridaje, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN vendedor_publica, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> comentario_pertenece, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ValoracionEN> valoracion_articulo, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN> usuarios_favoritos, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> lineaPedido_articulo)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Tipo_vino = tipo_vino;

        this.Tipo_uva = tipo_uva;

        this.Region = region;

        this.Precio = precio;

        this.Maridaje = maridaje;

        this.Vendedor_publica = vendedor_publica;

        this.Comentario_pertenece = comentario_pertenece;

        this.Valoracion_articulo = valoracion_articulo;

        this.Usuarios_favoritos = usuarios_favoritos;

        this.LineaPedido_articulo = lineaPedido_articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
