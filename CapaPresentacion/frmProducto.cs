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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            #region Carga combobox cboestado
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto"; //El texto que muestra el combobox
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;
            #endregion


            #region Carga combobox cborol desde la base de datos
            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            cbocategoria.SelectedIndex = 0;
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


            //MOSTRAR TODOS LOS ProductoS
            //Esta porcion de codigo carga el dgvdata desde la base de datos
            //mediante el metodo listar de clase CN_Producto.
            #region Carga DataGridView dgvdata
            List<Producto> listaProducto = new CN_Producto().Listar();

            foreach (Producto item in listaProducto)
            {
                dgvdata.Rows.Add(new object[] {
                "", 
                item.IdProducto, 
                item.Codigo, 
                item.Nombre, 
                item.Descripcion,
                item.oCategoria.IdCategoria, 
                item.oCategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
                item.Estado == true ? 1 : 0,  //Si es true muestra 1 de lo contrario 0
                item.Estado == true ? "Activo" : "No Activo"    //Si es true muestra Activo de lo contrario No Activo
                });
            }
            #endregion
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Producto obj = new Producto()
            { 
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtnombre.Text,
                Descripcion = txtdescripcion.Text,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            //Si el IdProducto es igual a 0 significa que se esta creando un nuevo Producto,
            //de lo contrario signific que se esta editando un Producto existente.
            if (obj.IdProducto == 0)
            {
                int idgenerado = new CN_Producto().Registrar(obj, out mensaje);

                //Si el idProductogenerado es distinto de 0 significa que se registro correctamente el Producto
                if (idgenerado != 0)
                {
                     //Carga datagridview con los datos del nuevo Producto, el primer valor lleva "" ya que no posee un valor como tal porque es un botón
                     dgvdata.Rows.Add(new object[] {"", 
                    idgenerado, 
                    txtcodigo.Text, 
                    txtnombre.Text,
                    txtdescripcion.Text,
                    ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString(),
                    "0",     //Stock
                    "0.00",  //PrecioCompra
                    "0.00",  //PrecioVenta
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
                //Editar Producto en la base de datos
                bool resultado = new CN_Producto().Editar(obj, out mensaje);

                //Actualiza el dgvdata la fila que corresponda con los nuevos valores del Producto que se edito
                if (resultado == true)
                {
                    //Se almacena en la variable row el indice de la fila seleccionada
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];

                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString();
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
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            cbocategoria.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

            txtcodigo.Select();
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
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    //Muestra en el combobox cbocategoria la categoria que le corresponda al producto que se selecciono
                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        //Valida que valor del combo sea la misma categoria de producto
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = cbocategoria.Items.IndexOf(oc);
                            cbocategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    //Muestra en el combobox cboestado el estado que le corresponda al usuario que se selecciono
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        //Valida que valor del combo sea el mismo que el de estado del usuario
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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            //Valida que se selecciono un producto del dgvdata
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                //Si se hace click en boton de SI procede a eliminar el producto
                if (MessageBox.Show("¿Desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Producto obj = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Producto().Eliminar(obj, out mensaje);

                    if (respuesta == true)
                    {
                        //Elimina la fila que le correspondia al producto eliminado
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
