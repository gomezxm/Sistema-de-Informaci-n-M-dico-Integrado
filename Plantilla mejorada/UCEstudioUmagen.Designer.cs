namespace Borrador
{
    partial class UCEstudioUmagen
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
            this.panelCONT = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRad = new System.Windows.Forms.Button();
            this.btnIma = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCONT
            // 
            this.panelCONT.Location = new System.Drawing.Point(49, 260);
            this.panelCONT.Name = "panelCONT";
            this.panelCONT.Size = new System.Drawing.Size(1261, 569);
            this.panelCONT.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnRad);
            this.panel2.Controls.Add(this.btnIma);
            this.panel2.Location = new System.Drawing.Point(49, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1261, 81);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1130, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(131, 30);
            this.panel3.TabIndex = 4;
            // 
            // btnRad
            // 
            this.btnRad.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRad.Location = new System.Drawing.Point(641, 16);
            this.btnRad.Name = "btnRad";
            this.btnRad.Size = new System.Drawing.Size(608, 49);
            this.btnRad.TabIndex = 4;
            this.btnRad.Text = "Informes Radiológicos ";
            this.btnRad.UseVisualStyleBackColor = false;
            this.btnRad.Click += new System.EventHandler(this.btnRad_Click);
            // 
            // btnIma
            // 
            this.btnIma.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnIma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIma.Location = new System.Drawing.Point(21, 16);
            this.btnIma.Name = "btnIma";
            this.btnIma.Size = new System.Drawing.Size(608, 49);
            this.btnIma.TabIndex = 3;
            this.btnIma.Text = "Estudios de Imagen ";
            this.btnIma.UseVisualStyleBackColor = false;
            this.btnIma.Click += new System.EventHandler(this.btnIma_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(74, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sistema de Gestión de estudio e informes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(68, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imagenología /Radiología ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(49, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 97);
            this.panel1.TabIndex = 7;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCONT);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1359, 869);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCONT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRad;
        private System.Windows.Forms.Button btnIma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
