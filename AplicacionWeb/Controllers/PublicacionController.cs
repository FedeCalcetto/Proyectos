using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class PublicacionController : Controller
    {
        public IActionResult IngresarVA(double valorIngresado,string texto)
        {
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Miembro.ValorRol))
            {
                List<Publicacion> ListarPublicaciones = Sistema.ObtenerInstancia.PublicacionesPopulares(valorIngresado,texto);
                return View(ListarPublicaciones);
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
        }
    }
}
