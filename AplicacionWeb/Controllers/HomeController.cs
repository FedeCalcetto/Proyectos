using AplicacionWeb.Models;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailLogueado = HttpContext.Session.GetString("loginUsuario");
                if (emailLogueado != null)
                {
                    Usuario usuario = Sistema.ObtenerInstancia.ObtenerUsuarioPorEmail(emailLogueado);
                    //ViewBag.NombreUsuario = usuario.Nombre;
                }
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
            }
            return View();
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