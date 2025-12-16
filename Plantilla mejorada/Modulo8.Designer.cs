namespace Borrador
{
    partial class Modulo8
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
<<<<<<< HEAD
=======
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
>>>>>>> Dev
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cBMedicoR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttTasladar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bttAlta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bttAdmitir = new System.Windows.Forms.Button();
            this.txtbDiagnostico = new System.Windows.Forms.TextBox();
            this.dateTimer = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBMotivo = new System.Windows.Forms.TextBox();
            this.txtBIdHospitalizacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cBPaciente = new System.Windows.Forms.ComboBox();
            this.cBCama = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cBSala = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
<<<<<<< HEAD
            this.label13 = new System.Windows.Forms.Label();
            this.tableListaC = new System.Windows.Forms.DataGridView();
            this.idcamas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
=======
            this.tableListaC = new System.Windows.Forms.DataGridView();
>>>>>>> Dev
            this.btnDetalles_camas = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboxSala = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboxFiltradoC = new System.Windows.Forms.ComboBox();
<<<<<<< HEAD
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
=======
>>>>>>> Dev
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableListaC)).BeginInit();
            this.panel1.SuspendLayout();
<<<<<<< HEAD
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
=======
>>>>>>> Dev
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
<<<<<<< HEAD
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1351, 965);
=======
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1282, 915);
>>>>>>> Dev
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
<<<<<<< HEAD
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.bttTasladar);
            this.tabPage1.Controls.Add(this.bttAlta);
            this.tabPage1.Controls.Add(this.bttAdmitir);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1343, 932);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Admisión";
            this.tabPage1.UseVisualStyleBackColor = true;
=======
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.cBMedicoR);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bttTasladar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.bttAlta);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.bttAdmitir);
            this.tabPage1.Controls.Add(this.txtbDiagnostico);
            this.tabPage1.Controls.Add(this.dateTimer);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtBMotivo);
            this.tabPage1.Controls.Add(this.txtBIdHospitalizacion);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cBPaciente);
            this.tabPage1.Controls.Add(this.cBCama);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.cBSala);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1274, 879);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Admisión";
>>>>>>> Dev
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cBMedicoR
            // 
<<<<<<< HEAD
            this.cBMedicoR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMedicoR.FormattingEnabled = true;
            this.cBMedicoR.Location = new System.Drawing.Point(150, 153);
            this.cBMedicoR.Name = "cBMedicoR";
            this.cBMedicoR.Size = new System.Drawing.Size(329, 28);
=======
            this.cBMedicoR.BackColor = System.Drawing.Color.White;
            this.cBMedicoR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMedicoR.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBMedicoR.FormattingEnabled = true;
            this.cBMedicoR.Location = new System.Drawing.Point(1032, 17);
            this.cBMedicoR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBMedicoR.Name = "cBMedicoR";
            this.cBMedicoR.Size = new System.Drawing.Size(221, 31);
>>>>>>> Dev
            this.cBMedicoR.TabIndex = 18;
            // 
            // label1
            // 
<<<<<<< HEAD
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Hospitalizacion:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bttTasladar
            // 
            this.bttTasladar.Location = new System.Drawing.Point(228, 799);
            this.bttTasladar.Name = "bttTasladar";
            this.bttTasladar.Size = new System.Drawing.Size(90, 44);
            this.bttTasladar.TabIndex = 24;
            this.bttTasladar.Text = "Trasladar";
            this.bttTasladar.UseVisualStyleBackColor = true;
=======
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Hospitalizacion:";
            // 
            // bttTasladar
            // 
            this.bttTasladar.BackColor = System.Drawing.Color.Goldenrod;
            this.bttTasladar.FlatAppearance.BorderSize = 0;
            this.bttTasladar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttTasladar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttTasladar.ForeColor = System.Drawing.Color.White;
            this.bttTasladar.Location = new System.Drawing.Point(951, 812);
            this.bttTasladar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttTasladar.Name = "bttTasladar";
            this.bttTasladar.Size = new System.Drawing.Size(146, 47);
            this.bttTasladar.TabIndex = 24;
            this.bttTasladar.Text = "Trasladar";
            this.bttTasladar.UseVisualStyleBackColor = false;
