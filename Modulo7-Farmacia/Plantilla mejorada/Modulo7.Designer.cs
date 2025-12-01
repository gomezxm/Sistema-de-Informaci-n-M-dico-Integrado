namespace Borrador
{
    partial class Modulo7
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PanelTabla = new System.Windows.Forms.Panel();
            this.ListaMedicamentos = new System.Windows.Forms.DataGridView();
            this.Medicamentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPrescrita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.PanelPago = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblTitulo1 = new System.Windows.Forms.Label();
            this.pnlContenedorTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.PanelDetalles = new System.Windows.Forms.Panel();
            this.lblFechasEntrega = new System.Windows.Forms.Label();
            this.txtFechas = new System.Windows.Forms.TextBox();
            this.txtMedicos = new System.Windows.Forms.TextBox();
            this.lblMedicos = new System.Windows.Forms.Label();
            this.txtNumeroRecetas = new System.Windows.Forms.TextBox();
            this.lblNumeroRecetas = new System.Windows.Forms.Label();
            this.cmbPacientes = new System.Windows.Forms.ComboBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.dgwListaActual = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerStock = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.nudExitenciaActual = new System.Windows.Forms.NumericUpDown();
            this.nudExistenciaMinima = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.PanelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaMedicamentos)).BeginInit();
            this.PanelPago.SuspendLayout();
            this.pnlContenedorTitulo.SuspendLayout();
            this.PanelDetalles.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaActual)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExitenciaActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExistenciaMinima)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(856, 609);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.tabPage1.Controls.Add(this.PanelTabla);
            this.tabPage1.Controls.Add(this.PanelPago);
            this.tabPage1.Controls.Add(this.pnlContenedorTitulo);
            this.tabPage1.Controls.Add(this.PanelDetalles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(848, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inventario";
            // 
            // PanelTabla
            // 
            this.PanelTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelTabla.Controls.Add(this.ListaMedicamentos);
            this.PanelTabla.Controls.Add(this.label10);
            this.PanelTabla.Location = new System.Drawing.Point(16, 387);
            this.PanelTabla.Name = "PanelTabla";
            this.PanelTabla.Size = new System.Drawing.Size(788, 197);
            this.PanelTabla.TabIndex = 11;
            // 
            // ListaMedicamentos
            // 
            this.ListaMedicamentos.BackgroundColor = System.Drawing.Color.White;
            this.ListaMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaMedicamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Medicamentos,
            this.Dosis,
            this.Frecuencia,
            this.CantidadPrescrita,
            this.CantidadEntregar});
            this.ListaMedicamentos.Location = new System.Drawing.Point(22, 35);
            this.ListaMedicamentos.Name = "ListaMedicamentos";
            this.ListaMedicamentos.Size = new System.Drawing.Size(742, 133);
            this.ListaMedicamentos.TabIndex = 1;
            // 
            // Medicamentos
            // 
            this.Medicamentos.HeaderText = "Medicamentos";
            this.Medicamentos.Name = "Medicamentos";
            this.Medicamentos.Width = 140;
            // 
            // Dosis
            // 
            this.Dosis.HeaderText = "Dosis";
            this.Dosis.Name = "Dosis";
            this.Dosis.Width = 140;
            // 
            // Frecuencia
            // 
            this.Frecuencia.HeaderText = "Frecuencia";
            this.Frecuencia.Name = "Frecuencia";
            this.Frecuencia.Width = 140;
            // 
            // CantidadPrescrita
            // 
            this.CantidadPrescrita.HeaderText = "Cantidad prescrita";
            this.CantidadPrescrita.Name = "CantidadPrescrita";
            this.CantidadPrescrita.Width = 140;
            // 
            // CantidadEntregar
            // 
            this.CantidadEntregar.HeaderText = "Cantidad a entregar";
            this.CantidadEntregar.Name = "CantidadEntregar";
            this.CantidadEntregar.Width = 140;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "Lista de medicamentos Prescritos";
            // 
            // PanelPago
            // 
            this.PanelPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelPago.Controls.Add(this.button2);
            this.PanelPago.Controls.Add(this.button1);
            this.PanelPago.Controls.Add(this.lblObservacion);
            this.PanelPago.Controls.Add(this.txbObservaciones);
            this.PanelPago.Controls.Add(this.cmbMetodoPago);
            this.PanelPago.Controls.Add(this.lblMetodoPago);
            this.PanelPago.Controls.Add(this.lblTitulo1);
            this.PanelPago.Location = new System.Drawing.Point(417, 95);
            this.PanelPago.Name = "PanelPago";
            this.PanelPago.Size = new System.Drawing.Size(387, 272);
            this.PanelPago.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(197, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 32);
            this.button2.TabIndex = 12;
            this.button2.Text = "Confirmar Dispensación";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(20, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "ImprimirComprobante";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(17, 98);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(161, 17);
            this.lblObservacion.TabIndex = 10;
            this.lblObservacion.Text = "Observacion de farmacia:";
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbObservaciones.Location = new System.Drawing.Point(20, 118);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(343, 96);
            this.txbObservaciones.TabIndex = 9;
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(20, 64);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(343, 21);
            this.cmbMetodoPago.TabIndex = 2;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.Location = new System.Drawing.Point(17, 42);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(113, 17);
            this.lblMetodoPago.TabIndex = 1;
            this.lblMetodoPago.Text = "Metodo de pago:";
            // 
            // lblTitulo1
            // 
            this.lblTitulo1.AutoSize = true;
            this.lblTitulo1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo1.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo1.Name = "lblTitulo1";
            this.lblTitulo1.Size = new System.Drawing.Size(108, 21);
            this.lblTitulo1.TabIndex = 0;
            this.lblTitulo1.Text = "Pago y notas";
            // 
            // pnlContenedorTitulo
            // 
            this.pnlContenedorTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.pnlContenedorTitulo.Controls.Add(this.lblTitulo);
            this.pnlContenedorTitulo.Location = new System.Drawing.Point(0, 6);
            this.pnlContenedorTitulo.Name = "pnlContenedorTitulo";
            this.pnlContenedorTitulo.Size = new System.Drawing.Size(856, 60);
            this.pnlContenedorTitulo.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitulo.Location = new System.Drawing.Point(24, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(244, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Farmacia";
            // 
            // PanelDetalles
            // 
            this.PanelDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelDetalles.Controls.Add(this.lblFechasEntrega);
            this.PanelDetalles.Controls.Add(this.txtFechas);
            this.PanelDetalles.Controls.Add(this.txtMedicos);
            this.PanelDetalles.Controls.Add(this.lblMedicos);
            this.PanelDetalles.Controls.Add(this.txtNumeroRecetas);
            this.PanelDetalles.Controls.Add(this.lblNumeroRecetas);
            this.PanelDetalles.Controls.Add(this.cmbPacientes);
            this.PanelDetalles.Controls.Add(this.lblPaciente);
            this.PanelDetalles.Controls.Add(this.lblTitulo2);
            this.PanelDetalles.Location = new System.Drawing.Point(16, 95);
            this.PanelDetalles.Name = "PanelDetalles";
            this.PanelDetalles.Size = new System.Drawing.Size(359, 272);
            this.PanelDetalles.TabIndex = 6;
            // 
            // lblFechasEntrega
            // 
            this.lblFechasEntrega.AutoSize = true;
            this.lblFechasEntrega.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechasEntrega.Location = new System.Drawing.Point(17, 210);
            this.lblFechasEntrega.Name = "lblFechasEntrega";
            this.lblFechasEntrega.Size = new System.Drawing.Size(106, 17);
            this.lblFechasEntrega.TabIndex = 8;
            this.lblFechasEntrega.Text = "Fecha de receta:";
            // 
            // txtFechas
            // 
            this.txtFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechas.Enabled = false;
            this.txtFechas.Location = new System.Drawing.Point(20, 232);
            this.txtFechas.Name = "txtFechas";
            this.txtFechas.Size = new System.Drawing.Size(277, 20);
            this.txtFechas.TabIndex = 7;
            // 
            // txtMedicos
            // 
            this.txtMedicos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedicos.Enabled = false;
            this.txtMedicos.Location = new System.Drawing.Point(20, 120);
            this.txtMedicos.Name = "txtMedicos";
            this.txtMedicos.Size = new System.Drawing.Size(277, 20);
            this.txtMedicos.TabIndex = 6;
            // 
            // lblMedicos
            // 
            this.lblMedicos.AutoSize = true;
            this.lblMedicos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicos.Location = new System.Drawing.Point(17, 98);
            this.lblMedicos.Name = "lblMedicos";
            this.lblMedicos.Size = new System.Drawing.Size(141, 17);
            this.lblMedicos.TabIndex = 5;
            this.lblMedicos.Text = "Medico que Prescribe:";
            // 
            // txtNumeroRecetas
            // 
            this.txtNumeroRecetas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroRecetas.Location = new System.Drawing.Point(20, 176);
            this.txtNumeroRecetas.Name = "txtNumeroRecetas";
            this.txtNumeroRecetas.Size = new System.Drawing.Size(277, 20);
            this.txtNumeroRecetas.TabIndex = 4;
            // 
            // lblNumeroRecetas
            // 
            this.lblNumeroRecetas.AutoSize = true;
            this.lblNumeroRecetas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroRecetas.Location = new System.Drawing.Point(17, 154);
            this.lblNumeroRecetas.Name = "lblNumeroRecetas";
            this.lblNumeroRecetas.Size = new System.Drawing.Size(121, 17);
            this.lblNumeroRecetas.TabIndex = 3;
            this.lblNumeroRecetas.Text = "Numero de receta:";
            // 
            // cmbPacientes
            // 
            this.cmbPacientes.FormattingEnabled = true;
            this.cmbPacientes.Location = new System.Drawing.Point(20, 64);
            this.cmbPacientes.Name = "cmbPacientes";
            this.cmbPacientes.Size = new System.Drawing.Size(277, 21);
            this.cmbPacientes.TabIndex = 2;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaciente.Location = new System.Drawing.Point(17, 42);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(62, 17);
            this.lblPaciente.TabIndex = 1;
            this.lblPaciente.Text = "Paciente:";
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo2.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(234, 21);
            this.lblTitulo2.TabIndex = 0;
            this.lblTitulo2.Text = "Detalles del paciente y receta";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.tabPage2.Controls.Add(this.btnActualizar);
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(848, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dispensación";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(438, 532);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(96, 27);
            this.btnActualizar.TabIndex = 36;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Location = new System.Drawing.Point(336, 532);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 27);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(856, 60);
            this.panel3.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(24, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 32);
            this.label13.TabIndex = 0;
            this.label13.Text = "Gestión de Farmacia";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dgwListaActual);
            this.panel2.Controls.Add(this.btnVerStock);
            this.panel2.Location = new System.Drawing.Point(336, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 442);
            this.panel2.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "Lista de inventario";
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
            this.dgwListaActual.Location = new System.Drawing.Point(20, 44);
            this.dgwListaActual.Name = "dgwListaActual";
            this.dgwListaActual.Size = new System.Drawing.Size(467, 377);
            this.dgwListaActual.TabIndex = 26;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 110;
            // 
            // Presentacion
            // 
            this.Presentacion.HeaderText = "Presentación";
            this.Presentacion.Name = "Presentacion";
            this.Presentacion.Width = 90;
            // 
            // StockActual
            // 
            this.StockActual.HeaderText = "Stock actual";
            this.StockActual.Name = "StockActual";
            this.StockActual.Width = 42;
            // 
            // StockMin
            // 
            this.StockMin.HeaderText = "Stock minimo";
            this.StockMin.Name = "StockMin";
            this.StockMin.Width = 42;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 60;
            // 
            // btnVerStock
            // 
            this.btnVerStock.BackColor = System.Drawing.Color.Gold;
            this.btnVerStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerStock.Location = new System.Drawing.Point(405, 9);
            this.btnVerStock.Name = "btnVerStock";
            this.btnVerStock.Size = new System.Drawing.Size(82, 26);
            this.btnVerStock.TabIndex = 25;
            this.btnVerStock.Text = "Ver stock bajo";
            this.btnVerStock.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbProveedor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtLote);
            this.panel1.Controls.Add(this.nudExitenciaActual);
            this.panel1.Controls.Add(this.nudExistenciaMinima);
            this.panel1.Controls.Add(this.dtpFechaVencimiento);
            this.panel1.Location = new System.Drawing.Point(11, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 490);
            this.panel1.TabIndex = 32;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(174, 445);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 27);
            this.btnLimpiar.TabIndex = 23;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(171, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Proveedor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Lote:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Fecha de vencimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(174, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Stock minimo:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(20, 176);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(277, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stock actual:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(20, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(277, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Codigo interno:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(46, 445);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(94, 27);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Presentación:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(174, 400);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(123, 21);
            this.cmbEstado.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del medicamento:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(20, 400);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(120, 21);
            this.cmbProveedor.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Detalles del medicamento:";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(20, 344);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(215, 20);
            this.txtLote.TabIndex = 19;
            // 
            // nudExitenciaActual
            // 
            this.nudExitenciaActual.Location = new System.Drawing.Point(20, 232);
            this.nudExitenciaActual.Name = "nudExitenciaActual";
            this.nudExitenciaActual.Size = new System.Drawing.Size(120, 20);
            this.nudExitenciaActual.TabIndex = 14;
            // 
            // nudExistenciaMinima
            // 
            this.nudExistenciaMinima.Location = new System.Drawing.Point(177, 232);
            this.nudExistenciaMinima.Name = "nudExistenciaMinima";
            this.nudExistenciaMinima.Size = new System.Drawing.Size(120, 20);
            this.nudExistenciaMinima.TabIndex = 16;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(20, 288);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(203, 20);
            this.dtpFechaVencimiento.TabIndex = 18;
            // 
            // Modulo7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Modulo7";
            this.Size = new System.Drawing.Size(856, 609);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.PanelTabla.ResumeLayout(false);
            this.PanelTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaMedicamentos)).EndInit();
            this.PanelPago.ResumeLayout(false);
            this.PanelPago.PerformLayout();
            this.pnlContenedorTitulo.ResumeLayout(false);
            this.pnlContenedorTitulo.PerformLayout();
            this.PanelDetalles.ResumeLayout(false);
            this.PanelDetalles.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaActual)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExitenciaActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExistenciaMinima)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel PanelDetalles;
        private System.Windows.Forms.Label lblFechasEntrega;
        private System.Windows.Forms.TextBox txtFechas;
        private System.Windows.Forms.TextBox txtMedicos;
        private System.Windows.Forms.Label lblMedicos;
        private System.Windows.Forms.TextBox txtNumeroRecetas;
        private System.Windows.Forms.Label lblNumeroRecetas;
        private System.Windows.Forms.ComboBox cmbPacientes;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblTitulo2;
        private System.Windows.Forms.Panel pnlContenedorTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel PanelPago;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblTitulo1;
        private System.Windows.Forms.Panel PanelTabla;
        private System.Windows.Forms.DataGridView ListaMedicamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medicamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPrescrita;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEntregar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.NumericUpDown nudExitenciaActual;
        private System.Windows.Forms.NumericUpDown nudExistenciaMinima;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgwListaActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button btnVerStock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
    }
}
