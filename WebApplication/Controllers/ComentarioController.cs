using Microsoft.AspNetCore.Mvc;
using System;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
public class ComentarioController : Controller
{
    private readonly IComentarioRepository _comentarioRepository;

    public ComentarioController(IComentarioRepository comentarioRepository)
    {
        _comentarioRepository = comentarioRepository;
    }

    public IActionResult Agregar(string comentario, int articuloId, string usuarioCorreo)
    {
        try
        {
            var comentarioCEN = new ComentarioCEN(_comentarioRepository);
            comentarioCEN.New_(comentario, articuloId, usuarioCorreo);
            return RedirectToAction("Details", "Detalle", new { id = articuloId });
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            return View();
        }
    }
}
