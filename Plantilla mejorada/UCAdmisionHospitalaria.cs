using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrador
{
    public partial class UCAdmisionHospitalaria: UserControl
    {
        private Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Este es un titulo";
            // 
            // UCAdmisionHospitalaria
            // 
            this.Controls.Add(this.label1);
            this.Name = "UCAdmisionHospitalaria";
            this.Size = new System.Drawing.Size(352, 279);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // Realizar aqui dentro todo el codigo de su interfaz
    }
}
