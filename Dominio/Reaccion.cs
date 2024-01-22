using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reaccion
    {
        public string TipoReaccion { get; set; }
        public Miembro Autor { get; set; }

        public Reaccion(string tipoReaccion, Miembro autor)
        {
            this.TipoReaccion = tipoReaccion;
            this.Autor = autor;
        }
    }
}
