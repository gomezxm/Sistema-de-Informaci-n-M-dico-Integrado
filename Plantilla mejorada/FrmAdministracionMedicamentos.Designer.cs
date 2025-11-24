namespace Borrador

{
    partial class FrmAdministracionMedicamentos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxAdministracion = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.chkAdministrado = new System.Windows.Forms.CheckBox();
            this.dtpHoraAdministracion = new System.Windows.Forms.DateTimePicker();
            this.lblHoraAdministracion = new System.Windows.Forms.Label();
            this.groupBoxMedicamentos = new System.Windows.Forms.GroupBox();
            this.dgvMedicamentosPrescritos = new System.Windows.Forms.DataGridView();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.cmbPrescripcion = new System.Windows.Forms.ComboBox();
            this.lblPrescripcion = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxAdministracion.SuspendLayout();
            this.groupBoxMedicamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentosPrescritos)).BeginInit();
            this.groupBoxDatos.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(458, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "💊 Administración de Medicamentos";
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.panelMain.Controls.Add(this.groupBoxAdministracion);
            this.panelMain.Controls.Add(this.groupBoxMedicamentos);
            this.panelMain.Controls.Add(this.groupBoxDatos);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1000, 540);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxAdministracion
            // 
            this.groupBoxAdministracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAdministracion.Controls.Add(this.txtObservaciones);
            this.groupBoxAdministracion.Controls.Add(this.lblObservaciones);
            this.groupBoxAdministracion.Controls.Add(this.cmbResponsable);
            this.groupBoxAdministracion.Controls.Add(this.lblResponsable);
            this.groupBoxAdministracion.Controls.Add(this.chkAdministrado);
            this.groupBoxAdministracion.Controls.Add(this.dtpHoraAdministracion);
            this.groupBoxAdministracion.Controls.Add(this.lblHoraAdministracion);
            this.groupBoxAdministracion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxAdministracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxAdministracion.Location = new System.Drawing.Point(23, 450);
            this.groupBoxAdministracion.Name = "groupBoxAdministracion";
            this.groupBoxAdministracion.Size = new System.Drawing.Size(954, 280);
            this.groupBoxAdministracion.TabIndex = 2;
            this.groupBoxAdministracion.TabStop = false;
            this.groupBoxAdministracion.Text = "Registro de Administración";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtObservaciones.Location = new System.Drawing.Point(25, 185);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(909, 75);
            this.txtObservaciones.TabIndex = 6;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblObservaciones.Location = new System.Drawing.Point(22, 162);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(104, 19);
            this.lblObservaciones.TabIndex = 5;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(509, 120);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(425, 25);
            this.cmbResponsable.TabIndex = 4;
            // 
            // lblResponsable
            // 
            this.lblResponsable.AutoSize = true;
            this.lblResponsable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResponsable.Location = new System.Drawing.Point(506, 97);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(180, 19);
            this.lblResponsable.TabIndex = 3;
            this.lblResponsable.Text = "Responsable (Enfermero/a):";
            // 
            // chkAdministrado
            // 
            this.chkAdministrado.AutoSize = true;
            this.chkAdministrado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkAdministrado.Location = new System.Drawing.Point(25, 122);
            this.chkAdministrado.Name = "chkAdministrado";
            this.chkAdministrado.Size = new System.Drawing.Size(201, 23);
            this.chkAdministrado.TabIndex = 2;
            this.chkAdministrado.Text = "✓ Medicamento Administrado";
            this.chkAdministrado.UseVisualStyleBackColor = true;
            // 
            // dtpHoraAdministracion
            // 
            this.dtpHoraAdministracion.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpHoraAdministracion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHoraAdministracion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraAdministracion.Location = new System.Drawing.Point(25, 60);
            this.dtpHoraAdministracion.Name = "dtpHoraAdministracion";
            this.dtpHoraAdministracion.ShowUpDown = true;
            this.dtpHoraAdministracion.Size = new System.Drawing.Size(350, 25);
            this.dtpHoraAdministracion.TabIndex = 1;
            // 
            // lblHoraAdministracion
            // 
            this.lblHoraAdministracion.AutoSize = true;
            this.lblHoraAdministracion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHoraAdministracion.Location = new System.Drawing.Point(22, 37);
            this.lblHoraAdministracion.Name = "lblHoraAdministracion";
            this.lblHoraAdministracion.Size = new System.Drawing.Size(159, 19);
            this.lblHoraAdministracion.TabIndex = 0;
            this.lblHoraAdministracion.Text = "Hora de Administración:";
            // 
            // groupBoxMedicamentos
            // 
            this.groupBoxMedicamentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMedicamentos.Controls.Add(this.dgvMedicamentosPrescritos);
            this.groupBoxMedicamentos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxMedicamentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxMedicamentos.Location = new System.Drawing.Point(23, 230);
            this.groupBoxMedicamentos.Name = "groupBoxMedicamentos";
            this.groupBoxMedicamentos.Size = new System.Drawing.Size(954, 204);
            this.groupBoxMedicamentos.TabIndex = 1;
            this.groupBoxMedicamentos.TabStop = false;
            this.groupBoxMedicamentos.Text = "Medicamentos Prescritos";
            // 
            // dgvMedicamentosPrescritos
            // 
            this.dgvMedicamentosPrescritos.AllowUserToAddRows = false;
            this.dgvMedicamentosPrescritos.AllowUserToDeleteRows = false;
            this.dgvMedicamentosPrescritos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMedicamentosPrescritos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicamentosPrescritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicamentosPrescritos.Location = new System.Drawing.Point(15, 28);
            this.dgvMedicamentosPrescritos.Name = "dgvMedicamentosPrescritos";
            this.dgvMedicamentosPrescritos.ReadOnly = true;
            this.dgvMedicamentosPrescritos.Size = new System.Drawing.Size(924, 160);
            this.dgvMedicamentosPrescritos.TabIndex = 0;
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDatos.Controls.Add(this.cmbPrescripcion);
            this.groupBoxDatos.Controls.Add(this.lblPrescripcion);
            this.groupBoxDatos.Controls.Add(this.cmbPaciente);
            this.groupBoxDatos.Controls.Add(this.lblPaciente);
            this.groupBoxDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxDatos.Location = new System.Drawing.Point(23, 23);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(954, 191);
            this.groupBoxDatos.TabIndex = 0;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos del Paciente";
            // 
            // cmbPrescripcion
            // 
            this.cmbPrescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPrescripcion.FormattingEnabled = true;
            this.cmbPrescripcion.Location = new System.Drawing.Point(25, 140);
            this.cmbPrescripcion.Name = "cmbPrescripcion";
            this.cmbPrescripcion.Size = new System.Drawing.Size(909, 25);
            this.cmbPrescripcion.TabIndex = 3;
            this.cmbPrescripcion.SelectedIndexChanged += new System.EventHandler(this.cmbPrescripcion_SelectedIndexChanged);
            // 
            // lblPrescripcion
            // 
            this.lblPrescripcion.AutoSize = true;
            this.lblPrescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrescripcion.Location = new System.Drawing.Point(22, 117);
            this.lblPrescripcion.Name = "lblPrescripcion";
            this.lblPrescripcion.Size = new System.Drawing.Size(158, 19);
            this.lblPrescripcion.TabIndex = 2;
            this.lblPrescripcion.Text = "Orden Médica / Prescripción:";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(25, 70);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(909, 25);
            this.cmbPaciente.TabIndex = 1;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaciente.Location = new System.Drawing.Point(22, 47);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(63, 19);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(188)))), ((int)(((byte)(170)))));
            this.panelFooter.Controls.Add(this.btnHistorial);
            this.panelFooter.Controls.Add(this.btnCancelar);
            this.panelFooter.Controls.Add(this.btnConfirmar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 610);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1000, 70);
            this.panelFooter.TabIndex = 2;
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(23, 15);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(180, 40);
            this.btnHistorial.TabIndex = 2;
            this.btnHistorial.Text = "📋 Ver Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(747, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✖ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(869, 15);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(110, 40);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "✓ Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // FrmAdministracionMedicamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1016, 719);
            this.Name = "FrmAdministracionMedicamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Hospital - Administración de Medicamentos";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxAdministracion.ResumeLayout(false);
            this.groupBoxAdministracion.PerformLayout();
            this.groupBoxMedicamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentosPrescritos)).EndInit();
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPrescripcion;
        private System.Windows.Forms.Label lblPrescripcion;
        private System.Windows.Forms.GroupBox groupBoxMedicamentos;
        private System.Windows.Forms.DataGridView dgvMedicamentosPrescritos;
        private System.Windows.Forms.GroupBox groupBoxAdministracion;
        private System.Windows.Forms.DateTimePicker dtpHoraAdministracion;
        private System.Windows.Forms.Label lblHoraAdministracion;
        private System.Windows.Forms.CheckBox chkAdministrado;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label lblResponsable;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnHistorial;
    }
}