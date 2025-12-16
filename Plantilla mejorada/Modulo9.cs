using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Borrador
{
    public partial class Modulo9 : UserControl
    {
        public Modulo9()
        {
            InitializeComponent();
            InicializarEventosTabPage1();
            InicializarEventosTabPage2();
            InicializarEventosTabPage3(); // AGREGAR ESTA LÍNEA
            CargarDatosInicialesTabPage1();
            CargarDatosInicialesTabPage2();
            CargarDatosInicialesTabPage3();
        }

        #region TabPage 1 - Registro de Urgencias

        private void InicializarEventosTabPage1()
        {
            // Evento para manejar la selección de Paciente/No identificado
            comboBoxPacientoNoIdentificado.SelectedIndexChanged += ComboBoxPacientoNoIdentificado_SelectedIndexChanged;

            // Evento del botón registrar
        }

        private void CargarDatosInicialesTabPage1()
        {
            // Cargar pacientes de la BD
            CargarPacientes();

            // Configurar fecha/hora actual
            dateTimePickerHoraIngreso.Value = DateTime.Now;
            dateTimePickerHoraIngreso.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraIngreso.CustomFormat = "dd/MM/yyyy HH:mm";

            // Deshabilitar controles inicialmente
            comboBoxPacientes.Enabled = false;
            textBoxPacienteNoIdentificado.Enabled = false;
            textBoxPacienteNoIdentificado.Visible = false;

            // Limpiar el textBox de ID
            textBoxIDAtencionUsuario.ReadOnly = true;
            textBoxIDAtencionUsuario.BackColor = System.Drawing.Color.LightGray;
            textBoxIDAtencionUsuario.Clear();
        }

        private void CargarPacientes()
        {
            try
            {
                string query = @"SELECT IdPaciente, 
                                 Nombre + ' ' + Apellido + ' - Cédula: ' + Cedula AS NombreCompleto 
                                 FROM PACIENTES 
                                 WHERE EstadoPaciente = 'Activo'
                                 ORDER BY Nombre, Apellido";

                // ERROR CORREGIDO: Usar ConexionDB1 en lugar de ConexionDB
                DataTable dt = ConexionDB1.EjecutarConsulta(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxPacientes.DataSource = dt;
                    comboBoxPacientes.DisplayMember = "NombreCompleto";
                    comboBoxPacientes.ValueMember = "IdPaciente";
                    comboBoxPacientes.SelectedIndex = -1;
                }
                else
                {
                    comboBoxPacientes.DataSource = null;
                    MessageBox.Show("No hay pacientes activos registrados en la base de datos.\n\n" +
                                    "Por favor, registre pacientes primero en el módulo correspondiente.",
                                    "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxPacientoNoIdentificado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPacientoNoIdentificado.SelectedItem == null) return;

            string seleccion = comboBoxPacientoNoIdentificado.SelectedItem.ToString();

            if (seleccion == "Paciente")
            {
                // Habilitar selección de paciente registrado
                comboBoxPacientes.Enabled = true;
                comboBoxPacientes.SelectedIndex = -1;

                // Deshabilitar y ocultar campo de texto
                textBoxPacienteNoIdentificado.Enabled = false;
                textBoxPacienteNoIdentificado.Visible = false;
                textBoxPacienteNoIdentificado.Clear();

                // Habilitar tipo de identificación
                CBox_TipoIdentificacion.Enabled = true;
                CBox_TipoIdentificacion.SelectedIndex = -1;
            }
            else if (seleccion == "No identificado")
            {
                // Deshabilitar selección de paciente
                comboBoxPacientes.Enabled = false;
                comboBoxPacientes.SelectedIndex = -1;

                // Habilitar y mostrar campo de texto para descripción
                textBoxPacienteNoIdentificado.Enabled = true;
                textBoxPacienteNoIdentificado.Visible = true;
                textBoxPacienteNoIdentificado.Clear();

                // Establecer tipo de identificación como Desconocido
                CBox_TipoIdentificacion.SelectedItem = "Desconocido";
                CBox_TipoIdentificacion.Enabled = false;
            }
        }

        private bool ValidarFormularioRegistro()
        {
            // Validar selección de tipo de paciente
            if (comboBoxPacientoNoIdentificado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar si es un paciente identificado o no identificado.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPacientoNoIdentificado.Focus();
                return false;
            }

            // Validar paciente seleccionado (si aplica)
            if (comboBoxPacientes.Enabled && comboBoxPacientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un paciente de la lista.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPacientes.Focus();
                return false;
            }

            // Validar descripción de paciente no identificado (si aplica)
            if (textBoxPacienteNoIdentificado.Enabled &&
                string.IsNullOrWhiteSpace(textBoxPacienteNoIdentificado.Text))
            {
                MessageBox.Show("Debe ingresar una descripción del paciente no identificado.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPacienteNoIdentificado.Focus();
                return false;
            }

            // Validar tipo de identificación
            if (CBox_TipoIdentificacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de identificación.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBox_TipoIdentificacion.Focus();
                return false;
            }

            // Validar modo de llegada
            if (CBox_Modollegada.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el modo de llegada del paciente.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBox_Modollegada.Focus();
                return false;
            }

            // Validar motivo principal de consulta
            if (string.IsNullOrWhiteSpace(Txt_MotivoPrincipalConsulta.Text))
            {
                MessageBox.Show("Debe ingresar el motivo principal de la consulta.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_MotivoPrincipalConsulta.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormularioRegistro()
        {
            // Limpiar selecciones
            comboBoxPacientoNoIdentificado.SelectedIndex = -1;
            comboBoxPacientes.SelectedIndex = -1;
            comboBoxPacientes.Enabled = false;
            CBox_TipoIdentificacion.SelectedIndex = -1;
            CBox_TipoIdentificacion.Enabled = true;
            CBox_Modollegada.SelectedIndex = -1;

            // Limpiar campos de texto
            textBoxPacienteNoIdentificado.Clear();
            textBoxPacienteNoIdentificado.Enabled = false;
            textBoxPacienteNoIdentificado.Visible = false;
            Txt_MotivoPrincipalConsulta.Clear();
            Txt_Nombre_Acompañante.Clear();
            Txt_NumeroAcompañante.Clear();
            Txt_ObservacionesIniciales.Clear();

            // Restablecer fecha/hora actual
            dateTimePickerHoraIngreso.Value = DateTime.Now;

            // NO limpiar el textBoxIDAtencionUsuario para que quede visible el último ID registrado
        }

        #endregion

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioRegistro()) return;

            // --- LÓGICA DE MANEJO DE IDPACIENTE MÁS CLARA ---
            object idPacienteParam;

            // Si el ComboBox de pacientes está habilitado y tiene un valor seleccionado
            if (comboBoxPacientes.Enabled && comboBoxPacientes.SelectedValue != null)
            {
                // Usar el IdPaciente seleccionado
                idPacienteParam = comboBoxPacientes.SelectedValue;
            }
            else if (comboBoxPacientes.Enabled && comboBoxPacientes.SelectedValue == null)
            {
                // Esto cubre el caso de que la lista de pacientes esté vacía pero la opción "Paciente" esté seleccionada.
                // En un entorno de producción, esto debería disparar un MessageBox, pero lo tratamos como NULL aquí.
                idPacienteParam = DBNull.Value;
            }
            else // Esto cubre el caso de "No identificado" (comboBoxPacientes.Enabled == false)
            {
                // Enviar NULL a la base de datos
                idPacienteParam = DBNull.Value;
            }

            try
            {
                // Query para insertar y obtener el ID generado
                string query = @"INSERT INTO ATENCIONES_URGENCIAS 
                                 (IdPaciente, TipoIdentificacion, HoraIngreso, ModoLlegada, 
                                 MotivoPrincipal, Acompanante, TelefonoAcompanante, ObservacionesIniciales)
                                 VALUES (@IdPaciente, @TipoIdentificacion, @HoraIngreso, @ModoLlegada, 
                                 @MotivoPrincipal, @Acompanante, @TelefonoAcompanante, @ObservacionesIniciales);
                                 SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@IdPaciente",
                        comboBoxPacientes.Enabled && comboBoxPacientes.SelectedValue != null
                        ? comboBoxPacientes.SelectedValue
                        : (object)DBNull.Value),
                    new SqlParameter("@TipoIdentificacion",
                        CBox_TipoIdentificacion.SelectedItem?.ToString() ?? "Desconocido"),
                    new SqlParameter("@HoraIngreso", dateTimePickerHoraIngreso.Value),
                    new SqlParameter("@ModoLlegada",
                        CBox_Modollegada.SelectedItem?.ToString() ?? ""),
                    new SqlParameter("@MotivoPrincipal", Txt_MotivoPrincipalConsulta.Text.Trim()),
                    new SqlParameter("@Acompanante",
                        string.IsNullOrWhiteSpace(Txt_Nombre_Acompañante.Text)
                        ? (object)DBNull.Value
                        : Txt_Nombre_Acompañante.Text.Trim()),
                    new SqlParameter("@TelefonoAcompanante",
                        string.IsNullOrWhiteSpace(Txt_NumeroAcompañante.Text)
                        ? (object)DBNull.Value
                        : Txt_NumeroAcompañante.Text.Trim()),
                    new SqlParameter("@ObservacionesIniciales",
                        string.IsNullOrWhiteSpace(Txt_ObservacionesIniciales.Text)
                        ? (object)DBNull.Value
                        : Txt_ObservacionesIniciales.Text.Trim())
                };

                // ERROR CORREGIDO: Usar ConexionDB1 en lugar de ConexionDB
                int idAtencion = ConexionDB1.EjecutarComandoConRetorno(query, parametros);

                if (idAtencion > 0)
                {
                    // Mostrar el ID en el TextBox
                    textBoxIDAtencionUsuario.Text = idAtencion.ToString();

                    string nombrePaciente = comboBoxPacientes.Enabled && comboBoxPacientes.SelectedIndex != -1
                        ? comboBoxPacientes.Text
                        : "Paciente No Identificado";

                    MessageBox.Show($"✓ Atención de urgencia registrada con éxito\n\n" +
                                    $"ID de Atención: {idAtencion}\n" +
                                    $"Paciente: {nombrePaciente}\n" +
                                    $"Hora de Ingreso: {dateTimePickerHoraIngreso.Value:dd/MM/yyyy HH:mm}\n\n" +
                                    $"Ahora puede proceder al triaje del paciente.",
                                    "Registro Exitoso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    LimpiarFormularioRegistro();

                    // Preguntar si desea ir al triaje
                    DialogResult resultado = MessageBox.Show(
                        "¿Desea realizar el triaje del paciente ahora?",
                        "Continuar al Triaje",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Cambiar a la pestaña de triaje (TabPage2)
                        Pesta2.SelectedIndex = 1;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID de la atención registrada.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la atención de urgencia:\n\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region TabPage 2 - Triaje

        private void InicializarEventosTabPage2()
        {
            // Evento del botón guardar triaje
            btn_guardartriaje.Click += Btn_guardartriaje_Click;

            // Evento para cuando se cambia de pestaña
            Pesta2.SelectedIndexChanged += Pesta2_SelectedIndexChanged;
        }

        private void Pesta2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se cambia a la pestaña 2 (Triaje), recargar datos
            if (Pesta2.SelectedIndex == 1)
            {
                CargarPacientesTriaje();
                CargarMedicos();
            }
        }

        private void CargarDatosInicialesTabPage2()
        {
            // Cargar pacientes pendientes de triaje
            CargarPacientesTriaje();

            // Cargar médicos
            CargarMedicos();

            // Configurar fecha/hora de triaje
            dateTimePickerFechaTriaje.Value = DateTime.Now;
            dateTimePickerFechaTriaje.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaTriaje.CustomFormat = "dd/MM/yyyy HH:mm";

            // Configurar NumericUpDown de escala de dolor (0-10)
            numericUpDownEsclDolor.Minimum = 0;
            numericUpDownEsclDolor.Maximum = 10;
            numericUpDownEsclDolor.Value = 0;
        }

        private void CargarPacientesTriaje()
        {
            try
            {
                // Query para obtener pacientes que ingresaron a urgencias HOY y NO tienen triaje
                string query = @"SELECT AU.IdAtencion,
                                CASE 
                                    WHEN AU.IdPaciente IS NOT NULL THEN 
                                        P.Nombre + ' ' + P.Apellido + ' - Cédula: ' + P.Cedula
                                    ELSE 
                                        'No Identificado - Ingreso: ' + FORMAT(AU.HoraIngreso, 'HH:mm')
                                END AS NombrePaciente,
                                AU.MotivoPrincipal,
                                FORMAT(AU.HoraIngreso, 'dd/MM/yyyy HH:mm') AS HoraIngreso
                                FROM ATENCIONES_URGENCIAS AU
                                LEFT JOIN PACIENTES P ON AU.IdPaciente = P.IdPaciente
                                WHERE NOT EXISTS (SELECT 1 FROM TRIAJES T WHERE T.IdAtencion = AU.IdAtencion)
                                AND CAST(AU.HoraIngreso AS DATE) = CAST(GETDATE() AS DATE)
                                ORDER BY AU.HoraIngreso ASC";

                DataTable dt = ConexionDB1.EjecutarConsulta(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxPacientePage2.DataSource = dt;
                    comboBoxPacientePage2.DisplayMember = "NombrePaciente";
                    comboBoxPacientePage2.ValueMember = "IdAtencion";
                    comboBoxPacientePage2.SelectedIndex = -1;

                    label13.Text = $"Paciente ({dt.Rows.Count} pendiente(s) de triaje)";
                }
                else
                {
                    comboBoxPacientePage2.DataSource = null;
                    label13.Text = "Paciente (No hay pacientes pendientes)";

                    MessageBox.Show("No hay pacientes pendientes de triaje en este momento.\n\n" +
                                  "Los pacientes deben registrarse primero en la pestaña 'Reg. Urg'.",
                                  "Sin Pacientes Pendientes",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes pendientes de triaje: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMedicos()
        {
            try
            {
                string query = @"SELECT M.IdMedico, 
                                E.Nombre + ' ' + E.Apellido + 
                                CASE 
                                    WHEN ES.NombreEspecialidad IS NOT NULL 
                                    THEN ' - ' + ES.NombreEspecialidad 
                                    ELSE '' 
                                END AS NombreCompleto
                                FROM MEDICOS M
                                INNER JOIN EMPLEADOS E ON M.IdEmpleado = E.IdEmpleado
                                LEFT JOIN CAT_ESPECIALIDADES ES ON M.IdEspecialidad = ES.IdEspecialidad
                                ORDER BY E.Nombre, E.Apellido";

                DataTable dt = ConexionDB1.EjecutarConsulta(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxMedico.DataSource = dt;
                    comboBoxMedico.DisplayMember = "NombreCompleto";
                    comboBoxMedico.ValueMember = "IdMedico";
                    comboBoxMedico.SelectedIndex = -1;
                }
                else
                {
                    comboBoxMedico.DataSource = null;
                    MessageBox.Show("No hay médicos registrados en el sistema.\n\n" +
                                  "Por favor, registre médicos primero.",
                                  "Sin Médicos",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar médicos: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_guardartriaje_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioTriaje()) return;

            try
            {
                // Obtener el nivel de triaje seleccionado (extraer solo el número romano)
                string nivelCompleto = comboBoxNivelTriaje.SelectedItem.ToString(); // "Nivel I", "Nivel II", etc.
                string nivel = nivelCompleto.Replace("Nivel ", "").Trim(); // "I", "II", etc.

                // Primero, obtener el IdEmpleado del médico seleccionado
                int idMedico = Convert.ToInt32(comboBoxMedico.SelectedValue);

                string queryEmpleado = @"SELECT IdEmpleado FROM MEDICOS WHERE IdMedico = @IdMedico";
                SqlParameter[] paramsEmpleado = new SqlParameter[]
                {
                    new SqlParameter("@IdMedico", idMedico)
                };

                DataTable dtEmpleado = ConexionDB1.EjecutarConsulta(queryEmpleado, paramsEmpleado);

                if (dtEmpleado.Rows.Count == 0)
                {
                    MessageBox.Show("No se pudo obtener el empleado asociado al médico seleccionado.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idEmpleado = Convert.ToInt32(dtEmpleado.Rows[0]["IdEmpleado"]);

                // Ahora insertar el triaje
                string query = @"INSERT INTO TRIAJES 
                                (IdAtencion, IdEmpleadoProfesional, NivelTriaje, FrecuenciaCardiaca, 
                                FrecuenciaRespiratoria, PresionArterialSistolica, PresionArterialDiastolica, 
                                SaturacionO2, Temperatura, EscalaDolor, ObservacionesTriaje, FechaHoraTriaje)
                                VALUES (@IdAtencion, @IdEmpleado, @NivelTriaje, @FC, @FR, @PAS, @PAD, 
                                @SatO2, @Temp, @EscDolor, @Obs, @FechaTriaje)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@IdAtencion", comboBoxPacientePage2.SelectedValue),
                    new SqlParameter("@IdEmpleado", idEmpleado),
                    new SqlParameter("@NivelTriaje", nivel),
                    new SqlParameter("@FC",
                        string.IsNullOrWhiteSpace(textBoxFrecuenciaCaridaca.Text)
                        ? (object)DBNull.Value
                        : int.Parse(textBoxFrecuenciaCaridaca.Text)),
                    new SqlParameter("@FR",
                        string.IsNullOrWhiteSpace(textBoxPresionRespiratoria.Text)
                        ? (object)DBNull.Value
                        : int.Parse(textBoxPresionRespiratoria.Text)),
                    new SqlParameter("@PAS",
                        string.IsNullOrWhiteSpace(textBoxPresionArtSitolica.Text)
                        ? (object)DBNull.Value
                        : int.Parse(textBoxPresionArtSitolica.Text)),
                    new SqlParameter("@PAD",
                        string.IsNullOrWhiteSpace(textBoxPresionArtDiastolica.Text)
                        ? (object)DBNull.Value
                        : int.Parse(textBoxPresionArtDiastolica.Text)),
                    new SqlParameter("@SatO2",
                        string.IsNullOrWhiteSpace(textBoxSaturacion.Text)
                        ? (object)DBNull.Value
                        : int.Parse(textBoxSaturacion.Text)),
                    new SqlParameter("@Temp",
                        string.IsNullOrWhiteSpace(textBoxTemperatura.Text)
                        ? (object)DBNull.Value
                        : decimal.Parse(textBoxTemperatura.Text)),
                    new SqlParameter("@EscDolor", numericUpDownEsclDolor.Value),
                    new SqlParameter("@Obs",
                        string.IsNullOrWhiteSpace(textBoxObservaciones.Text)
                        ? (object)DBNull.Value
                        : textBoxObservaciones.Text.Trim()),
                    new SqlParameter("@FechaTriaje", dateTimePickerFechaTriaje.Value)
                };

                if (ConexionDB1.EjecutarComando(query, parametros))
                {
                    string nombrePaciente = comboBoxPacientePage2.Text;
                    string nombreMedico = comboBoxMedico.Text;

                    MessageBox.Show($"✓ Triaje registrado con éxito\n\n" +
                                  $"Paciente: {nombrePaciente}\n" +
                                  $"Nivel de Triaje: {nivelCompleto}\n" +
                                  $"Profesional: {nombreMedico}\n" +
                                  $"Fecha/Hora: {dateTimePickerFechaTriaje.Value:dd/MM/yyyy HH:mm}",
                                  "Triaje Registrado",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    LimpiarFormularioTriaje();
                    CargarPacientesTriaje(); // Recargar la lista de pacientes pendientes

                    // Preguntar si desea ver el monitor de pacientes
                    DialogResult resultado = MessageBox.Show(
                        "¿Desea ver el monitor de pacientes en urgencias?",
                        "Monitor de Urgencias",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Cambiar a la pestaña 3 (Monitor)
                        Pesta2.SelectedIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el triaje:\n\n" + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormularioTriaje()
        {
            // Validar paciente seleccionado
            if (comboBoxPacientePage2.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un paciente de la lista.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPacientePage2.Focus();
                return false;
            }

            // Validar nivel de triaje
            if (comboBoxNivelTriaje.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el nivel de triaje.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxNivelTriaje.Focus();
                return false;
            }

            // Validar médico seleccionado
            if (comboBoxMedico.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el profesional que realiza el triaje.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMedico.Focus();
                return false;
            }

            // Validaciones numéricas opcionales (si se ingresan datos)
            if (!string.IsNullOrWhiteSpace(textBoxFrecuenciaCaridaca.Text))
            {
                if (!int.TryParse(textBoxFrecuenciaCaridaca.Text, out int fc) || fc < 0 || fc > 300)
                {
                    MessageBox.Show("La frecuencia cardíaca debe ser un número entre 0 y 300.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxFrecuenciaCaridaca.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(textBoxPresionRespiratoria.Text))
            {
                if (!int.TryParse(textBoxPresionRespiratoria.Text, out int fr) || fr < 0 || fr > 100)
                {
                    MessageBox.Show("La frecuencia respiratoria debe ser un número entre 0 y 100.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPresionRespiratoria.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(textBoxPresionArtSitolica.Text))
            {
                if (!int.TryParse(textBoxPresionArtSitolica.Text, out int pas) || pas < 0 || pas > 300)
                {
                    MessageBox.Show("La presión arterial sistólica debe ser un número entre 0 y 300.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPresionArtSitolica.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(textBoxPresionArtDiastolica.Text))
            {
                if (!int.TryParse(textBoxPresionArtDiastolica.Text, out int pad) || pad < 0 || pad > 200)
                {
                    MessageBox.Show("La presión arterial diastólica debe ser un número entre 0 y 200.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPresionArtDiastolica.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(textBoxSaturacion.Text))
            {
                if (!int.TryParse(textBoxSaturacion.Text, out int sat) || sat < 0 || sat > 100)
                {
                    MessageBox.Show("La saturación de O2 debe ser un número entre 0 y 100.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxSaturacion.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(textBoxTemperatura.Text))
            {
                if (!decimal.TryParse(textBoxTemperatura.Text, out decimal temp) || temp < 30 || temp > 45)
                {
                    MessageBox.Show("La temperatura debe ser un número entre 30 y 45 grados.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTemperatura.Focus();
                    return false;
                }
            }

            return true;
        }

        private void LimpiarFormularioTriaje()
        {
            // Limpiar selecciones
            comboBoxPacientePage2.SelectedIndex = -1;
            comboBoxNivelTriaje.SelectedIndex = -1;
            comboBoxMedico.SelectedIndex = -1;

            // Limpiar campos de signos vitales
            textBoxFrecuenciaCaridaca.Clear();
            textBoxPresionRespiratoria.Clear();
            textBoxPresionArtSitolica.Clear();
            textBoxPresionArtDiastolica.Clear();
            textBoxSaturacion.Clear();
            textBoxTemperatura.Clear();
            numericUpDownEsclDolor.Value = 0;
            textBoxObservaciones.Clear();

            // Restablecer fecha/hora actual
            dateTimePickerFechaTriaje.Value = DateTime.Now;
        }

        #endregion
        #region TabPage 3 - Cola de Urgencias (Monitor)

        private void InicializarEventosTabPage3()
        {
            // Eventos de los botones
            buttonLlamarPaciente.Click += ButtonLlamarPaciente_Click;
            buttonMarcarAtendido.Click += ButtonMarcarAtendido_Click;
            buttonReasignarPrioridad.Click += ButtonReasignarPrioridad_Click;
            buttonRefrescar.Click += ButtonRefrescar_Click;

            // Evento para filtros
            comboBoxFiltro.SelectedIndexChanged += ComboBoxFiltro_SelectedIndexChanged;
            comboBoxPrioridad.SelectedIndexChanged += ComboBoxPrioridad_SelectedIndexChanged;
        }

        private void CargarDatosInicialesTabPage3()
        {
            // Cargar opciones de prioridades
            CargarPrioridades();

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar datos del monitor
            CargarMonitorPacientes();
        }

        private void CargarPrioridades()
        {
            comboBoxPrioridad.Items.Clear();
            comboBoxPrioridad.Items.Add("Todos");
            comboBoxPrioridad.Items.Add("Nivel I");
            comboBoxPrioridad.Items.Add("Nivel II");
            comboBoxPrioridad.Items.Add("Nivel III");
            comboBoxPrioridad.Items.Add("Nivel IV");
            comboBoxPrioridad.Items.Add("Nivel V");
            comboBoxPrioridad.Items.Add("Sin Triaje");
            comboBoxPrioridad.SelectedIndex = 0; // "Todos"
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            dataGridView1.Columns.Clear();

            // Configurar propiedades generales
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowHeadersVisible = true;

            // Crear columnas manualmente
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdAtencion",
                HeaderText = "ID",
                DataPropertyName = "IdAtencion",
                Width = 60,
                Visible = false // Oculto pero disponible para operaciones
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Paciente",
                HeaderText = "Paciente",
                DataPropertyName = "Paciente",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraIngreso",
                HeaderText = "Hora de Ingreso",
                DataPropertyName = "HoraIngreso",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NivelTriaje",
                HeaderText = "Nivel Triaje",
                DataPropertyName = "NivelTriaje",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MedicoAsignado",
                HeaderText = "Médico Asignado",
                DataPropertyName = "MedicoAsignado",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MinutosEspera",
                HeaderText = "Tiempo Espera (min)",
                DataPropertyName = "MinutosEspera",
                Width = 130
            });
        }

        private void CargarMonitorPacientes(string filtroPrioridad = "Todos", string filtroEstado = null)
        {
            try
            {
                string query = @"SELECT 
                                    AU.IdAtencion,
                                    CASE 
                                        WHEN AU.IdPaciente IS NOT NULL THEN P.Nombre + ' ' + P.Apellido
                                        ELSE 'No Identificado'
                                    END AS Paciente,
                                    FORMAT(AU.HoraIngreso, 'dd/MM/yyyy HH:mm') AS HoraIngreso,
                                    CASE 
                                        WHEN T.NivelTriaje IS NULL THEN 'Sin Triaje'
                                        ELSE 'Nivel ' + T.NivelTriaje
                                    END AS NivelTriaje,
                                    CASE 
                                        WHEN EXISTS (SELECT 1 FROM CONSULTAS_MEDICAS CM 
                                                     WHERE CM.IdPaciente = AU.IdPaciente 
                                                     AND CAST(CM.FechaConsulta AS DATE) = CAST(AU.HoraIngreso AS DATE))
                                        THEN 'Atendido'
                                        WHEN T.IdTriaje IS NULL THEN 'Pendiente Triaje'
                                        ELSE 'En Espera'
                                    END AS Estado,
                                    ISNULL(E.Nombre + ' ' + E.Apellido, 'Sin asignar') AS MedicoAsignado,
                                    DATEDIFF(MINUTE, AU.HoraIngreso, GETDATE()) AS MinutosEspera
                                FROM ATENCIONES_URGENCIAS AU
                                LEFT JOIN PACIENTES P ON AU.IdPaciente = P.IdPaciente
                                LEFT JOIN TRIAJES T ON AU.IdAtencion = T.IdAtencion
                                LEFT JOIN EMPLEADOS E ON T.IdEmpleadoProfesional = E.IdEmpleado
                                WHERE CAST(AU.HoraIngreso AS DATE) = CAST(GETDATE() AS DATE)";

                // Aplicar filtro de prioridad
                if (filtroPrioridad != "Todos")
                {
                    if (filtroPrioridad == "Sin Triaje")
                    {
                        query += " AND T.IdTriaje IS NULL";
                    }
                    else
                    {
                        string nivel = filtroPrioridad.Replace("Nivel ", "");
                        query += $" AND T.NivelTriaje = '{nivel}'";
                    }
                }

                // Aplicar filtro de estado
                if (!string.IsNullOrEmpty(filtroEstado))
                {
                    if (filtroEstado == "En espera")
                    {
                        query += @" AND NOT EXISTS (SELECT 1 FROM CONSULTAS_MEDICAS CM 
                                    WHERE CM.IdPaciente = AU.IdPaciente 
                                    AND CAST(CM.FechaConsulta AS DATE) = CAST(AU.HoraIngreso AS DATE))
                                    AND T.IdTriaje IS NOT NULL";
                    }
                    else if (filtroEstado == "En atención")
                    {
                        query += @" AND EXISTS (SELECT 1 FROM CONSULTAS_MEDICAS CM 
                                    WHERE CM.IdPaciente = AU.IdPaciente 
                                    AND CAST(CM.FechaConsulta AS DATE) = CAST(AU.HoraIngreso AS DATE))";
                    }
                    else if (filtroEstado == "Alta")
                    {
                        // Aquí puedes agregar lógica para pacientes dados de alta
                        query += " AND 1=0"; // Por ahora no hay campo de alta en la BD
                    }
                }

                // Ordenar por prioridad y hora de ingreso
                query += @" ORDER BY 
                            CASE 
                                WHEN T.NivelTriaje IS NULL THEN 6
                                WHEN T.NivelTriaje = 'I' THEN 1 
                                WHEN T.NivelTriaje = 'II' THEN 2 
                                WHEN T.NivelTriaje = 'III' THEN 3 
                                WHEN T.NivelTriaje = 'IV' THEN 4 
                                WHEN T.NivelTriaje = 'V' THEN 5 
                                ELSE 7 
                            END, 
                            AU.HoraIngreso ASC";

                DataTable dt = ConexionDB1.EjecutarConsulta(query);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    AplicarColoresFilas();

                    // Actualizar el label con el conteo
                    label14.Text = $"Cola de atención - {dt.Rows.Count} paciente(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el monitor de pacientes: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarColoresFilas()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["NivelTriaje"].Value != null)
                {
                    string nivelTriaje = row.Cells["NivelTriaje"].Value.ToString();

                    switch (nivelTriaje)
                    {
                        case "Nivel I":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // Rojo
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                            row.DefaultCellStyle.Font = new System.Drawing.Font(dataGridView1.Font, System.Drawing.FontStyle.Bold);
                            break;
                        case "Nivel II":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 193, 7); // Naranja
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            break;
                        case "Nivel III":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 59); // Amarillo
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            break;
                        case "Nivel IV":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(76, 175, 80); // Verde
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                            break;
                        case "Nivel V":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(33, 150, 243); // Azul
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                            break;
                        case "Sin Triaje":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            break;
                    }
                }
            }
        }

        private void ComboBoxPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtroPrioridad = comboBoxPrioridad.SelectedItem?.ToString() ?? "Todos";
            string filtroEstado = comboBoxFiltro.SelectedItem?.ToString();
            CargarMonitorPacientes(filtroPrioridad, filtroEstado);
        }

        private void ComboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtroPrioridad = comboBoxPrioridad.SelectedItem?.ToString() ?? "Todos";
            string filtroEstado = comboBoxFiltro.SelectedItem?.ToString();
            CargarMonitorPacientes(filtroPrioridad, filtroEstado);
        }

        private void ButtonRefrescar_Click(object sender, EventArgs e)
        {
            string filtroPrioridad = comboBoxPrioridad.SelectedItem?.ToString() ?? "Todos";
            string filtroEstado = comboBoxFiltro.SelectedItem?.ToString();
            CargarMonitorPacientes(filtroPrioridad, filtroEstado);

            MessageBox.Show("Monitor actualizado correctamente.",
                          "Actualización",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void ButtonLlamarPaciente_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente del grid.",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

            string nombrePaciente = filaSeleccionada.Cells["Paciente"].Value.ToString();
            string nivelTriaje = filaSeleccionada.Cells["NivelTriaje"].Value.ToString();
            int idAtencion = Convert.ToInt32(filaSeleccionada.Cells["IdAtencion"].Value);

            string mensaje = $"═══════════════════════════════════\n" +
                           $"    LLAMADA DE PACIENTE\n" +
                           $"═══════════════════════════════════\n\n" +
                           $"Paciente: {nombrePaciente}\n" +
                           $"Prioridad: {nivelTriaje}\n" +
                           $"ID Atención: {idAtencion}\n\n" +
                           $"El paciente debe dirigirse al consultorio de urgencias.";

            MessageBox.Show(mensaje,
                          "Llamada de Paciente",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void ButtonMarcarAtendido_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente del grid.",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

            string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
            string nombrePaciente = filaSeleccionada.Cells["Paciente"].Value.ToString();

            if (estado == "Atendido")
            {
                MessageBox.Show("Este paciente ya ha sido marcado como atendido.",
                              "Información",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            if (estado == "Pendiente Triaje")
            {
                MessageBox.Show("Este paciente debe pasar por triaje antes de ser atendido.",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"Para marcar como atendido al paciente '{nombrePaciente}',\n" +
                "debe registrar una consulta médica en el Módulo 4: Consultas Médicas.\n\n" +
                "¿Desea continuar?",
                "Registrar Consulta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Diríjase al Módulo 4 para registrar la consulta médica.",
                              "Información",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        private void ButtonReasignarPrioridad_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente del grid.",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

            string nivelActual = filaSeleccionada.Cells["NivelTriaje"].Value.ToString();
            string nombrePaciente = filaSeleccionada.Cells["Paciente"].Value.ToString();
            int idAtencion = Convert.ToInt32(filaSeleccionada.Cells["IdAtencion"].Value);

            if (nivelActual == "Sin Triaje")
            {
                MessageBox.Show("Este paciente no tiene triaje registrado.\nDebe realizar el triaje primero.",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            // Crear formulario para seleccionar nueva prioridad
            Form formPrioridad = new Form
            {
                Text = "Reasignar Prioridad",
                Size = new System.Drawing.Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblInfo = new Label
            {
                Text = $"Paciente: {nombrePaciente}\nPrioridad actual: {nivelActual}",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblNueva = new Label
            {
                Text = "Nueva prioridad:",
                Location = new System.Drawing.Point(20, 80),
                AutoSize = true
            };

            ComboBox cmbNuevaPrioridad = new ComboBox
            {
                Location = new System.Drawing.Point(20, 110),
                Size = new System.Drawing.Size(150, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbNuevaPrioridad.Items.AddRange(new object[] { "I", "II", "III", "IV", "V" });

            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new System.Drawing.Point(200, 160),
                Size = new System.Drawing.Size(80, 30),
                DialogResult = DialogResult.OK
            };

            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new System.Drawing.Point(290, 160),
                Size = new System.Drawing.Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            formPrioridad.Controls.AddRange(new Control[] { lblInfo, lblNueva, cmbNuevaPrioridad, btnAceptar, btnCancelar });
            formPrioridad.AcceptButton = btnAceptar;
            formPrioridad.CancelButton = btnCancelar;

            if (formPrioridad.ShowDialog() == DialogResult.OK && cmbNuevaPrioridad.SelectedIndex != -1)
            {
                try
                {
                    string nuevaPrioridad = cmbNuevaPrioridad.SelectedItem.ToString();

                    string query = @"UPDATE TRIAJES SET NivelTriaje = @NuevaPrioridad 
                                    WHERE IdAtencion = @IdAtencion";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@NuevaPrioridad", nuevaPrioridad),
                        new SqlParameter("@IdAtencion", idAtencion)
                    };

                    if (ConexionDB1.EjecutarComando(query, parametros))
                    {
                        MessageBox.Show($"Prioridad reasignada con éxito.\n\nPaciente: {nombrePaciente}\nNueva prioridad: Nivel {nuevaPrioridad}",
                                      "Éxito",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Recargar el monitor
                        string filtroPrioridad = comboBoxPrioridad.SelectedItem?.ToString() ?? "Todos";
                        string filtroEstado = comboBoxFiltro.SelectedItem?.ToString();
                        CargarMonitorPacientes(filtroPrioridad, filtroEstado);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al reasignar prioridad: " + ex.Message,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }

    // CLASE ConexionDB (al final del archivo, dentro del namespace)
    public class ConexionDB1
    {
        // AJUSTA ESTA CADENA DE CONEXIÓN SEGÚN TU SERVIDOR
        private static string connectionString = ConfigurationManager.ConnectionStrings["ClinicaProDB"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable EjecutarConsulta(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    if (conn != null)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public static DataTable EjecutarConsulta(string query, SqlParameter[] parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    if (conn != null)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (parametros != null && parametros.Length > 0)
                        {
                            cmd.Parameters.AddRange(parametros);
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta con parámetros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public static bool EjecutarComando(string query, SqlParameter[] parametros = null)
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    if (conn != null)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (parametros != null && parametros.Length > 0)
                        {
                            cmd.Parameters.AddRange(parametros);
                        }
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }

        public static int EjecutarComandoConRetorno(string query, SqlParameter[] parametros = null)
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    if (conn != null)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (parametros != null && parametros.Length > 0)
                        {
                            cmd.Parameters.AddRange(parametros);
                        }
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando con retorno: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return -1;
        }
    }
}