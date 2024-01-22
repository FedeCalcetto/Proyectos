using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentario:Publicacion, IValidableComentario
    {
        
        public int IdComentario { get; set; }
        public List<Reaccion> reacciones { get; set; }

        public Comentario( int idComentario, string texto, DateTime fecha, Miembro autor,bool privado,int like, int disLikes) : base(texto,fecha,autor,privado,like, disLikes)
        {
           
            this.IdComentario=idComentario;
            this.reacciones = new List<Reaccion>();

        }
        public Comentario()
        {
            
        }
        public void ValidarComentario()
        {
            
           if (this.Texto == null || this.Texto.Length < 3)
           {
                    throw new Exception("El comentario no debe de ser vacío ni menor a 3 caracteres");
           }
        }
        public override string DarIdentificacion()
        {
            return $"Pulbiacion de tipo Comentario: ID: {IdComentario}, Texto: {base.Texto}, Fecha: {base.Fecha}, Autor: {base.Autor.Nombre} {base.Autor.Apellido}";
        }

        public override double CalcularValorApreciacion()
        {
            double VA = this.Like * 5 + this.DisLikes * (-2);
            return VA;
        }
    }
}
