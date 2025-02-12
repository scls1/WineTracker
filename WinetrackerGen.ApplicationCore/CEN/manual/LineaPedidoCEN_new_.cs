
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_LineaPedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class LineaPedidoCEN
{
public int New_ (int p_pedido_tiene, int p_articulo_pertenece, int p_cantidad, float p_importe)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_LineaPedido_new__customized) START*/

        LineaPedidoEN lineaPedidoEN = null;

        int oid;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();

        if (p_pedido_tiene != -1) {
                lineaPedidoEN.Pedido_tiene = new WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN ();
                lineaPedidoEN.Pedido_tiene.Id = p_pedido_tiene;
        }


        if (p_articulo_pertenece != -1) {
                lineaPedidoEN.Articulo_pertenece = new WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN ();
                lineaPedidoEN.Articulo_pertenece.Id = p_articulo_pertenece;
        }

        lineaPedidoEN.Cantidad = p_cantidad;

        lineaPedidoEN.Importe = p_importe;

        //Call to LineaPedidoRepository

        oid = _ILineaPedidoRepository.New_ (lineaPedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
