using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Se agregaron la librerias System.Data; y System.Data.SqlClient
using System.Data;
using System.Data.SqlClient;
//Se agrego una referencia a la CapaEntidad
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        //Este metodo devuelve una lista de usuarios.
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            //Le pasa por parametros la cadena de conexion de la clase Conexion
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //Consulta que se va realizar a la BD
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion FROM USUARIO u");
                    query.AppendLine("INNER JOIN ROL r ON r.IdRol = u.IdRol");

                    //Le pasa por parametros al SqlCommand el la Consulta y Cadena de Conexion
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader se encarga de leer el resultado del SqlCommand
                    //La variable de dr almacena el resultado del metodo ExecuteReader
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //El bucle while(dr.Read()) se ejecuta mientras hay más filas de resultados para leer
                        while (dr.Read())
                        {
                            //Se crea una nueva instancia de la clase Usuario.
                            //Se asignan valores a las propiedades de Usuario utilizando los datos leídos de la fila actual
                            //Después de asignar los valores a las propiedades de Usuario, se agrega la instancia de Usuario a una lista llamada lista
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    //Si hay un error deja la lista vacia
                    lista = new List<Usuario>();
                }
            }

            return lista;
        }



    }
}
