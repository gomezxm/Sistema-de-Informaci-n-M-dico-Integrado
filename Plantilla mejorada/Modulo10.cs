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
    public partial class Modulo10 : UserControl
    {
        private readonly CirugiaRepository _repository;
        private int _idEventoActual = 0;

        public Modulo10()
        {
            InitializeComponent();
            _repository = new CirugiaRepository();
            ConfigurarEventos();
            CargarDatosIniciales();
        }

        private void ConfigurarEventos()
        {
            // Eventos Tab Agenda
            btnProgramar.Click += BtnProgramar_Click;
            cmbPaciente.SelectedIndexChanged += CmbPaciente_SelectedIndexChanged;

            // Eventos Tab Nota Operatoria
            cmbCirugiaSel.SelectedIndexChanged += CmbCirugiaSel_SelectedIndexChanged;
            btnGuardarNota.Click += BtnGuardarNota_Click;
            btnImprimir.Click += BtnImprimir_Click;
        }

        private void CargarDatosIniciales()
        {
            try
            {
                // Cargar combos Tab Agenda
                CargarPacientes();
                CargarCirujanos();
                CargarTiposCirugia();
                CargarSalasQuirurgicas();

                // Cargar estados
                cmbEstado.Items.AddRange(new[] { "Programada", "En Curso", "Finalizada", "Cancelada" });
                cmbEstado.SelectedIndex = 0;

                cmbPrioridad.Items.AddRange(new[] { "Electiva", "Urgente", "Emergencia" });
                cmbPrioridad.SelectedIndex = 0;

                // Cargar combos Tab Nota
                CargarCirugiasParaNota();
                CargarProfesionales();

                cmbEstadoNota.Items.AddRange(new[] { "Borrador", "Final" });
                cmbEstadoNota.SelectedIndex = 0;

                // Configurar DataGridView Materiales
                ConfigurarGridMateriales();

                // Generar ID automático
                GenerarIdCirugia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Tab Agenda - Métodos

        private void CargarPacientes()
        {
            try
            {
                var dt = _repository.ObtenerPacientes();
                cmbPaciente.DataSource = dt;
                cmbPaciente.DisplayMember = "Display";
                cmbPaciente.ValueMember = "IdPersona";
                cmbPaciente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error");
            }
        }

        private void CargarCirujanos()
        {
            try
            {
                var dt = _repository.ObtenerCirujanos();
                cmbCirujano.DataSource = dt;
                cmbCirujano.DisplayMember = "Display";
                cmbCirujano.ValueMember = "IdPersona";
                cmbCirujano.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cirujanos: {ex.Message}", "Error");
            }
        }

        private void CargarTiposCirugia()
        {
            try
            {
                var dt = _repository.ObtenerTiposCirugia();
                cmbTipoCirugia.DataSource = dt;
                cmbTipoCirugia.DisplayMember = "Nombre";
                cmbTipoCirugia.ValueMember = "Codigo";
                cmbTipoCirugia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de cirugía: {ex.Message}", "Error");
            }
        }

        private void CargarSalasQuirurgicas()
        {
            try
            {
                var dt = _repository.ObtenerSalasQuirurgicas();
                cmbSala.DataSource = dt;
                cmbSala.DisplayMember = "Nombre";
                cmbSala.ValueMember = "IdLugar";
                cmbSala.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar salas: {ex.Message}", "Error");
            }
        }

        private void GenerarIdCirugia()
        {
            txtIdCirugia.Text = $"CIR-{DateTime.Now:yyyyMMddHHmmss}";
        }

        private void CmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí podrías cargar información adicional del paciente si lo necesitas
        }

        private void BtnProgramar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosAgenda())
                    return;

                var cirugia = new CirugiaDTO
                {
                    IdEvento = _idEventoActual,
                    IdPaciente = Convert.ToInt32(cmbPaciente.SelectedValue),
                    IdCirujano = Convert.ToInt32(cmbCirujano.SelectedValue),
                    EquipoQuirurgico = txtEquipo.Text.Trim(),
                    TipoCirugia = cmbTipoCirugia.Text,
                    DiagnosticoPreoperatorio = txtDiagPre.Text.Trim(),
                    IdSala = cmbSala.SelectedValue != null ? Convert.ToInt32(cmbSala.SelectedValue) : (int?)null,
                    FechaInicio = dtpFechaInicio.Value,
                    DuracionMinutos = Convert.ToInt32(numDuracion.Value),
                    Prioridad = cmbPrioridad.Text == "Electiva" ? "ELEC" :
                                cmbPrioridad.Text == "Urgente" ? "URG" : "EMER",
                    Estado = cmbEstado.Text == "Programada" ? "PROGRAMADO" :
                             cmbEstado.Text == "En Curso" ? "EN_CURSO" :
                             cmbEstado.Text == "Finalizada" ? "FINALIZADO" : "CANCELADO",
                    Observaciones = txtObservaciones.Text.Trim()
                };

                // Calcular fecha fin estimada
                if (numDuracion.Value > 0)
                {
                    cirugia.FechaFin = cirugia.FechaInicio.AddMinutes((double)numDuracion.Value);
                }

                _idEventoActual = _repository.GuardarCirugia(cirugia);

                MessageBox.Show("Cirugía guardada exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioAgenda();
                GenerarIdCirugia();
                CargarCirugiasParaNota(); // Actualizar lista en tab Nota
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cirugía: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatosAgenda()
        {
            if (cmbPaciente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un paciente", "Validación");
                cmbPaciente.Focus();
                return false;
            }

            if (cmbCirujano.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cirujano", "Validación");
                cmbCirujano.Focus();
                return false;
            }

            if (cmbTipoCirugia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de cirugía", "Validación");
                cmbTipoCirugia.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiagPre.Text))
            {
                MessageBox.Show("Debe ingresar el diagnóstico preoperatorio", "Validación");
                txtDiagPre.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormularioAgenda()
        {
            _idEventoActual = 0;
            cmbPaciente.SelectedIndex = -1;
            cmbCirujano.SelectedIndex = -1;
            cmbTipoCirugia.SelectedIndex = -1;
            cmbSala.SelectedIndex = -1;
            txtEquipo.Clear();
            txtDiagPre.Clear();
            numDuracion.Value = 0;
            cmbPrioridad.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            txtObservaciones.Clear();
            dtpFechaInicio.Value = DateTime.Now;
        }

        #endregion

        #region Tab Nota Operatoria - Métodos

        private void CargarCirugiasParaNota()
        {
            try
            {
                var dt = _repository.ObtenerCirugiasParaNota();
                cmbCirugiaSel.DataSource = dt;
                cmbCirugiaSel.DisplayMember = "Display";
                cmbCirugiaSel.ValueMember = "IdEvento";
                cmbCirugiaSel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cirugías: {ex.Message}", "Error");
            }
        }

        private void CargarProfesionales()
        {
            try
            {
                var dt = _repository.ObtenerProfesionalesMedicos();
                cmbProfesional.DataSource = dt;
                cmbProfesional.DisplayMember = "Display";
                cmbProfesional.ValueMember = "IdPersona";
                cmbProfesional.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar profesionales: {ex.Message}", "Error");
            }
        }

        private void ConfigurarGridMateriales()
        {
            dgvMateriales.AllowUserToAddRows = true;
            dgvMateriales.AllowUserToDeleteRows = true;
        }

        private void CmbCirugiaSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCirugiaSel.SelectedValue == null)
                return;

            try
            {
                int idEvento = Convert.ToInt32(cmbCirugiaSel.SelectedValue);
                var detalle = _repository.ObtenerDetalleCirugia(idEvento);

                if (detalle != null)
                {
                    // Cargar datos básicos
                    dtpInicioReal.Value = detalle.FechaInicio;
                    if (detalle.FechaFin.HasValue)
                        dtpFinReal.Value = detalle.FechaFin.Value;

                    // Si hay datos JSON, parsearlos (simplificado)
                    if (!string.IsNullOrEmpty(detalle.DatosClinicosJson))
                    {
                        // Aquí podrías usar un parser JSON para extraer los datos
                        // Por ahora, dejamos que el usuario complete la información
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error");
            }
        }

        private void BtnGuardarNota_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosNota())
                    return;

                var nota = new NotaOperatoriaDTO
                {
                    IdEvento = Convert.ToInt32(cmbCirugiaSel.SelectedValue),
                    InicioReal = dtpInicioReal.Value,
                    FinReal = dtpFinReal.Value,
                    DiagnosticoPostoperatorio = txtDiagPost.Text.Trim(),
                    TecnicaOperatoria = rtbTecnica.Text.Trim(),
                    Hallazgos = rtbHallazgos.Text.Trim(),
                    Complicaciones = txtComplicaciones.Text.Trim(),
                    MaterialesJson = GenerarJsonMateriales(),
                    IdProfesionalRegistra = cmbProfesional.SelectedValue != null ?
                        Convert.ToInt32(cmbProfesional.SelectedValue) : 0,
                    EstadoNota = cmbEstadoNota.Text
                };

                bool resultado = _repository.GuardarNotaOperatoria(nota);

                if (resultado)
                {
                    MessageBox.Show("Nota operatoria guardada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioNota();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar nota: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatosNota()
        {
            if (cmbCirugiaSel.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una cirugía", "Validación");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiagPost.Text))
            {
                MessageBox.Show("Debe ingresar el diagnóstico postoperatorio", "Validación");
                txtDiagPost.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rtbTecnica.Text))
            {
                MessageBox.Show("Debe describir la técnica operatoria", "Validación");
                rtbTecnica.Focus();
                return false;
            }

            return true;
        }

        private string GenerarJsonMateriales()
        {
            var materiales = new List<string>();

            foreach (DataGridViewRow row in dgvMateriales.Rows)
            {
                if (row.IsNewRow) continue;

                var material = row.Cells[0].Value?.ToString() ?? "";
                var cantidad = row.Cells[1].Value?.ToString() ?? "0";
                var observacion = row.Cells[2].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(material))
                {
                    materiales.Add($"{{\"Material\":\"{material}\",\"Cantidad\":\"{cantidad}\",\"Observacion\":\"{observacion}\"}}");
                }
            }

            return $"[{string.Join(",", materiales)}]";
        }

        private void LimpiarFormularioNota()
        {
            cmbCirugiaSel.SelectedIndex = -1;
            txtDiagPost.Clear();
            rtbTecnica.Clear();
            rtbHallazgos.Clear();
            txtComplicaciones.Clear();
            dgvMateriales.Rows.Clear();
            cmbProfesional.SelectedIndex = -1;
            cmbEstadoNota.SelectedIndex = 0;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
