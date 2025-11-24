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
    public partial class FrmAdministracionMedicamentos : Form
    {
        public FrmAdministracionMedicamentos()
        {
            //InitializeComponent();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // TODO: Cargar pacientes desde base de datos
            cmbPaciente.Items.AddRange(new string[] {
                "Paciente 1 - Juan Pérez",
                "Paciente 2 - María González",
                "Paciente 3 - Carlos Rodríguez"
            });

            // TODO: Cargar prescripciones desde base de datos
            cmbPrescripcion.Items.AddRange(new string[] {
                "Prescripción #001 - Dr. García",
                "Prescripción #002 - Dr. Morales",
                "Prescripción #003 - Dra. Torres"
            });

            // TODO: Cargar enfermeros desde base de datos
            cmbResponsable.Items.AddRange(new string[] {
                "Enf. Ana López",
                "Enf. Pedro Martínez",
                "Enf. Laura Sánchez"
            });

            // Configurar DataGridView de medicamentos prescritos
            dgvMedicamentosPrescritos.Columns.Add("Medicamento", "Medicamento");
            dgvMedicamentosPrescritos.Columns.Add("Dosis", "Dosis");
            dgvMedicamentosPrescritos.Columns.Add("Via", "Vía");
            dgvMedicamentosPrescritos.Columns.Add("Frecuencia", "Frecuencia");
            dgvMedicamentosPrescritos.Columns.Add("HoraProgramada", "Hora Programada");

            dgvMedicamentosPrescritos.Columns[0].Width = 180;
            dgvMedicamentosPrescritos.Columns[1].Width = 100;
            dgvMedicamentosPrescritos.Columns[2].Width = 100;
            dgvMedicamentosPrescritos.Columns[3].Width = 120;
            dgvMedicamentosPrescritos.Columns[4].Width = 120;
        }

        private void cmbPrescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrescripcion.SelectedIndex == -1) return;

            // TODO: Cargar medicamentos de la prescripción seleccionada desde base de datos
            dgvMedicamentosPrescritos.Rows.Clear();
            dgvMedicamentosPrescritos.Rows.Add("Paracetamol 500mg", "1 tableta", "Oral", "Cada 8 horas", "08:00");
            dgvMedicamentosPrescritos.Rows.Add("Omeprazol 20mg", "1 cápsula", "Oral", "Cada 12 horas", "08:00");
            dgvMedicamentosPrescritos.Rows.Add("Metformina 850mg", "1 tableta", "Oral", "Cada 12 horas", "08:00");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            // TODO: Implementar guardado en base de datos
            /*
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO AdministracionMedicamentos...", conn);
                // Agregar parámetros
                cmd.Parameters.AddWithValue("@IdPaciente", cmbPaciente.SelectedIndex);
                cmd.Parameters.AddWithValue("@IdPrescripcion", cmbPrescripcion.SelectedIndex);
                cmd.Parameters.AddWithValue("@HoraAdministracion", dtpHoraAdministracion.Value);
                cmd.Parameters.AddWithValue("@Administrado", chkAdministrado.Checked);
                cmd.Parameters.AddWithValue("@IdResponsable", cmbResponsable.SelectedIndex);
                cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text);
                cmd.ExecuteNonQuery();
            }
            */

            MessageBox.Show("Administración de medicamento registrada correctamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private bool ValidarFormulario()
        {
            if (cmbPaciente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un paciente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbPrescripcion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una prescripción", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbResponsable.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un responsable", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            cmbPaciente.SelectedIndex = -1;
            cmbPrescripcion.SelectedIndex = -1;
            cmbResponsable.SelectedIndex = -1;
            dtpHoraAdministracion.Value = DateTime.Now;
            chkAdministrado.Checked = false;
            txtObservaciones.Clear();
            dgvMedicamentosPrescritos.Rows.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            // TODO: Mostrar historial de administraciones
            MessageBox.Show("Función de historial en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}