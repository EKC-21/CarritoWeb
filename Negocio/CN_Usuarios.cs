using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios cd_Usuarios = new CD_Usuarios();

        public List<Usuario> oListUsuarios()
        {
            return cd_Usuarios.Listar();
        }

        public string RegistrarUsuario(Usuario usuario)
        {
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                mensaje = "El nombre de usuario no puede ser vacio, verifique";
                return mensaje;
            }
            if (string.IsNullOrEmpty(usuario.Apellidos) || string.IsNullOrWhiteSpace(usuario.Apellidos))
            {
                mensaje = "El campo Apellidos no puede ser vacio, verifique";
                return mensaje;

            }
            if (string.IsNullOrEmpty(usuario.Correo) || string.IsNullOrWhiteSpace(usuario.Correo))
            {
                mensaje = "El campo Correo no puede ser vacio, verifique";
                return mensaje;
            }

            if (mensaje == string.Empty)
            {
                string clave = "test123";
                //string clave = CN_Recursos.GenerarClave();
                usuario.Clave = CN_Recursos.ConvertirSHA256(clave);                
            }
            else
            {

            }
            return cd_Usuarios.RegistrarUsuario(usuario);
        }

        public string EditarUsuario(Usuario usuario)
        {
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                mensaje = "El nombre de usuario no puede ser vacio, verifique";
                return mensaje;
            }
            if (string.IsNullOrEmpty(usuario.Apellidos) || string.IsNullOrWhiteSpace(usuario.Apellidos))
            {
                mensaje = "El campo Apellidos no puede ser vacio, verifique";
                return mensaje;
            }
            if (string.IsNullOrEmpty(usuario.Correo) || string.IsNullOrWhiteSpace(usuario.Correo))
            {
                mensaje = "El campo Correo no puede ser vacio, verifique";
                return mensaje;
            }
            return cd_Usuarios.EditarUsuario(usuario);
        }

        public string EliminarUsuario(int IdUsuario)
        {
            string mensaje = string.Empty;
            if (IdUsuario == 0)
            {
                mensaje = "Debe seleccionar el usuario a eliminar";
                return mensaje;
            }
            return cd_Usuarios.EliminarUsuario(IdUsuario);
        }
    }
}
