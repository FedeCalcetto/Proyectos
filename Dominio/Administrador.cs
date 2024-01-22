using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador:Usuario
    {

        public const string Rol = "ADMIN";


        public Administrador(string email, string contrasena, string rol):base(email,contrasena,rol)
        {
            
        }
        public Administrador()
        {

        }
        public bool Bloqueado(Miembro m)
        {
            if (!m.Bloqueado)
            {
                m.Bloqueado = true;
                return m.Bloqueado; 
            }

            throw new Exception("El usuario ya está bloqueado.");
        }
        public bool BanearPost(Post p)
        {
            if (!p.Baneado)
            {
                p.Baneado = true;
                return p.Baneado;
            }
            throw new Exception("El post no existe.");
        }
    }

}
