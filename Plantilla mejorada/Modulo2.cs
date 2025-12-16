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
using System.Configuration;


namespace Borrador
{
    public partial class Modulo2 : UserControl
    {
        private CitasDAL _citasDal = new CitasDAL();
        private bool _isLoadingData = false; // Flag para evitar eventos recursivos

        public Modulo2()
        {
            InitializeComponent();

            // Cargar datos al iniciar el módulo
            this.Load += new EventHandler(Modulo2_Load);

            // ============================================
            // EVENTOS TAB AGENDA (tabPage1)
            // ============================================
            this.comboBoxEspecialidad.SelectedIndexChanged += ComboBoxEspecialidad_SelectedIndexChanged;
            this.comboBox_NameMedico.SelectedIndexChanged += AplicarFiltrosAgenda;
            this.dateTimePickerFechacita.ValueChanged += AplicarFiltrosAgenda;
            this.comboBoxVista.SelectedIndexChanged += AplicarFiltrosAgenda;
            this.comboBoxFiltro.SelectedIndexChanged += AplicarFiltrosAgenda;
            this.btnDetallesCita.Click += btnDetallesCita_Click;

            // ============================================
            // EVENTOS TAB AGREGAR (tabPage2)
            // ============================================
            // ⚠️ CAMBIO CRÍTICO: El evento del médico se dispara PRIMERO
            this.cmbMedico.SelectedIndexChanged += CmbMedico_SelectedIndexChanged;

            // ⚠️ IMPORTANTE: El evento de especialidad ya NO modifica los médicos en la pestaña Agregar
            this.comboBoxEspecialidadAgregar.SelectedIndexChanged += ComboBoxEspecialidadAgregar_SelectedIndexChanged;

            // ⚠️ CRÍTICO: Asegurarnos de que el evento solo se suscriba UNA VEZ
            this.btnGuardarCita.Click -= btnGuardarCita_Click_1; // Remover si existe
            this.btnGuardarCita.Click += btnGuardarCita_Click_1; // Agregar

            // ============================================
            // EVENTOS TAB EDITAR (tabPage3)
            // ============================================
            this.button1.Click += button1_Click;
        }

        // ******************************************************
        // LÓGICA DE CARGA INICIAL
        // ******************************************************

        private void Modulo2_Load(object sender, EventArgs e)
        {
            _isLoadingData = true; // Activar flag

            CargarCatalogos();

            // Inicializar filtros predeterminados
            if (comboBoxVista.Items.Count > 0) comboBoxVista.SelectedIndex = 0;
            if (comboBoxFiltro.Items.Count > 0) comboBoxFiltro.SelectedIndex = 0;

            _isLoadingData = false; // Desactivar flag

            // Cargar datos en los DataGridView
            CargarCitasAgenda();
            CargarCitasEditar();
        }

        private void CargarCatalogos()
        {
            // ============================================
            // 1. CATÁLOGOS PARA TAB AGREGAR (tabPage2)
            // ============================================

            // Pacientes
            List<Catalogo> pacientes = _citasDal.ObtenerPacientes();
            comboBoxPaciente.DataSource = new List<Catalogo>(pacientes); // Clonar lista
            comboBoxPaciente.DisplayMember = "Nombre";
            comboBoxPaciente.ValueMember = "Id";
            comboBoxPaciente.SelectedIndex = -1; // Sin selección inicial

            // Especialidades (Agregar)
            List<Catalogo> especialidadesAgregar = _citasDal.ObtenerEspecialidades();
            comboBoxEspecialidadAgregar.DataSource = new List<Catalogo>(especialidadesAgregar);
            comboBoxEspecialidadAgregar.DisplayMember = "Nombre";
            comboBoxEspecialidadAgregar.ValueMember = "Id";
            comboBoxEspecialidadAgregar.SelectedIndex = -1; // Sin selección inicial

            // Médicos (Agregar) - Cargar TODOS los médicos al inicio
            CargarMedicosAgregar();

            // Tipos de Cita (si no están en el Designer)
            if (comboBoxTipoCitaAgregar.Items.Count == 0)
            {
                comboBoxTipoCitaAgregar.Items.AddRange(new string[] { "Control", "Urgencia", "Telecita" });
            }

            // Estados de Cita (si no están en el Designer)
            if (comboBoxEstadoCitaAgregar.Items.Count == 0)
            {
                comboBoxEstadoCitaAgregar.Items.AddRange(new string[] { "Programada", "Atendida", "Cancelada", "No Asistió" });
            }

            // ============================================
            // 2. CATÁLOGOS PARA TAB AGENDA (tabPage1)
            // ============================================

            // Especialidades (Agenda)
            List<Catalogo> especialidadesAgenda = _citasDal.ObtenerEspecialidades();
            especialidadesAgenda.Insert(0, new Catalogo { Id = 0, Nombre = "Todas las Especialidades" });
            comboBoxEspecialidad.DataSource = especialidadesAgenda;
            comboBoxEspecialidad.DisplayMember = "Nombre";
            comboBoxEspecialidad.ValueMember = "Id";

            // Médicos (Agenda)
            CargarMedicosAgenda(null);

            // Vistas (si no están en el Designer)
            if (comboBoxVista.Items.Count == 0)
            {
                comboBoxVista.Items.AddRange(new string[] { "Semana", "Día" });
            }

            // Filtros de Estado (si no están en el Designer)
            if (comboBoxFiltro.Items.Count == 0)
            {
                comboBoxFiltro.Items.AddRange(new string[] { "Todos", "Programada", "Atendida", "Cancelada" });
            }
        }

