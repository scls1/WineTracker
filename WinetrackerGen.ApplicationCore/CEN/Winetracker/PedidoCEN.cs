

using System;
using System.Text;
using System.Collections.Generic;

using WinetrackerGen.ApplicationCore.Exceptions;

using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public void Modify (int p_Pedido_OID, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.EstadoPedidoEnum p_estado_pedido, Nullable<DateTime> p_fechaPedido)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Estado_pedido = p_estado_pedido;
        pedidoEN.FechaPedido = p_fechaPedido;
        //Call to PedidoRepository

        _IPedidoRepository.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoRepository.Destroy (id);
}

public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.ReadAll (first, size);
        return list;
}
}
}
