
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.Infraestructure.Repository.Winetracker;
using WinetrackerGen.Infraestructure.CP;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.Infraestructure.Repository;
using WinetrackerGen.Infraestructure.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                ArticuloRepository articulorepository = new ArticuloRepository ();
                ArticuloCEN articulocen = new ArticuloCEN (articulorepository);
                ComentarioRepository comentariorepository = new ComentarioRepository ();
                ComentarioCEN comentariocen = new ComentarioCEN (comentariorepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                MegustaRepository megustarepository = new MegustaRepository ();
                MegustaCEN megustacen = new MegustaCEN (megustarepository);
                LineaPedidoRepository lineapedidorepository = new LineaPedidoRepository ();
                LineaPedidoCEN lineapedidocen = new LineaPedidoCEN (lineapedidorepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
                string user1 = usuariocen.New_ ("user1", "user1@gmail.com", "1234", "default.png", ProvinciasEnum.Alava);
                string user2 = usuariocen.New_ ("user2", "user2@gmail.com", "1234", "default.png", ProvinciasEnum.Cadiz);





                Console.WriteLine ("\n\nUSUARIOS CREADOS CORRECTAMENTE\n\n");

                int art1 = articulocen.New_ (1, "Viñedos de la Serna", "", VinosEnum.Tinto, UvasEnum.Garganega, RegionEnum.Galicia, 15.5f, MaridajeEnum.cerdo, user1, 97, "foto2.jpg");
                int art2 = articulocen.New_ (2, "Bodega Montecalvo", "", VinosEnum.Blanco, UvasEnum.Merlot, RegionEnum.Piamonte, 15.5f, MaridajeEnum.cerdo, user2, 97, "foto1.jpg");
                int art3 = articulocen.New_ (3, "Gran Reserva Alaric", "", VinosEnum.Espumoso, UvasEnum.Garganega, RegionEnum.Piamonte, 15.5f, MaridajeEnum.cerdo, user2, 97, "foto3.jpg");
                int art4 = articulocen.New_ (4, "Cepa de Alba", "", VinosEnum.Fotificado, UvasEnum.Garganega, RegionEnum.Piamonte, 18.5f, MaridajeEnum.cerdo, user1, 97, "foto4.jpg");
                int art5 = articulocen.New_(5, "El Coto de Valderro", "", VinosEnum.Tinto, UvasEnum.Albarinyo, RegionEnum.Rioja, 14.0f, MaridajeEnum.cerdo, user1, 89, "foto5.jpg");
                int art6 = articulocen.New_(6, "Finca de los sueños", "", VinosEnum.Blanco, UvasEnum.Chardonnay, RegionEnum.Aragon, 12.5f, MaridajeEnum.cordero, user2, 85, "foto6.jpg");
                int art7 = articulocen.New_(7, "Hacienda Monteverde", "", VinosEnum.Rosado, UvasEnum.Merlot, RegionEnum.Alentejo, 13.0f, MaridajeEnum.pasta, user1, 90, "foto7.jpg");
                int art8 = articulocen.New_(8, "Cosecha de Oro", "", VinosEnum.Espumoso, UvasEnum.Chardonnay, RegionEnum.Piamonte, 15.0f, MaridajeEnum.pescado_azul, user2, 88, "foto8.jpg");
                int art9 = articulocen.New_(9, "Bodegas Castellano", "", VinosEnum.Fotificado, UvasEnum.Garganega, RegionEnum.Rioja, 19.0f, MaridajeEnum.ternera, user1, 92, "foto9.jpg");
                int art10 = articulocen.New_(10, "Viña de la Montaña", "", VinosEnum.Tinto, UvasEnum.Merlot, RegionEnum.Toscana, 14.5f, MaridajeEnum.pesacdo_blanco, user2, 87, "foto10.jpg");
                int art11 = articulocen.New_(11, "Reserva del Marqués", "", VinosEnum.Blanco, UvasEnum.Riesling, RegionEnum.Galicia, 11.5f, MaridajeEnum.ternera, user1, 84, "foto11.jpg");
                int art12 = articulocen.New_(12, "Viñedos del Sol", "", VinosEnum.Rosado, UvasEnum.Syrah, RegionEnum.Dao, 13.0f, MaridajeEnum.queso_cremoso, user2, 91, "foto12.jpg");
                int art13 = articulocen.New_(13, "Viña Real", "", VinosEnum.Espumoso, UvasEnum.Cabernet_Sauvignon, RegionEnum.Galicia, 14.5f, MaridajeEnum.queso_cremoso, user1, 95, "foto13.jpg");
                int art14 = articulocen.New_(14, "Castillo de la Luna", "", VinosEnum.Fotificado, UvasEnum.Pinot_girs, RegionEnum.Toscana, 20.0f, MaridajeEnum.ternera, user2, 93, "foto14.jpg");



                Console.WriteLine ("\n\nARTICULOS CREADOS CORRECTAMENTE\n\n");


                int comentario1 = comentariocen.New_ ("me gustan las peras", art1, user1);
                int comentario2 = comentariocen.New_ ("me gustan las manzanas", art1, user1);
                int comentario3 = comentariocen.New_ ("me gustan las bananas", art2, user1);
                int comentario4 = comentariocen.New_("Un vino perfecto para ocasiones especiales.", art3, user2);
                int comentario5 = comentariocen.New_("Me encantó su sabor único.", art4, user1);
                int comentario6 = comentariocen.New_("Muy buen equilibrio de sabores.", art5, user2);
                int comentario7 = comentariocen.New_("Lo recomiendo para una buena cena.", art6, user1);
                int comentario8 = comentariocen.New_("Excelente relación calidad-precio.", art7, user2);
                int comentario9 = comentariocen.New_("Un vino que sorprende por su frescura.", art8, user1);
                int comentario10 = comentariocen.New_("Ideal para acompañar platos de carne.", art9, user2);
                int comentario11 = comentariocen.New_("Un clásico que nunca falla.", art10, user1);
                int comentario12 = comentariocen.New_("Perfecto para los amantes del vino blanco.", art11, user2);
                int comentario13 = comentariocen.New_("Un toque frutal que lo hace especial.", art12, user1);
                int comentario14 = comentariocen.New_("Muy recomendable para eventos familiares.", art13, user2);
                int comentario15 = comentariocen.New_("Su aroma es espectacular.", art14, user1);

                Console.WriteLine ("\n\nCOMENTARIOS CREADOS CORRECTAMENTE\n\n");



                int pedido1 = pedidocen.New_ (user1, new DateTime (2024, 11, 12));
                int pedido2 = pedidocen.New_(user1, new DateTime(2024, 11, 12));
                int pedido3 = pedidocen.New_(user2, new DateTime(2024, 12, 12));

                Console.WriteLine ("\n\nPEDIDOS CREADOS CORRECTAMENTE\n\n");

                int linea1 = lineapedidocen.New_ (pedido1, art1, 2, 100f);
                int linea2 = lineapedidocen.New_(pedido1, art2, 1, 38.99f);
                int linea3 = lineapedidocen.New_(pedido1, art10, 3, 249.50f);

                int linea4 = lineapedidocen.New_(pedido2, art1, 1, 50f);
                int linea5 = lineapedidocen.New_(pedido2, art4, 1, 50f);

                Console.WriteLine ("\n\nLINEAS DE PEDIDO CREADAS CORRECTAMENTE\n\n");

                int valoracion1 = valoracioncen.New_ (5, art1, user1);

                int valoracion2 = valoracioncen.New_ (2, art1, user2);

                Console.WriteLine ("\n\nVALORACIONES CREADAS CORRECTAMENTE\n\n");

                ComentarioEN comentarioen1 = comentariocen.ReadOID (comentario1);
                ComentarioEN comentarioen2 = comentariocen.ReadOID (comentario2);
                ComentarioEN comentarioen3 = comentariocen.ReadOID (comentario3);

                Console.WriteLine ("\n\nLIKES DEL COMENTARIO 1: " + comentarioen1.NumLikes + "\n\n");
                comentariocen.AumentarLike (comentario1);
                Console.WriteLine ("\n\nLE DAMOS AL LIKE\n\n");
                comentarioen1 = comentariocen.ReadOID (comentario1);
                Console.WriteLine ("\n\nLIKES DEL COMENTARIO 1: " + comentarioen1.NumLikes + "\n\n");

                ArticuloEN articuloen1 = articulocen.ReadOID (art1);
                ArticuloEN articuloen2 = articulocen.ReadOID (art2);
                ArticuloEN articuloen3 = articulocen.ReadOID (art3);
                ArticuloEN articuloen4 = articulocen.ReadOID (art4);

                Console.WriteLine ("\n\nSTOCK DEL ARTICULO 1: " + articuloen1.Stock + "\n\n");
                articulocen.DecrementarStock (art1, 47);
                Console.WriteLine ("\n\nDECREMENTAMOS EL STOCK EN 47 UNIDADES\n\n");
                articuloen1 = articulocen.ReadOID (art1);
                Console.WriteLine ("\n\nSTOCK DEL ARTICULO 1: " + articuloen1.Stock + "\n\n");

                UsuarioEN usuarioen1 = usuariocen.ReadOID (user1);
                UsuarioEN usuarioen2 = usuariocen.ReadOID (user2);

                IList<ArticuloEN> lista = articulocen.DameArticuloPorUva (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum.Garganega);

                foreach (ArticuloEN item in lista) {
                        Console.WriteLine ("\n\n Filtrado por uva Garganega: " + item.Nombre + "\n\n");
                }

                IList<ArticuloEN> lista2 = articulocen.DameArticuloPorVino (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum.Tinto);

                foreach (ArticuloEN item in lista2) {
                        Console.WriteLine ("\n\n Todos los vinos tintos: " + item.Nombre + "\n\n");
                }

                IList<ArticuloEN> lista3 = articulocen.DameArticuloPorMaridaje (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum.cerdo);

                foreach (ArticuloEN item in lista3) {
                        Console.WriteLine ("\n\nFiltrado por Maridaje cerdo: " + item.Nombre + "\n\n");
                }

                IList<ArticuloEN> lista4 = articulocen.DameArticuloPorRegion (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum.Piamonte);

                foreach (ArticuloEN item in lista4) {
                        Console.WriteLine ("\n\nVinos de la region Piamonte: " + item.Nombre + "\n\n");
                }

                IList<ArticuloEN> lista5 = articulocen.DameArticuloPorUsuario (usuarioen1.Correo);

                foreach (ArticuloEN item in lista5) {
                        Console.WriteLine ("\n\n Articulos de usuario1: " + item.Nombre + "\n\n");
                }

                IList<ArticuloEN> lista6 = articulocen.DameArticuloPorPrecio (15.5f);

                foreach (ArticuloEN item in lista6) {
                        Console.WriteLine ("\n\nFILTRADO POR PRECIO: " + item.Nombre + "\n\n");
                }
                IList<ComentarioEN> lista7 = comentariocen.DameComentarioPorArticulo (art1);

                foreach (ComentarioEN item in lista7) {
                        Console.WriteLine ("\n\nCOMENTARIOS DEL ARTICULO 1: " + item.Comentario + "\n\n");
                }

                Console.WriteLine ("\n\nFILTROS FUNCIONANDO\n\n");


                PedidoCP pedidoCP = new PedidoCP (new SessionCPNHibernate ());

                pedidoCP.EnviarPedido (pedido1);
                articuloen1 = articulocen.ReadOID (art1);


                Console.WriteLine ("\n\n EL ARTICULO 1 TIENE UN STOCK DE: " + articuloen1.Stock);

                ValoracionCP valoracionCP = new ValoracionCP (new SessionCPNHibernate ());

                valoracionCP.ActualizarValoracion (valoracion1);
                valoracionCP.ActualizarValoracion (valoracion2);
                articuloen1 = articulocen.ReadOID (art1);
                Console.WriteLine ("\n\nEL NUMERO DE VALORACIONES DEL ARTICULO 1 ES: " + articuloen1.NumValoraciones);
                Console.WriteLine ("\n\nLA VALORACION TOTAL DEL ARTICULO 1 ES: " + articuloen1.ValoracionTotal);
                Console.WriteLine ("\n\nLA VALORACION MEDIA DEL ARTICULO 1 ES: " + articuloen1.ValoracionMedia);

                //usuarioen1 = usuariocen.ReadOID (user1);

                //Console.WriteLine ("\n\n" + usuarioen1.Correo + " " + usuarioen1.Password + "\n\n");

                if (usuariocen.Login ("user1@gmail.com", "1234") != null) {
                        Console.WriteLine ("\n\nEl Login es correcto\n\n");
                }
                else { Console.WriteLine ("\n\nEl Login es Incorrecto\n\n"); }

                Console.WriteLine ("\n\nBASE DE DATOS CREADA CORRECTAMENTE!");

                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
