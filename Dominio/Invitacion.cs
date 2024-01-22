using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Invitacion
    {

        public int IdInvitacion { get; set; }
        public Miembro Solicitante { get; set; }
        public Miembro Solicitado { get; set; }
        public string EstadoInvitacion { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public List<Invitacion> invitaciones { get; set; }

        public static int UltimoID { get; set; }

        public Invitacion(Miembro solicitante, Miembro solicitado, string estadoInvitacion, DateTime fechaSolicitud)
        {
            this.IdInvitacion = UltimoID++;
            this.Solicitante = solicitante;
            this.Solicitado = solicitado;
            this.EstadoInvitacion = estadoInvitacion;
            this.FechaSolicitud = fechaSolicitud;
            this.invitaciones = new List<Invitacion>();

            UltimoID++;
        }

        public Invitacion()
        {
            this.FechaSolicitud = DateTime.Now;
        }


        //public void Aceptar()
        //{
        //    if (Solicitante != null && Solicitado != null)
        //    {

        //    }
        //}
    }

}
