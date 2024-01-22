using Dominio;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class PostController : Controller
    {
        public IActionResult FormularioComentario()
        {
            string? rol = HttpContext.Session.GetString("Rol");
            if(rol != null && rol.Equals(Miembro.ValorRol))
            {
                return View();
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
        }
        [HttpPost]
        public IActionResult HacerComentario(Miembro m, Comentario c)
        {
            string? emailLogueado = HttpContext.Session.GetString("loginUsuario");
            m = Sistema.ObtenerInstancia.EncontrarUsuarioEmail(emailLogueado);
            c.Autor = m;
            try
            {
                if (emailLogueado != null && m.Bloqueado==false)
                {
                    Sistema.ObtenerInstancia.AltaComentario(c);
                }
                
                TempData["error"] = false;
                return RedirectToAction("FormularioComentario");
            }
            catch (Exception ex)
            {
                TempData["error"] = true;
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("FormularioComentario");
            }
        }
    }
}
