using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Listas()
        {
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Administrador.Rol))
            {
                List<Usuario> UsuariosOrdenados = Sistema.ObtenerInstancia.ListarUsuarios();
                return View(UsuariosOrdenados);
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
            
        }

        
        public IActionResult Bloquear()
        {

            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Administrador.Rol))
            {
                return View();
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
            

            
        }
        [HttpPost]
        public IActionResult Bloqueado(Administrador a, string email,Miembro m)
        {
            try
            {
                Sistema.ObtenerInstancia.BloquearUsuario(a, email);
                TempData["error"] = false;
                return RedirectToAction("Bloquear");
            }
            catch (Exception ex)
            {
                TempData["error"] = true;
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("Bloquear");
            }
        }
        public IActionResult BanearElPost()
        {
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Administrador.Rol))
            {
                return View();
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
            
        }

        [HttpPost]
        public IActionResult PostBaneado(Administrador a, int id, Post p)
        {
            try
            {
                Sistema.ObtenerInstancia.BanearUnPost(a, id);
                TempData["error"] = false;
                return RedirectToAction("BanearElPost");
            }
            catch (Exception ex)
            {
                TempData["error"] = true;
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("BanearElPost");
            }
        }
    }

}
