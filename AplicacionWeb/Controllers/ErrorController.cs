using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult MostrarError()
        {
            return View();
        }
    }
}
