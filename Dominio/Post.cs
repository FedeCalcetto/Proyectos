using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Post : Publicacion,IComparable,IValidablePost
    {
        
        public string Titulo { get; set; }   
        public int IdPost { get; set; }
        public static int Contador { get; set; }
        public bool Baneado { get; set; }
        public string NombreImagen { get; set; }
        public List<Comentario> comentarios { get; set; }
        public List<Reaccion>reacciones { get; set; }
        

        public Post(string titulo,int idPost,string nombreImagen,string texto,DateTime fecha, Miembro autor, bool privado, int like, int disLikes):base(texto,fecha,autor,privado,like,disLikes)
        {
            
            this.Titulo = titulo;
            this.IdPost = idPost;
            this.Baneado = false;
            this.NombreImagen = nombreImagen;
            this.comentarios = new List<Comentario>();
            this.reacciones = new List<Reaccion>();

           
        }
        public Post()
        {
            this.Baneado = false;
        }
       
        private void ValidarTitulo()
        {
            if (this.Titulo == null || this.Titulo.Length < 3)
            {
                throw new Exception("El título del post no debe de ser vacío ni menor a 3 caracteres");
            }
        }
        private void ValidarContenido()
        {
            if (this.NombreImagen == null)
            {
                throw new Exception("El nombre del archivo no debe de ser vacío");
            } 
            
            
            if (!(this.NombreImagen.EndsWith(".png")|| this.NombreImagen.EndsWith(".jpg")))
            {
                throw new Exception("El formato de la imagen debe ser .jpg o .png");
            }
        }
        public void ValidarPost()
        {
            ValidarContenido();
            ValidarTitulo();

        }

        public override string DarIdentificacion()
        {
            return $" publicacion de tipo Post: titulo: {Titulo} ID: {IdPublicacion}, Texto: {base.Texto}, Fecha: {base.Fecha}, Autor: {base.Autor.Nombre} {base.Autor.Apellido}";
        }
        public override string ToString()
        {
            return $"ID: {IdPublicacion}, Texto: {base.Texto}, Fecha: {base.Fecha}, Autor: {base.Autor.Nombre} {base.Autor.Apellido}";
        }

        public int CompareTo(object? obj)
        {
            Post comparar = (Post)obj;
            return comparar.Titulo.CompareTo(this.Titulo);
        }

        public override double CalcularValorApreciacion()
        {
            double VA = this.Like * 5 + this.DisLikes * (-2);

            if (!this.Privado)
            {
                VA += 10;
            }

            return VA;
        }
       
    }
}
