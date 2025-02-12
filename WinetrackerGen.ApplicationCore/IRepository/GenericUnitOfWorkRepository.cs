
using System;
using System.Collections.Generic;
using System.Text;

namespace WinetrackerGen.ApplicationCore.IRepository.Winetracker
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IArticuloRepository articulorepository;
protected IComentarioRepository comentariorepository;
protected IValoracionRepository valoracionrepository;
protected IPedidoRepository pedidorepository;
protected IMegustaRepository megustarepository;
protected ILineaPedidoRepository lineapedidorepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IArticuloRepository ArticuloRepository {
        get;
}
public abstract IComentarioRepository ComentarioRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract IMegustaRepository MegustaRepository {
        get;
}
public abstract ILineaPedidoRepository LineaPedidoRepository {
        get;
}
}
}
