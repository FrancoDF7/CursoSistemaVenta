using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            #region Carga combobox cboestado
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;
            #endregion


            #region Carga el combobox cbobusqueda con los valores de la columnas del datagridview
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
            #endregion


            #region Carga DataGridView dgvdata
            List<Categoria> lista = new CN_Categoria().Listar();

            foreach (Categoria item in lista)
            {
                dgvdata.Rows.Add(new object[] {"", item.IdCategoria, 
                item.Descripcion,
                item.Estado == true ? 1 : 0,  //Si es true muestra 1 de lo contrario 0
                item.Estado == true ? "Activo" : "No Activo"    //Si es true muestra Activo de lo contrario No Activo
                });
            }
            #endregion
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtid.Text),
                Descripcion = txtdescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            //Si el IdCategoria es igual a 0 significa que se esta creando una nueva categoria,
            //de lo contrario significa que se esta editando un Categoria existente.
            if (obj.IdCategoria == 0)
            {
                int idgenerado = new CN_Categoria().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"", idgenerado, txtdescripcion.Text,
                ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
                });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                //Editar Categoria en la base de datos
                bool resultado = new CN_Categoria().Editar(obj, out mensaje);

                //Actualiza el dgvdata la fila que corresponda con los nuevos valores de la Categoria que se edito
                if (resultado == true)
                {
                    //Se almacena en la variable row el indice de la fila seleccionada
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];

                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }

        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;

            txtdescripcion.Select();
        }

        //Este evento se dispara cada vez que se crea una nueva fila
        //Dibuja la imagen de un check dentro del boton del dgvdata
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width; //Asigna a la variable w el ancho de la imagen check20
                var h = Properties.Resources.check20.Height; //Asigna a la variable h el alto de la imagen check20
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2; //Centra imagen horizontalmente
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2; //Centra imagen verticalmente


                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h)); //Se dibuja la imagen en utilizando las dimensiones y coordenadas de las variables.
                e.Handled = true; //Esto indica que se ha manejado completamente el evento de pintura de la celda y evita que el sistema realice más procesamiento de pintura estándar
            }
        }

        //Se encarga de completar los campos de texto y combobox, obteniendo los datos de dgvdata.
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Valida que se haga click en la columna que se llama btnseleccionar en el dgvdata
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex; //Obtiene el indice de la fila seleccionda

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    //Muestra en el combobox cboestado el estado que le corresponda a la categoria que se selecciono
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        //Valida que valor del combo sea el mismo que el de estado de la categoria
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            //Valida que se selecciono un Categoria del dgvdata
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                //Si se hace click en boton de SI procede a eliminar el Categoria
                if (MessageBox.Show("¿Desea eliminar la categoría?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Categoria obj = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Categoria().Eliminar(obj, out mensaje);

                    if (respuesta == true)
                    {
                        //Elimina la fila que le correspondia al Categoria eliminado
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;

                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }


    }
}
