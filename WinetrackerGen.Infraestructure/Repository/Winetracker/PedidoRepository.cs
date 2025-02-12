
using System;
using System.Text;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;
using WinetrackerGen.Infraestructure.EN.Winetracker;


/*
 * Clase Pedido:
 *
 */

namespace WinetrackerGen.Infraestructure.Repository.Winetracker
{
public partial class PedidoRepository : BasicRepository, IPedidoRepository
{
public PedidoRepository() : base ()
{
}


public PedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PedidoEN ReadOIDDefault (int id
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;


}
        public System.Collections.Generic.IList<PedidoEN> ObtenerTodosLosPedidos()
        {
            System.Collections.Generic.IList<PedidoEN> result = null;

            try
            {
                SessionInitializeTransaction();

                // Consulta para obtener todos los pedidos con líneas de pedido y artículos relacionados
                result = session.CreateCriteria(typeof(PedidoNH))
                                .CreateAlias("LineaPedido_pertenece", "lineas") // Relaciona Pedido con LineasPedido
                                .CreateAlias("Comprador", "comprador") // Relaciona LineasPedido con Articulo
                                .List<PedidoEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else
                    throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException("Error en PedidoRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }


        public System.Collections.Generic.IList<PedidoEN> ObtenerPedidosPorUsuario(string correoUsuario)
        {
            System.Collections.Generic.IList<PedidoEN> result = null;
            try
            {
                SessionInitializeTransaction();

                // Realiza la consulta para obtener los pedidos asociados al usuario
                result = session.CreateCriteria(typeof(PedidoNH))
                                .CreateAlias("Comprador", "comprador")  // Asumiendo que 'Comprador' es la relación con el usuario
                                .Add(Restrictions.Eq("comprador.Correo", correoUsuario))  // Filtra por el correo del usuario
                                .List<PedidoEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else
                    throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException("Error in PedidoRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }

        public System.Collections.Generic.IList<LineaPedidoEN> ObtenerLineasPorPedido(int pedidoId)
        {
            System.Collections.Generic.IList<LineaPedidoEN> result = null;
            try
            {
                SessionInitializeTransaction();

                // Consulta para obtener las líneas de pedido con las relaciones cargadas
                result = session.CreateCriteria(typeof(LineaPedidoEN))
                                .CreateAlias("Pedido_tiene", "pedido")  // Relaciona LineaPedido con Pedido
                                .CreateAlias("Articulo_pertenece", "articulo")  // Relaciona LineaPedido con Articulo
                                .Add(Restrictions.Eq("pedido.Id", pedidoId))  // Filtra por el ID del pedido
                                .List<LineaPedidoEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else
                    throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException("Error in LineaPedidoRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }

        public void EliminarPedidoConLineas(int pedidoId)
        {
            try
            {
                SessionInitializeTransaction();

                // Recuperar el pedido por su ID
                PedidoNH pedidoNH = (PedidoNH)session.Get(typeof(PedidoNH), pedidoId);
                if (pedidoNH == null)
                {
                    throw new WinetrackerGen.ApplicationCore.Exceptions.ModelException($"El pedido con ID {pedidoId} no existe.");
                }

                // Recuperar las líneas asociadas al pedido
                var lineasPedido = session.CreateCriteria(typeof(LineaPedidoEN))
                                          .CreateAlias("Pedido_tiene", "pedido")
                                          .Add(Restrictions.Eq("pedido.Id", pedidoId))
                                          .List<LineaPedidoEN>();

                // Eliminar todas las líneas de pedido asociadas
                foreach (var linea in lineasPedido)
                {
                    session.Delete(linea);
                }

                // Eliminar el pedido
                session.Delete(pedidoNH);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else
                    throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException("Error al eliminar el pedido y sus líneas.", ex);
            }
            finally
            {
                SessionClose();
            }
        }



        public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.Id);

                pedidoNH.Estado_pedido = pedido.Estado_pedido;




                pedidoNH.FechaPedido = pedido.FechaPedido;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PedidoEN pedido)
{
        PedidoNH pedidoNH = new PedidoNH (pedido);

        try
        {
                SessionInitializeTransaction ();
                if (pedido.Comprador != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Comprador = (WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN), pedido.Comprador.Correo);

                        pedidoNH.Comprador.Pedido_comprado
                        .Add (pedidoNH);
                }

                session.Save (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoNH.Id;
}

public void Modify (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.Id);

                pedidoNH.Estado_pedido = pedido.Estado_pedido;


                pedidoNH.FechaPedido = pedido.FechaPedido;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), id);
                session.Delete (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PedidoEN
public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
