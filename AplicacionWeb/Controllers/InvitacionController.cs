using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class InvitacionController : Controller
    {
        public IActionResult CambiarDeEstado(int IdInvitacion, string estado)
        {

            try
            {
                Sistema.ObtenerInstancia.CambiarEstadoInvitacion(IdInvitacion, estado);
                return RedirectToAction("Invitaciones", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("Invitaciones","Usuario");
            }
        }
        public IActionResult EnviarInvitaciones(string emailSolicitado)
        {
            string? emailLogueado = HttpContext.Session.GetString("loginUsuario");
            try
            {
                if (emailLogueado != null)
                {
                    Sistema.ObtenerInstancia.EnviarInvitacion(emailLogueado, emailSolicitado);

                }
                TempData["error"] = false;
                return RedirectToAction("IngresarInvitacion", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["error"] = true;
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("IngresarInvitacion", "Usuario");
            }

        }
    }
}
