using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio
{

    public class Sistema
    {
        private List<Miembro> amigos;
        private List<Publicacion> publicaciones;
        private List<Invitacion> invitaciones;
        private List<Usuario> usuarios;
        private List<Comentario> comentarios;
        #region Singleton
        private static Sistema instancia;




        public static Sistema ObtenerInstancia
        {
            get
            {
                if (instancia == null) instancia = new Sistema();
                return instancia;
            }
        }
        private Sistema()
        {
            amigos = new List<Miembro>();
            publicaciones = new List<Publicacion>();
            invitaciones = new List<Invitacion>();
            usuarios = new List<Usuario>();
            comentarios = new List<Comentario>();
            cargaDeDatos();


        }

        private void cargaDeDatos()
        {

            //Precarga de administradores
            Administrador admin = new Administrador("Federico@gmail.com", "FedeCalce", "ADMIN");
            usuarios.Add(admin);

            //PreCarga de Miembros
            Miembro miembro = new Miembro("Lautaro@gmail.com", "LautaColman", "MIEMBRO", "Lautaro", "Colman", false, new DateTime(2003, 7, 22));
            Miembro miembro2 = new Miembro("Nicolas@gmail.com", "NicoNova", "MIEMBRO", "Nicolas", "Novasco", false, new DateTime(1999, 5, 15));
            Miembro miembro3 = new Miembro("Manu@gmail.com", "ManuRena", "MIEMBRO", "Manu", "Arena", false, new DateTime(2002, 7, 14));
            Miembro miembro4 = new Miembro("Rodri@gmail.com", "RodriBru", "MIEMBRO", "Rodrigo", "Brun", false, new DateTime(1997, 9, 14));
            Miembro miembro5 = new Miembro("Lucas@gmail.com", "LucaZor", "MIEMBRO", "Lucas", "Zorn", false, new DateTime(2002, 3, 22));
            Miembro miembro6 = new Miembro("Juani@gmail.com", "IlloJuan", "MIEMBRO", "Juan", "Rodriguez", false, new DateTime(1990, 10, 30));
            Miembro miembro7 = new Miembro("Maxi@gmail.com", "MaxiPer", "MIEMBRO", "Maximiliano", "Perez", false, new DateTime(2000, 12, 13));
            Miembro miembro8 = new Miembro("Reudi@gmail.com", "ReudiGer", "MIEMBRO", "Reudi", "Ruediger", false, new DateTime(1989, 1, 11));
            Miembro miembro9 = new Miembro("Menos@gmail.com", "Menostre", "MIEMBRO", "Menos", "Trece", false, new DateTime(1980, 4, 22));
            Miembro miembro10 = new Miembro("Fede@gmail.com", "Pajarito", "MIEMBRO", "Federico", "Valverde", false, new DateTime(1998, 7, 20));
            Miembro miembro11 = new Miembro("Benito@gmail.com", "Beni", "MIEMBRO", "Benito", "Perez", true, new DateTime(1996, 5, 25));
            usuarios.Add(miembro);
            usuarios.Add(miembro2);
            usuarios.Add(miembro3);
            usuarios.Add(miembro4);
            usuarios.Add(miembro5);
            usuarios.Add(miembro6);
            usuarios.Add(miembro7);
            usuarios.Add(miembro8);
            usuarios.Add(miembro9);
            usuarios.Add(miembro10);
            usuarios.Add(miembro11);

            //Lista de amigos del miembro 2 y miembro(1)
            miembro2.amigos.Add(miembro);
            miembro2.amigos.Add(miembro3);
            miembro2.amigos.Add(miembro4);
            miembro2.amigos.Add(miembro5);
            miembro2.amigos.Add(miembro6);
            miembro2.amigos.Add(miembro7);
            miembro2.amigos.Add(miembro8);
            miembro2.amigos.Add(miembro9);
            miembro2.amigos.Add(miembro10);

            miembro.amigos.Add(miembro2);
            miembro.amigos.Add(miembro3);
            miembro.amigos.Add(miembro4);
            miembro.amigos.Add(miembro5);
            miembro.amigos.Add(miembro6);
            miembro.amigos.Add(miembro7);
            miembro.amigos.Add(miembro8);
            miembro.amigos.Add(miembro9);
            miembro.amigos.Add(miembro10);

            //Invitaciones
            Invitacion invitacion = new Invitacion(miembro3, miembro4, "rechazada", DateTime.Now);
            Invitacion invitacion2 = new Invitacion(miembro5, miembro6, "PENDIENTE_APROBACION", DateTime.Now);
            Invitacion invitacion3 = new Invitacion(miembro7, miembro8, "rechazada", DateTime.Now);
            Invitacion invitacion4 = new Invitacion(miembro9, miembro10, "PENDIENTE_APROBACION", DateTime.Now);
            Invitacion invitacion5 = new Invitacion(miembro4, miembro9, "rechazada", DateTime.Now);
            Invitacion invitacion6 = new Invitacion(miembro6, miembro7, "PENDIENTE_APROBACION", DateTime.Now);
            Invitacion invitacion7 = new Invitacion(miembro8, miembro5, "rechazada", DateTime.Now);
            Invitacion invitacion8 = new Invitacion(miembro10, miembro3, "PENDIENTE_APROBACION", DateTime.Now);
            Invitacion invitacion9 = new Invitacion(miembro, miembro2, "aceptada", DateTime.Now);
            Invitacion invitacion10 = new Invitacion(miembro, miembro3, "aceptada", DateTime.Now);
            Invitacion invitacion11 = new Invitacion(miembro, miembro4, "aceptada", DateTime.Now);
            Invitacion invitacion12 = new Invitacion(miembro, miembro5, "aceptada", DateTime.Now);
            Invitacion invitacion13 = new Invitacion(miembro, miembro6, "aceptada", DateTime.Now);
            Invitacion invitacion14 = new Invitacion(miembro, miembro7, "aceptada", DateTime.Now);
            Invitacion invitacion15 = new Invitacion(miembro, miembro8, "aceptada", DateTime.Now);
            Invitacion invitacion16 = new Invitacion(miembro, miembro9, "aceptada", DateTime.Now);
            Invitacion invitacion17 = new Invitacion(miembro, miembro10, "aceptada", DateTime.Now);
            Invitacion invitacion18 = new Invitacion(miembro2, miembro3, "aceptada", DateTime.Now);
            Invitacion invitacion19 = new Invitacion(miembro2, miembro4, "aceptada", DateTime.Now);
            Invitacion invitacion20 = new Invitacion(miembro2, miembro5, "aceptada", DateTime.Now);
            Invitacion invitacion21 = new Invitacion(miembro2, miembro6, "aceptada", DateTime.Now);
            Invitacion invitacion22 = new Invitacion(miembro2, miembro7, "aceptada", DateTime.Now);
            Invitacion invitacion23 = new Invitacion(miembro2, miembro8, "aceptada", DateTime.Now);
            Invitacion invitacion24 = new Invitacion(miembro2, miembro9, "aceptada", DateTime.Now);
            Invitacion invitacion25 = new Invitacion(miembro2, miembro10, "aceptada", DateTime.Now);

            invitaciones.Add(invitacion);
            invitaciones.Add(invitacion2);
            invitaciones.Add(invitacion3);
            invitaciones.Add(invitacion4);
            invitaciones.Add(invitacion5);
            invitaciones.Add(invitacion6);
            invitaciones.Add(invitacion7);
            invitaciones.Add(invitacion8);
            invitaciones.Add(invitacion9);
            invitaciones.Add(invitacion10);
            invitaciones.Add(invitacion11);
            invitaciones.Add(invitacion12);
            invitaciones.Add(invitacion13);
            invitaciones.Add(invitacion14);
            invitaciones.Add(invitacion15);
            invitaciones.Add(invitacion16);
            invitaciones.Add(invitacion17);
            invitaciones.Add(invitacion18);
            invitaciones.Add(invitacion19);
            invitaciones.Add(invitacion20);
            invitaciones.Add(invitacion21);
            invitaciones.Add(invitacion22);
            invitaciones.Add(invitacion23);
            invitaciones.Add(invitacion24);
            invitaciones.Add(invitacion25);



            //Post con sus respectivos comentarios
            Publicacion post = new Post("Que mal día", 1, "Imagen.png", "Esta horrible", new DateTime(2022, 12, 1), miembro9, false, 99, 45);
            Comentario comentario = new Comentario(1, "Me siento mal por vos amigo", DateTime.Now, miembro10, false, 42, 24);
            Publicacion comentario2 = new Comentario(2, "Pegate una siesta bro", DateTime.Now, miembro3, false, 60, 20);
            Publicacion comentario3 = new Comentario(3, "Lo mismo digo", DateTime.Now, miembro4, false, 13, 1);

            publicaciones.Add(post);
            publicaciones.Add(comentario);
            post.comentarios.Add(comentario);
            publicaciones.Add(comentario2);
            publicaciones.Add(comentario3);
            //post.comentarios.Add(comentario2);
            //post.comentarios.Add(comentario3);

            Publicacion post2 = new Post("Al fin lo conseguí", 2, "Imagen2.jpg", "Re feliz estoy", new DateTime(2023, 2, 10), miembro, false, 104, 32);
            Publicacion comentario4 = new Comentario(4, "Tanta alegría para eso", DateTime.Now, miembro6, false, 32, 15);
            Publicacion comentario5 = new Comentario(5, "Felicidades", DateTime.Now, miembro7, false, 45, 2);
            Publicacion comentario6 = new Comentario(6, "Hay que ir por más", DateTime.Now, miembro8, false, 28, 11);

            publicaciones.Add(post2);
            publicaciones.Add(comentario4);
            publicaciones.Add(comentario5);
            publicaciones.Add(comentario6);

            Publicacion post3 = new Post("Nerfeen a la comerciante de calavares", 3, "Imagen3.png", "Aburridisima es", new DateTime(2022, 11, 30), miembro8, false, 189, 76);
            Comentario comentario7 = new Comentario(7, "Demasiado rota", DateTime.Now, miembro2, false, 73, 55);
            Publicacion comentario8 = new Comentario(8, "Arruina el juego", DateTime.Now, miembro2, false, 95, 73);
            Publicacion comentario9 = new Comentario(9, "Que esperas Behavior", DateTime.Now, miembro2, false, 87, 60);

            publicaciones.Add(post3);
            publicaciones.Add(comentario7);
            publicaciones.Add(comentario8);
            publicaciones.Add(comentario9);
            comentarios.Add(comentario7);

            Publicacion post4 = new Post("Pellistri tiene que ser titular en el United", 4, "Imagen4.jpg", "No Entiendo nada", new DateTime(2023, 9, 22), miembro10, false, 180, 165);
            Publicacion comentario10 = new Comentario(10, "Totalmente de acuerdo", DateTime.Now, miembro, false, 41, 5);
            Publicacion comentario11 = new Comentario(11, "Contra el Munich no hizo nada", DateTime.Now, miembro3, false, 92, 36);
            Publicacion comentario12 = new Comentario(12, "Hay que destituir al técnico", DateTime.Now, miembro6, false, 88, 68);

            publicaciones.Add(post4);
            publicaciones.Add(comentario10);
            publicaciones.Add(comentario11);
            publicaciones.Add(comentario12);

            Publicacion post5 = new Post("Fortnite con o sin construccion?", 5, "Imagen5.jpg", "Elijan!!", new DateTime(2022, 5, 17), miembro3, false, 183, 120);
            Publicacion comentario13 = new Comentario(13, "obvio que sin", DateTime.Now, miembro5, false, 60, 35);
            Publicacion comentario14 = new Comentario(14, "la construccion fue lo que lo hizo famos al Fortnite", DateTime.Now, miembro4, false, 70, 23);
            Publicacion comentario15 = new Comentario(15, "Ni idea ni juego al Fortnite", DateTime.Now, miembro, false, 50, 25);

            Publicacion post6 = new Post("No se que voy a hacer", 6, "Imagen6.png", "No entiendo nada", new DateTime(2022, 12, 13), miembro5, true, 0, 50);

            publicaciones.Add(post5);
            publicaciones.Add(comentario13);
            publicaciones.Add(comentario14);
            publicaciones.Add(comentario15);
            publicaciones.Add(post6);
            //Reacciones para posts y comentarios
            Reaccion reaccion1 = new Reaccion("Like", miembro4);
            Reaccion reaccion2 = new Reaccion("Dislike", miembro7);
            Reaccion reaccion3 = new Reaccion("Like", miembro3);
            Reaccion reaccion4 = new Reaccion("Dislike", miembro10);

            post.reacciones.Add(reaccion1);
            post2.reacciones.Add(reaccion2);
            comentario.reacciones.Add(reaccion3);
            comentario2.reacciones.Add(reaccion4);

        }

        #endregion

        public void AltaComentario(Comentario c)
        {
            c.ValidarComentario();
            publicaciones.Add(c);
        }
        public void AltaMiembro(Miembro m)
        {
            m.ValidarMiembro();
            usuarios.Add(m);

        }
        public void AltaPost(Post p)
        {
            foreach (Usuario u in usuarios)
            {
                if (u is Miembro m && m.Bloqueado == false)
                {
                    p.ValidarPost();
                    publicaciones.Add(p);
                    return;
                }
            }

            throw new Exception("El usuario está bloqueado");
        }

        public Miembro EncontrarUsuarioEmail(string email)
        {
            //inicializo la variable en null
            Miembro miembro = null;

            int i = 0;

            //uso un while con la condición de que siga iterando mientras que no encuentre al miembro
            while (i < usuarios.Count && miembro == null)
            {
                //si en la lista de usaurios en la posicion i encuentra al miembro y coincide el email entonces lo retorna
                if (usuarios[i] is Miembro miembroActual && miembroActual.Email == email)
                {
                    miembro = miembroActual;
                }
                i++;
            }

            return miembro;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> UsuariosOrdenados = new List<Usuario>();

            foreach (Usuario u in usuarios)
            {
                if (u is Miembro m)
                {
                    UsuariosOrdenados.Add(m);
                }
            }
            UsuariosOrdenados.Sort();
            return UsuariosOrdenados;
        }

        public List<Usuario> ListaMiembrosNoAmigos(string emailLogeado)
        {
            List<Usuario> miembros = new List<Usuario>();
            Usuario miembroActual = EncontrarUsuarioEmail(emailLogeado);
            Miembro miembroLogueado = miembroActual as Miembro;
            List<Miembro> amigos = miembroLogueado.amigos;

            foreach (Usuario usuario in usuarios)
            {
                if (!amigos.Contains(usuario))
                {
                    miembros.Add(usuario);
                }
            }

            return miembros;
        }


        public Usuario IniciarSesion(string email, string contrasena)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.Email.Equals(email) && u.Contrasena.Equals(contrasena))
                {
                    return u;
                }
            }


            throw new Exception("Email o contraseña erronea");
        }
        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            foreach (Usuario u in usuarios)
            {
                if (email.Equals(u.Email))
                {
                    return u;
                }
            }

            throw new Exception("El usuario no existe");
        }
        public List<Invitacion> ListarInvitaciones()
        {
            List<Invitacion> InvitacionesPendientes = new List<Invitacion>();

            foreach (Invitacion I in invitaciones)
            {
                if (I.EstadoInvitacion == "PENDIENTE_APROBACION")
                {
                    InvitacionesPendientes.Add(I);
                }
            }
            return InvitacionesPendientes;
        }

        public bool BloquearUsuario(Administrador a, string email)
        {
            foreach (Usuario u in usuarios)
            {
                if (u is Miembro miembro)
                {
                    if (miembro.Email.Equals(email))
                    {
                        a.Bloqueado(miembro);
                        return miembro.Bloqueado;
                    }
                }
            }
            throw new Exception("No se encontró el usuario.");
        }

        public bool BanearUnPost(Administrador a, int id)
        {
            foreach (Publicacion P in publicaciones)
            {
                if (P is Post post)
                {
                    if (post.IdPost.Equals(id))
                    {
                        a.BanearPost(post);
                        return post.Baneado;
                    }
                }
            }
            throw new Exception("No se encontró el usuario.");
        }



        public Miembro ObtenerMiembroPorEmail(string email)
        {
            foreach (Usuario u in usuarios)
            {
                if (u is Miembro miembro)
                {
                    if (miembro.Email.Equals(email))
                    {

                        return miembro;
                    }
                }
            }
            throw new Exception("No se encontró el usuario.");
        }

        public void EnviarInvitacion(string emailSolicitante, string emailSolicitado)
        {
            Miembro solicitante = ObtenerMiembroPorEmail(emailSolicitante);
            Miembro solicitado = ObtenerMiembroPorEmail(emailSolicitado);


            Invitacion invitacion = new Invitacion(solicitante, solicitado, "PENDIENTE_APROBACION", DateTime.Now);

            invitaciones.Add(invitacion);
        }

        public Invitacion ObtenerInvitacionPorId(int? id)
        {
            foreach (Invitacion I in invitaciones)
            {
                if (I.IdInvitacion == id)
                {
                    return I;
                }
            }

            throw new Exception("No se encontró ninguna invitacón");
        }
        public void CambiarEstadoInvitacion(int id, string estado)
        {
            Invitacion invitacion = ObtenerInvitacionPorId(id);

            // validar estado
            if (invitacion.EstadoInvitacion == "PENDIENTE_APROBACION")
            {
                invitacion.EstadoInvitacion = estado;
            } 
            if (invitacion.EstadoInvitacion == "aceptada")
            {
                invitacion.Solicitante.amigos.Add(invitacion.Solicitado);
                invitacion.Solicitado.amigos.Add(invitacion.Solicitante);
            }

        }
        public List<Post> ListarPublicaciones()
        {
            List<Post> verPublicaciones = new List<Post>();

            foreach (Publicacion p in publicaciones)
            {
                if (p is Post post && post.Privado == false && post.Baneado == false && post.Autor.Bloqueado == false)
                {
                    verPublicaciones.Add(post);
                }
            }
            return verPublicaciones;
        }
        public List<Publicacion> PublicacionesPopulares(double ValorIngresado, string texto)
        {
            
            List<Publicacion> ListarPublicacionesPopulares = new List<Publicacion>();
            if (texto == null)
            {
                texto = "";
            }
            
            foreach(Publicacion p in publicaciones)
            {
                if (ValorIngresado < p.CalcularValorApreciacion() && texto.Contains(p.Texto))
                {                   
                                       
                    ListarPublicacionesPopulares.Add(p);
                     
                }
            }
            return ListarPublicacionesPopulares;
        }

        public void UsuarioBloqueado()
        {
            foreach(Usuario u in usuarios)
            {
                if(u is Miembro m && m.Bloqueado == false)
                {

                }
                throw new Exception("El usuario esta bloqueado");
            }
        }

       
    }
}

