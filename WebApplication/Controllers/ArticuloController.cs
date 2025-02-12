using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.Infraestructure.Repository.Winetracker;

using WebApplication.Models;
using Winetracker.Assemblers;
using System.Linq;
using System;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.CP.Winetracker;
using WinetrackerGen.Infraestructure.CP;
using System.IO;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Controllers
{
    [AuthGuard]
    public class ArticuloController : Controller
    {
        // GET: ArticuloController
        public ActionResult Index()
        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
            IList<ArticuloEN> listaArt = articuloCEN.ReadAll(0, -1);

            ArticuloAssembler assembler = new ArticuloAssembler();
            IList<ArticuloViewModel> viewModelList = assembler.ConvertirListENToViewModel(listaArt);

            return View(viewModelList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.TipoVinoOptions = ArticuloAssembler.GetTipoVinoOptions();
            ViewBag.TipoUvaOptions = ArticuloAssembler.GetTipoUvaOptions();
            ViewBag.RegionOptions = ArticuloAssembler.GetRegionOptions();
            ViewBag.MaridajeOptions = ArticuloAssembler.GetMaridajeOptions();

            return View(new ArticuloViewModel());
        }

        [HttpPost]
        public IActionResult Create(ArticuloViewModel model, IFormFile foto)
        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

            var userBytes = HttpContext.Session.Get("login");
            var correoUser = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');

            // Manejar la imagen
            string fotoPath = "vino.png"; // Valor por defecto
            if (foto != null && foto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Guardar el archivo con su nombre original
                var filePath = Path.Combine(uploadsFolder, foto.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    foto.CopyTo(stream);
                }

                fotoPath = foto.FileName; // Asignar el nombre del archivo a la variable
            }

            if (ModelState.IsValid)
            {
                int ultimoId = ObtenerUltimoId();
                ViewBag.Id = ultimoId;

                // Crear el nuevo artículo y usar el nombre de la foto guardada
                var articulo = articuloCEN.New_(
                    ultimoId + 1,
                    model.Nombre,
                    model.Descripcion,
                    model.TipoVino,
                    model.TipoUva,
                    model.Region,
                    model.Precio,
                    model.Maridaje,
                    correoUser,
                    model.Stock,
                    fotoPath // Pasar solo el nombre del archivo
                );

                return RedirectToAction("Detalle", "Articulo", new { id = ultimoId + 1 });
            }
            ViewBag.TipoVinoOptions = ArticuloAssembler.GetTipoVinoOptions();
            ViewBag.TipoUvaOptions = ArticuloAssembler.GetTipoUvaOptions();
            ViewBag.RegionOptions = ArticuloAssembler.GetRegionOptions();
            ViewBag.MaridajeOptions = ArticuloAssembler.GetMaridajeOptions();
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.TipoVinoOptions = ArticuloAssembler.GetTipoVinoOptions();
            ViewBag.TipoUvaOptions = ArticuloAssembler.GetTipoUvaOptions();
            ViewBag.RegionOptions = ArticuloAssembler.GetRegionOptions();
            ViewBag.MaridajeOptions = ArticuloAssembler.GetMaridajeOptions();

            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

            // Obtener el artículo por ID
            var articuloEN = articuloCEN.ReadOID(id);
            if (articuloEN == null)
            {
                return NotFound(); // Si no se encuentra, devolver un error 404
            }

            // Convertir el ArticuloEN a ArticuloViewModel para pasarlo a la vista
            ArticuloAssembler assembler = new ArticuloAssembler();
            ArticuloViewModel articuloViewModel = assembler.ConvertirENToViewModel(articuloEN);

            return View(articuloViewModel); // Retornar la vista con el modelo cargado
        }

        [HttpPost]
        public IActionResult Edit(ArticuloViewModel model, IFormFile foto)
        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

            var userBytes = HttpContext.Session.Get("login");
            var correoUser = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            // Manejar la imagen
            ArticuloEN arten = articuloCEN.ReadOID(model.Id);

            string fotoPath  = arten.Foto;
            
            if (foto != null && foto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Guardar el archivo con su nombre original
                var filePath = Path.Combine(uploadsFolder, foto.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    foto.CopyTo(stream);
                }

                fotoPath = foto.FileName; // Asignar el nombre del archivo a la variable
            }
            if (ModelState.IsValid)
            {
                // Modificar el artículo
                articuloCEN.Modify(
                    model.Id,
                    model.Nombre,
                    model.Descripcion,
                    model.TipoVino,
                    model.TipoUva,
                    model.Region,
                    model.Precio,
                    model.Maridaje,
                    model.Stock,
                    model.ValoracionMedia,
                    model.NumValoraciones,
                    model.ValoracionTotal,
                    fotoPath
                );

                return RedirectToAction("Detalle", "Articulo", new { id = model.Id }); // Redirigir después de la modificación
            }
            ViewBag.TipoVinoOptions = ArticuloAssembler.GetTipoVinoOptions();
            ViewBag.TipoUvaOptions = ArticuloAssembler.GetTipoUvaOptions();
            ViewBag.RegionOptions = ArticuloAssembler.GetRegionOptions();
            ViewBag.MaridajeOptions = ArticuloAssembler.GetMaridajeOptions();
            return View(model); // Si el modelo no es válido, regresar a la vista con errores
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound(); // Devuelve un error si el ID no es válido
            }

            try
            {
                ArticuloRepository articuloRepo = new ArticuloRepository();
                ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

                // Llamada al método para eliminar el artículo
                articuloCEN.Destroy(id);

                return RedirectToAction("MisVinos"); // Redirige a la lista de artículos del usuario
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrarlo o mostrar un mensaje al usuario)
                ModelState.AddModelError("", $"Ocurrió un error al eliminar el artículo: {ex.Message}");
                return RedirectToAction("MisVinos"); // Redirige con un mensaje de error
            }
        }

        // GET: ArticuloController/Details/5
        public ActionResult Detalle(int id)
        {
            var userBytes = HttpContext.Session.Get("login");
            var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

            ValoracionRepository valoracionRepo = new ValoracionRepository();
            ValoracionCEN valCEN = new ValoracionCEN(valoracionRepo);

            var listaValoraciones = valCEN.ReadAll(0,-1);
            var valorado = listaValoraciones.FirstOrDefault(v => v.Usuario_valora.Correo == user && v.Articulo_valorado.Id == id);
            if(valorado != null)
            {
                ViewBag.Valorado = true;

            }
            else
            {
                ViewBag.Valorado = false;
            }
            ArticuloEN articulo = articuloCEN.ReadOID(id);


            if (articulo == null)
            {
                return NotFound(); // Devuelve un error 404 si no existe
            }

            ArticuloAssembler assembler = new ArticuloAssembler();
            ArticuloViewModel articuloViewModel = assembler.ConvertirENToViewModel(articulo);

            // Obtener comentarios asociados al artículo
            ComentarioRepository comentarioRepo = new ComentarioRepository();
            ComentarioCEN comentarioCEN = new ComentarioCEN(comentarioRepo);
            IList<ComentarioEN> comentariosEN = comentarioCEN.DameComentarioPorArticulo(id);

            // Convertir los comentarios y sus likes
            articuloViewModel.Comentarios = new List<ComentarioViewModel>();
            articuloViewModel.ComentariosLikes = new List<int>();
            if (comentariosEN != null)
            {
                foreach (var comentario in comentariosEN)
                {
                    var comentarioViewModel = new ComentarioViewModel
                    {
                        Texto = comentario.Comentario,      // Texto del comentario
                        NumLikes = comentario.NumLikes,    // Número de likes
                        NombreUsuario = comentario.Usuario_comenta.Nombre,
                        Foto = comentario.Usuario_comenta.Foto,// Nombre del usuario (ajusta esto según tu modelo)
                    };

                    articuloViewModel.Comentarios.Add(comentarioViewModel);
                    articuloViewModel.ComentariosLikes.Add(comentario.NumLikes);
                }
            }

            return View("DetalleVino", articuloViewModel);
        }


        [HttpPost]
        public IActionResult AddComment(int ArticuloId, string TextoComentario)
        {
            try
            {
                // Validar que el comentario no esté vacío
                if (string.IsNullOrEmpty(TextoComentario))
                {
                    TempData["Error"] = "El comentario no puede estar vacío.";
                    return RedirectToAction("Detalle", new { id = ArticuloId });
                }

                // Validar que el ID del artículo sea válido
                if (ArticuloId <= 0)
                {
                    TempData["Error"] = "El ID del artículo no es válido.";
                    return RedirectToAction("Detalle", new { id = ArticuloId });
                }

                // Obtener el usuario autenticado desde la sesión
                var userBytes = HttpContext.Session.Get("login");
                if (userBytes == null || userBytes.Length == 0)
                {
                    TempData["Error"] = "El usuario no está autenticado.";
                    return RedirectToAction("Detalle", new { id = ArticuloId });
                }

                var correoUser = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');

                // Verificar si el artículo existe en la base de datos
                ArticuloRepository articuloRepo = new ArticuloRepository();
                ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
                ArticuloEN articulo = articuloCEN.ReadOID(ArticuloId);

                if (articulo == null)
                {
                    TempData["Error"] = "El artículo especificado no existe.";
                    return RedirectToAction("Detalle", new { id = ArticuloId });
                }

                // Crear el comentario
                ComentarioRepository comentarioRepo = new ComentarioRepository();
                ComentarioCEN comentarioCEN = new ComentarioCEN(comentarioRepo);
                comentarioCEN.New_(TextoComentario, ArticuloId, correoUser);

                // Mensaje de éxito

                TempData["Comentario"] = "¡Tu comentario ha sido añadido correctamente!";
            }
            catch (DataLayerException ex)
            {
                // Manejar errores relacionados con la base de datos
                TempData["Error"] = "Error al añadir el comentario: " + ex.Message;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error genérico
                TempData["Error"] = "Ocurrió un error inesperado: " + ex.Message;
            }

            // Redirigir a la página de detalle del artículo
            return RedirectToAction("Detalle", new { id = ArticuloId });
        }

        [HttpPost]
        public IActionResult AddValoracion(int ArticuloId, int Valoracion)
        {
            try
            {
                // Validar que la valoración esté dentro del rango de 1 a 5
                if (Valoracion < 1 || Valoracion > 5)
                {
                    TempData["Error"] = "La valoración debe ser un número entre 1 y 5.";
                    return RedirectToAction("Detalle", new { id = ArticuloId });
                }
                
                // Obtener el usuario autenticado desde la sesión
                var userBytes = HttpContext.Session.Get("login");
                var correoUser = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');

                // Verificar si el artículo existe
                ArticuloRepository articuloRepo = new ArticuloRepository();
                ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
                ArticuloEN articulo = articuloCEN.ReadOID(ArticuloId);

                if (articulo == null)
                {
                    TempData["Error"] = "El artículo especificado no existe.";
                    return RedirectToAction("Detalle", new { id = ArticuloId });
                }

                // Crear la valoración para el artículo
                ValoracionRepository valoracionRepo = new ValoracionRepository();
                ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);
                int valoracionId = valoracionCEN.New_(Valoracion, ArticuloId, correoUser);

                // Actualizar la valoración global del artículo
                ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                valoracionCP.ActualizarValoracion(valoracionId);

                // Mensaje de éxito
                TempData["Valoracion"] = "¡Gracias por valorar este artículo!";
            }
            catch (DataLayerException ex)
            {
                TempData["Error"] = "Error al añadir la valoración: " + ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error inesperado: " + ex.Message;
            }

            // Redirigir a la página de detalle del artículo
            return RedirectToAction("Detalle", new { id = ArticuloId });
        }

        public IActionResult MisVinos()
        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
            // Recuperar el correo del usuario de la sesión
            var userBytes = HttpContext.Session.Get("login");
            var correoUser = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');

            // Obtener todos los artículos
            IList<ArticuloEN> listaArt = articuloCEN.ReadAll(0, -1);
            PedidoRepository pedidoRepo = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

            // Obtener todos los artículos

            var pedidos = pedidoRepo.ObtenerPedidosPorUsuario(correoUser);

            // Filtrar los pedidos excluyendo aquellos en estado "pendiente"
            var pedidosFiltrados = pedidos.Where(p => p.Estado_pedido != EstadoPedidoEnum.pendiente).ToList();

            // Obtiene la cantidad de pedidos filtrados
            int cantidadPedidos = pedidosFiltrados.Count;

            // Pasar la cantidad de pedidos a la vista
            ViewBag.CantidadPedidos = cantidadPedidos;
            // Filtrar los artículos por el correo del usuario
            var misVinos = listaArt.Where(a => a.Vendedor_publica.Correo == correoUser).ToList();

            // Convertirlos a ViewModel
            ArticuloAssembler assembler = new ArticuloAssembler();
            var misVinosViewModel = misVinos.Select(en => assembler.ConvertirENToViewModel(en)).ToList();


            return View(misVinosViewModel);
        }


        [HttpPost]
        public IActionResult AddToCart(int idArticulo, int Cantidad)
        {
            try
            {
                // Validar que la cantidad sea mayor a 0
                if (Cantidad <= 0)
                {
                    TempData["Error"] = "La cantidad debe ser mayor que 0.";
                    return RedirectToAction("Detalle", new { id = idArticulo });
                }

                // Verificar si el artículo existe
                ArticuloRepository articuloRepo = new ArticuloRepository();
                ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
                ArticuloEN articulo = articuloCEN.ReadOID(idArticulo);

                if (articulo == null)
                {
                    TempData["Error"] = "El artículo especificado no existe.";
                    return RedirectToAction("Detalle", new { id = idArticulo });
                }

                // Validar que haya suficiente stock
                if (articulo.Stock < Cantidad)
                {
                    TempData["Error"] = "No hay suficiente stock disponible.";
                    return RedirectToAction("Detalle", new { id = idArticulo });
                }

                // Obtener el usuario autenticado desde la sesión
                var userBytes = HttpContext.Session.Get("login");
                var correoUser = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');

                // Recuperar el ID del pedido desde la sesión (si existe)
                int? pedidoId = HttpContext.Session.GetInt32("pedidoId");

                if (pedidoId == null) // Si no hay un pedido existente, crea uno nuevo
                {
                    PedidoRepository pedidoRepo = new PedidoRepository();
                    PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);
                    pedidoId = pedidoCEN.New_(correoUser, DateTime.Now);

                    // Guardar el ID del pedido en la sesión
                    HttpContext.Session.SetInt32("pedidoId", pedidoId.Value);
                }

                // Crear la línea de pedido con el artículo
                LineaPedidoRepository lineaPedidoRepo = new LineaPedidoRepository();
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(lineaPedidoRepo);
                lineaPedidoCEN.New_(pedidoId.Value, idArticulo, Cantidad, articulo.Precio * Cantidad);

                // Decrementar el stock del artículo
                articuloCEN.DecrementarStock(idArticulo, Cantidad);

                TempData["Message"] = $"¡{Cantidad} unidad(es) añadidas correctamente al carrito!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al añadir el artículo al carrito: " + ex.Message;
            }

            return RedirectToAction("Detalle", new { id = idArticulo });
        }

        [HttpGet]
        public JsonResult SearchAjax(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new List<object>()); // Devuelve una lista vacía si no hay query
            }

            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

            var listaArticulos = articuloCEN.ReadAll(0, -1)
                                            .Where(a => a.Nombre.Contains(query, StringComparison.OrdinalIgnoreCase))
                                            .ToList();

            var resultados = listaArticulos.Select(a => new
            {
                id = a.Id,
                nombre = a.Nombre,
                descripcion = a.Descripcion,
                precio = a.Precio,
                imagen = Url.Content("~/imagenes/" + a.Foto), // Genera la URL completa
                region = a.Region.ToString() // Si a.Region es un Enum

            });

            return Json(resultados);
        }

        public int ObtenerUltimoId()
        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
            // Obtener todos los artículos
            IList<ArticuloEN> listaArt = articuloCEN.ReadAll(0, -1);

            // Verificar si la lista está vacía
            if (listaArt == null || listaArt.Count == 0)
            {
                return 0; // Retorna 0 si no hay artículos
            }

            // Encontrar el artículo con el ID más alto
            return listaArt.Max(a => a.Id);
        }

    }

}