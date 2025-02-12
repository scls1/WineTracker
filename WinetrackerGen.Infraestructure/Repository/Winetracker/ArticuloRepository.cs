
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







                articuloNH.Stock = articulo.Stock;


                articuloNH.ValoracionMedia = articulo.ValoracionMedia;


                articuloNH.NumValoraciones = articulo.NumValoraciones;


                articuloNH.ValoracionTotal = articulo.ValoracionTotal;


                articuloNH.Foto = articulo.Foto;

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
                        .Vendedor_publica = (WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN)session.Load (typeof(WinetrackerGen.ApplicationCore.EN.Winetracker.UsuarioEN), articulo.Vendedor_publica.Correo);

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


                articuloNH.Stock = articulo.Stock;


                articuloNH.ValoracionMedia = articulo.ValoracionMedia;


                articuloNH.NumValoraciones = articulo.NumValoraciones;


                articuloNH.ValoracionTotal = articulo.ValoracionTotal;


                articuloNH.Foto = articulo.Foto;

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

public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorVino (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum ? p_tipoVino)
{
        System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH AS art WHERE art.Tipo_vino = :p_tipoVino";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticuloPorVinoHQL");
                query.SetParameter ("p_tipoVino", p_tipoVino);

                result = query.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
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
public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorUva (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum ? p_tipoUva)
{
        System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH AS art WHERE art.Tipo_uva = :p_tipoUva";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticuloPorUvaHQL");
                query.SetParameter ("p_tipoUva", p_tipoUva);

                result = query.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
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
public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorMaridaje (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum ? p_maridaje)
{
        System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH AS art WHERE art.Maridaje = :p_maridaje";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticuloPorMaridajeHQL");
                query.SetParameter ("p_maridaje", p_maridaje);

                result = query.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
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
public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorRegion (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum ? p_region)
{
        System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH AS art WHERE art.Region = :p_region";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticuloPorRegionHQL");
                query.SetParameter ("p_region", p_region);

                result = query.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
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
public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorPrecio (float ? p_presupuesto)
{
        System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH AS art WHERE art.Precio <= :p_presupuesto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticuloPorPrecioHQL");
                query.SetParameter ("p_presupuesto", p_presupuesto);

                result = query.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
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
public System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorUsuario (string p_usuario)
{
        System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where FROM ArticuloNH AS art WHERE art.Vendedor_publica.Correo = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticuloPorUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN>();
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
