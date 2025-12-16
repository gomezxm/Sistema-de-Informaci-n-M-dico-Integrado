using Borrador.DBRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrador
{
    public partial class Modulo2 : UserControl
    {
        private CitaRepository _repoCitas = new CitaRepository();

        public Modulo2()
        {
            InitializeComponent();
            CargarConsultorios();
            CargarMedicosAgenda();
            CargarEspecialidades();
            CargarTodasLasCitas();
            CargarEstados();

            // Habilitar comandos comunes
            ConfigurarAtajosTeclado();
        }

        private void ConfigurarAtajosTeclado()
        {
            // Asociar el evento KeyDown al UserControl y todos sus controles
            this.KeyDown += Modulo2_KeyDown;

            // Suscribir todos los controles para que capturen las teclas
            foreach (Control ctrl in this.Controls)
            {
                ctrl.KeyDown += Modulo2_KeyDown;
                SuscribirControlesHijos(ctrl);
            }
        }

        private void SuscribirControlesHijos(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.KeyDown += Modulo2_KeyDown;
                if (ctrl.HasChildren)
                {
                    SuscribirControlesHijos(ctrl);
                }
            }
        }

        private void Modulo2_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + S: Guardar
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Ejecutar guardar según el contexto
                btnGuardarCita_Click(sender, e);
            }
            // Ctrl + N: Nuevo / Limpiar
            else if (e.Control && e.KeyCode == Keys.N)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LimpiarCampos();
            }
            // Ctrl + F: Buscar / Refrescar
            else if (e.Control && e.KeyCode == Keys.F)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                CargarAgendaConFiltros();
            }
            // Ctrl + R: Refrescar
            else if (e.Control && e.KeyCode == Keys.R)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                CargarAgendaConFiltros();
            }
            // Ctrl + D: Ver Detalles
            else if (e.Control && e.KeyCode == Keys.D)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnVerDetalles_Click(sender, e);
            }
            // ESC: Limpiar campos
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LimpiarCampos();
            }
        }

        private void CargarEstados()
        {
            var estados = new List<string>
            {
                "Programada",
                "Atendida",
                "Cancelada"
            };

            cmbEstado.DataSource = estados;
            cmbEstado.SelectedIndex = -1;
        }

        private void CargarEspecialidades()
        {
            string sql = "SELECT IdEspecialidad, NombreEspecialidad FROM CAT_ESPECIALIDADES ORDER BY NombreEspecialidad";

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(sql);

            cmbEspecialidad.DataSource = dt;
            cmbEspecialidad.DisplayMember = "NombreEspecialidad";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
            cmbEspecialidad.SelectedIndex = -1;
        }

        private void CargarConsultorios()
        {
            string sql = "SELECT IdConsultorio, NombreConsultorio FROM CAT_CONSULTORIOS ORDER BY NombreConsultorio";

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(sql);

            cmbConsultorio.DataSource = dt;
            cmbConsultorio.DisplayMember = "NombreConsultorio";
            cmbConsultorio.ValueMember = "IdConsultorio";
            cmbConsultorio.SelectedIndex = -1;
        }

        private void CargarMedicosAgenda()
        {
            string sql = @"
            SELECT 
                m.IdMedico,
                e.Nombre + ' ' + e.Apellido AS NombreCompleto
            FROM MEDICOS m
            INNER JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado
            ORDER BY e.Nombre, e.Apellido";

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(sql);

            cmbMedico2.DataSource = dt;
            cmbMedico2.DisplayMember = "NombreCompleto";
            cmbMedico2.ValueMember = "IdMedico";
            cmbMedico2.SelectedIndex = -1;
            cmbMedico.DataSource = dt;
            cmbMedico.DisplayMember = "NombreCompleto";
            cmbMedico.ValueMember = "IdMedico";
            cmbMedico.SelectedIndex = -1;
        }

        private void lblSubTituloSeleccion_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnGuardarCita_Click(object sender, EventArgs e)
        {
            if (txtPaciente.Tag == null ||
                cmbMedico.SelectedIndex == -1 ||
                cmbTipoDeCita.SelectedIndex == -1 ||
                cmbConsultorio.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TimeSpan horaSeleccionada = dtpHora.Value.TimeOfDay;

                _repoCitas.AgregarCita(
                    idPaciente: (int)txtPaciente.Tag,
                    idMedico: (int)cmbMedico.SelectedValue,
                    idConsultorio: (int)cmbConsultorio.SelectedValue,
                    fecha: dtpFechaDeLaCita.Value,
                    hora: horaSeleccionada,
                    tipoCita: cmbTipoDeCita.Text,
                    motivo: txtMotivo.Text,
                    estado: "Programada",
                    observaciones: null
                );

                MessageBox.Show("Cita registrada correctamente (Ctrl+S)", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la cita: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbMedico2.SelectedIndex = -1;
            txtPaciente.Clear();
            txtPaciente.Tag = null;
            cmbMedico.SelectedIndex = -1;
            txtEspecialidad.Clear();
            cmbEspecialidad.SelectedIndex = -1;
            cmbTipoDeCita.SelectedIndex = -1;
            txtMotivo.Clear();
            dtpFechaDeLaCita.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            dtpFechaDeLaCita.Checked = false;
        }

        private void CargarTodasLasCitas()
        {
            DataTable dt = _repoCitas.ListarTodasLasCitas();

            dgvEditarCitas.DataSource = dt;
            dgvEditarCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvEditarCitas.Columns["IdCita"].ReadOnly = true;
            dgvEditarCitas.Columns["Paciente"].ReadOnly = true;
            dgvEditarCitas.Columns["Medico"].ReadOnly = false;
            dgvEditarCitas.Columns["Fecha"].ReadOnly = false;
            dgvEditarCitas.Columns["Hora"].ReadOnly = false;
            dgvEditarCitas.Columns["EstadoCita"].ReadOnly = false;
            dgvEditarCitas.Columns["MotivoConsulta"].ReadOnly = false;
        }

        private void btnCancelarRegistroCita_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void label24_Click(object sender, EventArgs e)
        {
        }

        private void Modulo2_Load(object sender, EventArgs e)
        {
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarAgendaConFiltros();
        }

        private void CargarAgendaConFiltros()
        {
            int? idMedico = cmbMedico2.SelectedIndex != -1
                ? (int?)cmbMedico2.SelectedValue
                : null;

            string especialidad = cmbEspecialidad.SelectedIndex != -1
                ? cmbEspecialidad.Text
                : null;

            string estado = cmbEstado.SelectedIndex != -1
                ? cmbEstado.Text
                : null;

            DateTime? fecha = dtmFechaDeCita.Checked
                              ? (DateTime?)dtmFechaDeCita.Value.Date
                              : null;

            DataTable dt = _repoCitas.ListarCitasFiltradas(
                idMedico,
                especialidad,
                estado,
                fecha,
                "Día"
            );

            dgvVistaCitas.DataSource = dt;
            dgvVistaCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVistaCitas.ClearSelection();
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvVistaCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvVistaCitas.CurrentRow;

            MessageBox.Show(
                $"Paciente: {fila.Cells["Paciente"].Value}\n" +
                $"Médico: {fila.Cells["Medico"].Value}\n" +
                $"Fecha: {fila.Cells["Fecha"].Value}\n" +
                $"Hora: {fila.Cells["Hora"].Value}\n" +
                $"Estado: {fila.Cells["EstadoCita"].Value}\n\n" +
                $"Motivo:\n{fila.Cells["MotivoConsulta"].Value}",
                "Detalle de la Cita (Ctrl+D)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow fila in dgvEditarCitas.Rows)
                {
                    if (fila.IsNewRow) continue;

                    int idCita = Convert.ToInt32(fila.Cells["IdCita"].Value);
                    string nombreMedico = fila.Cells["Medico"].Value.ToString();
                    int idMedico = ObtenerIdMedicoPorNombre(nombreMedico);
                    DateTime fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                    TimeSpan hora = TimeSpan.Parse(fila.Cells["Hora"].Value.ToString());
                    string estado = fila.Cells["EstadoCita"].Value.ToString();
                    string motivo = fila.Cells["MotivoConsulta"].Value.ToString();

                    _repoCitas.ActualizarCita(idCita, idMedico, fecha, hora, estado, motivo);
                }

                MessageBox.Show("Cambios guardados correctamente (Ctrl+S)", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTodasLasCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerIdMedicoPorNombre(string nombreCompleto)
        {
            string sql = @"
            SELECT m.IdMedico
            FROM MEDICOS m
            INNER JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado
            WHERE e.Nombre + ' ' + e.Apellido = @NombreCompleto";

            SqlParameter[] parametros = {
                new SqlParameter("@NombreCompleto", nombreCompleto)
            };

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(sql, parametros);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["IdMedico"]);

            return 0;
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            if (dgvEditarCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita para cancelar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvEditarCitas.CurrentRow;

            if (MessageBox.Show(
                "¿Desea cancelar esta cita?\n\nUse Ctrl+Delete para cancelar rápidamente.",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            fila.Cells["EstadoCita"].Value = "Cancelada";
            fila.DefaultCellStyle.BackColor = Color.LightCoral;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}

// Estudiantes: José Ortega y Jesús Rodríguez