        // ******************************************************
        // LÓGICA TAB AGREGAR (tabPage2)
        // ******************************************************

        /// <summary>
        /// Carga TODOS los médicos en el ComboBox de Agregar
        /// </summary>
        private void CargarMedicosAgregar()
        {
            // Obtener TODOS los médicos (sin filtro de especialidad)
            List<Catalogo> medicosAgregar = _citasDal.ObtenerMedicosPorEspecialidad(null);

            // Añadir opción de placeholder
            medicosAgregar.Insert(0, new Catalogo { Id = 0, Nombre = "Seleccione un Médico" });

            cmbMedico.DataSource = medicosAgregar;
            cmbMedico.DisplayMember = "Nombre";
            cmbMedico.ValueMember = "Id";
            cmbMedico.SelectedIndex = 0; // Seleccionar placeholder
        }

        /// <summary>
        /// ⚠️ EVENTO PRINCIPAL: Cuando se selecciona un médico, se actualiza automáticamente la especialidad
        /// </summary>
        private void CmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar ejecución durante la carga inicial
            if (_isLoadingData) return;

            // Obtener el médico seleccionado
            if (cmbMedico.SelectedItem is Catalogo medico && medico.Id > 0)
            {
                // Obtener la especialidad del médico
                int idEsp = _citasDal.ObtenerIdEspecialidadPorMedico(medico.Id);

                if (idEsp > 0)
                {
                    // ✅ SOLUCIÓN: Seleccionar automáticamente la especialidad
                    comboBoxEspecialidadAgregar.SelectedValue = idEsp;
                }
                else
                {
                    // Si el médico no tiene especialidad asignada
                    comboBoxEspecialidadAgregar.SelectedIndex = -1;
                    MessageBox.Show("El médico seleccionado no tiene una especialidad asignada.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // ⚠️ CAMBIO: Solo limpiar, NO mostrar mensaje
                // Esto ocurre cuando se limpia el formulario o se selecciona el placeholder
                comboBoxEspecialidadAgregar.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Evento cuando cambia la especialidad en TAB AGREGAR
        /// YA NO filtra médicos, solo es informativo
        /// </summary>
        private void ComboBoxEspecialidadAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento ya NO modifica el ComboBox de médicos
            // El médico se selecciona primero y actualiza la especialidad
            // La especialidad es de solo lectura (informativa)

            // Opcional: Si quieres que sea de solo lectura visualmente
            // comboBoxEspecialidadAgregar.Enabled = false; // Descomentar si lo prefieres
        }

        /// <summary>
        /// Guardar nueva cita
        /// </summary>
        private void btnGuardarCita_Click_1(object sender, EventArgs e)
        {
            // ⚠️ CRÍTICO: Verificar que NO estamos en proceso de limpieza
            if (_isLoadingData) return;

            // 1. Validaciones
            if (comboBoxPaciente.SelectedItem == null ||
                (comboBoxPaciente.SelectedItem as Catalogo)?.Id <= 0)
            {
                MessageBox.Show("Por favor, seleccione un paciente.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMedico.SelectedItem == null ||
                (cmbMedico.SelectedItem as Catalogo)?.Id <= 0)
            {
                MessageBox.Show("Por favor, seleccione un médico.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxEspecialidadAgregar.SelectedItem == null ||
                (comboBoxEspecialidadAgregar.SelectedItem as Catalogo)?.Id <= 0)
            {
                MessageBox.Show("El médico seleccionado debe tener una especialidad asignada.",
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxTipoCitaAgregar.SelectedItem == null ||
                comboBoxEstadoCitaAgregar.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos (Tipo, Estado y Motivo).",
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Construir el objeto Cita
                Cita nuevaCita = new Cita
                {
                    IdPaciente = (comboBoxPaciente.SelectedItem as Catalogo).Id,
                    IdMedico = (cmbMedico.SelectedItem as Catalogo).Id, // Este es el IdEmpleado
                    Fecha = dtpFecha.Value.Date,
                    Hora = dtpFechaDelRegisgtro.Value.TimeOfDay,
                    TipoCita = comboBoxTipoCitaAgregar.SelectedItem.ToString(),
                    MotivoConsulta = txtMotivo.Text.Trim(),
                    EstadoCita = comboBoxEstadoCitaAgregar.SelectedItem.ToString()
                };

                // 3. Insertar en la base de datos
                bool exito = _citasDal.InsertarCita(nuevaCita);

                if (exito)
                {
                    MessageBox.Show("Cita guardada exitosamente. La agenda se ha actualizado.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Limpiar y Refrescar - DESPUÉS del mensaje de éxito
                    LimpiarFormularioNuevaCita();

                    // ⚠️ IMPORTANTE: Pequeña pausa para asegurar que el flag esté activo
                    Application.DoEvents();

                    CargarCitasAgenda();
                    CargarCitasEditar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar la cita. Verifique la configuración del médico.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar la cita: {ex.Message}",
                    "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioNuevaCita()
        {
            // ⚠️ IMPORTANTE: Activar el flag para evitar que los eventos se disparen
            _isLoadingData = true;

            comboBoxPaciente.SelectedIndex = -1;
            comboBoxEspecialidadAgregar.SelectedIndex = -1;
            cmbMedico.SelectedIndex = 0; // Volver al placeholder

            if (comboBoxTipoCitaAgregar.Items.Count > 0)
                comboBoxTipoCitaAgregar.SelectedIndex = -1;

            if (comboBoxEstadoCitaAgregar.Items.Count > 0)
                comboBoxEstadoCitaAgregar.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Now;
            dtpFechaDelRegisgtro.Value = DateTime.Now;
            txtMotivo.Clear();

            // ⚠️ IMPORTANTE: Desactivar el flag después de limpiar
            _isLoadingData = false;
        }

        // ******************************************************
        // LÓGICA TAB AGENDA (tabPage1)
        // ******************************************************

        private void CargarMedicosAgenda(int? idEsp)
        {
            List<Catalogo> medicosAgenda = _citasDal.ObtenerMedicosPorEspecialidad(idEsp);
            medicosAgenda.Insert(0, new Catalogo { Id = 0, Nombre = "Todos los Médicos" });
            comboBox_NameMedico.DataSource = medicosAgenda;
            comboBox_NameMedico.DisplayMember = "Nombre";
            comboBox_NameMedico.ValueMember = "Id";
        }

        private void ComboBoxEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEspecialidad.SelectedItem is Catalogo especialidad)
            {
                int? idEsp = especialidad.Id == 0 ? (int?)null : especialidad.Id;
                CargarMedicosAgenda(idEsp);
                AplicarFiltrosAgenda(sender, e);
            }
        }

        private void AplicarFiltrosAgenda(object sender, EventArgs e)
        {
            CargarCitasAgenda();
        }

        private void CargarCitasAgenda()
        {
            // Médicos
            int? idMedico = (comboBox_NameMedico.SelectedItem as Catalogo)?.Id;
            idMedico = idMedico == 0 ? (int?)null : idMedico;

            // Especialidad
            int? idEsp = (comboBoxEspecialidad.SelectedItem as Catalogo)?.Id;
            idEsp = idEsp == 0 ? (int?)null : idEsp;

            // Estado
            string estado = comboBoxFiltro.SelectedItem?.ToString();
            estado = (estado == "Todos" || estado == null) ? null : estado;

            // Fechas
            DateTime fechaBase = dateTimePickerFechacita.Value.Date;
            DateTime fechaInicio = fechaBase;
            DateTime? fechaFin = fechaBase;

            if (comboBoxVista.SelectedItem?.ToString() == "Semana")
            {
                fechaFin = fechaBase.AddDays(7);
            }

            // Llamada a la DAL
            List<Cita> citas = _citasDal.ObtenerCitas(idMedico, idEsp, fechaInicio, fechaFin, estado);

            dgvCVistaCitas.DataSource = citas;
            FormatearDgvCitas(dgvCVistaCitas);
        }

        // ******************************************************
        // LÓGICA TAB EDITAR (tabPage3)
        // ******************************************************

        private void CargarCitasEditar()
        {
            List<Cita> citas = _citasDal.ObtenerCitas(null, null,
                DateTime.Now.Date.AddMonths(-1), DateTime.Now.Date.AddMonths(3), "Programada");

            dgvEditarCitas.DataSource = citas;
            FormatearDgvCitas(dgvEditarCitas);

            dgvEditarCitas.ReadOnly = false;
            if (dgvEditarCitas.Columns["IdCita"] != null)
                dgvEditarCitas.Columns["IdCita"].ReadOnly = true;
            if (dgvEditarCitas.Columns["NombrePaciente"] != null)
                dgvEditarCitas.Columns["NombrePaciente"].ReadOnly = true;
        }

        private void btnDetallesCita_Click(object sender, EventArgs e)
        {
            if (dgvCVistaCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una cita para ver los detalles.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cita citaSeleccionada = dgvCVistaCitas.SelectedRows[0].DataBoundItem as Cita;

                if (citaSeleccionada != null)
                {
                    CargarCitaEnDgvEdicion(citaSeleccionada);
                    tbAgendaCita.SelectedTab = tabPage3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles de la cita: {ex.Message}",
                    "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCitaEnDgvEdicion(Cita cita)
        {
            List<Cita> listaCitaUnica = new List<Cita> { cita };
            dgvEditarCitas.DataSource = listaCitaUnica;
            FormatearDgvCitas(dgvEditarCitas);

            if (dgvEditarCitas.Columns.Contains("EstadoCita"))
            {
                DataGridViewComboBoxColumn estadoColumna = new DataGridViewComboBoxColumn();
                estadoColumna.HeaderText = "Estado";
                estadoColumna.Name = "EstadoCitaEditable";
                estadoColumna.DataPropertyName = "EstadoCita";
                estadoColumna.Items.AddRange("Programada", "Atendida", "Cancelada", "No Asistió");

                dgvEditarCitas.Columns.Remove("EstadoCita");
                dgvEditarCitas.Columns.Insert(dgvEditarCitas.ColumnCount, estadoColumna);
                estadoColumna.DefaultCellStyle.NullValue = cita.EstadoCita;
            }

            foreach (DataGridViewColumn col in dgvEditarCitas.Columns)
            {
                if (col.Name != "EstadoCitaEditable" && col.Name != "MotivoConsulta")
                {
                    col.ReadOnly = true;
                    col.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvEditarCitas.Rows.Count == 0 || dgvEditarCitas.Rows[0].IsNewRow)
            {
                MessageBox.Show("No hay cita cargada para guardar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Cita citaEditada = dgvEditarCitas.Rows[0].DataBoundItem as Cita;

                if (citaEditada == null)
                {
                    MessageBox.Show("Error al obtener el objeto de la fila.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = _citasDal.ActualizarCita(citaEditada);

                if (exito)
                {
                    MessageBox.Show("Cita actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbAgendaCita.SelectedTab = tabPage1;
                    CargarCitasAgenda();
                    dgvEditarCitas.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar la cita.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la aplicación: {ex.Message}", "Error Inesperado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ******************************************************
        // UTILIDADES
        // ******************************************************

        private void FormatearDgvCitas(DataGridView dgv)
        {
            // Ocultar IDs
            if (dgv.Columns.Contains("IdCita")) dgv.Columns["IdCita"].Visible = false;
            if (dgv.Columns.Contains("IdPaciente")) dgv.Columns["IdPaciente"].Visible = false;
            if (dgv.Columns.Contains("IdMedico")) dgv.Columns["IdMedico"].Visible = false;
            if (dgv.Columns.Contains("IdConsultorio")) dgv.Columns["IdConsultorio"].Visible = false;
            if (dgv.Columns.Contains("IdEspecialidad")) dgv.Columns["IdEspecialidad"].Visible = false;

            // Formatear
            if (dgv.Columns.Contains("Fecha"))
                dgv.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgv.Columns.Contains("Hora"))
                dgv.Columns["Hora"].DefaultCellStyle.Format = "hh\\:mm";

            // Renombrar
            if (dgv.Columns.Contains("NombrePaciente"))
                dgv.Columns["NombrePaciente"].HeaderText = "Paciente";
            if (dgv.Columns.Contains("NombreMedico"))
                dgv.Columns["NombreMedico"].HeaderText = "Médico";
            if (dgv.Columns.Contains("NombreEspecialidad"))
                dgv.Columns["NombreEspecialidad"].HeaderText = "Especialidad";
            if (dgv.Columns.Contains("NombreConsultorio"))
                dgv.Columns["NombreConsultorio"].HeaderText = "Consultorio";
            if (dgv.Columns.Contains("Fecha"))
                dgv.Columns["Fecha"].HeaderText = "Fecha Cita";
            if (dgv.Columns.Contains("Hora"))
                dgv.Columns["Hora"].HeaderText = "Hora Cita";
            if (dgv.Columns.Contains("TipoCita"))
                dgv.Columns["TipoCita"].HeaderText = "Tipo";
            if (dgv.Columns.Contains("EstadoCita"))
                dgv.Columns["EstadoCita"].HeaderText = "Estado";
            if (dgv.Columns.Contains("MotivoConsulta"))
                dgv.Columns["MotivoConsulta"].HeaderText = "Motivo";

            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            if (dgv.Columns.Contains("MotivoConsulta"))
                dgv.Columns["MotivoConsulta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }


    public class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } // Propiedad para la vista
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; } // Propiedad para la vista
        public int IdConsultorio { get; set; } // Se puede ignorar por ahora si no es relevante en la UI
        public string NombreConsultorio { get; set; } // Propiedad para la vista
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string TipoCita { get; set; }
        public string MotivoConsulta { get; set; }
        public string EstadoCita { get; set; }
        public int IdEspecialidad { get; set; } // Para agregar/filtrar por especialidad
        public string NombreEspecialidad { get; set; } // Propiedad para la vista
    }


    public class Catalogo
    {
        // Usado para Especialidades, Médicos, Pacientes
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Sobreescribir ToString es crucial para que el ComboBox muestre el nombre
        public override string ToString()
        {
            return Nombre;
        }
    }



    public class CitasDAL
    {
        // ⚠️ CAMBIA ESTA CADENA DE CONEXIÓN por la de tu base de datos
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ClinicaProDB"].ConnectionString;

        // ----------------------------------------------------
        // MÉTODOS DE CARGA PARA COMBOBOXES
        // ----------------------------------------------------

        public List<Catalogo> ObtenerEspecialidades()
        {
            List<Catalogo> especialidades = new List<Catalogo>();
            string sql = "SELECT IdEspecialidad, NombreEspecialidad FROM CAT_ESPECIALIDADES ORDER BY NombreEspecialidad";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    especialidades.Add(new Catalogo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            return especialidades;
        }

        // CitasDAL.cs

        // ----------------------------------------------------
        // MÉTODOS DE BÚSQUEDA ESPECÍFICOS
        // ----------------------------------------------------

        /// <summary>
        /// Obtiene el Id de Especialidad de un médico basado en su IdEmpleado.
        /// </summary>
        /// <param name="idEmpleado">El IdEmpleado del médico.</param>
        /// <returns>El IdEspecialidad si se encuentra, de lo contrario, 0.</returns>
        public int ObtenerIdEspecialidadPorMedico(int idEmpleado)
        {
            int idEsp = 0;
            string sql = "SELECT IdEspecialidad FROM MEDICOS WHERE IdEmpleado = @IdEmpleado";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                try
                {
                    conn.Open();
                    // ExecuteScalar es ideal para obtener un solo valor (el ID)
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        idEsp = Convert.ToInt32(resultado);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener la especialidad del médico: " + ex.Message);
                }
            }
            return idEsp;
        }

        public List<Catalogo> ObtenerMedicosPorEspecialidad(int? idEsp)
        {
            List<Catalogo> medicos = new List<Catalogo>();

            // La consulta siempre debe usar la tabla MEDICOS para filtrar solo a quienes son médicos.
            string sql = @"
        SELECT E.IdEmpleado, E.Nombre + ' ' + E.Apellido 
        FROM EMPLEADOS E
        INNER JOIN MEDICOS M ON E.IdEmpleado = M.IdEmpleado
        WHERE 1 = 1 "; // Se usa 1=1 para iniciar los filtros condicionales

            if (idEsp.HasValue && idEsp.Value != 0)
            {
                // Si se seleccionó una especialidad válida, aplicamos el filtro
                sql += " AND M.IdEspecialidad = @IdEspecialidad ";
            }

            sql += " ORDER BY E.Apellido";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (idEsp.HasValue && idEsp.Value != 0)
                {
                    cmd.Parameters.AddWithValue("@IdEspecialidad", idEsp.Value);
                }

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        medicos.Add(new Catalogo
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al obtener médicos: " + ex.Message);
                }
            }
            return medicos;
        }

        public List<Catalogo> ObtenerPacientes()
        {
            List<Catalogo> pacientes = new List<Catalogo>();
            string sql = "SELECT IdPaciente, Nombre + ' ' + Apellido FROM PACIENTES ORDER BY Apellido";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pacientes.Add(new Catalogo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            return pacientes;
        }

        // ----------------------------------------------------
        // MÉTODOS DE CONSULTA Y FILTRADO DE CITAS (tabPage1 y tabPage3)
        // ----------------------------------------------------
        public bool ActualizarCita(Cita citaModificada)
        {
            string sql = @"
        UPDATE CITAS 
        SET 
            Fecha = @Fecha, 
            Hora = @Hora, 
            TipoCita = @TipoCita, 
            MotivoConsulta = @MotivoConsulta, 
            EstadoCita = @EstadoCita
        WHERE IdCita = @IdCita";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdCita", citaModificada.IdCita);
                cmd.Parameters.AddWithValue("@Fecha", citaModificada.Fecha.Date);
                cmd.Parameters.AddWithValue("@Hora", citaModificada.Hora);
                cmd.Parameters.AddWithValue("@TipoCita", citaModificada.TipoCita);
                cmd.Parameters.AddWithValue("@MotivoConsulta", citaModificada.MotivoConsulta);
                cmd.Parameters.AddWithValue("@EstadoCita", citaModificada.EstadoCita);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar la cita: " + ex.Message);
                    return false;
                }
            }
        }

        public List<Cita> ObtenerCitas(int? idMedico, int? idEsp, DateTime? fechaInicio, DateTime? fechaFin, string estado)
        {
            List<Cita> citas = new List<Cita>();
            string sql = @"
                SELECT 
                    C.IdCita, C.Fecha, C.Hora, C.MotivoConsulta, C.EstadoCita, C.TipoCita,
                    P.IdPaciente, P.Nombre + ' ' + P.Apellido AS NombrePaciente,
                    E.IdEmpleado, E.Nombre + ' ' + E.Apellido AS NombreMedico,
                    CS.NombreConsultorio, CE.NombreEspecialidad
                FROM CITAS C
                INNER JOIN PACIENTES P ON C.IdPaciente = P.IdPaciente
                INNER JOIN MEDICOS M ON C.IdMedico = M.IdMedico
                INNER JOIN EMPLEADOS E ON M.IdEmpleado = E.IdEmpleado
                INNER JOIN CAT_CONSULTORIOS CS ON C.IdConsultorio = CS.IdConsultorio
                INNER JOIN CAT_ESPECIALIDADES CE ON M.IdEspecialidad = CE.IdEspecialidad
                WHERE 1 = 1 ";

            // Implementación de filtros dinámicos
            if (idMedico.HasValue) sql += " AND M.IdMedico = @IdMedico ";
            if (idEsp.HasValue) sql += " AND CE.IdEspecialidad = @IdEspecialidad ";
            if (fechaInicio.HasValue) sql += " AND C.Fecha >= @FechaInicio ";
            if (fechaFin.HasValue) sql += " AND C.Fecha <= @FechaFin ";
            if (!string.IsNullOrEmpty(estado) && estado != "Todos") sql += " AND C.EstadoCita = @EstadoCita ";

            sql += " ORDER BY C.Fecha, C.Hora";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (idMedico.HasValue) cmd.Parameters.AddWithValue("@IdMedico", idMedico.Value);
                if (idEsp.HasValue) cmd.Parameters.AddWithValue("@IdEspecialidad", idEsp.Value);
                if (fechaInicio.HasValue) cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value.Date);
                if (fechaFin.HasValue) cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Value.Date);
                if (!string.IsNullOrEmpty(estado) && estado != "Todos") cmd.Parameters.AddWithValue("@EstadoCita", estado);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    citas.Add(new Cita
                    {
                        IdCita = reader.GetInt32(0),
                        Fecha = reader.GetDateTime(1),
                        Hora = reader.GetTimeSpan(2),
                        MotivoConsulta = reader.GetString(3),
                        EstadoCita = reader.GetString(4),
                        TipoCita = reader.GetString(5),
                        IdPaciente = reader.GetInt32(6),
                        NombrePaciente = reader.GetString(7),
                        IdMedico = reader.GetInt32(8),
                        NombreMedico = reader.GetString(9),
                        NombreConsultorio = reader.GetString(10),
                        NombreEspecialidad = reader.GetString(11)
                    });
                }
            }
            return citas;
        }

        // ----------------------------------------------------
        // MÉTODOS DE INSERCIÓN (tabPage2)
        // ----------------------------------------------------

        public bool InsertarCita(Cita nuevaCita)
        {
            // Necesitamos buscar un IdConsultorio por defecto o basado en la especialidad del médico
            // Por simplicidad, tomaremos el primer consultorio disponible de la tabla CAT_CONSULTORIOS
            int idConsultorio = 1; // Asumiendo que el ID 1 es un consultorio genérico. Ajusta según tu lógica.

            // Necesitamos obtener el IdMedico real del objeto Catalogo (que trae IdEmpleado), 
            // no el IdEmpleado. Debemos hacer un sub-query o asegurarnos que el combobox traiga IdMedico.
            // Por simplicidad de la DAL, asumimos que IdMedico en el modelo Cita es en realidad el IdEmpleado del médico seleccionado.
            // Para ser correctos, debemos obtener el IdMedico de la tabla MEDICOS a partir del IdEmpleado.

            // Subconsulta para obtener IdMedico y IdConsultorio del médico
            string obtenerIdsSql = @"
                SELECT M.IdMedico, C.IdConsultorio 
                FROM MEDICOS M 
                INNER JOIN EMPLEADOS E ON M.IdEmpleado = E.IdEmpleado 
                INNER JOIN CAT_ESPECIALIDADES CE ON M.IdEspecialidad = CE.IdEspecialidad
                INNER JOIN CAT_CONSULTORIOS C ON C.NombreConsultorio = (
                    SELECT TOP 1 NombreConsultorio FROM CAT_CONSULTORIOS WHERE NombreConsultorio LIKE '%' + CE.NombreEspecialidad + '%' OR NombreConsultorio LIKE '%General%'
                )
                WHERE E.IdEmpleado = @IdEmpleado;
            ";

            int idMedicoTabla = 0;
            int idConsultorioAsignado = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmdIds = new SqlCommand(obtenerIdsSql, conn);
                cmdIds.Parameters.AddWithValue("@IdEmpleado", nuevaCita.IdMedico); // IdMedico en DTO está cargando IdEmpleado del ComboBox
                conn.Open();
                SqlDataReader reader = cmdIds.ExecuteReader();
                if (reader.Read())
                {
                    idMedicoTabla = reader.GetInt32(0);
                    idConsultorioAsignado = reader.GetInt32(1);
                }
                reader.Close();
            }

            if (idMedicoTabla == 0) return false; // Error al encontrar el médico o el consultorio asociado

            string sql = @"
                INSERT INTO CITAS (IdPaciente, IdMedico, IdConsultorio, Fecha, Hora, TipoCita, MotivoConsulta, EstadoCita) 
                VALUES (@IdPaciente, @IdMedico, @IdConsultorio, @Fecha, @Hora, @TipoCita, @MotivoConsulta, @EstadoCita)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdPaciente", nuevaCita.IdPaciente);
                cmd.Parameters.AddWithValue("@IdMedico", idMedicoTabla); // Usamos el IdMedico real
                cmd.Parameters.AddWithValue("@IdConsultorio", idConsultorioAsignado); // Usamos el consultorio asignado
                cmd.Parameters.AddWithValue("@Fecha", nuevaCita.Fecha.Date);
                cmd.Parameters.AddWithValue("@Hora", nuevaCita.Hora);
                cmd.Parameters.AddWithValue("@TipoCita", nuevaCita.TipoCita);
                cmd.Parameters.AddWithValue("@MotivoConsulta", nuevaCita.MotivoConsulta);
                cmd.Parameters.AddWithValue("@EstadoCita", nuevaCita.EstadoCita);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }

}