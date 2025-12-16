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
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.comboBoxVista = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDetallesCita = new System.Windows.Forms.Button();
            this.dgvCVistaCitas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerFechacita = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_NameMedico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubTituloSeleccion = new System.Windows.Forms.Label();
            this.lblTituloSeleccion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelNuevaCita = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxEstadoCitaAgregar = new System.Windows.Forms.ComboBox();
            this.comboBoxEspecialidadAgregar = new System.Windows.Forms.ComboBox();
            this.comboBoxPaciente = new System.Windows.Forms.ComboBox();
            this.btnGuardarCita = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxTipoCitaAgregar = new System.Windows.Forms.ComboBox();
            this.lblTituloAgendarCita = new System.Windows.Forms.Label();
            this.dtpFechaDelRegisgtro = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvEditarCitas = new System.Windows.Forms.DataGridView();
            this.tbAgendaCita.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCVistaCitas)).BeginInit();
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
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.comboBoxFiltro);
            this.tabPage1.Controls.Add(this.comboBoxVista);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnDetallesCita);
            this.tabPage1.Controls.Add(this.dgvCVistaCitas);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lblSubTituloSeleccion);
            this.tabPage1.Controls.Add(this.lblTituloSeleccion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1331, 892);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agenda";
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Items.AddRange(new object[] {
            "Programada",
            "Atendida",
            "Cancelada",
            "No Asistió"});
            this.comboBoxFiltro.Location = new System.Drawing.Point(664, 422);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(292, 31);
            this.comboBoxFiltro.TabIndex = 12;
            // 
            // comboBoxVista
            // 
            this.comboBoxVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVista.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVista.FormattingEnabled = true;
            this.comboBoxVista.Items.AddRange(new object[] {
            "Semana",
            "Dia"});
            this.comboBoxVista.Location = new System.Drawing.Point(193, 422);
            this.comboBoxVista.Name = "comboBoxVista";
            this.comboBoxVista.Size = new System.Drawing.Size(292, 31);
            this.comboBoxVista.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Vista (Semana/Dia)";
            // 
            // btnDetallesCita
            // 
            this.btnDetallesCita.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDetallesCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallesCita.ForeColor = System.Drawing.Color.White;
            this.btnDetallesCita.Location = new System.Drawing.Point(532, 800);
            this.btnDetallesCita.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetallesCita.Name = "btnDetallesCita";
            this.btnDetallesCita.Size = new System.Drawing.Size(364, 46);
            this.btnDetallesCita.TabIndex = 28;
            this.btnDetallesCita.Text = "Ver detalles";
            this.btnDetallesCita.UseVisualStyleBackColor = false;
            this.btnDetallesCita.Click += new System.EventHandler(this.btnDetallesCita_Click);
            // 
            // dgvCVistaCitas
            // 
            this.dgvCVistaCitas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCVistaCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCVistaCitas.Location = new System.Drawing.Point(31, 466);
            this.dgvCVistaCitas.Name = "dgvCVistaCitas";
            this.dgvCVistaCitas.RowHeadersWidth = 51;
            this.dgvCVistaCitas.RowTemplate.Height = 24;
            this.dgvCVistaCitas.Size = new System.Drawing.Size(1245, 289);
            this.dgvCVistaCitas.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimePickerFechacita);
            this.panel1.Controls.Add(this.comboBoxEspecialidad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox_NameMedico);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(31, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1245, 282);
            this.panel1.TabIndex = 12;
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
            // dateTimePickerFechacita
            // 
            this.dateTimePickerFechacita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechacita.Location = new System.Drawing.Point(24, 220);
            this.dateTimePickerFechacita.Name = "dateTimePickerFechacita";
            this.dateTimePickerFechacita.Size = new System.Drawing.Size(329, 30);
            this.dateTimePickerFechacita.TabIndex = 6;
            // 
            // comboBoxEspecialidad
            // 
            this.comboBoxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEspecialidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEspecialidad.FormattingEnabled = true;
            this.comboBoxEspecialidad.Location = new System.Drawing.Point(23, 141);
            this.comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            this.comboBoxEspecialidad.Size = new System.Drawing.Size(633, 31);
            this.comboBoxEspecialidad.TabIndex = 5;
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
            // comboBox_NameMedico
            // 
            this.comboBox_NameMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NameMedico.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_NameMedico.FormattingEnabled = true;
            this.comboBox_NameMedico.Location = new System.Drawing.Point(25, 60);
            this.comboBox_NameMedico.Name = "comboBox_NameMedico";
            this.comboBox_NameMedico.Size = new System.Drawing.Size(631, 31);
            this.comboBox_NameMedico.TabIndex = 3;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(603, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtros";
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
            this.panelNuevaCita.AutoScroll = true;
            this.panelNuevaCita.BackColor = System.Drawing.Color.White;
            this.panelNuevaCita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNuevaCita.Controls.Add(this.label9);
            this.panelNuevaCita.Controls.Add(this.comboBoxEstadoCitaAgregar);
            this.panelNuevaCita.Controls.Add(this.comboBoxEspecialidadAgregar);
            this.panelNuevaCita.Controls.Add(this.comboBoxPaciente);
            this.panelNuevaCita.Controls.Add(this.btnGuardarCita);
            this.panelNuevaCita.Controls.Add(this.label8);
            this.panelNuevaCita.Controls.Add(this.comboBoxTipoCitaAgregar);
            this.panelNuevaCita.Controls.Add(this.lblTituloAgendarCita);
            this.panelNuevaCita.Controls.Add(this.dtpFechaDelRegisgtro);
            this.panelNuevaCita.Controls.Add(this.label25);
            this.panelNuevaCita.Controls.Add(this.txtMotivo);
            this.panelNuevaCita.Controls.Add(this.label24);
            this.panelNuevaCita.Controls.Add(this.label23);
            this.panelNuevaCita.Controls.Add(this.label22);
            this.panelNuevaCita.Controls.Add(this.cmbMedico);
            this.panelNuevaCita.Controls.Add(this.label21);
            this.panelNuevaCita.Controls.Add(this.label20);
            this.panelNuevaCita.Controls.Add(this.dtpFecha);
            this.panelNuevaCita.Location = new System.Drawing.Point(6, 3);
            this.panelNuevaCita.Name = "panelNuevaCita";
            this.panelNuevaCita.Size = new System.Drawing.Size(1283, 893);
            this.panelNuevaCita.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 23);
            this.label9.TabIndex = 33;
            this.label9.Text = "Estado de cita";
            // 
            // comboBoxEstadoCitaAgregar
            // 
            this.comboBoxEstadoCitaAgregar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoCitaAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstadoCitaAgregar.FormattingEnabled = true;
            this.comboBoxEstadoCitaAgregar.Items.AddRange(new object[] {
            "Programada",
            "Atendida",
            "Cancelada",
            "No Asistió"});
            this.comboBoxEstadoCitaAgregar.Location = new System.Drawing.Point(20, 472);
            this.comboBoxEstadoCitaAgregar.Name = "comboBoxEstadoCitaAgregar";
            this.comboBoxEstadoCitaAgregar.Size = new System.Drawing.Size(268, 31);
            this.comboBoxEstadoCitaAgregar.TabIndex = 32;
            // 
            // comboBoxEspecialidadAgregar
            // 
            this.comboBoxEspecialidadAgregar.Enabled = false;
            this.comboBoxEspecialidadAgregar.FormattingEnabled = true;
            this.comboBoxEspecialidadAgregar.Location = new System.Drawing.Point(19, 319);
            this.comboBoxEspecialidadAgregar.Name = "comboBoxEspecialidadAgregar";
            this.comboBoxEspecialidadAgregar.Size = new System.Drawing.Size(584, 33);
            this.comboBoxEspecialidadAgregar.TabIndex = 31;
            // 
            // comboBoxPaciente
            // 
            this.comboBoxPaciente.FormattingEnabled = true;
            this.comboBoxPaciente.Location = new System.Drawing.Point(19, 133);
            this.comboBoxPaciente.Name = "comboBoxPaciente";
            this.comboBoxPaciente.Size = new System.Drawing.Size(584, 33);
            this.comboBoxPaciente.TabIndex = 30;
            // 
            // btnGuardarCita
            // 
            this.btnGuardarCita.BackColor = System.Drawing.Color.OliveDrab;
            this.btnGuardarCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCita.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardarCita.Location = new System.Drawing.Point(333, 837);
            this.btnGuardarCita.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCita.Name = "btnGuardarCita";
            this.btnGuardarCita.Size = new System.Drawing.Size(584, 44);
            this.btnGuardarCita.TabIndex = 26;
            this.btnGuardarCita.Text = "Guardar Cita";
            this.btnGuardarCita.UseVisualStyleBackColor = false;
            this.btnGuardarCita.Click += new System.EventHandler(this.btnGuardarCita_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 23);
            this.label8.TabIndex = 29;
            this.label8.Text = "Tipo de cita";
            // 
            // comboBoxTipoCitaAgregar
            // 
            this.comboBoxTipoCitaAgregar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCitaAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoCitaAgregar.FormattingEnabled = true;
            this.comboBoxTipoCitaAgregar.Items.AddRange(new object[] {
            "control",
            "urgencia",
            "telecita"});
            this.comboBoxTipoCitaAgregar.Location = new System.Drawing.Point(20, 393);
            this.comboBoxTipoCitaAgregar.Name = "comboBoxTipoCitaAgregar";
            this.comboBoxTipoCitaAgregar.Size = new System.Drawing.Size(268, 31);
            this.comboBoxTipoCitaAgregar.TabIndex = 28;
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
            // dtpFechaDelRegisgtro
            // 
            this.dtpFechaDelRegisgtro.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDelRegisgtro.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFechaDelRegisgtro.Location = new System.Drawing.Point(20, 646);
            this.dtpFechaDelRegisgtro.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaDelRegisgtro.Name = "dtpFechaDelRegisgtro";
            this.dtpFechaDelRegisgtro.ShowUpDown = true;
            this.dtpFechaDelRegisgtro.Size = new System.Drawing.Size(583, 30);
            this.dtpFechaDelRegisgtro.TabIndex = 25;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(15, 616);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 23);
            this.label25.TabIndex = 24;
            this.label25.Text = "Hora";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(20, 731);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(1195, 100);
            this.txtMotivo.TabIndex = 23;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(15, 698);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(156, 23);
            this.label24.TabIndex = 22;
            this.label24.Text = "Motivo de consulta";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(16, 521);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 23);
            this.label23.TabIndex = 20;
            this.label23.Text = "Fecha de la cita";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(15, 277);
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
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(19, 548);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(583, 30);
            this.dtpFecha.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dgvEditarCitas);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1331, 892);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Editar";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(634, 776);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(657, 46);
            this.button1.TabIndex = 27;
            this.button1.Text = "Guardar Cambios";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // 
            // Modulo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbAgendaCita);
            this.Name = "Modulo2";
            this.Size = new System.Drawing.Size(1359, 973);
            this.tbAgendaCita.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCVistaCitas)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechacita;
        private System.Windows.Forms.ComboBox comboBoxEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_NameMedico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCVistaCitas;
        private System.Windows.Forms.Panel panelNuevaCita;
        private System.Windows.Forms.Label lblTituloAgendarCita;
        private System.Windows.Forms.Button btnGuardarCita;
        private System.Windows.Forms.DateTimePicker dtpFechaDelRegisgtro;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEditarCitas;
        private System.Windows.Forms.ComboBox comboBoxVista;
        private System.Windows.Forms.Button btnDetallesCita;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxTipoCitaAgregar;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.ComboBox comboBoxPaciente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxEstadoCitaAgregar;
        private System.Windows.Forms.ComboBox comboBoxEspecialidadAgregar;
        private System.Windows.Forms.Label label22;
    }
}