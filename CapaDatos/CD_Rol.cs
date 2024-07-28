using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//Referencia CapaEntidad
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        //Retorna una lista el id de los roles y su descripcion (ADMINISTRADOR y EMPLEADO).
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //StringBuilder permite realiza consultas con saltos de linea, utilizando AppendLine
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdRol,Descripcion FROM ROL");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    //Si hay un error deja la lista vacia
                    lista = new List<Rol>();
                }
            }

            return lista;
        }
    }
}
