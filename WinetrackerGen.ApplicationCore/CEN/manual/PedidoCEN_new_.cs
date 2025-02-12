
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
public int New_ (int p_comprador, Nullable<DateTime> p_fechaPedido)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Pedido_new__customized) START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_comprador != -1) {
                pedidoEN.Comprador = new WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN ();
                pedidoEN.Comprador.Id = p_comprador;
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
