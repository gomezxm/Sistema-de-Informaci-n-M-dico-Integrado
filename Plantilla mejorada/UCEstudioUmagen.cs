using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrador
{
    public partial class UCEstudioUmagen : UserControl
    {
        public UCEstudioUmagen()
        {
            InitializeComponent();
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
           // Cargar por defecto la vista de Estudios de Imagen
            CargarUserControl(new UC_EstudiosImagen());
        }

        private void CargarUserControl(UserControl uc)
        {
            panelCONT.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelCONT.Controls.Add(uc);
        }

        private void ActivarBoton(Button activo, Button inactivo)
        {
            activo.BackColor = Color.RoyalBlue;
            activo.ForeColor = Color.White;
            inactivo.BackColor = Color.LightGray;
            inactivo.ForeColor = Color.Black;
        }


        private void btnIma_Click(object sender, EventArgs e)
        {
            CargarUserControl(new UC_EstudiosImagen());
            ActivarBoton(btnIma, btnRad);
        }

        private void btnRad_Click(object sender, EventArgs e)
        {
            CargarUserControl(new UC_InformesRadiologicos());
            ActivarBoton(btnRad, btnIma);
        }

       
    }
}