>>>>>>> Dev
            // 
            // label2
            // 
            this.label2.AutoSize = true;
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(70, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
=======
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
>>>>>>> Dev
            this.label2.TabIndex = 1;
            this.label2.Text = "Paciente:";
            // 
            // bttAlta
            // 
<<<<<<< HEAD
            this.bttAlta.Location = new System.Drawing.Point(342, 799);
            this.bttAlta.Name = "bttAlta";
            this.bttAlta.Size = new System.Drawing.Size(90, 44);
            this.bttAlta.TabIndex = 23;
            this.bttAlta.Text = "Dar Alta";
            this.bttAlta.UseVisualStyleBackColor = true;
=======
            this.bttAlta.BackColor = System.Drawing.Color.Green;
            this.bttAlta.FlatAppearance.BorderSize = 0;
            this.bttAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttAlta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttAlta.ForeColor = System.Drawing.Color.White;
            this.bttAlta.Location = new System.Drawing.Point(1112, 812);
            this.bttAlta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttAlta.Name = "bttAlta";
            this.bttAlta.Size = new System.Drawing.Size(141, 47);
            this.bttAlta.TabIndex = 23;
            this.bttAlta.Text = "Dar Alta";
            this.bttAlta.UseVisualStyleBackColor = false;
            this.bttAlta.Click += new System.EventHandler(this.bttAlta_Click);
>>>>>>> Dev
            // 
            // label3
            // 
            this.label3.AutoSize = true;
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diagnostico de Ingreso:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // bttAdmitir
            // 
            this.bttAdmitir.Location = new System.Drawing.Point(99, 799);
            this.bttAdmitir.Name = "bttAdmitir";
            this.bttAdmitir.Size = new System.Drawing.Size(87, 44);
            this.bttAdmitir.TabIndex = 22;
            this.bttAdmitir.Text = "Admitir";
            this.bttAdmitir.UseVisualStyleBackColor = true;
            // 
            // txtbDiagnostico
            // 
            this.txtbDiagnostico.Location = new System.Drawing.Point(18, 53);
            this.txtbDiagnostico.MaxLength = 300;
            this.txtbDiagnostico.Multiline = true;
            this.txtbDiagnostico.Name = "txtbDiagnostico";
            this.txtbDiagnostico.Size = new System.Drawing.Size(519, 123);
            this.txtbDiagnostico.TabIndex = 3;
            this.txtbDiagnostico.TextChanged += new System.EventHandler(this.txtbDiagnostico_TextChanged);
            // 
            // dateTimer
            // 
            this.dateTimer.Location = new System.Drawing.Point(150, 216);
            this.dateTimer.Name = "dateTimer";
            this.dateTimer.Size = new System.Drawing.Size(329, 26);
=======
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diagnostico de Ingreso:";
            // 
            // bttAdmitir
            // 
            this.bttAdmitir.BackColor = System.Drawing.Color.RoyalBlue;
            this.bttAdmitir.FlatAppearance.BorderSize = 0;
            this.bttAdmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttAdmitir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttAdmitir.ForeColor = System.Drawing.Color.White;
            this.bttAdmitir.Location = new System.Drawing.Point(802, 812);
            this.bttAdmitir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttAdmitir.Name = "bttAdmitir";
            this.bttAdmitir.Size = new System.Drawing.Size(135, 47);
            this.bttAdmitir.TabIndex = 22;
            this.bttAdmitir.Text = "Admitir";
            this.bttAdmitir.UseVisualStyleBackColor = false;
            // 
            // txtbDiagnostico
            // 
            this.txtbDiagnostico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbDiagnostico.Location = new System.Drawing.Point(13, 217);
            this.txtbDiagnostico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbDiagnostico.MaxLength = 300;
            this.txtbDiagnostico.Multiline = true;
            this.txtbDiagnostico.Name = "txtbDiagnostico";
            this.txtbDiagnostico.Size = new System.Drawing.Size(1240, 176);
            this.txtbDiagnostico.TabIndex = 3;
            // 
            // dateTimer
            // 
            this.dateTimer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimer.Location = new System.Drawing.Point(857, 115);
            this.dateTimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimer.Name = "dateTimer";
            this.dateTimer.Size = new System.Drawing.Size(329, 30);
>>>>>>> Dev
            this.dateTimer.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
<<<<<<< HEAD
            this.label4.Location = new System.Drawing.Point(14, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Motivo de hospitalizacion:";
=======
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Motivo de hospitalizacion:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
>>>>>>> Dev
            // 
            // label10
            // 
            this.label10.AutoSize = true;
<<<<<<< HEAD
            this.label10.Location = new System.Drawing.Point(35, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 40);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fecha/Hora \r\nde Ingreso:";
            // 
            // txtBMotivo
            // 
            this.txtBMotivo.Location = new System.Drawing.Point(18, 218);
            this.txtBMotivo.MaxLength = 300;
            this.txtBMotivo.Multiline = true;
            this.txtBMotivo.Name = "txtBMotivo";
            this.txtBMotivo.Size = new System.Drawing.Size(519, 123);
=======
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(853, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fecha/Hora de Ingreso";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtBMotivo
            // 
            this.txtBMotivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBMotivo.Location = new System.Drawing.Point(13, 456);
            this.txtBMotivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBMotivo.MaxLength = 300;
            this.txtBMotivo.Multiline = true;
            this.txtBMotivo.Name = "txtBMotivo";
            this.txtBMotivo.Size = new System.Drawing.Size(1240, 266);
>>>>>>> Dev
            this.txtBMotivo.TabIndex = 6;
            // 
            // txtBIdHospitalizacion
            // 
<<<<<<< HEAD
            this.txtBIdHospitalizacion.Location = new System.Drawing.Point(151, 15);
            this.txtBIdHospitalizacion.MaxLength = 40;
            this.txtBIdHospitalizacion.Name = "txtBIdHospitalizacion";
            this.txtBIdHospitalizacion.Size = new System.Drawing.Size(328, 26);
=======
            this.txtBIdHospitalizacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBIdHospitalizacion.Location = new System.Drawing.Point(160, 14);
            this.txtBIdHospitalizacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBIdHospitalizacion.MaxLength = 40;
            this.txtBIdHospitalizacion.Name = "txtBIdHospitalizacion";
            this.txtBIdHospitalizacion.Size = new System.Drawing.Size(193, 30);
>>>>>>> Dev
            this.txtBIdHospitalizacion.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
<<<<<<< HEAD
            this.label9.Location = new System.Drawing.Point(35, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 40);
            this.label9.TabIndex = 17;
            this.label9.Text = "Medico \r\nresponsable:";
            // 
            // cBPaciente
            // 
            this.cBPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPaciente.FormattingEnabled = true;
            this.cBPaciente.Location = new System.Drawing.Point(151, 57);
            this.cBPaciente.Name = "cBPaciente";
            this.cBPaciente.Size = new System.Drawing.Size(328, 28);
=======
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(855, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Medico responsable:";
            // 
            // cBPaciente
            // 
            this.cBPaciente.BackColor = System.Drawing.Color.White;
            this.cBPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBPaciente.FormattingEnabled = true;
            this.cBPaciente.Location = new System.Drawing.Point(166, 89);
            this.cBPaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBPaciente.Name = "cBPaciente";
            this.cBPaciente.Size = new System.Drawing.Size(193, 31);
>>>>>>> Dev
            this.cBPaciente.TabIndex = 8;
            // 
            // cBCama
            // 
<<<<<<< HEAD
            this.cBCama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCama.FormattingEnabled = true;
            this.cBCama.Location = new System.Drawing.Point(150, 95);
            this.cBCama.Name = "cBCama";
            this.cBCama.Size = new System.Drawing.Size(329, 28);
=======
            this.cBCama.BackColor = System.Drawing.Color.White;
            this.cBCama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBCama.FormattingEnabled = true;
            this.cBCama.Location = new System.Drawing.Point(484, 89);
            this.cBCama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBCama.Name = "cBCama";
            this.cBCama.Size = new System.Drawing.Size(246, 31);
>>>>>>> Dev
            this.cBCama.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
<<<<<<< HEAD
            this.label5.Location = new System.Drawing.Point(96, 740);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
=======
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 766);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 23);
>>>>>>> Dev
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo de regimen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
<<<<<<< HEAD
            this.label8.Location = new System.Drawing.Point(77, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
=======
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(422, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 23);
>>>>>>> Dev
            this.label8.TabIndex = 15;
            this.label8.Text = "Cama:";
            // 
            // comboBox2
            // 
<<<<<<< HEAD
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
=======
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
>>>>>>> Dev
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Privada",
            "Seguro",
            "Estado"});
<<<<<<< HEAD
            this.comboBox2.Location = new System.Drawing.Point(228, 740);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(164, 28);
=======
            this.comboBox2.Location = new System.Drawing.Point(164, 763);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(166, 31);
>>>>>>> Dev
            this.comboBox2.TabIndex = 10;
            // 
            // cBSala
            // 
<<<<<<< HEAD
            this.cBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSala.FormattingEnabled = true;
            this.cBSala.Location = new System.Drawing.Point(150, 30);
            this.cBSala.Name = "cBSala";
            this.cBSala.Size = new System.Drawing.Size(329, 28);
=======
            this.cBSala.BackColor = System.Drawing.Color.White;
            this.cBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSala.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBSala.FormattingEnabled = true;
            this.cBSala.Location = new System.Drawing.Point(478, 16);
            this.cBSala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBSala.Name = "cBSala";
            this.cBSala.Size = new System.Drawing.Size(246, 31);
>>>>>>> Dev
            this.cBSala.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
<<<<<<< HEAD
            this.label6.Location = new System.Drawing.Point(417, 740);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
=======
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(354, 766);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 23);
>>>>>>> Dev
            this.label6.TabIndex = 11;
            this.label6.Text = "Estado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
