using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.Infraestructure.Repository.Winetracker;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;


namespace WebApplication.Controllers
{
    [AuthGuard]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? tipoVino, int? tipoUva, int? maridaje, int? region)
        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);

            // Inicializar la lista de artículos
            IList<ArticuloEN> listaArt = articuloCEN.ReadAll(0, -1);

            // Filtrar artículos según los parámetros recibidos
            if (tipoVino.HasValue)
            {
                listaArt = listaArt.Where(a => a.Tipo_vino == (VinosEnum)tipoVino.Value).ToList();
            }
            if (tipoUva.HasValue)
            {
                listaArt = listaArt.Where(a => a.Tipo_uva == (UvasEnum)tipoUva.Value).ToList();
            }
            if (maridaje.HasValue)
            {
                listaArt = listaArt.Where(a => a.Maridaje == (MaridajeEnum)maridaje.Value).ToList();
            }
            if (region.HasValue)
            {
                listaArt = listaArt.Where(a => a.Region == (RegionEnum)region.Value).ToList();
            }

            ViewData["TipoVino"] = tipoVino;
            ViewData["TipoUva"] = tipoUva;
            ViewData["Maridaje"] = maridaje;
            ViewData["Region"] = region;


            // Obtener el nombre de usuario desde la sesión
            var userBytes = HttpContext.Session.Get("login");
            var user = System.Text.Encoding.UTF8.GetString(userBytes).Trim('"');
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);
            UsuarioEN usuarioen = usuarioCEN.ReadOID(user);
            ViewBag.User = usuarioen.Nombre;

            // Retornar la vista con los artículos filtrados
            return View(listaArt);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
