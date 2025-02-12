
using System;
using System.Text;

using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;



/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CP.Winetracker_Pedido_enviarPedido) ENABLED START*/
//  references to other libraries
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CP.Winetracker
{
public partial class PedidoCP : GenericBasicCP
{
public void EnviarPedido (int p_oid)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CP.Winetracker_Pedido_enviarPedido) ENABLED START*/

        PedidoCEN pedidoCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoCEN = new  PedidoCEN (CPSession.UnitRepo.PedidoRepository);



                ArticuloCEN articulocen = new ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);

                PedidoEN pedidoen = pedidoCEN.ReadOID (p_oid);

                foreach (LineaPedidoEN linea in pedidoen.LineaPedido_pertenece) {
                        ArticuloEN articulo = linea.Articulo_pertenece;
                        articulocen.DecrementarStock (articulo.Id, linea.Cantidad);
                }

                pedidoen.Estado_pedido = EstadoPedidoEnum.enviado;

                pedidoCEN.get_IPedidoRepository ().ModifyDefault (pedidoen);

                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