<<<<<<< HEAD
            this.label7.Location = new System.Drawing.Point(87, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
=======
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(421, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 23);
>>>>>>> Dev
            this.label7.TabIndex = 13;
            this.label7.Text = "Sala:";
            // 
            // comboBox3
            // 
<<<<<<< HEAD
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
=======
            this.comboBox3.BackColor = System.Drawing.Color.White;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
>>>>>>> Dev
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Hospitalizado",
            "Alta",
            "Referido"});
<<<<<<< HEAD
            this.comboBox3.Location = new System.Drawing.Point(487, 740);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(361, 28);
=======
            this.comboBox3.Location = new System.Drawing.Point(425, 763);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(321, 31);
>>>>>>> Dev
            this.comboBox3.TabIndex = 12;
            // 
            // tabPage2
            // 
<<<<<<< HEAD
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1343, 932);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnRefrescar);
            this.panel2.Controls.Add(this.btnDetalles_camas);
            this.panel2.Controls.Add(this.tableListaC);
            this.panel2.Location = new System.Drawing.Point(53, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1205, 491);
            this.panel2.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Lista de camas";
            // 
=======
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1274, 879);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableListaC);
            this.panel2.Controls.Add(this.btnDetalles_camas);
            this.panel2.Controls.Add(this.btnRefrescar);
            this.panel2.Location = new System.Drawing.Point(47, 141);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 717);
            this.panel2.TabIndex = 9;
            // 
