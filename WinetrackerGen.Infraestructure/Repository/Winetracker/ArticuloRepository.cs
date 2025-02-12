
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
 * Clase Articulo:
 *
 */

namespace WinetrackerGen.Infraestructure.Repository.Winetracker
{
public partial class ArticuloRepository : BasicRepository, IArticuloRepository
{
public ArticuloRepository() : base ()
{
}


public ArticuloRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ArticuloEN ReadOIDDefault (int id
                                  )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ArticuloNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                        else
                                result = session.CreateCriteria (typeof(ArticuloNH)).List<ArticuloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articulo.Id);

                articuloNH.Nombre = articulo.Nombre;


                articuloNH.Descripcion = articulo.Descripcion;


                articuloNH.Tipo_vino = articulo.Tipo_vino;


                articuloNH.Tipo_uva = articulo.Tipo_uva;


                articuloNH.Region = articulo.Region;


                articuloNH.Precio = articulo.Precio;


                articuloNH.Maridaje = articulo.Maridaje;






                session.Update (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ArticuloEN articulo)
{
        ArticuloNH articuloNH = new ArticuloNH (articulo);

        try
        {
                SessionInitializeTransaction ();
                if (articulo.Vendedor_publica != null) {
                        // Argumento OID y no colección.
                        articuloNH
                        .Vendedor_publica = (WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN), articulo.Vendedor_publica.Id);

                        articuloNH.Vendedor_publica.Articulo_publicado
                        .Add (articuloNH);
                }

                session.Save (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloNH.Id;
}

public void Modify (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articulo.Id);

                articuloNH.Nombre = articulo.Nombre;


                articuloNH.Descripcion = articulo.Descripcion;


                articuloNH.Tipo_vino = articulo.Tipo_vino;


                articuloNH.Tipo_uva = articulo.Tipo_uva;


                articuloNH.Region = articulo.Region;


                articuloNH.Precio = articulo.Precio;


                articuloNH.Maridaje = articulo.Maridaje;

                session.Update (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
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
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), id);
                session.Delete (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ArticuloEN
public ArticuloEN ReadOID (int id
                           )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ArticuloNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                else
                        result = session.CreateCriteria (typeof(ArticuloNH)).List<ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
