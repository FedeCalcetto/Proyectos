using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public List<Usuario> usuarios { get; set; }
        

        public Usuario(string email, string contrasena,string rol)
        {
            this.Email = email;
           this.Contrasena = contrasena;
            this.Rol = rol;
            this.usuarios = new List<Usuario>();
        }

        public Usuario()
        {

        }

    }
}
