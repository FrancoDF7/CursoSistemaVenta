namespace CapaPresentacion
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btncrearventa = new FontAwesome.Sharp.IconButton();
            this.txttotalpagar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnagregarproducto = new FontAwesome.Sharp.IconButton();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnbuscarproducto = new FontAwesome.Sharp.IconButton();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.txtidproducto = new System.Windows.Forms.TextBox();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcodproducto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtnombrecliente = new System.Windows.Forms.TextBox();
            this.btnbuscarcliente = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdocumentocliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbotipodocumento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpagacon = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtcambio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btncrearventa
            // 
            this.btncrearventa.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.btncrearventa.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.btncrearventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncrearventa.IconSize = 35;
            this.btncrearventa.Location = new System.Drawing.Point(836, 402);
            this.btncrearventa.Name = "btncrearventa";
            this.btncrearventa.Size = new System.Drawing.Size(92, 38);
            this.btncrearventa.TabIndex = 35;
            this.btncrearventa.Text = "Crear Venta";
            this.btncrearventa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncrearventa.UseVisualStyleBackColor = true;
            this.btncrearventa.Click += new System.EventHandler(this.btncrearventa_Click);
            // 
            // txttotalpagar
            // 
            this.txttotalpagar.Location = new System.Drawing.Point(836, 280);
            this.txttotalpagar.Name = "txttotalpagar";
            this.txttotalpagar.ReadOnly = true;
            this.txttotalpagar.Size = new System.Drawing.Size(92, 20);
            this.txttotalpagar.TabIndex = 34;
            this.txttotalpagar.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(833, 264);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Total a Pagar:";
            // 
            // btnagregarproducto
            // 
            this.btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.btnagregarproducto.IconColor = System.Drawing.Color.Green;
            this.btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnagregarproducto.IconSize = 30;
            this.btnagregarproducto.Location = new System.Drawing.Point(835, 172);
            this.btnagregarproducto.Name = "btnagregarproducto";
            this.btnagregarproducto.Size = new System.Drawing.Size(95, 73);
            this.btnagregarproducto.TabIndex = 33;
            this.btnagregarproducto.Text = "Agregar";
            this.btnagregarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnagregarproducto.UseVisualStyleBackColor = true;
            this.btnagregarproducto.Click += new System.EventHandler(this.btnagregarproducto_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.SubTotal,
            this.btneliminar});
            this.dgvdata.Location = new System.Drawing.Point(201, 264);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(621, 176);
            this.dgvdata.TabIndex = 36;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 125;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 114;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 113;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 114;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 113;
            // 
            // btneliminar
            // 
            this.btneliminar.HeaderText = "";
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.ReadOnly = true;
            this.btneliminar.Width = 30;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtcantidad);
            this.groupBox3.Controls.Add(this.txtstock);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnbuscarproducto);
            this.groupBox3.Controls.Add(this.txtprecio);
            this.groupBox3.Controls.Add(this.txtidproducto);
            this.groupBox3.Controls.Add(this.txtproducto);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtcodproducto);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(201, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(621, 73);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información de Producto";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(533, 43);
            this.txtcantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtcantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(79, 20);
            this.txtcantidad.TabIndex = 11;
            this.txtcantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(441, 43);
            this.txtstock.Name = "txtstock";
            this.txtstock.ReadOnly = true;
            this.txtstock.Size = new System.Drawing.Size(84, 20);
            this.txtstock.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(438, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Stock:";
            // 
            // btnbuscarproducto
            // 
            this.btnbuscarproducto.BackColor = System.Drawing.SystemColors.Control;
            this.btnbuscarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarproducto.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnbuscarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarproducto.ForeColor = System.Drawing.Color.White;
            this.btnbuscarproducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarproducto.IconColor = System.Drawing.Color.Black;
            this.btnbuscarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarproducto.IconSize = 20;
            this.btnbuscarproducto.Location = new System.Drawing.Point(132, 43);
            this.btnbuscarproducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnbuscarproducto.Name = "btnbuscarproducto";
            this.btnbuscarproducto.Size = new System.Drawing.Size(33, 20);
            this.btnbuscarproducto.TabIndex = 7;
            this.btnbuscarproducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarproducto.UseVisualStyleBackColor = false;
            this.btnbuscarproducto.Click += new System.EventHandler(this.btnbuscarproducto_Click);
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(351, 43);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(84, 20);
            this.txtprecio.TabIndex = 9;
            this.txtprecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecio_KeyPress);
            // 
            // txtidproducto
            // 
            this.txtidproducto.Location = new System.Drawing.Point(89, 20);
            this.txtidproducto.Name = "txtidproducto";
            this.txtidproducto.Size = new System.Drawing.Size(38, 20);
            this.txtidproducto.TabIndex = 29;
            this.txtidproducto.Visible = false;
            // 
            // txtproducto
            // 
            this.txtproducto.Location = new System.Drawing.Point(171, 43);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.ReadOnly = true;
            this.txtproducto.Size = new System.Drawing.Size(174, 20);
            this.txtproducto.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(530, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Cantidad:";
            // 
            // txtcodproducto
            // 
            this.txtcodproducto.Location = new System.Drawing.Point(9, 43);
            this.txtcodproducto.Name = "txtcodproducto";
            this.txtcodproducto.Size = new System.Drawing.Size(118, 20);
            this.txtcodproducto.TabIndex = 6;
            this.txtcodproducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodproducto_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Precio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cod. Producto:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtnombrecliente);
            this.groupBox2.Controls.Add(this.btnbuscarcliente);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtdocumentocliente);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(525, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 71);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Cliente";
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.Location = new System.Drawing.Point(189, 37);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.ReadOnly = true;
            this.txtnombrecliente.Size = new System.Drawing.Size(194, 20);
            this.txtnombrecliente.TabIndex = 5;
            // 
            // btnbuscarcliente
            // 
            this.btnbuscarcliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnbuscarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcliente.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnbuscarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcliente.ForeColor = System.Drawing.Color.White;
            this.btnbuscarcliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarcliente.IconColor = System.Drawing.Color.Black;
            this.btnbuscarcliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarcliente.IconSize = 20;
            this.btnbuscarcliente.Location = new System.Drawing.Point(132, 37);
            this.btnbuscarcliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.Size = new System.Drawing.Size(33, 20);
            this.btnbuscarcliente.TabIndex = 4;
            this.btnbuscarcliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarcliente.UseVisualStyleBackColor = false;
            this.btnbuscarcliente.Click += new System.EventHandler(this.btnbuscarcliente_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre Completo:";
            // 
            // txtdocumentocliente
            // 
            this.txtdocumentocliente.Location = new System.Drawing.Point(9, 37);
            this.txtdocumentocliente.Name = "txtdocumentocliente";
            this.txtdocumentocliente.Size = new System.Drawing.Size(116, 20);
            this.txtdocumentocliente.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Número Documento:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbotipodocumento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(201, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 71);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Venta";
            // 
            // cbotipodocumento
            // 
            this.cbotipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipodocumento.FormattingEnabled = true;
            this.cbotipodocumento.Location = new System.Drawing.Point(127, 37);
            this.cbotipodocumento.Name = "cbotipodocumento";
            this.cbotipodocumento.Size = new System.Drawing.Size(185, 21);
            this.cbotipodocumento.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo Documento:";
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(9, 37);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.ReadOnly = true;
            this.txtfecha.Size = new System.Drawing.Size(100, 20);
            this.txtfecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "Registrar Venta";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label10.Location = new System.Drawing.Point(183, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 6, 0, 0);
            this.label10.Size = new System.Drawing.Size(761, 436);
            this.label10.TabIndex = 37;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpagacon
            // 
            this.txtpagacon.Location = new System.Drawing.Point(835, 335);
            this.txtpagacon.Name = "txtpagacon";
            this.txtpagacon.Size = new System.Drawing.Size(92, 20);
            this.txtpagacon.TabIndex = 43;
            this.txtpagacon.Text = "0";
            this.txtpagacon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpagacon_KeyDown);
            this.txtpagacon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpagacon_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(832, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Paga con:";
            // 
            // txtcambio
            // 
            this.txtcambio.Location = new System.Drawing.Point(836, 376);
            this.txtcambio.Name = "txtcambio";
            this.txtcambio.ReadOnly = true;
            this.txtcambio.Size = new System.Drawing.Size(92, 20);
            this.txtcambio.TabIndex = 45;
            this.txtcambio.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(833, 360);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Cambio:";
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 499);
            this.Controls.Add(this.txtcambio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtpagacon);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btncrearventa);
            this.Controls.Add(this.txttotalpagar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnagregarproducto);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVentas";
            this.Text = "frmVentas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btncrearventa;
        private System.Windows.Forms.TextBox txttotalpagar;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btnbuscarproducto;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtidproducto;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcodproducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private FontAwesome.Sharp.IconButton btnbuscarcliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdocumentocliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbotipodocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtpagacon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminar;
    }
}