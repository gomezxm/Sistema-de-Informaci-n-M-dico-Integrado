using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Borrador
{
    public partial class UCInventarioFarmacia : UserControl
    {
        private Label lblTitulo;
        private Button btnInventario;
        private Button btnDispensación;
        private Panel LineaDivisora;
        private Panel PanelDetalles;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
        private Panel PanelTabla;
        private Label label10;
        private DataGridView ListaMedicamentos;
        private DataGridViewTextBoxColumn Medicamentos;
        private DataGridViewTextBoxColumn Dosis;
        private DataGridViewTextBoxColumn Frecuencia;
        private DataGridViewTextBoxColumn CantidadPrescrita;
        private DataGridViewTextBoxColumn CantidadEntregar;
        private Panel PanelPago;
        private ComboBox comboBox2;
        private Label label9;
        private Label label11;
        private Button button2;
        private Button button1;
        private Label label6;
        private TextBox textBox4;
        private Panel pnlContenedorTitulo;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedorTitulo = new System.Windows.Forms.Panel();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnDispensación = new System.Windows.Forms.Button();
            this.LineaDivisora = new System.Windows.Forms.Panel();
            this.PanelDetalles = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
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
            this.lblTitulo.Size = new System.Drawing.Size(301, 41);
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
            this.btnInventario.Location = new System.Drawing.Point(173, 66);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(93, 35);
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
            this.btnDispensación.Location = new System.Drawing.Point(19, 67);
            this.btnDispensación.Name = "btnDispensación";
            this.btnDispensación.Size = new System.Drawing.Size(144, 33);
            this.btnDispensación.TabIndex = 3;
            this.btnDispensación.Text = "Dispensación";
            this.btnDispensación.UseVisualStyleBackColor = false;
            this.btnDispensación.Click += new System.EventHandler(this.btnDispencion_Click);
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
            this.PanelDetalles.Controls.Add(this.label5);
            this.PanelDetalles.Controls.Add(this.textBox3);
            this.PanelDetalles.Controls.Add(this.textBox2);
            this.PanelDetalles.Controls.Add(this.label4);
            this.PanelDetalles.Controls.Add(this.textBox1);
            this.PanelDetalles.Controls.Add(this.label3);
            this.PanelDetalles.Controls.Add(this.comboBox1);
            this.PanelDetalles.Controls.Add(this.label2);
            this.PanelDetalles.Controls.Add(this.label1);
            this.PanelDetalles.Location = new System.Drawing.Point(33, 115);
            this.PanelDetalles.Name = "PanelDetalles";
            this.PanelDetalles.Size = new System.Drawing.Size(359, 272);
            this.PanelDetalles.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de receta:";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(20, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(277, 22);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(20, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(277, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Medico que Prescribe:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(20, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 22);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Numero de receta:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paciente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalles del paciente y receta";
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
            this.ListaMedicamentos.RowHeadersWidth = 51;
            this.ListaMedicamentos.Size = new System.Drawing.Size(742, 133);
            this.ListaMedicamentos.TabIndex = 1;
            // 
            // Medicamentos
            // 
            this.Medicamentos.HeaderText = "Medicamentos";
            this.Medicamentos.MinimumWidth = 6;
            this.Medicamentos.Name = "Medicamentos";
            this.Medicamentos.Width = 140;
            // 
            // Dosis
            // 
            this.Dosis.HeaderText = "Dosis";
            this.Dosis.MinimumWidth = 6;
            this.Dosis.Name = "Dosis";
            this.Dosis.Width = 140;
            // 
            // Frecuencia
            // 
            this.Frecuencia.HeaderText = "Frecuencia";
            this.Frecuencia.MinimumWidth = 6;
            this.Frecuencia.Name = "Frecuencia";
            this.Frecuencia.Width = 140;
            // 
            // CantidadPrescrita
            // 
            this.CantidadPrescrita.HeaderText = "Cantidad prescrita";
            this.CantidadPrescrita.MinimumWidth = 6;
            this.CantidadPrescrita.Name = "CantidadPrescrita";
            this.CantidadPrescrita.Width = 140;
            // 
            // CantidadEntregar
            // 
            this.CantidadEntregar.HeaderText = "Cantidad a entregar";
            this.CantidadEntregar.MinimumWidth = 6;
            this.CantidadEntregar.Name = "CantidadEntregar";
            this.CantidadEntregar.Width = 140;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(328, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Lista de medicamentos Prescritos";
            // 
            // PanelPago
            // 
            this.PanelPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(200)))), ((int)(((byte)(242)))));
            this.PanelPago.Controls.Add(this.button2);
            this.PanelPago.Controls.Add(this.button1);
            this.PanelPago.Controls.Add(this.label6);
            this.PanelPago.Controls.Add(this.textBox4);
            this.PanelPago.Controls.Add(this.comboBox2);
            this.PanelPago.Controls.Add(this.label9);
            this.PanelPago.Controls.Add(this.label11);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Observacion de farmacia:";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(20, 118);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(343, 96);
            this.textBox4.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(20, 64);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(343, 24);
            this.comboBox2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "Metodo de pago:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 28);
            this.label11.TabIndex = 0;
            this.label11.Text = "Pago y notas";
            // 
            // UCInventarioFarmacia
            // 
            this.BackColor = System.Drawing.Color.White;
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

        private void btnInventario_Click(object sender, EventArgs e)
        {

        }

        private void btnDispencion_Click(object sender, EventArgs e)
        {
            
        }

        // Realizar aqui dentro todo el codigo de su interfaz

    }
}