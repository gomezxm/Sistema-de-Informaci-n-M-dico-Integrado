using Borrador;
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
    public partial class FrmHojaEnfermeria : Form
    {
        public FrmHojaEnfermeria()
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

            // TODO: Cargar enfermeros desde base de datos
            cmbEnfermero.Items.AddRange(new string[] {
                "Enf. Ana López",
                "Enf. Pedro Martínez",
                "Enf. Laura Sánchez"
            });

            cmbTurno.Items.AddRange(new string[] { "Mañana", "Tarde", "Noche" });

            // Configurar DataGridView de intervenciones
            dgvIntervenciones.Columns.Add("Hora", "Hora");
            dgvIntervenciones.Columns.Add("Intervencion", "Intervención");
            dgvIntervenciones.Columns.Add("Firma", "Firma");
            dgvIntervenciones.Columns[1].Width = 250;

            // Configurar DataGridView de signos vitales
            dgvSignosVitales.Columns.Add("Hora", "Hora");
            dgvSignosVitales.Columns.Add("PresionArterial", "Presión Arterial");
            dgvSignosVitales.Columns.Add("Temperatura", "Temperatura (°C)");
            dgvSignosVitales.Columns.Add("FrecuenciaCardiaca", "Frecuencia Cardíaca");
            dgvSignosVitales.Columns.Add("Saturacion", "Saturación O2 (%)");
        }

        private void btnAgregarIntervencion_Click(object sender, EventArgs e)
        {
            dgvIntervenciones.Rows.Add(
                DateTime.Now.ToString("HH:mm"),
                "",
                cmbEnfermero.Text
            );
        }

        private void btnAgregarSignos_Click(object sender, EventArgs e)
        {
            dgvSignosVitales.Rows.Add(
                DateTime.Now.ToString("HH:mm"),
                "",
                "",
                "",
                ""
            );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            // TODO: Implementar guardado en base de datos
            /*
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO HojasEnfermeria...", conn);
                // Agregar parámetros
                cmd.ExecuteNonQuery();
            }
            */

            MessageBox.Show("Hoja de enfermería guardada correctamente",
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
            if (cmbEnfermero.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un enfermero responsable", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTurno.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un turno", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            cmbPaciente.SelectedIndex = -1;
            cmbEnfermero.SelectedIndex = -1;
            cmbTurno.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dgvIntervenciones.Rows.Clear();
            dgvSignosVitales.Rows.Clear();
            txtObservaciones.Clear();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // TODO: Implementar impresión de reporte
            MessageBox.Show("Función de impresión en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            FrmAdministracionMedicamentos frmMed = new FrmAdministracionMedicamentos();
            frmMed.ShowDialog();
        }
    }
}