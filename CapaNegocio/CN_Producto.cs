using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {
        //Instancia de la clase CD_Producto de la CapaDatos
        private CD_Producto objcd_producto = new CD_Producto();

        //Retorna la lista obtenida del metodo Listar de la clase CD_Producto 
        public List<Producto> Listar()
        {
            return objcd_producto.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el código del Producto\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripción del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_producto.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el código del Producto\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripción del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_producto.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return objcd_producto.Eliminar(obj, out Mensaje);
        }
    }
}