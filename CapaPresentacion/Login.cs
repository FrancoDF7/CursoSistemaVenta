using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Referenia a CapaNegocio
using CapaNegocio;
//Referecia a CapaEntidad
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtclave.UseSystemPasswordChar = true;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
         {
            //El metodo Listar devuelve una lista de usuarios.
            //Where filtra un usuario de la lista que coincida con el numero de documento y su clave, de lo contrario devuelve null.
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();

            if(ousuario != null)
            {
                //Le envia al constructor del formulario Inicio los datos del usuario que encontro
                Inicio form = new Inicio(ousuario);

                form.Show();
                this.Hide();

                //Llama al metodo frm_closing para que cuando el formulario Inicio se cierre.
                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario","Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }


        }

        //Muestra nuevamente el formulario Login y resetea los campos de documento y contraseña.
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtdocumento.Text = "";
            txtclave.Text = "";

            //Muestra el formulario
            this.Show();
        }



    }
}