>>>>>>> Dev
            // tableListaC
            // 
            this.tableListaC.AllowUserToAddRows = false;
            this.tableListaC.AllowUserToDeleteRows = false;
<<<<<<< HEAD
            this.tableListaC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableListaC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcamas,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.tableListaC.Location = new System.Drawing.Point(17, 59);
            this.tableListaC.Name = "tableListaC";
            this.tableListaC.ReadOnly = true;
            this.tableListaC.RowHeadersWidth = 62;
            this.tableListaC.RowTemplate.Height = 28;
            this.tableListaC.Size = new System.Drawing.Size(1171, 300);
            this.tableListaC.TabIndex = 5;
            // 
            // idcamas
            // 
            this.idcamas.HeaderText = "ID ";
            this.idcamas.MinimumWidth = 8;
            this.idcamas.Name = "idcamas";
            this.idcamas.ReadOnly = true;
            this.idcamas.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sala";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Estado";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Paciente";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tiempo ocupado";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // btnDetalles_camas
            // 
            this.btnDetalles_camas.Location = new System.Drawing.Point(938, 382);
            this.btnDetalles_camas.Name = "btnDetalles_camas";
            this.btnDetalles_camas.Size = new System.Drawing.Size(250, 79);
            this.btnDetalles_camas.TabIndex = 7;
            this.btnDetalles_camas.Text = "Ver detalles de cama";
            this.btnDetalles_camas.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(665, 382);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(250, 79);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
