using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se agrego una referencia a System.Configuration en la capa de datos
using System.Configuration;  

namespace CapaDatos
{
    //Esta clase envia a la demas clases la cadena conexion existente el archivo App.config de la CapaPresentacion
    public class Conexion
    {   
        //cadena_conexion es el nombre que le dimos al connectionString en el archivo App.config
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
