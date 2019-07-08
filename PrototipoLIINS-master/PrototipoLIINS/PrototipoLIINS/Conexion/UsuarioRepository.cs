using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using PrototipoLIINS.Modelo;

namespace PrototipoLIINS.Conexion
{
    public class UsuarioRepository
    {
        private SQLiteConnection con;

        private static UsuarioRepository instancia;
        public static UsuarioRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al Inicializador");
                return instancia;
            }
        }

        public static void Inicializador(String filename)
        {
            if (filename == null)
                throw new ArgumentNullException();

            if (instancia != null)
                instancia.con.Close();

            instancia = new UsuarioRepository(filename);
        }

        private UsuarioRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);

            con.CreateTable<Usuario>();
        }

        public string EstadoMensaje;

        public void AddNuevoUsuario(string user, string contraseña, string nombre, string apellido, string tipo, string estado)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(user))
                    throw new Exception("Usuario inválido");
                if (string.IsNullOrEmpty(contraseña))
                    throw new Exception("Contraseña inválida");
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre inválido");
                if (string.IsNullOrEmpty(apellido))
                    throw new Exception("Apellido inválido");
                if (string.IsNullOrEmpty(tipo))
                    throw new Exception("Tipo inválido");
                if (string.IsNullOrEmpty(estado))
                    throw new Exception("Estado inválido");

                result = con.Insert(new Usuario()
                {
                    User = user,
                    Contraseña = contraseña,
                    Nombre = nombre,
                    Apellido = apellido,
                    Tipo = tipo,
                    Estado = estado
                });

                EstadoMensaje = string.Format("Nuevo usuario añadido", result);
            } catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            try
            {
                return con.Table<Usuario>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }

        public Boolean AttempLogin(string us, string contraseña)
        {
            try
            {
                if (string.IsNullOrEmpty(us))
                    throw new Exception("Ingrese un Usuario válido");
                if (string.IsNullOrEmpty(contraseña))
                    throw new Exception("Ingrese una Contraseña válida");
                var usuario = from u in con.Table<Usuario>()
                              where u.User == us && u.Contraseña == contraseña
                              select u;

                Usuario user = usuario.SingleOrDefault();

                if (user != null)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
                return false;
            }

            EstadoMensaje = "El Usuario y/o la contraseña es inválida";
            return false;
        }

        public int DeleteUsuario(int id)
        {
            int result = 0;
            try
            {
                result = con.Delete<Usuario>(id);

                if (result > 0)
                {
                    EstadoMensaje = string.Format("Usuario Eliminado", id);
                }


            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public void DeleteAllUsers()
        {
            con.DeleteAll<Usuario>();
        }

        public Usuario BuscarUsuario(string user)
        {
            try
            {
                if (string.IsNullOrEmpty(user))
                    throw new Exception("Ingrese un Usuario válido");

                var usuario = from u in con.Table<Usuario>()
                              where u.User == user
                              select u;
                Usuario buscado = usuario.SingleOrDefault();

                if (buscado != null)
                {
                    return buscado;
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
                return null;
            }

            EstadoMensaje = "No existen coincidencias";
            return null;
        }

        public Usuario userType(string us, string contraseña)
        {
            var usuario = from u in con.Table<Usuario>()
                          where u.User == us && u.Contraseña == contraseña
                          select u;

            Usuario uTipo = usuario.SingleOrDefault();

            return uTipo;
        }

        public int UpdateUser(Usuario u)
        {
            int result = 0;

            try
            {
                result = con.Update(u);

                if (result > 0)
                {
                    EstadoMensaje = string.Format("Usuario Actualizado", u.Id);
                }

            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return result;
        }

    }
}
