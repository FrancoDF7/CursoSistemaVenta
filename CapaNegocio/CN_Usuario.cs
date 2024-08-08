using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Referencia a CapaDatos
using CapaDatos;
//Referencia a CapaEntidad
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        //Instancia de la clase CD_Usuario de la CapaDatos
        private CD_Usuario objcd_usuario = new CD_Usuario();

        //Retorna la lista obtenida del metodo Listar de la clase CD_Usuario 
        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave de usuario\n";
            }

            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave de usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }

        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }



    }
}
