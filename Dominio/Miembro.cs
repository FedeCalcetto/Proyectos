using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Miembro : Usuario,IValidable,IComparable
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Miembro> amigos {get; set;}
        public List<Publicacion> publicaciones { get; set; }

        public const string ValorRol = "MIEMBRO";


        public Miembro()
        {
            // Constructor vacío
            this.Rol = Miembro.ValorRol;
        }

        public Miembro( string email, string contrasena,string rol ,string nombre, string apellido,bool bloqueado, DateTime fechaNacimiento) : base(email,contrasena,rol)
        {
            
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Bloqueado = bloqueado;
            this.FechaNacimiento = fechaNacimiento;
            this.amigos = new List<Miembro>();
            this.publicaciones = new List<Publicacion>();
            
        }

        public void ValidarMiembro()
        {
            if (this.Nombre == null || this.Apellido == null || this.Email == null || this.Contrasena==null)
            {
                throw new Exception("Los campos no pueden ser vacíos");
            }
        }
        
        public override string ToString()
        {
            return "El nombre del miembro es " + this.Nombre + " El apellido es " + this.Apellido + " Nació el " + this.FechaNacimiento;
        }
        public int CompareTo(object? obj)
        {
            Miembro m = (Miembro)obj;
            int CompararNombre = this.Nombre.CompareTo(m.Nombre);

      
            if (CompararNombre == 0)
            {
                return this.Apellido.CompareTo(m.Apellido);
            }

            return CompararNombre;
        }
    }
}
