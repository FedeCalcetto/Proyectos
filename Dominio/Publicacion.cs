using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion
    {
        public int IdPublicacion { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public Miembro Autor { get; set; }
        public bool Privado { get; set; }
        public int Like { get; set; }
        public int DisLikes { get; set; }
        public List<Publicacion> publicaciones { get; set; }
        public List<Comentario> comentarios { get; set; }
        public List<Reaccion> reacciones { get; set; }

        public static int UltimoID { get; set; }


        public Publicacion(string texto, DateTime fecha, Miembro autor,bool privado,int like, int disLikes)
        {
            this.IdPublicacion = UltimoID++;
            this.Texto = texto;
            this.Fecha = fecha;
            this.Autor = autor;
            this.Privado = privado;
            this.Like = like;
            this.DisLikes = disLikes;
            this.publicaciones = new List<Publicacion>();
            this.comentarios = new List<Comentario>();
            this.reacciones = new List<Reaccion>();
           
            UltimoID++;
        }
        
        public Publicacion()
        {
            this.Fecha = DateTime.Now;
        }
        public override bool Equals(object? obj)
        {
            Post p = (Post)obj;
            return this.Autor == p.Autor;
        }
        public abstract string DarIdentificacion();
        public override string ToString()
        {
            return "el id es: " + IdPublicacion + " el contenido es " + Texto + " la fecha es " + Fecha;
        }

        public abstract double CalcularValorApreciacion();
    }
}
