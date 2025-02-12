
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
 * Clase Comentario:
 *
 */

namespace WinetrackerGen.Infraestructure.Repository.Winetracker
{
public partial class ComentarioRepository : BasicRepository, IComentarioRepository
{
public ComentarioRepository() : base ()
{
}


public ComentarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComentarioEN ReadOIDDefault (int id
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioNH)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), comentario.Id);

                comentarioNH.NumLikes = comentario.NumLikes;


                comentarioNH.Comentario = comentario.Comentario;




                session.Update (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioEN comentario)
{
        ComentarioNH comentarioNH = new ComentarioNH (comentario);

        try
        {
                SessionInitializeTransaction ();
                if (comentario.Articulo_tiene != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Articulo_tiene = (WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN), comentario.Articulo_tiene.Id);

                        comentarioNH.Articulo_tiene.Comentario_pertenece
                        .Add (comentarioNH);
                }
                if (comentario.Usuario_comenta != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Usuario_comenta = (WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN), comentario.Usuario_comenta.Correo);

                        comentarioNH.Usuario_comenta.EsPuesto
                        .Add (comentarioNH);
                }

                session.Save (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioNH.Id;
}

public void Modify (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), comentario.Id);

                comentarioNH.NumLikes = comentario.NumLikes;


                comentarioNH.Comentario = comentario.Comentario;

                session.Update (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
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
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), id);
                session.Delete (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComentarioEN
public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioNH)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

        public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> DameComentarioPorArticulo(int? p_articulo)
        {
            System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> result = null;

            try
            {
                SessionInitializeTransaction();

                // Crear el criterio para obtener los comentarios relacionados con el artículo
                result = session.CreateCriteria(typeof(ComentarioNH))
                                .CreateAlias("Articulo_tiene", "articulo") // Relacionar Comentario con Articulo
                                .CreateAlias("Usuario_comenta", "usuario") // Relacionar Comentario con Usuario
                                .Add(Restrictions.Eq("articulo.Id", p_articulo)) // Filtrar por ID del artículo
                                .List<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is WinetrackerGen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else
                    throw new WinetrackerGen.ApplicationCore.Exceptions.DataLayerException("Error en ComentarioRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }

    }
}
