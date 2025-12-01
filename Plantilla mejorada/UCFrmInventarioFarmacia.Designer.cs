namespace Borrador
{
    partial class UCFrmInventarioFarmacia
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.nudExitenciaActual = new System.Windows.Forms.NumericUpDown();
            this.nudExistenciaMinima = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgwListaActual = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlContenedorTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.LineaDivisora = new System.Windows.Forms.Panel();
            this.btnDispensación = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.PanelDetalles = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PanelTabla = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudExitenciaActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExistenciaMinima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaActual)).BeginInit();
            this.pnlContenedorTitulo.SuspendLayout();
            this.PanelDetalles.SuspendLayout();
            this.PanelTabla.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(540, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 32);
            this.button1.TabIndex = 25;
            this.button1.Text = "Ver stock bajo";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // nudExitenciaActual
            // 
            this.nudExitenciaActual.Location = new System.Drawing.Point(27, 286);
            this.nudExitenciaActual.Margin = new System.Windows.Forms.Padding(4);
            this.nudExitenciaActual.Name = "nudExitenciaActual";
            this.nudExitenciaActual.Size = new System.Drawing.Size(160, 22);
            this.nudExitenciaActual.TabIndex = 14;
            // 
            // nudExistenciaMinima
            // 
            this.nudExistenciaMinima.Location = new System.Drawing.Point(236, 286);
            this.nudExistenciaMinima.Margin = new System.Windows.Forms.Padding(4);
            this.nudExistenciaMinima.Name = "nudExistenciaMinima";
            this.nudExistenciaMinima.Size = new System.Drawing.Size(160, 22);
            this.nudExistenciaMinima.TabIndex = 16;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(27, 354);
            this.dtpFechaVencimiento.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(269, 22);
            this.dtpFechaVencimiento.TabIndex = 18;
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(27, 423);
            this.txtLote.Margin = new System.Windows.Forms.Padding(4);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(285, 22);
            this.txtLote.TabIndex = 19;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(27, 492);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(159, 24);
            this.cmbProveedor.TabIndex = 20;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(232, 492);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(163, 24);
            this.cmbEstado.TabIndex = 21;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(61, 548);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(125, 33);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Image = global::Borrador.Properties.Resources.delete;
            this.btnEliminar.Location = new System.Drawing.Point(485, 688);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 66);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = global::Borrador.Properties.Resources.update;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(630, 688);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(89, 66);
            this.btnActualizar.TabIndex = 24;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // dgwListaActual
            // 
            this.dgwListaActual.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgwListaActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListaActual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Presentacion,
            this.StockActual,
            this.StockMin,
            this.Estado});
            this.dgwListaActual.Location = new System.Drawing.Point(27, 54);
            this.dgwListaActual.Margin = new System.Windows.Forms.Padding(4);
            this.dgwListaActual.Name = "dgwListaActual";
            this.dgwListaActual.RowHeadersWidth = 51;
            this.dgwListaActual.Size = new System.Drawing.Size(623, 464);
            this.dgwListaActual.TabIndex = 26;
            this.dgwListaActual.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwListaActual_CellContentClick);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 110;
            // 
            // Presentacion
            // 
            this.Presentacion.HeaderText = "Presentación";
            this.Presentacion.MinimumWidth = 6;
            this.Presentacion.Name = "Presentacion";
            this.Presentacion.Width = 90;
            // 
            // StockActual
            // 
            this.StockActual.HeaderText = "Stock actual";
            this.StockActual.MinimumWidth = 6;
            this.StockActual.Name = "StockActual";
            this.StockActual.Width = 42;
            // 
            // StockMin
            // 
            this.StockMin.HeaderText = "Stock minimo";
            this.StockMin.MinimumWidth = 6;
            this.StockMin.Name = "StockMin";
            this.StockMin.Width = 42;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.Width = 60;
            // 
            // pnlContenedorTitulo
            // 
            this.pnlContenedorTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.pnlContenedorTitulo.Controls.Add(this.lblTitulo);
            this.pnlContenedorTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedorTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenedorTitulo.Name = "pnlContenedorTitulo";
            this.pnlContenedorTitulo.Size = new System.Drawing.Size(1141, 74);
            this.pnlContenedorTitulo.TabIndex = 27;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitulo.Location = new System.Drawing.Point(32, 16);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(301, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Farmacia";
            // 
            // LineaDivisora
            // 
            this.LineaDivisora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(188)))), ((int)(((byte)(170)))));
            this.LineaDivisora.Location = new System.Drawing.Point(0, 123);
            this.LineaDivisora.Margin = new System.Windows.Forms.Padding(4);
            this.LineaDivisora.Name = "LineaDivisora";
            this.LineaDivisora.Size = new System.Drawing.Size(1141, 1);
            this.LineaDivisora.TabIndex = 28;
            // 
            // btnDispensación
            // 
            this.btnDispensación.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.btnDispensación.FlatAppearance.BorderSize = 0;
            this.btnDispensación.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispensación.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDispensación.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDispensación.Location = new System.Drawing.Point(25, 84);
            this.btnDispensación.Margin = new System.Windows.Forms.Padding(4);
            this.btnDispensación.Name = "btnDispensación";
            this.btnDispensación.Size = new System.Drawing.Size(155, 37);
            this.btnDispensación.TabIndex = 29;
            this.btnDispensación.Text = "Dispensación";
            this.btnDispensación.UseVisualStyleBackColor = false;
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInventario.Location = new System.Drawing.Point(191, 84);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(124, 37);
            this.btnInventario.TabIndex = 30;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // PanelDetalles
            // 
            this.PanelDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelDetalles.Controls.Add(this.button2);
            this.PanelDetalles.Controls.Add(this.label11);
            this.PanelDetalles.Controls.Add(this.label10);
            this.PanelDetalles.Controls.Add(this.label9);
            this.PanelDetalles.Controls.Add(this.label8);
            this.PanelDetalles.Controls.Add(this.label7);
            this.PanelDetalles.Controls.Add(this.comboBox2);
            this.PanelDetalles.Controls.Add(this.label5);
            this.PanelDetalles.Controls.Add(this.textBox2);
            this.PanelDetalles.Controls.Add(this.label4);
            this.PanelDetalles.Controls.Add(this.btnAgregar);
            this.PanelDetalles.Controls.Add(this.label3);
            this.PanelDetalles.Controls.Add(this.comboBox1);
            this.PanelDetalles.Controls.Add(this.cmbEstado);
            this.PanelDetalles.Controls.Add(this.label2);
            this.PanelDetalles.Controls.Add(this.cmbProveedor);
            this.PanelDetalles.Controls.Add(this.label6);
            this.PanelDetalles.Controls.Add(this.txtLote);
            this.PanelDetalles.Controls.Add(this.nudExitenciaActual);
            this.PanelDetalles.Controls.Add(this.nudExistenciaMinima);
            this.PanelDetalles.Controls.Add(this.dtpFechaVencimiento);
            this.PanelDetalles.Location = new System.Drawing.Point(25, 132);
            this.PanelDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.PanelDetalles.Name = "PanelDetalles";
            this.PanelDetalles.Size = new System.Drawing.Size(425, 603);
            this.PanelDetalles.TabIndex = 31;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(232, 548);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 33);
            this.button2.TabIndex = 23;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(228, 465);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Estado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 465);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Proveedor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 396);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Lote:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 327);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Fecha de vencimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(232, 258);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Stock minimo:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(27, 217);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(368, 24);
            this.comboBox2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stock actual:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(27, 148);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(369, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Codigo interno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Presentación:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(27, 79);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(368, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del medicamento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(264, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Detalles del medicamento:";
            // 
            // PanelTabla
            // 
            this.PanelTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelTabla.Controls.Add(this.label1);
            this.PanelTabla.Controls.Add(this.dgwListaActual);
            this.PanelTabla.Controls.Add(this.button1);
            this.PanelTabla.Location = new System.Drawing.Point(459, 132);
            this.PanelTabla.Margin = new System.Windows.Forms.Padding(4);
            this.PanelTabla.Name = "PanelTabla";
            this.PanelTabla.Size = new System.Drawing.Size(675, 544);
            this.PanelTabla.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de inventario";
            // 
            // UCFrmInventarioFarmacia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PanelTabla);
            this.Controls.Add(this.PanelDetalles);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnDispensación);
            this.Controls.Add(this.LineaDivisora);
            this.Controls.Add(this.pnlContenedorTitulo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCFrmInventarioFarmacia";
            this.Size = new System.Drawing.Size(1141, 764);
            ((System.ComponentModel.ISupportInitialize)(this.nudExitenciaActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExistenciaMinima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaActual)).EndInit();
            this.pnlContenedorTitulo.ResumeLayout(false);
            this.pnlContenedorTitulo.PerformLayout();
            this.PanelDetalles.ResumeLayout(false);
            this.PanelDetalles.PerformLayout();
            this.PanelTabla.ResumeLayout(false);
            this.PanelTabla.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudExitenciaActual;
        private System.Windows.Forms.NumericUpDown nudExistenciaMinima;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgwListaActual;
        private System.Windows.Forms.Panel pnlContenedorTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel LineaDivisora;
        private System.Windows.Forms.Button btnDispensación;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Panel PanelDetalles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel PanelTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button button2;
    }
}
