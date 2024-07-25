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


    }
}
