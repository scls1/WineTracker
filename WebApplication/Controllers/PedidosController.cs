using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

namespace WebApplication.Controllers
{
    public class PedidosController : Controller
    {
        private readonly UsuarioRepository _usuarioRepo;
        private readonly PedidoRepository _pedidoRepo;

        public PedidosController(UsuarioRepository usuarioRepo, PedidoRepository pedidoRepo)
        {
            _usuarioRepo = usuarioRepo;
            _pedidoRepo = pedidoRepo;
        }

        // Acción para ver la lista de pedidos
        public ActionResult MisPedidos()
        {
            // Recupera el correo (token del usuario) de la sesión
            var userBytes = HttpContext.Session.Get("login");
            var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            ViewBag.User = user;

            // Obtiene el usuario a través del correo
            UsuarioEN usuarioEN = _usuarioRepo.ReadOID(user); // Asegúrate de que tu repositorio tenga este método

            // Obtiene los pedidos del usuario
            var pedidos = _pedidoRepo.ObtenerPedidosPorUsuario(user);

            // Mapea los pedidos a un ViewModel
            var pedidosViewModel = pedidos.Select(p => new PedidoViewModel
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
            // Recupera el pedido por su ID
            var pedido = _pedidoRepo.ReadOID(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Recupera las líneas del pedido asociadas
            var lineasPedido = _pedidoRepo.ObtenerLineasPorPedido(id); // Asegúrate de tener un método que te recupere las líneas del pedido

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
                    Importe = l.Importe
                }).ToList(),
                // Calcula el importe total
                ImporteTotal = lineasPedido.Sum(l => l.Importe)
            };

            return View(detallePedidoViewModel);
        }

        public ActionResult Cesta()
        {
            // Recuperar el ID del pedido desde la sesión
            int? pedidoId = HttpContext.Session.GetInt32("pedidoId");

            if (pedidoId == null)
            {
                // Si no hay un pedido en la sesión, devolver un modelo vacío
                var emptyCesta = new PedidoViewModel
                {
                    PedidoId = 0,
                    LineasPedido = new List<LineaPedidoViewModel>(), // Lista vacía
                    ImporteTotal = 0
                };
                return View(emptyCesta); // Devuelve la vista con un modelo vacío
            }

            // Recuperar el pedido por su ID
            var pedido = _pedidoRepo.ReadOID(pedidoId.Value);
            if (pedido == null)
            {
                // Si el pedido no existe, devolver un modelo vacío
                var emptyCesta = new PedidoViewModel
                {
                    PedidoId = 0,
                    LineasPedido = new List<LineaPedidoViewModel>(), // Lista vacía
                    ImporteTotal = 0
                };
                return View(emptyCesta); // Devuelve la vista con un modelo vacío
            }

            // Recuperar las líneas del pedido
            var lineasPedido = _pedidoRepo.ObtenerLineasPorPedido(pedidoId.Value);

            if (lineasPedido == null || !lineasPedido.Any())
            {
                // Si no hay líneas en el pedido, devolver un modelo vacío
                var emptyCesta = new PedidoViewModel
                {
                    PedidoId = pedido.Id,
                    LineasPedido = new List<LineaPedidoViewModel>(), // Lista vacía
                    ImporteTotal = 0
                };
                return View(emptyCesta); // Devuelve la vista con un modelo vacío
            }

            // Mapea las líneas del pedido a un ViewModel
            var cestaViewModel = new PedidoViewModel
            {
                PedidoId = pedido.Id,
                Fecha = pedido.FechaPedido.HasValue ? pedido.FechaPedido.Value : DateTime.MinValue,
                Estado = pedido.Estado_pedido.ToString(),
                LineasPedido = lineasPedido.Select(l => new LineaPedidoViewModel
                {
                    LineaPedidoId = l.Id,
                    NombreArticulo = l.Articulo_pertenece.Nombre,
                    Cantidad = l.Cantidad,
                    Importe = l.Importe,
                    FotoArticulo = l.Articulo_pertenece.Foto // Asignar la foto del artículo
                }).ToList(),
                ImporteTotal = lineasPedido.Sum(l => l.Importe) // Calcula el importe total del pedido
            };

            // Devuelve la vista con los datos de la cesta
            return View(cestaViewModel);
        }

        [HttpPost]
        public IActionResult VaciarCesta()
        {
            // Recuperar el ID del pedido desde la sesión
            int? pedidoId = HttpContext.Session.GetInt32("pedidoId");

            if (pedidoId == null)
            {
                TempData["Error"] = "El carrito ya está vacío o la sesión ha expirado.";

                // Devuelve un modelo vacío si no hay pedido
                var emptyCesta = new PedidoViewModel
                {
                    PedidoId = 0,
                    LineasPedido = new List<LineaPedidoViewModel>(),
                    ImporteTotal = 0
                };
                return View("Cesta", emptyCesta);
            }

            try
            {
                // Llamar al método para eliminar el pedido y sus líneas
                _pedidoRepo.EliminarPedidoConLineas(pedidoId.Value);

                // Limpiar el pedido de la sesión
                HttpContext.Session.Remove("pedidoId");

                TempData["Message"] = "La cesta se ha vaciado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al vaciar la cesta: " + ex.Message;
            }

            // Devuelve la vista de la cesta con un modelo vacío
            var emptyCestaViewModel = new PedidoViewModel
            {
                PedidoId = 0,
                LineasPedido = new List<LineaPedidoViewModel>(),
                ImporteTotal = 0
            };
            return View("Cesta", emptyCestaViewModel);
        }

        [HttpPost]
        public IActionResult ConfirmarCompra()
        {
            // Recuperar el ID del pedido desde la sesión
            int? pedidoId = HttpContext.Session.GetInt32("pedidoId");

            if (pedidoId == null)
            {
                TempData["Error"] = "No hay un pedido activo para confirmar.";
                return RedirectToAction("Cesta"); // Redirige a la cesta
            }

            try
            {
                // Recuperar el pedido
                var pedido = _pedidoRepo.ReadOID(pedidoId.Value);
                if (pedido == null)
                {
                    TempData["Error"] = "El pedido no existe.";
                    return RedirectToAction("Cesta");
                }

                // Recuperar las líneas del pedido
                var lineasPedido = _pedidoRepo.ObtenerLineasPorPedido(pedidoId.Value);
                if (lineasPedido == null || !lineasPedido.Any())
                {
                    TempData["Error"] = "El pedido no contiene líneas.";
                    return RedirectToAction("Cesta");
                }

                // Cambiar el estado del pedido a "Enviado"
                pedido.Estado_pedido = EstadoPedidoEnum.enviado;
                _pedidoRepo.Modify(pedido); // Actualiza el pedido en la base de datos

                // Guardar el ID del pedido en TempData para mostrar el modal
                TempData["PedidoIdConfirmado"] = pedido.Id;
                TempData["Message"] = "¡Compra confirmada! Gracias por tu pedido.";

                // Eliminar el pedido de la sesión
                HttpContext.Session.Remove("pedidoId");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al confirmar la compra: " + ex.Message;
            }

            return RedirectToAction("Cesta"); // Redirige a la cesta
        }

    }
}
