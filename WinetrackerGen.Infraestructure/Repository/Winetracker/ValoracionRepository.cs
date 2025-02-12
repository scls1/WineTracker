
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
 * Clase Valoracion:
 *
 */

namespace WinetrackerGen.Infraestructure.Repository.Winetracker
{
public partial class ValoracionRepository : BasicRepository, IValoracionRepository
{
public ValoracionRepository() : base ()
{
}


public ValoracionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ValoracionEN ReadOIDDefault (int id
                                    )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionNH)).List<ValoracionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), valoracion.Id);

                valoracionNH.Valoracion = valoracion.Valoracion;



                session.Update (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionEN valoracion)
{
        ValoracionNH valoracionNH = new ValoracionNH (valoracion);

        try
        {
                SessionInitializeTransaction ();
                if (valoracion.Articulo_valorado != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Articulo_valorado = (WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN), valoracion.Articulo_valorado.Id);

                        valoracionNH.Articulo_valorado.Valoracion_articulo
                        .Add (valoracionNH);
                }
                if (valoracion.Usuario_valora != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Usuario_valora = (WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN), valoracion.Usuario_valora.Correo);

                        valoracionNH.Usuario_valora.Valoracion_usuario
                        .Add (valoracionNH);
                }

                session.Save (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionNH.Id;
}

public void Modify (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), valoracion.Id);

                valoracionNH.Valoracion = valoracion.Valoracion;

                session.Update (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
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
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), id);
                session.Delete (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ValoracionEN
public ValoracionEN ReadOID (int id
                             )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionNH)).List<ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
