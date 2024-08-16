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
using ClosedXML.Excel;

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
            cboestado.DisplayMember = "Texto"; //El texto que muestra el combobox
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


            //MOSTRAR TODOS LOS USUARIOS
            //Esta porcion de codigo carga el dgvdata desde la base de datos
            //mediante el metodo listar de clase CN_Usuario.
            #region Carga DataGridView dgvdata
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] {"", item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1 : 0,  //Si es true muestra 1 de lo contrario 0
                item.Estado == true ? "Activo" : "No Activo"    //Si es true muestra Activo de lo contrario No Activo
                });
            }
            #endregion
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            //Si el IdUsuario es igual a 0 significa que se esta creando un nuevo usuario,
            //de lo contrario signific que se esta editando un usuario existente.
            if (objusuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objusuario, out mensaje);

                //Si el idusuariogenerado es distinto de 0 significa que se registro correctamente el usuario
                if (idusuariogenerado != 0)
                {
                    //Carga datagridview con los datos del nuevo usuario, el primer valor lleva "" ya que no posee un valor como tal porque es un botón
                    dgvdata.Rows.Add(new object[] {"", idusuariogenerado, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text,
                ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
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
                //Editar usuario en la base de datos
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);

                //Actualiza el dgvdata la fila que corresponda con los nuevos valores del usuario que se edito
                if(resultado == true)
                {
                    //Se almacena en la variable row el indice de la fila seleccionada
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];

                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Clave"].Value = txtclave.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).Texto.ToString();
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
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

            txtdocumento.Select();
        }

        //Este evento se dispara cada vez que se crea una nueva fila
        //Dibuja la imagen de un check dentro del boton del dgvdata
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex < 0) 
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width; //Asigna a la variable w el ancho de la imagen check20
                var h = Properties.Resources.check20.Height; //Asigna a la variable h el alto de la imagen check20
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2; //Centra imagen horizontalmente
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2; //Centra imagen verticalmente


                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x,y,w,h)); //Se dibuja la imagen en utilizando las dimensiones y coordenadas de las variables.
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
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    //Muestra en el combobox cborol el rol que le corresponda al usuario que se selecciono
                    foreach (OpcionCombo oc in cborol.Items)
                    {
                        //Valida que valor del combo sea el mismo que el de rol del usuario
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            //Valida que se selecciono un usuario del dgvdata
            if(Convert.ToInt32(txtid.Text) != 0)
            {
                //Si se hace click en boton de SI procede a eliminar el usuario
                if(MessageBox.Show("¿Desea eliminar el usuario?","Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Usuario objusuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);
                    
                    if(respuesta == true)
                    {
                        //Elimina la fila que le correspondia al usuario eliminado
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

            if(dgvdata.Rows.Count > 0 )
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

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                //Siempre y cuando se cumplan las condiciones del if dentro de foreach,
                //lo que se hara es agregar una nueva columna al DataTable dt con el mismo nombre que la cabecera de la columna.
                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible == true)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                //Inserta la filas de el dgvdata
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible == true)
                    {
                        dt.Rows.Add(new object[]
                        {
                           row.Cells[2].Value.ToString(),
                           row.Cells[3].Value.ToString(),
                           row.Cells[4].Value.ToString(),
                           row.Cells[7].Value.ToString(),
                           row.Cells[9].Value.ToString(),
                        });
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteUsuarios_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss")); //Nombre del archivo excel junto con su fecha de creacion
                savefile.Filter = "Excel Files | *xlsx"; //Filtra "hace visible" solamente archivos con la extension xlsx

                //Evento que se dispara cuando se presionar aceptar para guardar
                //el archivo en la ubicacion que se hallamos seleccionado
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

    }
}