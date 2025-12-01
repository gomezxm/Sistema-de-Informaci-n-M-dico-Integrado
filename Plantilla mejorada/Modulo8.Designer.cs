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
            this.label13 = new System.Windows.Forms.Label();
            this.tableListaC = new System.Windows.Forms.DataGridView();
            this.btnDetalles_camas = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboxSala = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboxFiltradoC = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableListaC)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(185, 163);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 678);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 645);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Admisión";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cBMedicoR
            // 
            this.cBMedicoR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMedicoR.FormattingEnabled = true;
            this.cBMedicoR.Location = new System.Drawing.Point(499, 166);
            this.cBMedicoR.Name = "cBMedicoR";
            this.cBMedicoR.Size = new System.Drawing.Size(329, 28);
            this.cBMedicoR.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Hospitalizacion:";
            // 
            // bttTasladar
            // 
            this.bttTasladar.Location = new System.Drawing.Point(208, 530);
            this.bttTasladar.Name = "bttTasladar";
            this.bttTasladar.Size = new System.Drawing.Size(90, 44);
            this.bttTasladar.TabIndex = 24;
            this.bttTasladar.Text = "Trasladar";
            this.bttTasladar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paciente:";
            // 
            // bttAlta
            // 
            this.bttAlta.Location = new System.Drawing.Point(322, 530);
            this.bttAlta.Name = "bttAlta";
            this.bttAlta.Size = new System.Drawing.Size(90, 44);
            this.bttAlta.TabIndex = 23;
            this.bttAlta.Text = "Dar Alta";
            this.bttAlta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diagnostico de Ingreso:";
            // 
            // bttAdmitir
            // 
            this.bttAdmitir.Location = new System.Drawing.Point(79, 530);
            this.bttAdmitir.Name = "bttAdmitir";
            this.bttAdmitir.Size = new System.Drawing.Size(87, 44);
            this.bttAdmitir.TabIndex = 22;
            this.bttAdmitir.Text = "Admitir";
            this.bttAdmitir.UseVisualStyleBackColor = true;
            // 
            // txtbDiagnostico
            // 
            this.txtbDiagnostico.Location = new System.Drawing.Point(79, 166);
            this.txtbDiagnostico.MaxLength = 300;
            this.txtbDiagnostico.Multiline = true;
            this.txtbDiagnostico.Name = "txtbDiagnostico";
            this.txtbDiagnostico.Size = new System.Drawing.Size(333, 101);
            this.txtbDiagnostico.TabIndex = 3;
            // 
            // dateTimer
            // 
            this.dateTimer.Location = new System.Drawing.Point(499, 233);
            this.dateTimer.Name = "dateTimer";
            this.dateTimer.Size = new System.Drawing.Size(329, 26);
            this.dateTimer.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Motivo de hospitalizacion:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(495, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fecha/Hora de Ingreso";
            // 
            // txtBMotivo
            // 
            this.txtBMotivo.Location = new System.Drawing.Point(79, 312);
            this.txtBMotivo.MaxLength = 300;
            this.txtBMotivo.Multiline = true;
            this.txtBMotivo.Name = "txtBMotivo";
            this.txtBMotivo.Size = new System.Drawing.Size(333, 101);
            this.txtBMotivo.TabIndex = 6;
            // 
            // txtBIdHospitalizacion
            // 
            this.txtBIdHospitalizacion.Location = new System.Drawing.Point(195, 48);
            this.txtBIdHospitalizacion.MaxLength = 40;
            this.txtBIdHospitalizacion.Name = "txtBIdHospitalizacion";
            this.txtBIdHospitalizacion.Size = new System.Drawing.Size(217, 26);
            this.txtBIdHospitalizacion.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Medico responsable:";
            // 
            // cBPaciente
            // 
            this.cBPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPaciente.FormattingEnabled = true;
            this.cBPaciente.Location = new System.Drawing.Point(195, 86);
            this.cBPaciente.Name = "cBPaciente";
            this.cBPaciente.Size = new System.Drawing.Size(217, 28);
            this.cBPaciente.TabIndex = 8;
            // 
            // cBCama
            // 
            this.cBCama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCama.FormattingEnabled = true;
            this.cBCama.Location = new System.Drawing.Point(552, 86);
            this.cBCama.Name = "cBCama";
            this.cBCama.Size = new System.Drawing.Size(276, 28);
            this.cBCama.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo de regimen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cama:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Privada",
            "Seguro",
            "Estado"});
            this.comboBox2.Location = new System.Drawing.Point(208, 471);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(164, 28);
            this.comboBox2.TabIndex = 10;
            // 
            // cBSala
            // 
            this.cBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSala.FormattingEnabled = true;
            this.cBSala.Location = new System.Drawing.Point(552, 50);
            this.cBSala.Name = "cBSala";
            this.cBSala.Size = new System.Drawing.Size(276, 28);
            this.cBSala.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 471);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Estado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Sala:";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Hospitalizado",
            "Alta",
            "Referido"});
            this.comboBox3.Location = new System.Drawing.Point(467, 471);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(361, 28);
            this.comboBox3.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 645);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.tableListaC);
            this.panel2.Controls.Add(this.btnDetalles_camas);
            this.panel2.Controls.Add(this.btnRefrescar);
            this.panel2.Location = new System.Drawing.Point(53, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 433);
            this.panel2.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Lista de camas";
            // 
            // tableListaC
            // 
            this.tableListaC.AllowUserToAddRows = false;
            this.tableListaC.AllowUserToDeleteRows = false;
            this.tableListaC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableListaC.Location = new System.Drawing.Point(17, 59);
            this.tableListaC.Name = "tableListaC";
            this.tableListaC.ReadOnly = true;
            this.tableListaC.RowHeadersWidth = 62;
            this.tableListaC.RowTemplate.Height = 28;
            this.tableListaC.Size = new System.Drawing.Size(783, 300);
            this.tableListaC.TabIndex = 5;
            // 
            // btnDetalles_camas
            // 
            this.btnDetalles_camas.Location = new System.Drawing.Point(592, 376);
            this.btnDetalles_camas.Name = "btnDetalles_camas";
            this.btnDetalles_camas.Size = new System.Drawing.Size(208, 43);
            this.btnDetalles_camas.TabIndex = 7;
            this.btnDetalles_camas.Text = "Ver detalles de cama";
            this.btnDetalles_camas.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(420, 376);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(109, 43);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboxSala);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboxFiltradoC);
            this.panel1.Location = new System.Drawing.Point(53, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 100);
            this.panel1.TabIndex = 8;
            // 
            // cboxSala
            // 
            this.cboxSala.AutoCompleteCustomSource.AddRange(new string[] {
            "A1",
            "A2",
            "A3",
            "S3"});
            this.cboxSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSala.FormattingEnabled = true;
            this.cboxSala.Items.AddRange(new object[] {
            "A1",
            "A2",
            "A3",
            "A4"});
            this.cboxSala.Location = new System.Drawing.Point(64, 14);
            this.cboxSala.Name = "cboxSala";
            this.cboxSala.Size = new System.Drawing.Size(394, 28);
            this.cboxSala.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Sala:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Filtro por estado:";
            // 
            // cboxFiltradoC
            // 
            this.cboxFiltradoC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFiltradoC.FormattingEnabled = true;
            this.cboxFiltradoC.Items.AddRange(new object[] {
            "Todas",
            "Libres",
            "Ocupadas",
            "Reservadas"});
            this.cboxFiltradoC.Location = new System.Drawing.Point(147, 52);
            this.cboxFiltradoC.Name = "cboxFiltradoC";
            this.cboxFiltradoC.Size = new System.Drawing.Size(311, 28);
            this.cboxFiltradoC.TabIndex = 3;
            // 
            // Modulo8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Modulo8";
            this.Size = new System.Drawing.Size(1351, 996);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableListaC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView tableListaC;
        private System.Windows.Forms.Button btnDetalles_camas;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboxSala;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboxFiltradoC;
    }
}
