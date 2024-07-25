using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Referencia a carpeta de utilidades
using CapaPresentacion.Utilidades;
//Referencia CapaEntidad
using CapaEntidad;
//Referencia CapaNegocio
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            #region Carga combobox cboestado
            cboestado.Items.Add(new OpcionCombo() { Valor = 1 , Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto"; ;
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;
            #endregion


            #region Carga combobox cborol desde la base de datos
            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cborol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;
            #endregion

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //Carga datagridview con los valores correspondientes
            dgvdata.Rows.Add(new object[] {"", txtid.Text, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text, 
            ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
            ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
            ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
            ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
            });

            Limpiar();

        }


        private void Limpiar()
        {
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

    }
}
