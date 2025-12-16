namespace Borrador
{
    partial class Modulo5
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
            this.dataGridViewListaExamenes = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPrioridad = new System.Windows.Forms.ComboBox();
            this.textBoxIDOrden = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxEstadoOrden = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxTipoMuestra = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaSolicitud = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMedicoSolicitante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIndicaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_GenerarOrden = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonGuardarResgistrosResultados = new System.Windows.Forms.Button();
            this.textBoxComentariosInterpretacion = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dataGridViewExamenesResultados = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxIDOrdenLab = new System.Windows.Forms.ComboBox();
            this.comboBoxEstadoResultado = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxValidadoPor = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaProcesamiento = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPaciente = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPaciente = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaExamenes)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExamenesResultados)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1290, 944);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.tabPage1.Controls.Add(this.dataGridViewListaExamenes);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxIndicaciones);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bt_GenerarOrden);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1282, 906);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Solicitar examenes";
            // 
            // dataGridViewListaExamenes
            // 
            this.dataGridViewListaExamenes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewListaExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListaExamenes.Location = new System.Drawing.Point(33, 504);
            this.dataGridViewListaExamenes.Name = "dataGridViewListaExamenes";
            this.dataGridViewListaExamenes.RowHeadersWidth = 51;
            this.dataGridViewListaExamenes.RowTemplate.Height = 24;
            this.dataGridViewListaExamenes.Size = new System.Drawing.Size(1221, 203);
            this.dataGridViewListaExamenes.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(33, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1221, 100);
            this.panel2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Sistema de Gestión";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(356, 51);
            this.label6.TabIndex = 8;
            this.label6.Text = "Solicitar exámenes";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBoxPaciente);
            this.panel1.Controls.Add(this.comboBoxPrioridad);
            this.panel1.Controls.Add(this.textBoxIDOrden);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.comboBoxEstadoOrden);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.comboBoxTipoMuestra);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateTimePickerFechaSolicitud);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxMedicoSolicitante);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(33, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 289);
            this.panel1.TabIndex = 6;
            // 
            // comboBoxPrioridad
            // 
            this.comboBoxPrioridad.FormattingEnabled = true;
            this.comboBoxPrioridad.Items.AddRange(new object[] {
            "Rutina",
            "Urgente"});
            this.comboBoxPrioridad.Location = new System.Drawing.Point(946, 58);
            this.comboBoxPrioridad.Name = "comboBoxPrioridad";
            this.comboBoxPrioridad.Size = new System.Drawing.Size(121, 33);
            this.comboBoxPrioridad.TabIndex = 21;
            // 
            // textBoxIDOrden
            // 
            this.textBoxIDOrden.Enabled = false;
            this.textBoxIDOrden.Location = new System.Drawing.Point(36, 60);
            this.textBoxIDOrden.Name = "textBoxIDOrden";
            this.textBoxIDOrden.Size = new System.Drawing.Size(100, 31);
            this.textBoxIDOrden.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(39, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 25);
            this.label21.TabIndex = 19;
            this.label21.Text = "ID Orden";
            // 
            // comboBoxEstadoOrden
            // 
            this.comboBoxEstadoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoOrden.FormattingEnabled = true;
            this.comboBoxEstadoOrden.Location = new System.Drawing.Point(500, 223);
            this.comboBoxEstadoOrden.Name = "comboBoxEstadoOrden";
            this.comboBoxEstadoOrden.Size = new System.Drawing.Size(265, 33);
            this.comboBoxEstadoOrden.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(496, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Estado orden";
            // 
            // comboBoxTipoMuestra
            // 
            this.comboBoxTipoMuestra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoMuestra.FormattingEnabled = true;
            this.comboBoxTipoMuestra.Location = new System.Drawing.Point(35, 223);
            this.comboBoxTipoMuestra.Name = "comboBoxTipoMuestra";
            this.comboBoxTipoMuestra.Size = new System.Drawing.Size(290, 33);
            this.comboBoxTipoMuestra.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "Tipo de muestra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(496, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fecha y hora de solicitud";
            // 
            // dateTimePickerFechaSolicitud
            // 
            this.dateTimePickerFechaSolicitud.Location = new System.Drawing.Point(500, 134);
            this.dateTimePickerFechaSolicitud.Name = "dateTimePickerFechaSolicitud";
            this.dateTimePickerFechaSolicitud.Size = new System.Drawing.Size(340, 31);
            this.dateTimePickerFechaSolicitud.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(942, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Prioridad";
            // 
            // comboBoxMedicoSolicitante
            // 
            this.comboBoxMedicoSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMedicoSolicitante.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMedicoSolicitante.FormattingEnabled = true;
            this.comboBoxMedicoSolicitante.Location = new System.Drawing.Point(36, 134);
            this.comboBoxMedicoSolicitante.Name = "comboBoxMedicoSolicitante";
            this.comboBoxMedicoSolicitante.Size = new System.Drawing.Size(290, 31);
            this.comboBoxMedicoSolicitante.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Médico solicitante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(496, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de exámenes";
            // 
            // textBoxIndicaciones
            // 
            this.textBoxIndicaciones.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxIndicaciones.Location = new System.Drawing.Point(33, 752);
            this.textBoxIndicaciones.Multiline = true;
            this.textBoxIndicaciones.Name = "textBoxIndicaciones";
            this.textBoxIndicaciones.Size = new System.Drawing.Size(580, 137);
            this.textBoxIndicaciones.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 718);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Indicaciones";
            // 
            // bt_GenerarOrden
            // 
            this.bt_GenerarOrden.BackColor = System.Drawing.Color.Green;
            this.bt_GenerarOrden.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bt_GenerarOrden.Location = new System.Drawing.Point(708, 802);
            this.bt_GenerarOrden.Name = "bt_GenerarOrden";
            this.bt_GenerarOrden.Size = new System.Drawing.Size(241, 52);
            this.bt_GenerarOrden.TabIndex = 1;
            this.bt_GenerarOrden.Text = "Generar Orden";
            this.bt_GenerarOrden.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.buttonGuardarResgistrosResultados);
            this.tabPage2.Controls.Add(this.textBoxComentariosInterpretacion);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.dataGridViewExamenesResultados);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1282, 906);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registrar resultados validados";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(800, 809);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 52);
            this.button2.TabIndex = 15;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonGuardarResgistrosResultados
            // 
            this.buttonGuardarResgistrosResultados.BackColor = System.Drawing.Color.Green;
            this.buttonGuardarResgistrosResultados.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardarResgistrosResultados.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonGuardarResgistrosResultados.Location = new System.Drawing.Point(800, 724);
            this.buttonGuardarResgistrosResultados.Name = "buttonGuardarResgistrosResultados";
            this.buttonGuardarResgistrosResultados.Size = new System.Drawing.Size(241, 52);
            this.buttonGuardarResgistrosResultados.TabIndex = 14;
            this.buttonGuardarResgistrosResultados.Text = "Guardar";
            this.buttonGuardarResgistrosResultados.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonGuardarResgistrosResultados.UseVisualStyleBackColor = false;
            // 
            // textBoxComentariosInterpretacion
            // 
            this.textBoxComentariosInterpretacion.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxComentariosInterpretacion.Location = new System.Drawing.Point(47, 724);
            this.textBoxComentariosInterpretacion.Multiline = true;
            this.textBoxComentariosInterpretacion.Name = "textBoxComentariosInterpretacion";
            this.textBoxComentariosInterpretacion.Size = new System.Drawing.Size(726, 137);
            this.textBoxComentariosInterpretacion.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(40, 690);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(227, 23);
            this.label20.TabIndex = 12;
            this.label20.Text = "Comentarios/ Interpretación";
            // 
            // dataGridViewExamenesResultados
            // 
            this.dataGridViewExamenesResultados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewExamenesResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExamenesResultados.Location = new System.Drawing.Point(39, 519);
            this.dataGridViewExamenesResultados.Name = "dataGridViewExamenesResultados";
            this.dataGridViewExamenesResultados.RowHeadersWidth = 51;
            this.dataGridViewExamenesResultados.RowTemplate.Height = 24;
            this.dataGridViewExamenesResultados.Size = new System.Drawing.Size(1218, 127);
            this.dataGridViewExamenesResultados.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(41, 485);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(223, 25);
            this.label19.TabIndex = 10;
            this.label19.Text = "Lista exámenes/Resultados";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.comboBoxIDOrdenLab);
            this.panel4.Controls.Add(this.comboBoxEstadoResultado);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.comboBoxValidadoPor);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.dateTimePickerFechaProcesamiento);
            this.panel4.Controls.Add(this.comboBoxPaciente);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Location = new System.Drawing.Point(41, 164);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1216, 281);
            this.panel4.TabIndex = 9;
            // 
            // comboBoxIDOrdenLab
            // 
            this.comboBoxIDOrdenLab.FormattingEnabled = true;
            this.comboBoxIDOrdenLab.Location = new System.Drawing.Point(35, 48);
            this.comboBoxIDOrdenLab.Name = "comboBoxIDOrdenLab";
            this.comboBoxIDOrdenLab.Size = new System.Drawing.Size(290, 33);
            this.comboBoxIDOrdenLab.TabIndex = 21;
            // 
            // comboBoxEstadoResultado
            // 
            this.comboBoxEstadoResultado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstadoResultado.FormattingEnabled = true;
            this.comboBoxEstadoResultado.Location = new System.Drawing.Point(500, 44);
            this.comboBoxEstadoResultado.Name = "comboBoxEstadoResultado";
            this.comboBoxEstadoResultado.Size = new System.Drawing.Size(337, 31);
            this.comboBoxEstadoResultado.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(496, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 23);
            this.label16.TabIndex = 19;
            this.label16.Text = "Estado resultados";
            // 
            // comboBoxValidadoPor
            // 
            this.comboBoxValidadoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValidadoPor.FormattingEnabled = true;
            this.comboBoxValidadoPor.Location = new System.Drawing.Point(35, 229);
            this.comboBoxValidadoPor.Name = "comboBoxValidadoPor";
            this.comboBoxValidadoPor.Size = new System.Drawing.Size(290, 33);
            this.comboBoxValidadoPor.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(32, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 23);
            this.label14.TabIndex = 15;
            this.label14.Text = "Validado por";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(494, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(196, 23);
            this.label15.TabIndex = 14;
            this.label15.Text = "Fecha de procesamiento";
            // 
            // dateTimePickerFechaProcesamiento
            // 
            this.dateTimePickerFechaProcesamiento.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaProcesamiento.Location = new System.Drawing.Point(498, 130);
            this.dateTimePickerFechaProcesamiento.Name = "dateTimePickerFechaProcesamiento";
            this.dateTimePickerFechaProcesamiento.Size = new System.Drawing.Size(339, 31);
            this.dateTimePickerFechaProcesamiento.TabIndex = 8;
            // 
            // comboBoxPaciente
            // 
            this.comboBoxPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaciente.FormattingEnabled = true;
            this.comboBoxPaciente.Location = new System.Drawing.Point(35, 130);
            this.comboBoxPaciente.Name = "comboBoxPaciente";
            this.comboBoxPaciente.Size = new System.Drawing.Size(290, 33);
            this.comboBoxPaciente.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(31, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 23);
            this.label17.TabIndex = 9;
            this.label17.Text = "Paciente";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(31, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(173, 23);
            this.label18.TabIndex = 7;
            this.label18.Text = "ID Orden Laboratorio";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(41, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1216, 100);
            this.panel3.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 23);
            this.label11.TabIndex = 14;
            this.label11.Text = "Sistema de Gestión";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(493, 51);
            this.label12.TabIndex = 8;
            this.label12.Text = "Registro de resultados L.V.";
            // 
            // textBoxPaciente
            // 
            this.textBoxPaciente.FormattingEnabled = true;
            this.textBoxPaciente.Location = new System.Drawing.Point(500, 48);
            this.textBoxPaciente.Name = "textBoxPaciente";
            this.textBoxPaciente.Size = new System.Drawing.Size(340, 33);
            this.textBoxPaciente.TabIndex = 22;
            // 
            // Modulo5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Modulo5";
            this.Size = new System.Drawing.Size(1296, 950);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaExamenes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExamenesResultados)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_GenerarOrden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMedicoSolicitante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEstadoOrden;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxTipoMuestra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaSolicitud;
        private System.Windows.Forms.DataGridView dataGridViewListaExamenes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxValidadoPor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaProcesamiento;
        private System.Windows.Forms.ComboBox comboBoxPaciente;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonGuardarResgistrosResultados;
        private System.Windows.Forms.TextBox textBoxComentariosInterpretacion;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dataGridViewExamenesResultados;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxIndicaciones;
        private System.Windows.Forms.TextBox textBoxIDOrden;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxEstadoResultado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxIDOrdenLab;
        private System.Windows.Forms.ComboBox comboBoxPrioridad;
        private System.Windows.Forms.ComboBox textBoxPaciente;
    }
}