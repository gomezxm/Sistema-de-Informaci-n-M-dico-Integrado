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
    public partial class Modulo4 : UserControl
    {
        public Modulo4()
        {
            InitializeComponent();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            CargarDatosEnfermeria();
            CargarDatosMedicamentos();
        }

        // ==========================================
        // LÓGICA DE HOJA DE ENFERMERÍA
        // ==========================================

        private void CargarDatosEnfermeria()
        {
            // Cargar pacientes (Datos de ejemplo)
            cmbPaciente_Enf.Items.AddRange(new string[] {
                "Paciente 1 - Juan Pérez",
                "Paciente 2 - María González",
                "Paciente 3 - Carlos Rodríguez"
            });

            // Cargar enfermeros
            cmbEnfermero_Enf.Items.AddRange(new string[] {
                "Enf. Ana López",
                "Enf. Pedro Martínez",
                "Enf. Laura Sánchez"
            });

            cmbTurno_Enf.Items.AddRange(new string[] { "Mañana", "Tarde", "Noche" });

            // Configurar Grid Intervenciones
            dgvIntervenciones_Enf.Columns.Clear();
            dgvIntervenciones_Enf.Columns.Add("Hora", "Hora");
            dgvIntervenciones_Enf.Columns.Add("Intervencion", "Intervención");
            dgvIntervenciones_Enf.Columns.Add("Firma", "Firma");
            dgvIntervenciones_Enf.Columns[1].Width = 250;

            // Configurar Grid Signos
            dgvSignosVitales_Enf.Columns.Clear();
            dgvSignosVitales_Enf.Columns.Add("Hora", "Hora");
            dgvSignosVitales_Enf.Columns.Add("PresionArterial", "Presión Arterial");
            dgvSignosVitales_Enf.Columns.Add("Temperatura", "Temperatura (°C)");
            dgvSignosVitales_Enf.Columns.Add("FrecuenciaCardiaca", "Frecuencia Cardíaca");
            dgvSignosVitales_Enf.Columns.Add("Saturacion", "Saturación O2 (%)");
        }

        private void btnAgregarIntervencion_Enf_Click(object sender, EventArgs e)
        {
            dgvIntervenciones_Enf.Rows.Add(
                DateTime.Now.ToString("HH:mm"),
                "",
                cmbEnfermero_Enf.Text
            );
        }

        private void btnAgregarSignos_Enf_Click(object sender, EventArgs e)
        {
            dgvSignosVitales_Enf.Rows.Add(
                DateTime.Now.ToString("HH:mm"),
                "",
                "",
                "",
                ""
            );
        }

        private void btnGuardar_Enf_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioEnfermeria()) return;

            // Aquí iría el código de guardado a base de datos...
            MessageBox.Show("Hoja de enfermería guardada correctamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormularioEnfermeria();
        }

        private bool ValidarFormularioEnfermeria()
        {
            if (cmbPaciente_Enf.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un paciente en Enfermería", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbEnfermero_Enf.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un enfermero responsable", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTurno_Enf.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un turno", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormularioEnfermeria()
        {
            cmbPaciente_Enf.SelectedIndex = -1;
            cmbEnfermero_Enf.SelectedIndex = -1;
            cmbTurno_Enf.SelectedIndex = -1;
            dtpFecha_Enf.Value = DateTime.Now;
            dgvIntervenciones_Enf.Rows.Clear();
            dgvSignosVitales_Enf.Rows.Clear();
            txtObservaciones_Enf.Clear();
        }

        private void btnImprimir_Enf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Este botón ahora cambia a la pestaña de medicamentos
        private void btnIrAMedicamentos_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 1; // Cambia a la pestaña de Medicamentos
        }

        // ==========================================
        // LÓGICA DE ADMINISTRACIÓN DE MEDICAMENTOS
        // ==========================================

        private void CargarDatosMedicamentos()
        {
            // Cargar pacientes (pueden ser los mismos, pero cargamos aparte por si acaso)
            cmbPaciente_Med.Items.AddRange(new string[] {
                "Paciente 1 - Juan Pérez",
                "Paciente 2 - María González",
                "Paciente 3 - Carlos Rodríguez"
            });

            // Cargar prescripciones
            cmbPrescripcion_Med.Items.AddRange(new string[] {
                "Prescripción #001 - Dr. García",
                "Prescripción #002 - Dr. Morales",
                "Prescripción #003 - Dra. Torres"
            });

            // Cargar responsables
            cmbResponsable_Med.Items.AddRange(new string[] {
                "Enf. Ana López",
                "Enf. Pedro Martínez",
                "Enf. Laura Sánchez"
            });

            // Configurar Grid Medicamentos
            dgvMedicamentosPrescritos_Med.Columns.Clear();
            dgvMedicamentosPrescritos_Med.Columns.Add("Medicamento", "Medicamento");
            dgvMedicamentosPrescritos_Med.Columns.Add("Dosis", "Dosis");
            dgvMedicamentosPrescritos_Med.Columns.Add("Via", "Vía");
            dgvMedicamentosPrescritos_Med.Columns.Add("Frecuencia", "Frecuencia");
            dgvMedicamentosPrescritos_Med.Columns.Add("HoraProgramada", "Hora Programada");

            dgvMedicamentosPrescritos_Med.Columns[0].Width = 180;
            dgvMedicamentosPrescritos_Med.Columns[1].Width = 100;
            dgvMedicamentosPrescritos_Med.Columns[2].Width = 100;
            dgvMedicamentosPrescritos_Med.Columns[3].Width = 120;
            dgvMedicamentosPrescritos_Med.Columns[4].Width = 120;
        }

        private void cmbPrescripcion_Med_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrescripcion_Med.SelectedIndex == -1) return;

            dgvMedicamentosPrescritos_Med.Rows.Clear();
            dgvMedicamentosPrescritos_Med.Rows.Add("Paracetamol 500mg", "1 tableta", "Oral", "Cada 8 horas", "08:00");
            dgvMedicamentosPrescritos_Med.Rows.Add("Omeprazol 20mg", "1 cápsula", "Oral", "Cada 12 horas", "08:00");
            dgvMedicamentosPrescritos_Med.Rows.Add("Metformina 850mg", "1 tableta", "Oral", "Cada 12 horas", "08:00");
        }

        private void btnConfirmar_Med_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioMedicamentos()) return;

            // Aquí iría el código de guardado a base de datos...
            MessageBox.Show("Administración de medicamento registrada correctamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormularioMedicamentos();
        }

        private bool ValidarFormularioMedicamentos()
        {
            if (cmbPaciente_Med.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un paciente en Medicamentos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbPrescripcion_Med.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una prescripción", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbResponsable_Med.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un responsable", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormularioMedicamentos()
        {
            cmbPaciente_Med.SelectedIndex = -1;
            cmbPrescripcion_Med.SelectedIndex = -1;
            cmbResponsable_Med.SelectedIndex = -1;
            dtpHoraAdministracion_Med.Value = DateTime.Now;
            chkAdministrado_Med.Checked = false;
            txtObservaciones_Med.Clear();
            dgvMedicamentosPrescritos_Med.Rows.Clear();
        }

        private void btnCancelar_Med_Click(object sender, EventArgs e)
        {
            // Como ahora es un UserControl, "Cancelar" probablemente signifique limpiar o volver a la pestaña principal
            if (MessageBox.Show("¿Desea limpiar los datos actuales?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LimpiarFormularioMedicamentos();
                tabControlPrincipal.SelectedIndex = 0; // Vuelve a la hoja de enfermería
            }
        }

        private void btnHistorial_Med_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de historial en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabPageEnfermeria_Click(object sender, EventArgs e)
        {

        }
    }
}