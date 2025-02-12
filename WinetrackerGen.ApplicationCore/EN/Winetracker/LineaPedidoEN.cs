
using System;
// Definición clase LineaPedidoEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class LineaPedidoEN
{
/**
 *	Atributo pedido_tiene
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN pedido_tiene;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo_pertenece
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_pertenece;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo importe
 */
private float importe;






public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN Pedido_tiene {
        get { return pedido_tiene; } set { pedido_tiene = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN Articulo_pertenece {
        get { return articulo_pertenece; } set { articulo_pertenece = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual float Importe {
        get { return importe; } set { importe = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN pedido_tiene, WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_pertenece, int cantidad, float importe
                     )
{
        this.init (Id, pedido_tiene, articulo_pertenece, cantidad, importe);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (lineaPedido.Id, lineaPedido.Pedido_tiene, lineaPedido.Articulo_pertenece, lineaPedido.Cantidad, lineaPedido.Importe);
}

private void init (int id
                   , WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN pedido_tiene, WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN articulo_pertenece, int cantidad, float importe)
{
        this.Id = id;


        this.Pedido_tiene = pedido_tiene;

        this.Articulo_pertenece = articulo_pertenece;

        this.Cantidad = cantidad;

        this.Importe = importe;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
