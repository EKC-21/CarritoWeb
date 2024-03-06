using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> oListUsuarios = new List<Usuario>();

            try
            {
                using(SqlConnection oConnection = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListUsuarios.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Reestablecer = Convert.ToBoolean(dr["Reestablecer"]),
                                Activo = Convert.ToBoolean(dr["Activo"]),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                            });
                        }
                    }
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                new ArgumentException(ex.ToString());
            }
            return oListUsuarios;
        }

        public string RegistrarUsuario(Usuario usuario)
        {
            string msg = "";
            try
            {
                using (SqlConnection oConecction = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", oConecction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit, 0);
                    cmd.Parameters.Add("@msg", SqlDbType.VarChar, 800).Direction = ParameterDirection.Output;

                    cmd.Parameters["@Nombre"].Value = usuario.Nombre;
                    cmd.Parameters["@Apellidos"].Value = usuario.Apellidos;
                    cmd.Parameters["@Correo"].Value = usuario.Correo;
                    cmd.Parameters["@Clave"].Value = usuario.Clave;
                    cmd.Parameters["@Activo"].Value = usuario.Activo;

                    oConecction.Open();
                    msg = Convert.ToString(cmd.ExecuteScalar());
                    oConecction.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return msg;
        }

        public string EditarUsuario(Usuario usuario)
        {
            string msg = "";
            try
            {
                using (SqlConnection oConecction = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oConecction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int, 0);
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit, 0);
                    cmd.Parameters.Add("@msg", SqlDbType.VarChar, 800).Direction = ParameterDirection.Output;

                    cmd.Parameters["@IdUsuario"].Value = usuario.IdUsuario;
                    cmd.Parameters["@Nombre"].Value = usuario.Nombre;
                    cmd.Parameters["@Apellidos"].Value = usuario.Apellidos;
                    cmd.Parameters["@Correo"].Value = usuario.Correo;
                    cmd.Parameters["@Activo"].Value = usuario.Activo;

                    oConecction.Open();
                    msg = Convert.ToString(cmd.ExecuteScalar());
                    oConecction.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return msg;
        }

        public string EliminarUsuario(int IdUsuario)
        {
            string msg = string.Empty;
            try
            {
                using (SqlConnection oConnection = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminaUsuario", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int, 0);
                    cmd.Parameters.Add("@msg", SqlDbType.VarChar, 800).Direction = ParameterDirection.Output;

                    cmd.Parameters["@IdUsuario"].Value = IdUsuario;

                    oConnection.Open();
                    msg = Convert.ToString(cmd.ExecuteScalar());
                    oConnection.Close();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return msg;
        }
    }
}
