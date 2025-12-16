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
    public partial class Modulo6 : UserControl
    {
        // Instancias de los repositorios
        private  ImagenRepository imagenRepo;
        private  RadioRepository radioRepo;
        private string connectionString;


        public Modulo6()
        {
            InitializeComponent();

            // IMPORTANTE: Reemplaza esta cadena de conexión con la tuya
            connectionString = "Data Source=hospitalserver.database.windows.net;" +
                    "Initial Catalog=BD-Hospital;" +
                    "User ID=SuperAdmin;" +
                    "Password=Hospital.123;" +
                    "Integrated Security=False;" +
                    "MultipleActiveResultSets=True;" +
                    "Connect Timeout=30;" +
                    "Encrypt=True;" +
                    "TrustServerCertificate=False;";

            // Inicializar repositorios
            imagenRepo = new ImagenRepository(connectionString);
            radioRepo = new RadioRepository(connectionString);

            // Suscribir eventos adicionales
            SuscribirEventos();

            // Cargar datos iniciales
            CargarDatosIniciales();
        }

        #region SUSCRIPCIÓN DE EVENTOS

        private void SuscribirEventos()
        {
            // Evento para cuando cambia la selección del estudio en el tab de informes
            comboBox6.SelectedIndexChanged += ComboBox6_SelectedIndexChanged;

            // Evento para cargar datos al cambiar de tab
            tabControl2.SelectedIndexChanged += TabControl2_SelectedIndexChanged;
        }

        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recargar datos cuando se cambia de tab
            if (tabControl2.SelectedIndex == 0)
            {
                CargarEstudios();
            }
            else if (tabControl2.SelectedIndex == 1)
            {
                CargarInformes();
                CargarEstudiosParaInforme();
            }
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona un estudio, cargar el nombre del paciente
            if (comboBox6.SelectedItem != null)
            {
                try
                {
                    int idEstudio = ((ComboBoxItem)comboBox6.SelectedItem).Value;
                    EstudioImagen estudio = imagenRepo.ObtenerPorId(idEstudio);

                    if (estudio != null)
                    {
                        textBox4.Text = estudio.NombrePaciente;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos del estudio: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region MÉTODOS DE CARGA INICIAL

        private void CargarDatosIniciales()
        {
            try
            {
                // Cargar ComboBoxes del Tab de Estudios de Imagen
                CargarPacientes();
                CargarMedicos();
                CargarTiposEstudio();
                CargarSalasEquipo();

                // Establecer estado por defecto
                comboBox5.SelectedIndex = 0; // "Pendiente"

                // Cargar estudios existentes
                CargarEstudios();

                // Cargar datos del Tab de Informes Radiológicos
                CargarEstudiosParaInforme();
                CargarRadiologos();

                // Establecer estado por defecto para informe
                if (comboBox8.Items.Count > 0)
                    comboBox8.SelectedIndex = 0; // "Borrador"

                // Cargar informes existentes
                CargarInformes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void CargarPacientes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT IdPaciente, Nombre + ' ' + Apellido AS NombreCompleto FROM PACIENTES ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    PacienteBox.Items.Clear();
                    while (reader.Read())
                    {
                        PacienteBox.Items.Add(new ComboBoxItem
                        {
                            Value = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }

                    PacienteBox.DisplayMember = "Text";
                    PacienteBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMedicos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT m.IdMedico, e.Nombre + ' ' + e.Apellido AS NombreCompleto 
                                    FROM MEDICOS m
                                    INNER JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado
                                    ORDER BY e.Nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    MedSolBox.Items.Clear();
                    while (reader.Read())
                    {
                        MedSolBox.Items.Add(new ComboBoxItem
                        {
                            Value = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }

                    MedSolBox.DisplayMember = "Text";
                    MedSolBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar médicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposEstudio()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT IdTipoEstudio, NombreEstudio FROM CAT_ESTUDIOS_IMAGEN ORDER BY NombreEstudio";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    TipoEstudioBox.Items.Clear();
                    while (reader.Read())
                    {
                        TipoEstudioBox.Items.Add(new ComboBoxItem
                        {
                            Value = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }

                    TipoEstudioBox.DisplayMember = "Text";
                    TipoEstudioBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de estudio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSalasEquipo()
        {
            // Puedes cargar desde una tabla catálogo o usar valores fijos
            SalEqBox.Items.Clear();
            SalEqBox.Items.AddRange(new string[]
            {
                "Sala Rayos X 1",
                "Sala Rayos X 2",
                "Tomografía",
                "Resonancia Magnética",
                "Ecografía 1",
                "Ecografía 2"
            });
        }

        private void CargarEstudios()
        {
            try
            {
                List<EstudioImagen> estudios = imagenRepo.ObtenerTodos();

                listBox1.Items.Clear();
                foreach (var estudio in estudios)
                {
                    string item = $"ID: {estudio.IdEstudio} | {estudio.NombrePaciente} | " +
                                 $"{estudio.TipoEstudio} | {estudio.FechaHoraEstudio:dd/MM/yyyy HH:mm} | " +
                                 $"Estado: {estudio.EstadoEstudio}";
                    listBox1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estudios: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void CargarEstudiosParaInforme()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Solo estudios realizados que no tienen informe o ya informados
                    string query = @"SELECT e.IdEstudio, 
                                            p.Nombre + ' ' + p.Apellido + ' - ' + c.NombreEstudio + ' (' + 
                                            CONVERT(VARCHAR, e.FechaHoraEstudio, 103) + ')' AS Descripcion
                                    FROM ESTUDIOS_IMAGEN e
                                    INNER JOIN PACIENTES p ON e.IdPaciente = p.IdPaciente
                                    INNER JOIN CAT_ESTUDIOS_IMAGEN c ON e.IdTipoEstudio = c.IdTipoEstudio
                                    WHERE e.EstadoEstudio IN ('Realizado', 'Informado')
                                    ORDER BY e.FechaHoraEstudio DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBox6.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox6.Items.Add(new ComboBoxItem
                        {
                            Value = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }

                    comboBox6.DisplayMember = "Text";
                    comboBox6.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estudios para informe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRadiologos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT IdEmpleado, Nombre + ' ' + Apellido AS NombreCompleto 
                                    FROM EMPLEADOS
                                    WHERE Puesto LIKE '%Radiólogo%' OR Puesto LIKE '%Radiolog%'
                                    ORDER BY Nombre";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBox7.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox7.Items.Add(new ComboBoxItem
                        {
                            Value = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }

                    comboBox7.DisplayMember = "Text";
                    comboBox7.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar radiólogos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarInformes()
        {
            try
            {
                List<InformeRadiologico> informes = radioRepo.ObtenerTodos();

                listBox2.Items.Clear();
                foreach (var informe in informes)
                {
                    string item = $"ID: {informe.IdInforme} | Paciente: {informe.NombrePaciente} | " +
                                 $"{informe.TipoEstudio} | {informe.FechaInforme:dd/MM/yyyy} | " +
                                 $"Estado: {informe.EstadoInforme}";
                    listBox2.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar informes: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        #endregion

        #region EVENTOS TAB ESTUDIOS DE IMAGEN

      

        private void ButtAdjuntar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.dicom;*.dcm|" +
                                       "Archivos DICOM|*.dicom;*.dcm|" +
                                       "Todos los archivos|*.*";

                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Seleccionar archivo de imagen";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaArchivo = openFileDialog.FileName;
                        RutaArcText.Text = rutaArchivo;

                        if (!System.IO.File.Exists(rutaArchivo))
                        {
                            MessageBox.Show("El archivo seleccionado no existe.",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                            RutaArcText.Text = string.Empty;
                            return;
                        }

                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(rutaArchivo);
                        long tamañoKB = fileInfo.Length / 1024;

                        MessageBox.Show($"Archivo adjuntado exitosamente.\nTamaño: {tamañoKB} KB",
                                      "Éxito",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al adjuntar el archivo: {ex.Message}",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                        RutaArcText.Text = string.Empty;
                    }
                }
            }
        }

        private void LimpiarFormularioEstudio()
        {
            IDEstBox.Clear();
            PacienteBox.SelectedIndex = -1;
            MedSolBox.SelectedIndex = -1;
            TipoEstudioBox.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            SalEqBox.SelectedIndex = -1;
            RutaArcText.Clear();
            ObsBox.Clear();
            comboBox5.SelectedIndex = 0;
        }

        #endregion

        #region EVENTOS TAB INFORMES RADIOLÓGICOS

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (comboBox6.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estudio", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox6.Focus();
                    return;
                }

                if (comboBox7.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un radiólogo", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox7.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Debe ingresar la descripción de hallazgos", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Debe ingresar la conclusión diagnóstica", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox6.Focus();
                    return;
                }

                if (comboBox8.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox8.Focus();
                    return;
                }

                // Crear objeto InformeRadiologico
                InformeRadiologico nuevoInforme = new InformeRadiologico
                {
                    IdEstudio = ((ComboBoxItem)comboBox6.SelectedItem).Value,
                    IdEmpleadoRadiologo = ((ComboBoxItem)comboBox7.SelectedItem).Value,
                    FechaInforme = dateTimePicker2.Value,
                    DescripcionHallazgos = textBox5.Text.Trim(),
                    ConclusionDiagnostica = textBox6.Text.Trim(),
                    Recomendaciones = null,
                    EstadoInforme = comboBox8.SelectedItem.ToString()
                };

                // Guardar en la base de datos
                int idGenerado = radioRepo.Insertar(nuevoInforme);

                MessageBox.Show($"Informe guardado exitosamente con ID: {idGenerado}",
                              "Éxito",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // Limpiar formulario
                LimpiarFormularioInforme();

                // Recargar listas
                CargarInformes();
                CargarEstudios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el informe: {ex.Message}\n\nDetalles: {ex.ToString()}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de impresión pendiente de implementar",
                          "Información",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void LimpiarFormularioInforme()
        {
            textBox4.Clear();
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            dateTimePicker2.Value = DateTime.Now;
            textBox5.Clear();
            textBox6.Clear();
            comboBox8.SelectedIndex = 0;
        }

        #endregion

        #region CLASE AUXILIAR

        private class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        #endregion


        #region GUARDAR DATOS DE IMAGEN E INFORMES DE RADIOLOGÍA
        // ----------------------------------------------------------------------
        // BOTÓN 1: buttAdjuntar (Seleccionar Archivo)
        // Solo obtiene la ruta, no guarda en BD todavía para evitar registros incompletos.
        // ----------------------------------------------------------------------
        private void buttAdjuntar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configuración para buscar imágenes o archivos DICOM
                openFileDialog.Filter = "Imágenes Médicas|*.jpg;*.jpeg;*.png;*.bmp;*.dicom;*.dcm|Todos los archivos|*.*";
                openFileDialog.Title = "Seleccionar Imagen del Estudio";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Simplemente mostramos la ruta en el TextBox
                    RutaArcText.Text = openFileDialog.FileName;
                }
            }
        }

        // ----------------------------------------------------------------------
        // BOTÓN 2: Guardar1Butt (Guardar Estudio en BD)
        // Aquí es donde se insertan los datos en la tabla ESTUDIOS_IMAGEN
        // ----------------------------------------------------------------------


        #endregion

        private void Guardar1Butt_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones básicas (Campos obligatorios marcados con *)
                if (PacienteBox.SelectedItem == null || MedSolBox.SelectedItem == null || TipoEstudioBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor complete los campos obligatorios: Paciente, Médico y Tipo de Estudio.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Obtener los IDs desde los SelectedItem de tipo ComboBoxItem de forma segura
                if (!(PacienteBox.SelectedItem is ComboBoxItem pacienteItem)
                    || !(MedSolBox.SelectedItem is ComboBoxItem medicoItem)
                    || !(TipoEstudioBox.SelectedItem is ComboBoxItem tipoItem))
                {
                    MessageBox.Show("Seleccione Paciente, Médico y Tipo de Estudio correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Crear el objeto con los datos del formulario usando los valores obtenidos
                EstudioImagen nuevoEstudio = new EstudioImagen
                {
                    IdPaciente = pacienteItem.Value,
                    IdMedico = medicoItem.Value,
                    IdTipoEstudio = tipoItem.Value,

                    FechaHoraEstudio = dateTimePicker1.Value,
                    SalaEquipo = SalEqBox.Text,

                    // Aquí usamos la ruta que se obtuvo con buttAdjuntar
                    RutaArchivoImagen = RutaArcText.Text,

                    Observaciones = ObsBox.Text,
                    EstadoEstudio = comboBox5.Text // Pendiente, Realizado, etc.
                };

                // 4. Llamar al repositorio para guardar en SQL
                int idGenerado = imagenRepo.Insertar(nuevoEstudio);

                if (idGenerado > 0)
                {
                    MessageBox.Show($"Estudio guardado correctamente con ID: {idGenerado}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioEstudio();
                    CargarEstudios();            // Recargar la lista de abajo (listBox1)
                    CargarEstudiosParaInforme(); // Actualizar la lista en la pestaña de informes
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el estudio: " + ex.Message);
            }
        }

        private void ButtGuaInforme_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones
                if (comboBox6.SelectedItem == null) // Estudio seleccionado
                {
                    MessageBox.Show("Debe seleccionar un Estudio realizado para crear el informe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox7.SelectedItem == null) // Radiólogo
                {
                    MessageBox.Show("Debe seleccionar el Radiólogo responsable.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Crear el objeto Informe
                InformeRadiologico nuevoInforme = new InformeRadiologico
                {
                    IdEstudio = (int)comboBox6.SelectedValue,       // ID del estudio seleccionado
                    IdEmpleadoRadiologo = (int)comboBox7.SelectedValue, // ID del Radiólogo
                    FechaInforme = dateTimePicker2.Value,
                    DescripcionHallazgos = textBox5.Text,           // Hallazgos
                    ConclusionDiagnostica = textBox6.Text,          // Conclusión
                    EstadoInforme = comboBox8.Text                  // Borrador / Final
                };

                // 3. Guardar en Base de Datos
                int idInforme = radioRepo.Insertar(nuevoInforme);

                if (idInforme > 0)
                {
                    MessageBox.Show("Informe guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Opcional: Cambiar el estado del estudio original a "Informado" visualmente
                    // (El repositorio ya hace el UPDATE en SQL, aquí solo actualizamos listas)
                    CargarInformes();       // Recargar listBox2
                    CargarEstudios();       // Recargar lista de estudios para ver el cambio de estado

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar informe: " + ex.Message);
            }
        }

        private void ButtImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}