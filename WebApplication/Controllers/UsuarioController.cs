using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WebApplication.Models;
using WebApplication;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;
using WinetrackerGen.ApplicationCore.Utils;
using WinetrackerGen.Infraestructure.Repository.Winetracker;
using WebApplication.Helpers;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Linq;

namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            if (usuarioCEN.Login(login.Correo, login.Password) == null)
            {
                ModelState.AddModelError("", "Error al introducir uno de los campos");
                return View();
            }
            else
            {
                HttpContext.Session.Set("login", login.Correo);

                // Mensaje de éxito
                TempData["Success"] = "¡Sesión iniciada con éxito!";

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsuarioController/Register
        public ActionResult Register()
        {
            return View(new RegisterUsuarioViewModel());
        }

        // POST: UsuarioController/Register
        [HttpPost]
        public ActionResult Register(RegisterUsuarioViewModel register, IFormFile foto)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            // Gestionar la imagen
            string fotoPath = "default.png"; // Valor por defecto
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

            // Validar el modelo antes de continuar
            if (!ModelState.IsValid)
            {
                return View(register); // Volver a la vista con los errores de validación
            }

            // Crear el nuevo usuario
            var userId = usuarioCEN.New_(register.Nombre, register.Correo, register.Password, fotoPath, ProvinciasEnum.Alava);
            if (userId == null)
            {
                ModelState.AddModelError("", "Error al introducir uno de los campos");
                return View(register);
            }

            // Redirigir al inicio si el registro fue exitoso
            HttpContext.Session.Set("login", register.Correo);
            TempData["Success"] = "¡Registro exitoso!";
            return RedirectToAction("Index", "Home");
        }



        // GET: UsuarioController/Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET usuario/cesta
        public IActionResult Cesta()
        {
            // Simulación de datos para la cesta
            List<ArticuloViewModel> cesta = new List<ArticuloViewModel>();

            // Si la cesta está vacía, retorna una vista sin datos
            if (cesta == null || !cesta.Any())
            {
                return View(); // Retorna la vista vacía
            }

            return View(cesta); // Enviar el modelo si tiene datos
        }

        // GET: Usuario/Edit
        [HttpGet]
        public ActionResult Edit()
        {
            var userBytes = HttpContext.Session.Get("login");
            if (userBytes == null)
            {
                return RedirectToAction("Login");
            }

            var userId = Encoding.UTF8.GetString(userBytes).Trim('"');
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);


            PedidoRepository pedidoRepo = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);


            UsuarioEN usuarioEN = usuarioCEN.ReadOID(userId);

            var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            ViewBag.User = user;


            var pedidos = pedidoRepo.ObtenerPedidosPorUsuario(user);

            // Filtrar los pedidos excluyendo aquellos en estado "pendiente"
            var pedidosFiltrados = pedidos.Where(p => p.Estado_pedido != EstadoPedidoEnum.pendiente).ToList();

            // Obtiene la cantidad de pedidos filtrados
            int cantidadPedidos = pedidosFiltrados.Count;

            // Pasar la cantidad de pedidos a la vista
            ViewBag.CantidadPedidos = cantidadPedidos;

          
            if (usuarioEN == null)
            {
                return RedirectToAction("Login");
            }

            return View("Perfil", usuarioEN);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioEN model, IFormFile foto)
        {
            if (string.IsNullOrWhiteSpace(model.Nombre))
            {
                ModelState.AddModelError("", "El nombre no puede estar vacío.");
                return View("Perfil", model);
            }

            try
            {
                var userBytes = HttpContext.Session.Get("login");
                if (userBytes == null)
                {
                    return RedirectToAction("Login");
                }

                var userId = Encoding.UTF8.GetString(userBytes).Trim('"');
                UsuarioRepository usuarioRepo = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

                PedidoRepository pedidoRepo = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);


                UsuarioEN usuarioEN = usuarioCEN.ReadOID(userId);

                var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
                ViewBag.User = user;

                var pedidos = pedidoRepo.ObtenerPedidosPorUsuario(user);

                // Filtrar los pedidos excluyendo aquellos en estado "pendiente"
                var pedidosFiltrados = pedidos.Where(p => p.Estado_pedido != EstadoPedidoEnum.pendiente).ToList();

                // Obtiene la cantidad de pedidos filtrados
                int cantidadPedidos = pedidosFiltrados.Count;

                // Pasar la cantidad de pedidos a la vista
                ViewBag.CantidadPedidos = cantidadPedidos;


                if (usuarioEN == null)
                {
                    ModelState.AddModelError("", "El usuario no existe.");
                    return View("Perfil", model);
                }

                // Actualizar el nombre
                usuarioEN.Nombre = model.Nombre;

                // Verificar la contraseña
                if (string.IsNullOrWhiteSpace(model.Password))
                {
                    // Recuperar la contraseña almacenada en la sesión si está vacía
                    model.Password = HttpContext.Session.GetString("password");
                }
                else
                {
                    // Guardar la nueva contraseña en la sesión
                    HttpContext.Session.SetString("password", model.Password);
                    usuarioEN.Password = Utils.Util.GetEncondeMD5(model.Password);
                }

                // Agregar un log para mostrar la contraseña actual
                Console.WriteLine($"Contraseña antes de actualizar el usuario: {model.Password}");

                // Gestionar la imagen
                if (foto != null && foto.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", foto.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        foto.CopyTo(stream);
                    }

                    usuarioEN.Foto = foto.FileName;
                }

                // Guardar los cambios
                usuarioCEN.Modify(
                    userId,
                    usuarioEN.Nombre,
                    usuarioEN.Password, // Usar la contraseña final
                    usuarioEN.Foto,
                    usuarioEN.Provincia
                );
                Console.WriteLine($"Contraseña NUEVA: {usuarioEN.Password}");
                TempData["Success"] = "Perfil actualizado correctamente.";
                return RedirectToAction("Edit");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar el perfil: " + ex.Message);
                return View("Perfil", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarImagen()
        {
            try
            {
                var userBytes = HttpContext.Session.Get("login");
                if (userBytes == null)
                {
                    return RedirectToAction("Login");
                }

                var userId = Encoding.UTF8.GetString(userBytes).Trim('"');
                UsuarioRepository usuarioRepo = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

                UsuarioEN usuarioEN = usuarioCEN.ReadOID(userId);
                if (usuarioEN != null && !string.IsNullOrEmpty(usuarioEN.Foto))
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", usuarioEN.Foto);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    usuarioEN.Foto = "default.png";
                    usuarioCEN.Modify(userId, usuarioEN.Nombre, usuarioEN.Password, usuarioEN.Foto, usuarioEN.Provincia);
                }

                TempData["Success"] = "Imagen borrada correctamente.";
                return RedirectToAction("Edit");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al borrar la imagen: " + ex.Message);
                return RedirectToAction("Edit");
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Acción para ver la lista de pedidos
        public ActionResult MisPedidos()
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            PedidoRepository pedidoRepo = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

            var userBytes = HttpContext.Session.Get("login");
            var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            ViewBag.User = user;

            // Obtiene el usuario a través del correo
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(user);

            // Obtiene los pedidos del usuario
            var pedidos = pedidoRepo.ObtenerPedidosPorUsuario(user);

            // Filtrar los pedidos excluyendo aquellos en estado "pendiente"
            var pedidosFiltrados = pedidos.Where(p => p.Estado_pedido != EstadoPedidoEnum.pendiente).ToList();

            // Obtiene la cantidad de pedidos filtrados
            int cantidadPedidos = pedidosFiltrados.Count;

            // Pasar la cantidad de pedidos a la vista
            ViewBag.CantidadPedidos = cantidadPedidos;

            // Mapea los pedidos filtrados a un ViewModel
            var pedidosViewModel = pedidosFiltrados.Select(p => new PedidoViewModel
            {
                PedidoId = p.Id,
                Fecha = p.FechaPedido.HasValue ? p.FechaPedido.Value : DateTime.MinValue,
                Estado = p.Estado_pedido.ToString()
            }).ToList();

            return View(pedidosViewModel);
        }

        // Acción para ver los detalles de un pedido
        public ActionResult Detalle(int id)
        {

            PedidoRepository pedidoRepo = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);
            // Recupera el pedido por su ID
            var pedido = pedidoRepo.ReadOID(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Recupera las líneas del pedido asociadas
            var lineasPedido = pedidoRepo.ObtenerLineasPorPedido(id); // Asegúrate de tener un método que te recupere las líneas del pedido

            // Mapea los detalles del pedido a un ViewModel
            var detallePedidoViewModel = new PedidoViewModel
            {
                PedidoId = pedido.Id,
                Fecha = pedido.FechaPedido.HasValue ? pedido.FechaPedido.Value : DateTime.MinValue,
                Estado = pedido.Estado_pedido.ToString(),
                // Mapea las líneas del pedido a LineaPedidoViewModel
                LineasPedido = lineasPedido.Select(l => new LineaPedidoViewModel
                {
                    LineaPedidoId = l.Id,
                    NombreArticulo = l.Articulo_pertenece.Nombre, // Cambia según cómo obtienes el nombre del artículo
                    Cantidad = l.Cantidad,
                    Importe = l.Importe,
                    FotoArticulo = Url.Content("~/imagenes/" + l.Articulo_pertenece.Foto),
                    ImporteTotal = (decimal)l.Cantidad * (decimal)l.Importe
                }).ToList(),
                // Calcula el importe total
                ImporteTotal = lineasPedido.Sum(l => l.Cantidad * l.Importe)
            };

            return View(detallePedidoViewModel);
        }

        public ActionResult MisVentas()
        {

            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            PedidoRepository pedidoRepo = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

            var userBytes = HttpContext.Session.Get("login");
            var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            ViewBag.User = user;

            // Obtiene el usuario a través del correo
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(user); // Asegúrate de que tu repositorio tenga este método

            var pedidos = pedidoRepo.ObtenerPedidosPorUsuario(user);

            // Filtrar los pedidos excluyendo aquellos en estado "pendiente"
            var pedidosFiltrados = pedidos.Where(p => p.Estado_pedido != EstadoPedidoEnum.pendiente).ToList();

            // Obtiene la cantidad de pedidos filtrados
            int cantidadPedidos = pedidosFiltrados.Count;

            // Pasar la cantidad de pedidos a la vista
            ViewBag.CantidadPedidos = cantidadPedidos;

            // Mapea los pedidos a un ViewModel
            var ventasViewModel = pedidosFiltrados.Select(p => new VentaViewModel
            {
                VentaId = p.Id,
                Fecha = p.FechaPedido.HasValue ? p.FechaPedido.Value : DateTime.MinValue,
                Estado = p.Estado_pedido.ToString(),
                Usuario = p.Comprador?.Nombre ?? "Desconocido",

            }).ToList();

            return View(ventasViewModel);

        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancelar(int id)
        {
            try
            {
                PedidoRepository pedidoRepo = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

                // Obtener el pedido por su ID
                var pedido = pedidoRepo.ReadOID(id);
                if (pedido == null)
                {
                    // Si no se encuentra el pedido, redirige con un error
                    TempData["Error"] = "Pedido no encontrado.";
                    return RedirectToAction("MisPedidos");
                }

                // Verificar si el pedido ya ha sido cancelado
                if (pedido.Estado_pedido == EstadoPedidoEnum.cancelado)
                {
                    TempData["Error"] = "Este pedido ya ha sido cancelado.";
                    return RedirectToAction("MisPedidos");
                }

                // Cambiar el estado del pedido a "Cancelado"
                pedidoCEN.Modify(id, EstadoPedidoEnum.cancelado, pedido.FechaPedido);

                // Redirigir a la vista de "Mis Pedidos" con un mensaje de éxito
                TempData["Success"] = "Pedido cancelado correctamente.";
                return RedirectToAction("MisPedidos");
            }
            catch (Exception ex)
            {
                // En caso de error, muestra el mensaje
                TempData["Error"] = "Error al cancelar el pedido: " + ex.Message;
                return RedirectToAction("MisPedidos");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}