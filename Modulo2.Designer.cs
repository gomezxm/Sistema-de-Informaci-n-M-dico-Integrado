namespace Borrador
{
    partial class Modulo2
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
            this.tbAgendaCita = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.cmbVistaSemanaDia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.dgvVistaCitas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtmFechaDeCita = new System.Windows.Forms.DateTimePicker();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMedico2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubTituloSeleccion = new System.Windows.Forms.Label();
            this.lblTituloSeleccion = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelNuevaCita = new System.Windows.Forms.Panel();
            this.cmbConsultorio = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardarCita = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoDeCita = new System.Windows.Forms.ComboBox();
            this.lblTituloAgendarCita = new System.Windows.Forms.Label();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpFechaDeLaCita = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvEditarCitas = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbAgendaCita.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaCitas)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelNuevaCita.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditarCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAgendaCita
            // 
            this.tbAgendaCita.Controls.Add(this.tabPage1);
            this.tbAgendaCita.Controls.Add(this.tabPage2);
            this.tbAgendaCita.Controls.Add(this.tabPage3);
            this.tbAgendaCita.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAgendaCita.Location = new System.Drawing.Point(0, 18);
            this.tbAgendaCita.Name = "tbAgendaCita";
            this.tbAgendaCita.SelectedIndex = 0;
            this.tbAgendaCita.Size = new System.Drawing.Size(1339, 930);
            this.tbAgendaCita.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnRefrescar);
            this.tabPage1.Controls.Add(this.cmbVistaSemanaDia);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnVerDetalles);
            this.tabPage1.Controls.Add(this.dgvVistaCitas);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lblSubTituloSeleccion);
            this.tabPage1.Controls.Add(this.lblTituloSeleccion);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1331, 892);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agenda";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Gray;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(807, 839);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(346, 46);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.AccessibleDescription = "CTRL + S";
            this.btnRefrescar.BackColor = System.Drawing.Color.Green;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(27, 839);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(346, 46);
            this.btnRefrescar.TabIndex = 29;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // cmbVistaSemanaDia
            // 
            this.cmbVistaSemanaDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVistaSemanaDia.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVistaSemanaDia.FormattingEnabled = true;
            this.cmbVistaSemanaDia.Items.AddRange(new object[] {
            "Semana",
            "Dia"});
            this.cmbVistaSemanaDia.Location = new System.Drawing.Point(193, 487);
            this.cmbVistaSemanaDia.Name = "cmbVistaSemanaDia";
            this.cmbVistaSemanaDia.Size = new System.Drawing.Size(292, 31);
            this.cmbVistaSemanaDia.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 490);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Vista (Semana/Dia)";
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnVerDetalles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalles.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalles.Location = new System.Drawing.Point(393, 839);
            this.btnVerDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(364, 46);
            this.btnVerDetalles.TabIndex = 28;
            this.btnVerDetalles.Text = "Ver detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = false;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // dgvVistaCitas
            // 
            this.dgvVistaCitas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVistaCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaCitas.Location = new System.Drawing.Point(31, 531);
            this.dgvVistaCitas.Name = "dgvVistaCitas";
            this.dgvVistaCitas.ReadOnly = true;
            this.dgvVistaCitas.RowHeadersWidth = 51;
            this.dgvVistaCitas.RowTemplate.Height = 24;
            this.dgvVistaCitas.Size = new System.Drawing.Size(1245, 289);
            this.dgvVistaCitas.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = "";
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtmFechaDeCita);
            this.panel1.Controls.Add(this.cmbEspecialidad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbMedico2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(31, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1245, 359);
            this.panel1.TabIndex = 12;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(24, 299);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(632, 31);
            this.cmbEstado.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de cita*";
            // 
            // dtmFechaDeCita
            // 
            this.dtmFechaDeCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFechaDeCita.Location = new System.Drawing.Point(24, 220);
            this.dtmFechaDeCita.Name = "dtmFechaDeCita";
            this.dtmFechaDeCita.ShowCheckBox = true;
            this.dtmFechaDeCita.Size = new System.Drawing.Size(329, 30);
            this.dtmFechaDeCita.TabIndex = 6;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(25, 141);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(633, 31);
            this.cmbEspecialidad.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Especialidad";
            // 
            // cmbMedico2
            // 
            this.cmbMedico2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedico2.FormattingEnabled = true;
            this.cmbMedico2.Location = new System.Drawing.Point(25, 60);
            this.cmbMedico2.Name = "cmbMedico2";
            this.cmbMedico2.Size = new System.Drawing.Size(631, 31);
            this.cmbMedico2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Médico*";
            // 
            // lblSubTituloSeleccion
            // 
            this.lblSubTituloSeleccion.AutoSize = true;
            this.lblSubTituloSeleccion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTituloSeleccion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubTituloSeleccion.Location = new System.Drawing.Point(26, 68);
            this.lblSubTituloSeleccion.Name = "lblSubTituloSeleccion";
            this.lblSubTituloSeleccion.Size = new System.Drawing.Size(444, 23);
            this.lblSubTituloSeleccion.TabIndex = 11;
            this.lblSubTituloSeleccion.Text = "Gestión de citas por médico, especialidad, estado y fecha";
            this.lblSubTituloSeleccion.Click += new System.EventHandler(this.lblSubTituloSeleccion_Click);
            // 
            // lblTituloSeleccion
            // 
            this.lblTituloSeleccion.AutoSize = true;
            this.lblTituloSeleccion.Font = new System.Drawing.Font("Segoe UI", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSeleccion.Location = new System.Drawing.Point(18, 10);
            this.lblTituloSeleccion.Name = "lblTituloSeleccion";
            this.lblTituloSeleccion.Size = new System.Drawing.Size(487, 51);
            this.lblTituloSeleccion.TabIndex = 3;
            this.lblTituloSeleccion.Text = "Manejo de Citas y Agenda";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelNuevaCita);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1331, 892);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Agregar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelNuevaCita
            // 
            this.panelNuevaCita.BackColor = System.Drawing.Color.White;
            this.panelNuevaCita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNuevaCita.Controls.Add(this.cmbConsultorio);
            this.panelNuevaCita.Controls.Add(this.label9);
            this.panelNuevaCita.Controls.Add(this.btnGuardarCita);
            this.panelNuevaCita.Controls.Add(this.label8);
            this.panelNuevaCita.Controls.Add(this.cmbTipoDeCita);
            this.panelNuevaCita.Controls.Add(this.lblTituloAgendarCita);
            this.panelNuevaCita.Controls.Add(this.btnLimpiarCampos);
            this.panelNuevaCita.Controls.Add(this.dtpHora);
            this.panelNuevaCita.Controls.Add(this.label25);
            this.panelNuevaCita.Controls.Add(this.txtMotivo);
            this.panelNuevaCita.Controls.Add(this.label24);
            this.panelNuevaCita.Controls.Add(this.txtEspecialidad);
            this.panelNuevaCita.Controls.Add(this.label23);
            this.panelNuevaCita.Controls.Add(this.label22);
            this.panelNuevaCita.Controls.Add(this.cmbMedico);
            this.panelNuevaCita.Controls.Add(this.label21);
            this.panelNuevaCita.Controls.Add(this.txtPaciente);
            this.panelNuevaCita.Controls.Add(this.label20);
            this.panelNuevaCita.Controls.Add(this.dtpFechaDeLaCita);
            this.panelNuevaCita.Location = new System.Drawing.Point(6, 3);
            this.panelNuevaCita.Name = "panelNuevaCita";
            this.panelNuevaCita.Size = new System.Drawing.Size(1283, 883);
            this.panelNuevaCita.TabIndex = 16;
            // 
            // cmbConsultorio
            // 
            this.cmbConsultorio.FormattingEnabled = true;
            this.cmbConsultorio.Location = new System.Drawing.Point(18, 423);
            this.cmbConsultorio.Name = "cmbConsultorio";
            this.cmbConsultorio.Size = new System.Drawing.Size(268, 33);
            this.cmbConsultorio.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 23);
            this.label9.TabIndex = 31;
            this.label9.Text = "Consultorio";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnGuardarCita
            // 
            this.btnGuardarCita.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGuardarCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCita.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardarCita.Location = new System.Drawing.Point(631, 799);
            this.btnGuardarCita.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCita.Name = "btnGuardarCita";
            this.btnGuardarCita.Size = new System.Drawing.Size(584, 46);
            this.btnGuardarCita.TabIndex = 26;
            this.btnGuardarCita.Text = "Guardar Cita";
            this.btnGuardarCita.UseVisualStyleBackColor = false;
            this.btnGuardarCita.Click += new System.EventHandler(this.btnGuardarCita_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 23);
            this.label8.TabIndex = 29;
            this.label8.Text = "Tipo de cita";
            // 
            // cmbTipoDeCita
            // 
            this.cmbTipoDeCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDeCita.FormattingEnabled = true;
            this.cmbTipoDeCita.Location = new System.Drawing.Point(18, 359);
            this.cmbTipoDeCita.Name = "cmbTipoDeCita";
            this.cmbTipoDeCita.Size = new System.Drawing.Size(268, 31);
            this.cmbTipoDeCita.TabIndex = 28;
            // 
            // lblTituloAgendarCita
            // 
            this.lblTituloAgendarCita.AutoSize = true;
            this.lblTituloAgendarCita.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTituloAgendarCita.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAgendarCita.ForeColor = System.Drawing.Color.Black;
            this.lblTituloAgendarCita.Location = new System.Drawing.Point(10, 16);
            this.lblTituloAgendarCita.Name = "lblTituloAgendarCita";
            this.lblTituloAgendarCita.Size = new System.Drawing.Size(210, 50);
            this.lblTituloAgendarCita.TabIndex = 1;
            this.lblTituloAgendarCita.Text = "Nueva Cita";
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.BackColor = System.Drawing.Color.Gray;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(19, 799);
            this.btnLimpiarCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(584, 46);
            this.btnLimpiarCampos.TabIndex = 27;
            this.btnLimpiarCampos.Text = "Limpiar ";
            this.btnLimpiarCampos.UseVisualStyleBackColor = false;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // dtpHora
            // 
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(20, 575);
            this.dtpHora.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(583, 30);
            this.dtpHora.TabIndex = 25;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(15, 545);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 23);
            this.label25.TabIndex = 24;
            this.label25.Text = "Hora";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(20, 680);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(1195, 99);
            this.txtMotivo.TabIndex = 23;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(15, 644);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(156, 23);
            this.label24.TabIndex = 22;
            this.label24.Text = "Motivo de consulta";
            this.label24.Click += new System.EventHandler(this.label24_Click);
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecialidad.Location = new System.Drawing.Point(19, 285);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEspecialidad.Multiline = true;
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(583, 31);
            this.txtEspecialidad.TabIndex = 21;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(15, 457);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 23);
            this.label23.TabIndex = 20;
            this.label23.Text = "Fecha de la cita";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(17, 260);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 23);
            this.label22.TabIndex = 19;
            this.label22.Text = "Especialidad";
            // 
            // cmbMedico
            // 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(20, 211);
            this.cmbMedico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(583, 33);
            this.cmbMedico.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(15, 182);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 23);
            this.label21.TabIndex = 17;
            this.label21.Text = "Médico";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(20, 120);
            this.txtPaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaciente.Multiline = true;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(583, 31);
            this.txtPaciente.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(15, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(171, 23);
            this.label20.TabIndex = 15;
            this.label20.Text = "Nombre del paciente";
            // 
            // dtpFechaDeLaCita
            // 
            this.dtpFechaDeLaCita.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDeLaCita.Location = new System.Drawing.Point(18, 484);
            this.dtpFechaDeLaCita.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaDeLaCita.Name = "dtpFechaDeLaCita";
            this.dtpFechaDeLaCita.Size = new System.Drawing.Size(583, 30);
            this.dtpFechaDeLaCita.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCancelarCita);
            this.tabPage3.Controls.Add(this.btnGuardarCambios);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dgvEditarCitas);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1331, 895);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Editar";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // btnCancelarCita
            // 
            this.btnCancelarCita.BackColor = System.Drawing.Color.Red;
            this.btnCancelarCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCita.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelarCita.Location = new System.Drawing.Point(13, 776);
            this.btnCancelarCita.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(576, 46);
            this.btnCancelarCita.TabIndex = 28;
            this.btnCancelarCita.Text = "Cancelar Cita";
            this.btnCancelarCita.UseVisualStyleBackColor = false;
            this.btnCancelarCita.Click += new System.EventHandler(this.btnCancelarCita_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardarCambios.Location = new System.Drawing.Point(693, 776);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(598, 46);
            this.btnGuardarCambios.TabIndex = 27;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 51);
            this.label6.TabIndex = 2;
            this.label6.Text = "Editar Citas";
            // 
            // dgvEditarCitas
            // 
            this.dgvEditarCitas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEditarCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditarCitas.Location = new System.Drawing.Point(13, 84);
            this.dgvEditarCitas.Name = "dgvEditarCitas";
            this.dgvEditarCitas.RowHeadersWidth = 51;
            this.dgvEditarCitas.RowTemplate.Height = 24;
            this.dgvEditarCitas.Size = new System.Drawing.Size(1278, 669);
            this.dgvEditarCitas.TabIndex = 0;
            this.dgvEditarCitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(790, 58);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 80);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Refrescar: Control + S\r\nLimpiar Campos: Control + N\r\nVer detalles: Control + D\r\n\r" +
    "\n";
            // 
            // Modulo2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tbAgendaCita);
            this.Name = "Modulo2";
            this.Size = new System.Drawing.Size(1359, 973);
            this.Load += new System.EventHandler(this.Modulo2_Load);
            this.tbAgendaCita.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaCitas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panelNuevaCita.ResumeLayout(false);
            this.panelNuevaCita.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditarCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbAgendaCita;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTituloSeleccion;
        private System.Windows.Forms.Label lblSubTituloSeleccion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtmFechaDeCita;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMedico2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvVistaCitas;
        private System.Windows.Forms.Panel panelNuevaCita;
        private System.Windows.Forms.Label lblTituloAgendarCita;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnGuardarCita;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpFechaDeLaCita;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEditarCitas;
        private System.Windows.Forms.ComboBox cmbVistaSemanaDia;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoDeCita;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbConsultorio;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.TextBox textBox1;
    }
}