using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrador
{
    public partial class UCInventarioFarmacia: UserControl
    {
        private Label lblTitulo;
        private Button btnInventario;
        private Button btnDispensación;
        private Panel LineaDivisora;
        private Panel PanelDetalles;
        private Label lblTitulo2;
        private Label lblPaciente;
        private TextBox txtNumeroRecetas;
        private Label lblNumeroRecetas;
        private ComboBox cmbPacientes;
        private Label lblMedicos;
        private TextBox txtMedicos;
        private Label lblFechasEntrega;
        private TextBox txtFechas;
        private Panel PanelTabla;
        private Label label10;
        private DataGridView ListaMedicamentos;
        private DataGridViewTextBoxColumn Medicamentos;
        private DataGridViewTextBoxColumn Dosis;
        private DataGridViewTextBoxColumn Frecuencia;
        private DataGridViewTextBoxColumn CantidadPrescrita;
        private DataGridViewTextBoxColumn CantidadEntregar;
        private Panel PanelPago;
        private ComboBox cmbMetodoPago;
        private Label lblMetodoPago;
        private Label lblTitulo1;
        private Button button2;
        private Button button1;
        private Label lblObservacion;
        private TextBox txbObservaciones;
        private Panel pnlContenedorTitulo;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedorTitulo = new System.Windows.Forms.Panel();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnDispensación = new System.Windows.Forms.Button();
            this.LineaDivisora = new System.Windows.Forms.Panel();
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
            this.pnlContenedorTitulo.SuspendLayout();
            this.PanelDetalles.SuspendLayout();
            this.PanelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaMedicamentos)).BeginInit();
            this.PanelPago.SuspendLayout();
            this.SuspendLayout();
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
            // pnlContenedorTitulo
            // 
            this.pnlContenedorTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(89)))));
            this.pnlContenedorTitulo.Controls.Add(this.lblTitulo);
            this.pnlContenedorTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedorTitulo.Name = "pnlContenedorTitulo";
            this.pnlContenedorTitulo.Size = new System.Drawing.Size(856, 60);
            this.pnlContenedorTitulo.TabIndex = 1;
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInventario.Location = new System.Drawing.Point(130, 68);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(93, 26);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnDispensación
            // 
            this.btnDispensación.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.btnDispensación.FlatAppearance.BorderSize = 0;
            this.btnDispensación.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispensación.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDispensación.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDispensación.Location = new System.Drawing.Point(19, 68);
            this.btnDispensación.Name = "btnDispensación";
            this.btnDispensación.Size = new System.Drawing.Size(116, 30);
            this.btnDispensación.TabIndex = 3;
            this.btnDispensación.Text = "Dispensación";
            this.btnDispensación.UseVisualStyleBackColor = false;
            this.btnDispensación.Click += new System.EventHandler(this.btnDispensación_Click);
            // 
            // LineaDivisora
            // 
            this.LineaDivisora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(188)))), ((int)(((byte)(170)))));
            this.LineaDivisora.Location = new System.Drawing.Point(0, 100);
            this.LineaDivisora.Name = "LineaDivisora";
            this.LineaDivisora.Size = new System.Drawing.Size(856, 1);
            this.LineaDivisora.TabIndex = 4;
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
            this.PanelDetalles.Location = new System.Drawing.Point(33, 115);
            this.PanelDetalles.Name = "PanelDetalles";
            this.PanelDetalles.Size = new System.Drawing.Size(359, 272);
            this.PanelDetalles.TabIndex = 5;
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
            // PanelTabla
            // 
            this.PanelTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelTabla.Controls.Add(this.ListaMedicamentos);
            this.PanelTabla.Controls.Add(this.label10);
            this.PanelTabla.Location = new System.Drawing.Point(33, 399);
            this.PanelTabla.Name = "PanelTabla";
            this.PanelTabla.Size = new System.Drawing.Size(788, 197);
            this.PanelTabla.TabIndex = 9;
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
            this.PanelPago.Location = new System.Drawing.Point(434, 115);
            this.PanelPago.Name = "PanelPago";
            this.PanelPago.Size = new System.Drawing.Size(387, 272);
            this.PanelPago.TabIndex = 9;
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
            // UCInventarioFarmacia
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.PanelPago);
            this.Controls.Add(this.PanelTabla);
            this.Controls.Add(this.PanelDetalles);
            this.Controls.Add(this.LineaDivisora);
            this.Controls.Add(this.btnDispensación);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.pnlContenedorTitulo);
            this.Name = "UCInventarioFarmacia";
            this.Size = new System.Drawing.Size(856, 609);
            this.pnlContenedorTitulo.ResumeLayout(false);
            this.pnlContenedorTitulo.PerformLayout();
            this.PanelDetalles.ResumeLayout(false);
            this.PanelDetalles.PerformLayout();
            this.PanelTabla.ResumeLayout(false);
            this.PanelTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaMedicamentos)).EndInit();
            this.PanelPago.ResumeLayout(false);
            this.PanelPago.PerformLayout();
            this.ResumeLayout(false);

        }

        // Realizar aqui dentro todo el codigo de su interfaz

        //Pantalla Principal de inventario UCInventario Farmacia
        private void btnInventario_Click(object sender, EventArgs e)
        {
            // Limpiar panel antes de cargar UCInventarioFarmacia
            //pnlContent.Controls.Clear(); -- Error de conexion PanelContenedor

            // Crear instancia del UserControl
            UCInventarioFarmacia ucInventario = new UCInventarioFarmacia();

            // Ajustar tamaño y dock para que llene el panel
            ucInventario.Dock = DockStyle.Fill;

            // Agregar User control al principal
            //pnlContent.Controls.Add(ucInventario); --- Marca Error 
        }

        //Boton que te redirige a la Ventana de UCFrmInvetarioFarmacia
        private void btnDispensación_Click(object sender, EventArgs e)
        {
            // Limpiar panel antes de cargar UCInventarioFarmacia
            //pnlContent.Controls.Clear(); -- Error de conexion PanelContenedor

            // Crear instancia del UserControl
            UCFrmInventarioFarmacia ucInventario = new UCFrmInventarioFarmacia();

            // Ajustar tamaño y dock para que llene el panel
            ucInventario.Dock = DockStyle.Fill;

            // Agregar User control al principal
            //pnlContent.Controls.Add(ucInventario); --- Marca Error 
        }



    }
}
