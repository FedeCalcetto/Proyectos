using Dominio;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ObligatorioP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////La instancia de Sistema
            //Sistema sistema = Sistema.ObtenerInstancia;

            

            

            
            //Console.WriteLine("Bienvenido a la red social");

            //bool Salir = false;
            //while (!Salir)
            //{
            //    Console.WriteLine("Ingrese una opcion");
            //    Console.WriteLine("1-Cree su usuario ");
            //    Console.WriteLine("2- Ver publicaciones de un miembro");
            //    Console.WriteLine("3- Ver los posts en el que un miembro hizo comentarios ");
            //    Console.WriteLine("4- Ver posts que fueron realizados entre 2 fechas");
            //    Console.WriteLine("5- Ver los miembros con más publiaciones");

            //    string opcion = Console.ReadLine();
            //    switch (opcion)
            //    {
            //        case "1":
            //            bool Salir3 = false;
            //            while (Salir3)
            //            {
            //                Console.Clear();
            //                Console.WriteLine("Ingrese su email");
            //                string emailMiembro = Console.ReadLine();
            //                Console.WriteLine("Ingrese la contrasena");
            //                string contrasena = Console.ReadLine();
            //                Console.WriteLine("Ingrese su nombre");
            //                string nombre = Console.ReadLine();
            //                Console.WriteLine("Ingrese el apellido");
            //                string apellido = Console.ReadLine();
            //                DateTime fecha = DateTime.Now;
            //                string fechaMiembro = Console.ReadLine();
            //                bool okFecha = DateTime.TryParse(fechaMiembro, out fecha);
            //                if (okFecha)
            //                {
            //                    Console.WriteLine("Fecha ingresada correctamente");
            //                    Salir3 = true;
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Error al ingresar la fecha, ingreelo nuevamente");
            //                }
            //                //Miembro m = new Miembro(emailMiembro, contrasena,rol, nombre, apellido, false, fecha);
            //                try
            //                {
            //                    //sistema.AltaMiembro(m);

            //                }
            //                catch(Exception ex)
            //                {
            //                    Console.WriteLine(ex.Message);
            //                }
            //            }
            //            break;
            //        case "2":
            //            Console.Clear();
            //            Console.WriteLine("Ingrese el email del miembro del cual quiere ver las publicaciones");
            //            string email = Console.ReadLine();
            //            List<Publicacion> publicaciones = sistema.ListadoPublicaciones(email);
            //            foreach(Publicacion publicacion in publicaciones)
            //            {
            //                //Console.WriteLine(publicacion.DarIdentificacion());
            //                Console.WriteLine("");
            //            }
            //            Console.ReadLine();
            //            break;
            //        case "3":
            //            Console.Clear();
            //            Console.WriteLine("Ingrese el email del miembro del cual quiere ver los posts en los que hizo comentarios");
            //            email = Console.ReadLine();
            //            List<Post> PostConComentario = sistema.ListarPostConComentario(email);
            //            foreach(Post publicacion in PostConComentario)
            //            {
            //                Console.WriteLine(publicacion);
            //                Console.WriteLine("");
            //            }
            //            Console.ReadLine();
            //            break;
            //        case "4":
            //            bool Salir2 = false;
            //            while (!Salir2)
            //            {
            //                Console.Clear();
            //                Console.WriteLine("Ingrese una fecha de inicio y una de fin para mostrar todos los post dentro de esas 2 fechas");
            //                DateTime fechaInicio = DateTime.Now;
            //                DateTime fechaFin = DateTime.Now;
            //                string fecha1 = Console.ReadLine();
            //                string fecha2 = Console.ReadLine();
            //                bool ok = DateTime.TryParse(fecha1, out fechaInicio);
            //                bool ok2 = DateTime.TryParse(fecha2, out fechaFin);

            //                if (ok && ok2)
            //                {
            //                   List<Post> publicaciones3= sistema.ListarPostsEntreFechas(fechaInicio, fechaFin);
            //                    foreach(Publicacion publicacion3 in publicaciones3)
            //                    {
            //                        Console.WriteLine(publicacion3);
            //                        Console.WriteLine("");
            //                    }
            //                    Console.ReadLine();
            //                    Salir2 = true;
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Error al ingresar las fechas");
            //                }
            //            }
                                           
            //            break;
            //        case "5":
            //            Console.Clear();
            //            Console.WriteLine("Ver el o los miembros con más publicaciones");
            //            List<Miembro> mayorCantPublicaciones = sistema.MiembrosConMasPublicaciones();
            //            foreach(Miembro miembro in mayorCantPublicaciones)
            //            {
            //                Console.WriteLine(miembro);
            //                Console.WriteLine();
            //            }
            //            Console.ReadLine();
            //            break;
            //        case "0":
            //            Salir = true;
            //            break;
            //        default:
            //            Console.WriteLine("Opcion incorrecta, vuela a seleccionar una opción");
            //            break;
        }
    }
            

}