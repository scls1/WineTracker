
using System;
// Definición clase PedidoEN
namespace WinetrackerGen.ApplicationCore.EN.Winetracker
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado_pedido
 */
private WinetrackerGen.ApplicationCore.Enumerated.Winetracker.EstadoPedidoEnum estado_pedido;



/**
 *	Atributo comprador
 */
private WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN comprador;



/**
 *	Atributo lineaPedido_pertenece
 */
private System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> lineaPedido_pertenece;



/**
 *	Atributo fechaPedido
 */
private Nullable<DateTime> fechaPedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual WinetrackerGen.ApplicationCore.Enumerated.Winetracker.EstadoPedidoEnum Estado_pedido {
        get { return estado_pedido; } set { estado_pedido = value;  }
}



public virtual WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN Comprador {
        get { return comprador; } set { comprador = value;  }
}



public virtual System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> LineaPedido_pertenece {
        get { return lineaPedido_pertenece; } set { lineaPedido_pertenece = value;  }
}



public virtual Nullable<DateTime> FechaPedido {
        get { return fechaPedido; } set { fechaPedido = value;  }
}





public PedidoEN()
{
        lineaPedido_pertenece = new System.Collections.Generic.List<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN>();
}



public PedidoEN(int id, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.EstadoPedidoEnum estado_pedido, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN comprador, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> lineaPedido_pertenece, Nullable<DateTime> fechaPedido
                )
{
        this.init (Id, estado_pedido, comprador, lineaPedido_pertenece, fechaPedido);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.Id, pedido.Estado_pedido, pedido.Comprador, pedido.LineaPedido_pertenece, pedido.FechaPedido);
}

private void init (int id
                   , WinetrackerGen.ApplicationCore.Enumerated.Winetracker.EstadoPedidoEnum estado_pedido, WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN comprador, System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.LineaPedidoEN> lineaPedido_pertenece, Nullable<DateTime> fechaPedido)
{
        this.Id = id;


        this.Estado_pedido = estado_pedido;

        this.Comprador = comprador;

        this.LineaPedido_pertenece = lineaPedido_pertenece;

        this.FechaPedido = fechaPedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
