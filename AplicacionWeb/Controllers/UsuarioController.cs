using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Ingresar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Inicio(Usuario u)
        {
           
            try
            {
                Usuario loginUsuario = Sistema.ObtenerInstancia.IniciarSesion(u.Email, u.Contrasena);
                HttpContext.Session.SetString("loginUsuario", loginUsuario.Email);
                HttpContext.Session.SetString("Rol",loginUsuario.Rol);
                
                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                //TempData["error"] = true;
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("Ingresar");
            }
        }
       
        public IActionResult MostrarInvitacion(int id)
        {
            try
            {
                Invitacion i = Sistema.ObtenerInstancia.ObtenerInvitacionPorId(id);
                return View(i);
            }
            catch (Exception ex)
            {
                //Mostrar excepcioón
                TempData["MensajeError"] = ex.Message;
                return View();
            }
        }
        
        public IActionResult IngresarInvitacion()
        {
            string? emailLogueado = HttpContext.Session.GetString("loginUsuario");
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Miembro.ValorRol))
            {
                
                List<Usuario> UsuariosOrdenados = Sistema.ObtenerInstancia.ListaMiembrosNoAmigos(emailLogueado);
                return View(UsuariosOrdenados);
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
            
        }

        

        public IActionResult FormularioPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearPost(Miembro m,Post p,IFormFile file)
        {
            string? emailLogueado = HttpContext.Session.GetString("loginUsuario");
            m = Sistema.ObtenerInstancia.EncontrarUsuarioEmail(emailLogueado);
            p.Autor = m;
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Miembro.ValorRol))
            {
                try
                {
                    if(file !=null && file.Length > 0)
                    {
                        string[] separarArchivo = file.FileName.Split(".");
                        string extension = separarArchivo[separarArchivo.Length - 1];
                        p.NombreImagen = p.IdPost + "." + extension;

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagenes", p.NombreImagen);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyTo(stream);
                    }
                    if (emailLogueado != null && m.Bloqueado==false) {
                        Sistema.ObtenerInstancia.AltaPost(p);
                        TempData["error"] = false;
                    }
                    // si agregamos el if para verificar el email nunca entraba al 
                    Sistema.ObtenerInstancia.AltaPost(p);
                    TempData["error"] = false;
                    return RedirectToAction("FormularioPost");
                }
                catch (Exception ex)
                {
                    TempData["error"] = true;
                    TempData["MensajeError"] = ex.Message;
                    return RedirectToAction("FormularioPost");
                }
            }
            else
            {
                TempData["MensajeError"] = "No está autorizado para acceder a esta página";
                return RedirectToAction("MostrarError", "Error");
            }

        }

        public IActionResult MostrarPublicaciones()
        {
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Miembro.ValorRol))
            {
                List<Post> ListaDePublicaciones = Sistema.ObtenerInstancia.ListarPublicaciones();
                return View(ListaDePublicaciones);
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
            
        }

        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Invitaciones()
        {
            string? rol = HttpContext.Session.GetString("Rol");
            if (rol != null && rol.Equals(Miembro.ValorRol))
            {
                List<Invitacion> InvitacionesPendientes = Sistema.ObtenerInstancia.ListarInvitaciones();
                return View(InvitacionesPendientes);
            }
            TempData["MensajeError"] = "No está autorizado para acceder a esta página";
            return RedirectToAction("MostrarError", "Error");
            
        }
    }
}
