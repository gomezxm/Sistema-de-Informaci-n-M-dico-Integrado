namespace Borrador

{
    partial class FrmHojaEnfermeria
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
            this.groupBoxObservaciones = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.groupBoxSignos = new System.Windows.Forms.GroupBox();
            this.btnAgregarSignos = new System.Windows.Forms.Button();
            this.dgvSignosVitales = new System.Windows.Forms.DataGridView();
            this.groupBoxIntervenciones = new System.Windows.Forms.GroupBox();
            this.btnAgregarIntervencion = new System.Windows.Forms.Button();
            this.dgvIntervenciones = new System.Windows.Forms.DataGridView();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbEnfermero = new System.Windows.Forms.ComboBox();
            this.lblEnfermero = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnMedicamentos = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxObservaciones.SuspendLayout();
            this.groupBoxSignos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSignosVitales)).BeginInit();
            this.groupBoxIntervenciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervenciones)).BeginInit();
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
            this.panelHeader.Size = new System.Drawing.Size(1100, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(367, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🧑‍⚕️ Hoja de Enfermería";
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.panelMain.Controls.Add(this.groupBoxObservaciones);
            this.panelMain.Controls.Add(this.groupBoxSignos);
            this.panelMain.Controls.Add(this.groupBoxIntervenciones);
            this.panelMain.Controls.Add(this.groupBoxDatos);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1100, 610);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxObservaciones
            // 
            this.groupBoxObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxObservaciones.Controls.Add(this.txtObservaciones);
            this.groupBoxObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxObservaciones.Location = new System.Drawing.Point(23, 680);
            this.groupBoxObservaciones.Name = "groupBoxObservaciones";
            this.groupBoxObservaciones.Size = new System.Drawing.Size(1054, 120);
            this.groupBoxObservaciones.TabIndex = 3;
            this.groupBoxObservaciones.TabStop = false;
            this.groupBoxObservaciones.Text = "Observaciones de Turno";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtObservaciones.Location = new System.Drawing.Point(15, 28);
            this.txtObservaciones.MaxLength = 400;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(1024, 76);
            this.txtObservaciones.TabIndex = 0;
            // 
            // groupBoxSignos
            // 
            this.groupBoxSignos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSignos.Controls.Add(this.btnAgregarSignos);
            this.groupBoxSignos.Controls.Add(this.dgvSignosVitales);
            this.groupBoxSignos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSignos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxSignos.Location = new System.Drawing.Point(23, 480);
            this.groupBoxSignos.Name = "groupBoxSignos";
            this.groupBoxSignos.Size = new System.Drawing.Size(1054, 184);
            this.groupBoxSignos.TabIndex = 2;
            this.groupBoxSignos.TabStop = false;
            this.groupBoxSignos.Text = "Signos Vitales por Hora";
            // 
            // btnAgregarSignos
            // 
            this.btnAgregarSignos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.btnAgregarSignos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSignos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarSignos.ForeColor = System.Drawing.Color.White;
            this.btnAgregarSignos.Location = new System.Drawing.Point(15, 145);
            this.btnAgregarSignos.Name = "btnAgregarSignos";
            this.btnAgregarSignos.Size = new System.Drawing.Size(160, 30);
            this.btnAgregarSignos.TabIndex = 1;
            this.btnAgregarSignos.Text = "+ Agregar Registro";
            this.btnAgregarSignos.UseVisualStyleBackColor = false;
            this.btnAgregarSignos.Click += new System.EventHandler(this.btnAgregarSignos_Click);
            // 
            // dgvSignosVitales
            // 
            this.dgvSignosVitales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSignosVitales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSignosVitales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSignosVitales.Location = new System.Drawing.Point(15, 28);
            this.dgvSignosVitales.Name = "dgvSignosVitales";
            this.dgvSignosVitales.Size = new System.Drawing.Size(1024, 108);
            this.dgvSignosVitales.TabIndex = 0;
            // 
            // groupBoxIntervenciones
            // 
            this.groupBoxIntervenciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxIntervenciones.Controls.Add(this.btnAgregarIntervencion);
            this.groupBoxIntervenciones.Controls.Add(this.dgvIntervenciones);
            this.groupBoxIntervenciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxIntervenciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxIntervenciones.Location = new System.Drawing.Point(23, 280);
            this.groupBoxIntervenciones.Name = "groupBoxIntervenciones";
            this.groupBoxIntervenciones.Size = new System.Drawing.Size(1054, 184);
            this.groupBoxIntervenciones.TabIndex = 1;
            this.groupBoxIntervenciones.TabStop = false;
            this.groupBoxIntervenciones.Text = "Lista de Intervenciones";
            // 
            // btnAgregarIntervencion
            // 
            this.btnAgregarIntervencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.btnAgregarIntervencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarIntervencion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarIntervencion.ForeColor = System.Drawing.Color.White;
            this.btnAgregarIntervencion.Location = new System.Drawing.Point(15, 145);
            this.btnAgregarIntervencion.Name = "btnAgregarIntervencion";
            this.btnAgregarIntervencion.Size = new System.Drawing.Size(160, 30);
            this.btnAgregarIntervencion.TabIndex = 1;
            this.btnAgregarIntervencion.Text = "+ Agregar Intervención";
            this.btnAgregarIntervencion.UseVisualStyleBackColor = false;
            this.btnAgregarIntervencion.Click += new System.EventHandler(this.btnAgregarIntervencion_Click);
            // 
            // dgvIntervenciones
            // 
            this.dgvIntervenciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIntervenciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvIntervenciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntervenciones.Location = new System.Drawing.Point(15, 28);
            this.dgvIntervenciones.Name = "dgvIntervenciones";
            this.dgvIntervenciones.Size = new System.Drawing.Size(1024, 108);
            this.dgvIntervenciones.TabIndex = 0;
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDatos.Controls.Add(this.cmbTurno);
            this.groupBoxDatos.Controls.Add(this.lblTurno);
            this.groupBoxDatos.Controls.Add(this.dtpFecha);
            this.groupBoxDatos.Controls.Add(this.lblFecha);
            this.groupBoxDatos.Controls.Add(this.cmbEnfermero);
            this.groupBoxDatos.Controls.Add(this.lblEnfermero);
            this.groupBoxDatos.Controls.Add(this.cmbPaciente);
            this.groupBoxDatos.Controls.Add(this.lblPaciente);
            this.groupBoxDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.groupBoxDatos.Location = new System.Drawing.Point(23, 23);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(1054, 241);
            this.groupBoxDatos.TabIndex = 0;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos Generales";
            // 
            // cmbTurno
            // 
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Location = new System.Drawing.Point(25, 195);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(300, 25);
            this.cmbTurno.TabIndex = 7;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTurno.Location = new System.Drawing.Point(22, 172);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(51, 19);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "Turno:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(551, 195);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(300, 25);
            this.dtpFecha.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFecha.Location = new System.Drawing.Point(548, 172);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(48, 19);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha:";
            // 
            // cmbEnfermero
            // 
            this.cmbEnfermero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnfermero.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEnfermero.FormattingEnabled = true;
            this.cmbEnfermero.Location = new System.Drawing.Point(551, 120);
            this.cmbEnfermero.Name = "cmbEnfermero";
            this.cmbEnfermero.Size = new System.Drawing.Size(470, 25);
            this.cmbEnfermero.TabIndex = 3;
            // 
            // lblEnfermero
            // 
            this.lblEnfermero.AutoSize = true;
            this.lblEnfermero.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEnfermero.Location = new System.Drawing.Point(548, 97);
            this.lblEnfermero.Name = "lblEnfermero";
            this.lblEnfermero.Size = new System.Drawing.Size(157, 19);
            this.lblEnfermero.TabIndex = 2;
            this.lblEnfermero.Text = "Enfermero/a Responsable:";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(25, 120);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(470, 25);
            this.cmbPaciente.TabIndex = 1;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaciente.Location = new System.Drawing.Point(22, 97);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(63, 19);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(188)))), ((int)(((byte)(170)))));
            this.panelFooter.Controls.Add(this.btnMedicamentos);
            this.panelFooter.Controls.Add(this.btnImprimir);
            this.panelFooter.Controls.Add(this.btnGuardar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 680);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1100, 70);
            this.panelFooter.TabIndex = 2;
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMedicamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.btnMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicamentos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMedicamentos.ForeColor = System.Drawing.Color.White;
            this.btnMedicamentos.Location = new System.Drawing.Point(588, 15);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(250, 40);
            this.btnMedicamentos.TabIndex = 2;
            this.btnMedicamentos.Text = "💊 Administrar Medicamentos";
            this.btnMedicamentos.UseVisualStyleBackColor = false;
            this.btnMedicamentos.Click += new System.EventHandler(this.btnMedicamentos_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(850, 15);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 40);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "🖨️ Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(972, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 40);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmHojaEnfermeria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1116, 789);
            this.Name = "FrmHojaEnfermeria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Hospital - Hoja de Enfermería";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxObservaciones.ResumeLayout(false);
            this.groupBoxObservaciones.PerformLayout();
            this.groupBoxSignos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSignosVitales)).EndInit();
            this.groupBoxIntervenciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervenciones)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbEnfermero;
        private System.Windows.Forms.Label lblEnfermero;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.GroupBox groupBoxIntervenciones;
        private System.Windows.Forms.DataGridView dgvIntervenciones;
        private System.Windows.Forms.Button btnAgregarIntervencion;
        private System.Windows.Forms.GroupBox groupBoxSignos;
        private System.Windows.Forms.DataGridView dgvSignosVitales;
        private System.Windows.Forms.Button btnAgregarSignos;
        private System.Windows.Forms.GroupBox groupBoxObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnMedicamentos;
    }
}