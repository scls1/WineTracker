
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
 * Clase LineaPedido:
 *
 */

namespace WinetrackerGen.Infraestructure.Repository.Winetracker
{
public partial class LineaPedidoRepository : BasicRepository, ILineaPedidoRepository
{
public LineaPedidoRepository() : base ()
{
}


public LineaPedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LineaPedidoEN ReadOIDDefault (int id
                                     )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Id);



                lineaPedidoNH.Cantidad = lineaPedido.Cantidad;


                lineaPedidoNH.Importe = lineaPedido.Importe;

                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaPedidoEN lineaPedido)
{
        LineaPedidoNH lineaPedidoNH = new LineaPedidoNH (lineaPedido);

        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Pedido_tiene != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Pedido_tiene = (WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.PedidoEN), lineaPedido.Pedido_tiene.Id);

                        lineaPedidoNH.Pedido_tiene.LineaPedido_pertenece
                        .Add (lineaPedidoNH);
                }
                if (lineaPedido.Articulo_pertenece != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Articulo_pertenece = (WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN), lineaPedido.Articulo_pertenece.Id);

                        lineaPedidoNH.Articulo_pertenece.LineaPedido_articulo
                        .Add (lineaPedidoNH);
                }

                session.Save (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoNH.Id;
}

public void Modify (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Id);

                lineaPedidoNH.Cantidad = lineaPedido.Cantidad;


                lineaPedidoNH.Importe = lineaPedido.Importe;

                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
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
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), id);
                session.Delete (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
