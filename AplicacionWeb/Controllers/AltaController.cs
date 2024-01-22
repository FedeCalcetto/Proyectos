using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class AltaController : Controller
    {
        public IActionResult Formulario()
        {
            
            
                return View();
            
        }

        [HttpPost]
        public IActionResult DarDeAlta(Miembro m)
        {
                     
                try
                {
                    Sistema.ObtenerInstancia.AltaMiembro(m);
                    TempData["error"] = false;
                    return RedirectToAction("Formulario");
                }
                catch (Exception ex)
                {
                    TempData["error"] = true;
                    TempData["MensajeError"] = ex.Message;
                    return RedirectToAction("Formulario");
                }


        }
    }
}