=======
            this.tableListaC.BackgroundColor = System.Drawing.Color.White;
            this.tableListaC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(46)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableListaC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableListaC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableListaC.EnableHeadersVisualStyles = false;
            this.tableListaC.Location = new System.Drawing.Point(15, 19);
            this.tableListaC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableListaC.Name = "tableListaC";
            this.tableListaC.ReadOnly = true;
            this.tableListaC.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tableListaC.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tableListaC.RowTemplate.Height = 28;
            this.tableListaC.Size = new System.Drawing.Size(1173, 630);
            this.tableListaC.TabIndex = 5;
            // 
            // btnDetalles_camas
            // 
            this.btnDetalles_camas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(46)))), ((int)(((byte)(89)))));
            this.btnDetalles_camas.FlatAppearance.BorderSize = 0;
            this.btnDetalles_camas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles_camas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetalles_camas.ForeColor = System.Drawing.Color.White;
            this.btnDetalles_camas.Location = new System.Drawing.Point(944, 662);
            this.btnDetalles_camas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetalles_camas.Name = "btnDetalles_camas";
            this.btnDetalles_camas.Size = new System.Drawing.Size(244, 34);
            this.btnDetalles_camas.TabIndex = 7;
            this.btnDetalles_camas.Text = "Ver detalles de cama";
            this.btnDetalles_camas.UseVisualStyleBackColor = false;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.Green;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(807, 662);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(120, 34);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
>>>>>>> Dev
            this.panel1.Controls.Add(this.cboxSala);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboxFiltradoC);
<<<<<<< HEAD
            this.panel1.Location = new System.Drawing.Point(53, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 127);
=======
            this.panel1.Location = new System.Drawing.Point(47, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 80);
>>>>>>> Dev
            this.panel1.TabIndex = 8;
            // 
            // cboxSala
            // 
            this.cboxSala.AutoCompleteCustomSource.AddRange(new string[] {
            "A1",
            "A2",
            "A3",
            "S3"});
<<<<<<< HEAD
            this.cboxSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
=======
            this.cboxSala.BackColor = System.Drawing.Color.White;
            this.cboxSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSala.Font = new System.Drawing.Font("Segoe UI", 10F);
>>>>>>> Dev
            this.cboxSala.FormattingEnabled = true;
            this.cboxSala.Items.AddRange(new object[] {
            "A1",
            "A2",
            "A3",
            "A4"});
<<<<<<< HEAD
            this.cboxSala.Location = new System.Drawing.Point(64, 14);
            this.cboxSala.Name = "cboxSala";
            this.cboxSala.Size = new System.Drawing.Size(394, 28);
