
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
 * Clase Megusta:
 *
 */

namespace WinetrackerGen.Infraestructure.Repository.Winetracker
{
public partial class MegustaRepository : BasicRepository, IMegustaRepository
{
public MegustaRepository() : base ()
{
}


public MegustaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MegustaEN ReadOIDDefault (int id
                                 )
{
        MegustaEN megustaEN = null;

        try
        {
                SessionInitializeTransaction ();
                megustaEN = (MegustaEN)session.Get (typeof(MegustaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return megustaEN;
}

public System.Collections.Generic.IList<MegustaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MegustaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MegustaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MegustaEN>();
                        else
                                result = session.CreateCriteria (typeof(MegustaNH)).List<MegustaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in MegustaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MegustaEN megusta)
{
        try
        {
                SessionInitializeTransaction ();
                MegustaNH megustaNH = (MegustaNH)session.Load (typeof(MegustaNH), megusta.Id);


                session.Update (megustaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in MegustaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MegustaEN megusta)
{
        MegustaNH megustaNH = new MegustaNH (megusta);

        try
        {
                SessionInitializeTransaction ();
                if (megusta.Usuario_pone != null) {
                        // Argumento OID y no colección.
                        megustaNH
                        .Usuario_pone = (WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN), megusta.Usuario_pone.Id);

                        megustaNH.Usuario_pone.Megusta_0
                        .Add (megustaNH);
                }
                if (megusta.Comentario_tiene != null) {
                        // Argumento OID y no colección.
                        megustaNH
                        .Comentario_tiene = (WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN), megusta.Comentario_tiene.Id);

                        megustaNH.Comentario_tiene.Megusta_1
                        .Add (megustaNH);
                }

                session.Save (megustaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in MegustaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return megustaNH.Id;
}

public void Modify (MegustaEN megusta)
{
        try
        {
                SessionInitializeTransaction ();
                MegustaNH megustaNH = (MegustaNH)session.Load (typeof(MegustaNH), megusta.Id);
                session.Update (megustaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in MegustaRepository.", ex);
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
                MegustaNH megustaNH = (MegustaNH)session.Load (typeof(MegustaNH), id);
                session.Delete (megustaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in MegustaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
