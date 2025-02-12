using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.Infraestructure.Repository.Winetracker;
using WebApplication.Models;
using System;

namespace WebApplication.Controllers
{
    public class DetalleController : Controller
    {
        // GET: DetalleController/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                // Obtener el artículo desde el repositorio
               /* ArticuloCEN articuloCEN = new ArticuloCEN();
                var articuloEN = articuloCEN.ReadOID(id);

                // Mapear los datos a ArticuloViewModel
                var model = new ArticuloViewModel
                {
                    Id = articuloEN.Id,
                    Nombre = articuloEN.Nombre,
                    Descripcion = articuloEN.Descripcion,
                    Precio = articuloEN.Precio,
                    Stock = articuloEN.Stock,
                    CalificacionPromedio = articuloEN.CalificacionPromedio,
                    Comentarios = articuloEN.Comentarios.Select(c => c.Comentario).ToList()
                };
               */
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }

}