=======
            this.cboxSala.Location = new System.Drawing.Point(57, 11);
            this.cboxSala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxSala.Name = "cboxSala";
            this.cboxSala.Size = new System.Drawing.Size(351, 31);
>>>>>>> Dev
            this.cboxSala.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
<<<<<<< HEAD
            this.label11.Location = new System.Drawing.Point(13, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
=======
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 23);
>>>>>>> Dev
            this.label11.TabIndex = 0;
            this.label11.Text = "Sala:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
<<<<<<< HEAD
            this.label12.Location = new System.Drawing.Point(13, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 20);
=======
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 23);
>>>>>>> Dev
            this.label12.TabIndex = 2;
            this.label12.Text = "Filtro por estado:";
            // 
            // cboxFiltradoC
            // 
<<<<<<< HEAD
            this.cboxFiltradoC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
=======
            this.cboxFiltradoC.BackColor = System.Drawing.Color.White;
            this.cboxFiltradoC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFiltradoC.Font = new System.Drawing.Font("Segoe UI", 10F);
>>>>>>> Dev
            this.cboxFiltradoC.FormattingEnabled = true;
            this.cboxFiltradoC.Items.AddRange(new object[] {
            "Todas",
            "Libres",
            "Ocupadas",
            "Reservadas"});
<<<<<<< HEAD
            this.cboxFiltradoC.Location = new System.Drawing.Point(147, 52);
            this.cboxFiltradoC.Name = "cboxFiltradoC";
            this.cboxFiltradoC.Size = new System.Drawing.Size(311, 28);
            this.cboxFiltradoC.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Poppins ExtraBold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.label14.Location = new System.Drawing.Point(41, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(703, 70);
            this.label14.TabIndex = 10;
            this.label14.Text = "Mapa de camas de los pacientes";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtBIdHospitalizacion);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cBPaciente);
            this.panel3.Location = new System.Drawing.Point(96, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 108);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtbDiagnostico);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtBMotivo);
            this.panel4.Location = new System.Drawing.Point(96, 218);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(566, 411);
            this.panel4.TabIndex = 26;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cBCama);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.cBSala);
            this.panel5.Controls.Add(this.cBMedicoR);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.dateTimer);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(712, 61);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(518, 295);
            this.panel5.TabIndex = 27;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(3, 681);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1344, 17);
            this.panel6.TabIndex = 28;
            // 
            // Modulo8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.tabControl1);
            this.Name = "Modulo8";
            this.Size = new System.Drawing.Size(1351, 996);
=======
            this.cboxFiltradoC.Location = new System.Drawing.Point(157, 45);
            this.cboxFiltradoC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxFiltradoC.Name = "cboxFiltradoC";
            this.cboxFiltradoC.Size = new System.Drawing.Size(251, 31);
            this.cboxFiltradoC.TabIndex = 3;
            // 
            // Modulo8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Modulo8";
            this.Size = new System.Drawing.Size(1323, 946);
>>>>>>> Dev
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
<<<<<<< HEAD
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableListaC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
=======
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableListaC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
>>>>>>> Dev
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cBMedicoR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttTasladar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttAlta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bttAdmitir;
        private System.Windows.Forms.TextBox txtbDiagnostico;
        private System.Windows.Forms.DateTimePicker dateTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBMotivo;
        private System.Windows.Forms.TextBox txtBIdHospitalizacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cBPaciente;
        private System.Windows.Forms.ComboBox cBCama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox cBSala;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
<<<<<<< HEAD
        private System.Windows.Forms.Label label13;
=======
>>>>>>> Dev
        private System.Windows.Forms.DataGridView tableListaC;
        private System.Windows.Forms.Button btnDetalles_camas;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboxSala;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboxFiltradoC;
<<<<<<< HEAD
        private System.Windows.Forms.DataGridViewTextBoxColumn idcamas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}
=======
    }
}
>>>>>>> Dev
