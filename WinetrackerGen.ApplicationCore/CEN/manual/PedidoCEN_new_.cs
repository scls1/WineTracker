
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Pedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class PedidoCEN
{
public int New_ (string p_comprador, Nullable<DateTime> p_fechaPedido)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Pedido_new__customized) ENABLED START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_comprador != null) {
                pedidoEN.Comprador = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                pedidoEN.Comprador.Correo = p_comprador;
        }

        pedidoEN.FechaPedido = p_fechaPedido;
        pedidoEN.Estado_pedido = Enumerated.Winetracker.EstadoPedidoEnum.pendiente;




        //Call to PedidoRepository

        oid = _IPedidoRepository.New_ (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
