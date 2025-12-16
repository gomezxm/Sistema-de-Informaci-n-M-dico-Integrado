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
    public partial class Modulo5 : UserControl
    {
        private LaboratorioDAL _laboratorioDAL;
        private bool _isLoadingData = false;

        public Modulo5()
        {
            InitializeComponent();
            _laboratorioDAL = new LaboratorioDAL();

            // Suscribir eventos
            this.Load += Modulo5_Load;

            // Eventos TabPage1 - Generar Orden
            this.bt_GenerarOrden.Click += Bt_GenerarOrden_Click;
            this.comboBoxPaciente.SelectedIndexChanged += ComboBoxPaciente_SelectedIndexChanged;

            // Eventos TabPage2 - Resultados
            this.comboBoxIDOrdenLab.SelectedIndexChanged += ComboBoxIDOrdenLab_SelectedIndexChanged;
            this.buttonGuardarResgistrosResultados.Click += ButtonGuardarResultados_Click;
            this.button2.Click += Button2_ImprimirResultados_Click; // Botón Imprimir Resultados
        }

        // ******************************************************
        // CARGA INICIAL
        // ******************************************************

        private void Modulo5_Load(object sender, EventArgs e)
        {
            _isLoadingData = true;

            CargarCatalogosTabOrden();
            CargarCatalogosTabResultados();

            _isLoadingData = false;
        }

        // ******************************************************
        // TAB 1: GENERAR ORDEN DE LABORATORIO
        // ******************************************************

        private void CargarCatalogosTabOrden()
        {
            try
            {
                // Cargar Pacientes
                List<Catalogo> pacientes = _laboratorioDAL.ObtenerPacientes();
                pacientes.Insert(0, new Catalogo { Id = 0, Nombre = "Seleccione un Paciente" });
                textBoxPaciente.DataSource = pacientes;
                textBoxPaciente.DisplayMember = "Nombre";
                textBoxPaciente.ValueMember = "Id";
                textBoxPaciente.SelectedIndex = 0;

                // Cargar Médicos Solicitantes
                List<Catalogo> medicos = _laboratorioDAL.ObtenerMedicos();
                medicos.Insert(0, new Catalogo { Id = 0, Nombre = "Seleccione un Médico" });
                comboBoxMedicoSolicitante.DataSource = medicos;
                comboBoxMedicoSolicitante.DisplayMember = "Nombre";
                comboBoxMedicoSolicitante.ValueMember = "Id";
                comboBoxMedicoSolicitante.SelectedIndex = 0;

                // Tipos de Muestra
                if (comboBoxTipoMuestra.Items.Count == 0)
                {
                    comboBoxTipoMuestra.Items.AddRange(new string[] {
                        "Sangre venosa",
                        "Orina",
                        "Heces",
                        "Sangre arterial",
                        "Líquido cefalorraquídeo",
                        "Esputo"
                    });
                }

                // Prioridad
                if (comboBoxPrioridad.Items.Count == 0)
                {
                    comboBoxPrioridad.Items.AddRange(new string[] { "Rutina", "Urgente" });
                }

                // Estado de Orden
                if (comboBoxEstadoOrden.Items.Count == 0)
                {
                    comboBoxEstadoOrden.Items.AddRange(new string[] {
                        "Pendiente",
                        "Procesando",
                        "Completada"
                    });
                    comboBoxEstadoOrden.SelectedIndex = 0; // Pendiente por defecto
                }

                // Cargar Exámenes Disponibles
                CargarExamenesDisponibles();

                // Fecha actual
                dateTimePickerFechaSolicitud.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarExamenesDisponibles()
        {
            try
            {
                List<Examen> examenes = _laboratorioDAL.ObtenerExamenesDisponibles();

                // Configurar DataGridView con CheckBox para selección
                dataGridViewListaExamenes.DataSource = examenes;

                // Agregar columna de selección si no existe
                if (!dataGridViewListaExamenes.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    dataGridViewListaExamenes.Columns.Insert(0, checkColumn);
                }

                // Ocultar ID
                if (dataGridViewListaExamenes.Columns.Contains("IdExamen"))
                    dataGridViewListaExamenes.Columns["IdExamen"].Visible = false;

                // Formatear columnas
                if (dataGridViewListaExamenes.Columns.Contains("NombreExamen"))
                    dataGridViewListaExamenes.Columns["NombreExamen"].HeaderText = "Examen";

                if (dataGridViewListaExamenes.Columns.Contains("UnidadMedida"))
                    dataGridViewListaExamenes.Columns["UnidadMedida"].HeaderText = "Unidad";

                if (dataGridViewListaExamenes.Columns.Contains("ValorReferencia"))
                {
                    dataGridViewListaExamenes.Columns["ValorReferencia"].HeaderText = "Valor Referencia";
                    dataGridViewListaExamenes.Columns["ValorReferencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dataGridViewListaExamenes.AllowUserToAddRows = false;
                dataGridViewListaExamenes.AllowUserToDeleteRows = false;
                dataGridViewListaExamenes.ReadOnly = false;
                dataGridViewListaExamenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar exámenes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar información adicional del paciente si es necesario
            if (textBoxPaciente.SelectedItem is Catalogo paciente && paciente.Id > 0)
            {
                // Aquí puedes cargar datos adicionales del paciente si los necesitas
                textBoxIDOrden.Text = ""; // Limpiar ID de orden anterior
            }
        }

        private void Bt_GenerarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (textBoxPaciente.SelectedItem == null ||
                    (textBoxPaciente.SelectedItem as Catalogo)?.Id <= 0)
                {
                    MessageBox.Show("Por favor, seleccione un paciente.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxMedicoSolicitante.SelectedItem == null ||
                    (comboBoxMedicoSolicitante.SelectedItem as Catalogo)?.Id <= 0)
                {
                    MessageBox.Show("Por favor, seleccione un médico solicitante.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(comboBoxTipoMuestra.Text))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de muestra.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(comboBoxPrioridad.Text))
                {
                    MessageBox.Show("Por favor, seleccione la prioridad.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener exámenes seleccionados
                List<int> examenesSeleccionados = new List<int>();
                foreach (DataGridViewRow row in dataGridViewListaExamenes.Rows)
                {
                    if (row.Cells["Seleccionar"].Value != null &&
                        (bool)row.Cells["Seleccionar"].Value == true)
                    {
                        int idExamen = Convert.ToInt32(row.Cells["IdExamen"].Value);
                        examenesSeleccionados.Add(idExamen);
                    }
                }

                if (examenesSeleccionados.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione al menos un examen.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto OrdenLaboratorio
                OrdenLaboratorio nuevaOrden = new OrdenLaboratorio
                {
                    IdPaciente = (textBoxPaciente.SelectedItem as Catalogo).Id,
                    IdMedico = (comboBoxMedicoSolicitante.SelectedItem as Catalogo).Id,
                    FechaSolicitud = dateTimePickerFechaSolicitud.Value,
                    TipoMuestra = comboBoxTipoMuestra.Text,
                    Prioridad = comboBoxPrioridad.Text,
                    IndicacionesClinicas = textBoxIndicaciones.Text.Trim(),
                    EstadoOrden = comboBoxEstadoOrden.Text,
                    ExamenesSeleccionados = examenesSeleccionados
                };

                // Insertar en la base de datos
                int idOrdenGenerada = _laboratorioDAL.InsertarOrdenLaboratorio(nuevaOrden);

                if (idOrdenGenerada > 0)
                {
                    textBoxIDOrden.Text = idOrdenGenerada.ToString();
                    MessageBox.Show($"Orden de laboratorio generada exitosamente.\nID Orden: {idOrdenGenerada}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormularioOrden();
                    CargarOrdenesEnTabResultados(); // Actualizar tab de resultados
                }
                else
                {
                    MessageBox.Show("Error al generar la orden de laboratorio.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar orden: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioOrden()
        {
            _isLoadingData = true;

            textBoxPaciente.SelectedIndex = 0;
            comboBoxMedicoSolicitante.SelectedIndex = 0;
            comboBoxTipoMuestra.SelectedIndex = -1;
            comboBoxPrioridad.SelectedIndex = -1;
            comboBoxEstadoOrden.SelectedIndex = 0;
            textBoxIndicaciones.Clear();
            textBoxIDOrden.Clear();
            dateTimePickerFechaSolicitud.Value = DateTime.Now;

            // Desmarcar todos los checkboxes
            foreach (DataGridViewRow row in dataGridViewListaExamenes.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
            }

            _isLoadingData = false;
        }

        // ******************************************************
        // TAB 2: RESULTADOS DE LABORATORIO
        // ******************************************************

        private void CargarCatalogosTabResultados()
        {
            try
            {
                // Cargar Pacientes
                List<Catalogo> pacientes = _laboratorioDAL.ObtenerPacientes();
                pacientes.Insert(0, new Catalogo { Id = 0, Nombre = "Todos los Pacientes" });
                comboBoxPaciente.DataSource = pacientes;
                comboBoxPaciente.DisplayMember = "Nombre";
                comboBoxPaciente.ValueMember = "Id";
                comboBoxPaciente.SelectedIndex = 0;

                // Cargar Empleados Validadores (Profesionales de Lab)
                List<Catalogo> validadores = _laboratorioDAL.ObtenerEmpleados();
                validadores.Insert(0, new Catalogo { Id = 0, Nombre = "Seleccione Validador" });
                comboBoxValidadoPor.DataSource = validadores;
                comboBoxValidadoPor.DisplayMember = "Nombre";
                comboBoxValidadoPor.ValueMember = "Id";
                comboBoxValidadoPor.SelectedIndex = 0;

                // Estado Resultado
                if (comboBoxEstadoResultado.Items.Count == 0)
                {
                    comboBoxEstadoResultado.Items.AddRange(new string[] {
                        "Preliminar",
                        "Validado"
                    });
                    comboBoxEstadoResultado.SelectedIndex = 0;
                }

                // Cargar órdenes pendientes
                CargarOrdenesEnTabResultados();

                dateTimePickerFechaProcesamiento.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogos de resultados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrdenesEnTabResultados()
        {
            try
            {
                // Obtener órdenes pendientes o en procesamiento
                List<Catalogo> ordenes = _laboratorioDAL.ObtenerOrdenesPendientes();
                ordenes.Insert(0, new Catalogo { Id = 0, Nombre = "Seleccione una Orden" });

                comboBoxIDOrdenLab.DataSource = ordenes;
                comboBoxIDOrdenLab.DisplayMember = "Nombre";
                comboBoxIDOrdenLab.ValueMember = "Id";
                comboBoxIDOrdenLab.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar órdenes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxIDOrdenLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingData) return;

            if (comboBoxIDOrdenLab.SelectedItem is Catalogo orden && orden.Id > 0)
            {
                // Cargar información de la orden
                CargarInformacionOrden(orden.Id);

                // Cargar exámenes de la orden
                CargarExamenesDeOrden(orden.Id);
            }
            else
            {
                dataGridViewExamenesResultados.DataSource = null;

                // Limpiar y habilitar el ComboBox de paciente
                _isLoadingData = true;
                comboBoxPaciente.SelectedIndex = 0;
                comboBoxPaciente.Enabled = true;
                _isLoadingData = false;
            }
        }

        private void CargarInformacionOrden(int idOrdenLab)
        {
            try
            {
                // Obtener información completa de la orden
                OrdenLaboratorioInfo infoOrden = _laboratorioDAL.ObtenerInformacionOrden(idOrdenLab);

                if (infoOrden != null)
                {
                    _isLoadingData = true;

                    // Seleccionar el paciente correspondiente en el ComboBox
                    comboBoxPaciente.SelectedValue = infoOrden.IdPaciente;

                    // Deshabilitar el ComboBox para que no se pueda modificar
                    comboBoxPaciente.Enabled = false;

                    _isLoadingData = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar información de la orden: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarExamenesDeOrden(int idOrdenLab)
        {
            try
            {
                List<DetalleOrdenLab> detalles = _laboratorioDAL.ObtenerDetallesOrden(idOrdenLab);

                dataGridViewExamenesResultados.DataSource = detalles;

                // Ocultar columnas ID
                if (dataGridViewExamenesResultados.Columns.Contains("IdDetalleLab"))
                    dataGridViewExamenesResultados.Columns["IdDetalleLab"].Visible = false;

                if (dataGridViewExamenesResultados.Columns.Contains("IdOrdenLab"))
                    dataGridViewExamenesResultados.Columns["IdOrdenLab"].Visible = false;

                if (dataGridViewExamenesResultados.Columns.Contains("IdExamen"))
                    dataGridViewExamenesResultados.Columns["IdExamen"].Visible = false;

                // Formatear columnas
                if (dataGridViewExamenesResultados.Columns.Contains("NombreExamen"))
                {
                    dataGridViewExamenesResultados.Columns["NombreExamen"].HeaderText = "Examen";
                    dataGridViewExamenesResultados.Columns["NombreExamen"].ReadOnly = true;
                    dataGridViewExamenesResultados.Columns["NombreExamen"].Width = 200;
                }

                if (dataGridViewExamenesResultados.Columns.Contains("UnidadMedida"))
                {
                    dataGridViewExamenesResultados.Columns["UnidadMedida"].HeaderText = "Unidad";
                    dataGridViewExamenesResultados.Columns["UnidadMedida"].ReadOnly = true;
                }

                if (dataGridViewExamenesResultados.Columns.Contains("ValorReferencia"))
                {
                    dataGridViewExamenesResultados.Columns["ValorReferencia"].HeaderText = "Valor Ref.";
                    dataGridViewExamenesResultados.Columns["ValorReferencia"].ReadOnly = true;
                }

                if (dataGridViewExamenesResultados.Columns.Contains("Resultado"))
                {
                    dataGridViewExamenesResultados.Columns["Resultado"].HeaderText = "Resultado";
                    dataGridViewExamenesResultados.Columns["Resultado"].ReadOnly = false; // Editable
                }

                dataGridViewExamenesResultados.AllowUserToAddRows = false;
                dataGridViewExamenesResultados.AllowUserToDeleteRows = false;
                dataGridViewExamenesResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar exámenes de la orden: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonGuardarResultados_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (comboBoxIDOrdenLab.SelectedItem == null ||
                    (comboBoxIDOrdenLab.SelectedItem as Catalogo)?.Id <= 0)
                {
                    MessageBox.Show("Por favor, seleccione una orden de laboratorio.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxValidadoPor.SelectedItem == null ||
                    (comboBoxValidadoPor.SelectedItem as Catalogo)?.Id <= 0)
                {
                    MessageBox.Show("Por favor, seleccione el profesional validador.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridViewExamenesResultados.Rows.Count == 0)
                {
                    MessageBox.Show("No hay exámenes para guardar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos del formulario
                int idOrdenLab = (comboBoxIDOrdenLab.SelectedItem as Catalogo).Id;
                int idValidador = (comboBoxValidadoPor.SelectedItem as Catalogo).Id;
                DateTime fechaProcesamiento = dateTimePickerFechaProcesamiento.Value;
                string estadoResultado = comboBoxEstadoResultado.Text;
                string comentarios = textBoxComentariosInterpretacion.Text.Trim();

                // Recopilar resultados del DataGridView
                List<DetalleOrdenLab> resultados = new List<DetalleOrdenLab>();

                foreach (DataGridViewRow row in dataGridViewExamenesResultados.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DetalleOrdenLab detalle = new DetalleOrdenLab
                        {
                            IdDetalleLab = Convert.ToInt32(row.Cells["IdDetalleLab"].Value),
                            IdOrdenLab = idOrdenLab,
                            IdExamen = Convert.ToInt32(row.Cells["IdExamen"].Value),
                            Resultado = row.Cells["Resultado"].Value?.ToString() ?? "",
                            FechaProcesamiento = fechaProcesamiento,
                            IdEmpleadoValidador = idValidador,
                            ComentariosInterpretacion = comentarios,
                            EstadoResultados = estadoResultado
                        };

                        resultados.Add(detalle);
                    }
                }

                // Guardar en la base de datos
                bool exito = _laboratorioDAL.ActualizarResultadosOrden(resultados);

                if (exito)
                {
                    MessageBox.Show("Resultados guardados exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormularioResultados();
                    CargarOrdenesEnTabResultados(); // Refrescar lista de órdenes
                }
                else
                {
                    MessageBox.Show("Error al guardar los resultados.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar resultados: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_ImprimirResultados_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya una orden seleccionada
                if (comboBoxIDOrdenLab.SelectedItem == null ||
                    (comboBoxIDOrdenLab.SelectedItem as Catalogo)?.Id <= 0)
                {
                    MessageBox.Show("Por favor, seleccione una orden de laboratorio para imprimir.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que haya resultados cargados
                if (dataGridViewExamenesResultados.Rows.Count == 0)
                {
                    MessageBox.Show("No hay resultados para imprimir.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idOrdenLab = (comboBoxIDOrdenLab.SelectedItem as Catalogo).Id;

                // Obtener información completa de la orden
                OrdenLaboratorioInfo infoOrden = _laboratorioDAL.ObtenerInformacionOrden(idOrdenLab);

                if (infoOrden == null)
                {
                    MessageBox.Show("No se pudo obtener la información de la orden.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener detalles con resultados
                List<DetalleOrdenLab> resultados = _laboratorioDAL.ObtenerDetallesOrden(idOrdenLab);

                // Generar el reporte
                GenerarReporteResultados(infoOrden, resultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir resultados: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporteResultados(OrdenLaboratorioInfo orden, List<DetalleOrdenLab> resultados)
        {
            try
            {
                // Crear StringBuilder para el reporte
                StringBuilder reporte = new StringBuilder();

                // Encabezado del reporte
                reporte.AppendLine("═══════════════════════════════════════════════════════════════");
                reporte.AppendLine("              CLÍNICA PRO - RESULTADOS DE LABORATORIO");
                reporte.AppendLine("═══════════════════════════════════════════════════════════════");
                reporte.AppendLine();

                // Información de la orden
                reporte.AppendLine("INFORMACIÓN DE LA ORDEN:");
                reporte.AppendLine("───────────────────────────────────────────────────────────────");
                reporte.AppendLine($"Orden No.:           {orden.IdOrdenLab}");
                reporte.AppendLine($"Fecha de Solicitud:  {orden.FechaSolicitud:dd/MM/yyyy HH:mm}");
                reporte.AppendLine($"Estado:              {orden.EstadoOrden}");
                reporte.AppendLine($"Tipo de Muestra:     {orden.TipoMuestra}");
                reporte.AppendLine($"Prioridad:           {orden.Prioridad}");
                reporte.AppendLine();

                // Información del paciente
                reporte.AppendLine("DATOS DEL PACIENTE:");
                reporte.AppendLine("───────────────────────────────────────────────────────────────");
                reporte.AppendLine($"Paciente:            {orden.NombrePaciente}");
                reporte.AppendLine();

                // Información del médico
                reporte.AppendLine("MÉDICO SOLICITANTE:");
                reporte.AppendLine("───────────────────────────────────────────────────────────────");
                reporte.AppendLine($"Dr(a):               {orden.NombreMedico}");
                reporte.AppendLine();

                // Fecha de impresión
                reporte.AppendLine($"Fecha de Impresión:  {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                reporte.AppendLine();
                reporte.AppendLine("═══════════════════════════════════════════════════════════════");
                reporte.AppendLine("                      RESULTADOS DE EXÁMENES");
                reporte.AppendLine("═══════════════════════════════════════════════════════════════");
                reporte.AppendLine();

                // Tabla de resultados
                int contador = 1;
                foreach (var detalle in resultados)
                {
                    reporte.AppendLine($"{contador}. {detalle.NombreExamen}");
                    reporte.AppendLine($"   Resultado:         {detalle.Resultado ?? "PENDIENTE"}");
                    reporte.AppendLine($"   Unidad:            {detalle.UnidadMedida ?? "N/A"}");
                    reporte.AppendLine($"   Valor Referencia:  {detalle.ValorReferencia ?? "N/A"}");

                    if (detalle.FechaProcesamiento.HasValue)
                    {
                        reporte.AppendLine($"   Fecha Proceso:     {detalle.FechaProcesamiento.Value:dd/MM/yyyy}");
                    }

                    reporte.AppendLine($"   Estado:            {detalle.EstadoResultados}");
                    reporte.AppendLine();
                    contador++;
                }

                // Comentarios e interpretación
                if (!string.IsNullOrWhiteSpace(textBoxComentariosInterpretacion.Text))
                {
                    reporte.AppendLine("───────────────────────────────────────────────────────────────");
                    reporte.AppendLine("COMENTARIOS E INTERPRETACIÓN:");
                    reporte.AppendLine("───────────────────────────────────────────────────────────────");
                    reporte.AppendLine(textBoxComentariosInterpretacion.Text);
                    reporte.AppendLine();
                }

                // Validador
                if (comboBoxValidadoPor.SelectedItem is Catalogo validador && validador.Id > 0)
                {
                    reporte.AppendLine("───────────────────────────────────────────────────────────────");
                    reporte.AppendLine($"Validado por:        {validador.Nombre}");
                    if (dateTimePickerFechaProcesamiento.Value != null)
                    {
                        reporte.AppendLine($"Fecha Validación:    {dateTimePickerFechaProcesamiento.Value:dd/MM/yyyy}");
                    }
                    reporte.AppendLine();
                }

                // Pie de página
                reporte.AppendLine("═══════════════════════════════════════════════════════════════");
                reporte.AppendLine("          Este documento es válido sin firma ni sello");
                reporte.AppendLine("═══════════════════════════════════════════════════════════════");

                // Mostrar el reporte en un formulario de vista previa
                MostrarVistaPrevia(reporte.ToString(), $"Resultados_Orden_{orden.IdOrdenLab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarVistaPrevia(string contenido, string titulo)
        {
            // Crear formulario de vista previa
            Form formVistaPrevia = new Form
            {
                Text = $"Vista Previa - {titulo}",
                Size = new Size(900, 700),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.Sizable,
                MinimizeBox = true,
                MaximizeBox = true
            };

            // TextBox para mostrar el contenido
            TextBox txtVistaPrevia = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new Font("Courier New", 9),
                Text = contenido,
                BackColor = Color.White,
                WordWrap = false
            };

            // Panel de botones
            Panel panelBotones = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.LightGray
            };

            // Botón Imprimir
            Button btnImprimir = new Button
            {
                Text = "🖨️ Imprimir",
                Width = 120,
                Height = 35,
                Location = new Point(20, 12),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnImprimir.FlatAppearance.BorderSize = 0;

            // Botón Guardar como TXT
            Button btnGuardarTXT = new Button
            {
                Text = "💾 Guardar TXT",
                Width = 120,
                Height = 35,
                Location = new Point(150, 12),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuardarTXT.FlatAppearance.BorderSize = 0;

            // Botón Copiar al Portapapeles
            Button btnCopiar = new Button
            {
                Text = "📋 Copiar",
                Width = 120,
                Height = 35,
                Location = new Point(280, 12),
                BackColor = Color.FromArgb(241, 196, 15),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCopiar.FlatAppearance.BorderSize = 0;

            // Botón Cerrar
            Button btnCerrar = new Button
            {
                Text = "❌ Cerrar",
                Width = 120,
                Height = 35,
                Location = new Point(410, 12),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;

            // Eventos de botones
            btnImprimir.Click += (s, e) => ImprimirDocumento(contenido);
            btnGuardarTXT.Click += (s, e) => GuardarComoTXT(contenido, titulo);
            btnCopiar.Click += (s, e) =>
            {
                Clipboard.SetText(contenido);
                MessageBox.Show("Contenido copiado al portapapeles.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            btnCerrar.Click += (s, e) => formVistaPrevia.Close();

            // Agregar controles
            panelBotones.Controls.Add(btnImprimir);
            panelBotones.Controls.Add(btnGuardarTXT);
            panelBotones.Controls.Add(btnCopiar);
            panelBotones.Controls.Add(btnCerrar);

            formVistaPrevia.Controls.Add(txtVistaPrevia);
            formVistaPrevia.Controls.Add(panelBotones);

            // Mostrar el formulario
            formVistaPrevia.ShowDialog();
        }

        private void ImprimirDocumento(string contenido)
        {
            try
            {
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                printDoc.PrintPage += (s, ev) =>
                {
                    Font font = new Font("Courier New", 9);
                    float yPos = ev.MarginBounds.Top;
                    int count = 0;
                    float leftMargin = ev.MarginBounds.Left;
                    float topMargin = ev.MarginBounds.Top;
                    string[] lines = contenido.Split('\n');

                    // Calcular líneas por página
                    float linesPerPage = ev.MarginBounds.Height / font.GetHeight(ev.Graphics);

                    // Imprimir cada línea
                    foreach (string line in lines)
                    {
                        if (count < linesPerPage)
                        {
                            yPos = topMargin + (count * font.GetHeight(ev.Graphics));
                            ev.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos, new StringFormat());
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // Si hay más líneas, indicar que hay más páginas
                    if (count < lines.Length)
                    {
                        ev.HasMorePages = true;
                    }
                    else
                    {
                        ev.HasMorePages = false;
                    }
                };

                // Mostrar diálogo de impresión
                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    MessageBox.Show("Documento enviado a la impresora.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarComoTXT(string contenido, string nombreArchivo)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                    FileName = $"{nombreArchivo}_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                    Title = "Guardar Reporte de Resultados"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveDialog.FileName, contenido, Encoding.UTF8);
                    MessageBox.Show($"Archivo guardado exitosamente en:\n{saveDialog.FileName}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioResultados()
        {
            _isLoadingData = true;

            comboBoxIDOrdenLab.SelectedIndex = 0;
            comboBoxPaciente.SelectedIndex = 0;
            comboBoxPaciente.Enabled = true; // Rehabilitar cuando se limpia
            comboBoxValidadoPor.SelectedIndex = 0;
            comboBoxEstadoResultado.SelectedIndex = 0;
            textBoxComentariosInterpretacion.Clear();
            dateTimePickerFechaProcesamiento.Value = DateTime.Now;
            dataGridViewExamenesResultados.DataSource = null;

            _isLoadingData = false;
        }
    }

    // ============================================
    // MODELOS DE DATOS
    // ============================================

    public class Examen
    {
        public int IdExamen { get; set; }
        public string NombreExamen { get; set; }
        public string UnidadMedida { get; set; }
        public string ValorReferencia { get; set; }
    }

    public class OrdenLaboratorio
    {
        public int IdOrdenLab { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string TipoMuestra { get; set; }
        public string Prioridad { get; set; }
        public string IndicacionesClinicas { get; set; }
        public string EstadoOrden { get; set; }
        public List<int> ExamenesSeleccionados { get; set; }
    }

    public class OrdenLaboratorioInfo
    {
        public int IdOrdenLab { get; set; }
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string TipoMuestra { get; set; }
        public string Prioridad { get; set; }
        public string EstadoOrden { get; set; }
    }

    public class DetalleOrdenLab
    {
        public int IdDetalleLab { get; set; }
        public int IdOrdenLab { get; set; }
        public int IdExamen { get; set; }
        public string NombreExamen { get; set; }
        public string UnidadMedida { get; set; }
        public string ValorReferencia { get; set; }
        public string Resultado { get; set; }
        public DateTime? FechaProcesamiento { get; set; }
        public int? IdEmpleadoValidador { get; set; }
        public string ComentariosInterpretacion { get; set; }
        public string EstadoResultados { get; set; }
    }

    // ============================================
    // CAPA DE ACCESO A DATOS
    // ============================================

    public class LaboratorioDAL
    {
        private readonly string connectionString;

        public LaboratorioDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ClinicaProDB"].ConnectionString;
        }

        // Obtener catálogos
        public List<Catalogo> ObtenerPacientes()
        {
            List<Catalogo> pacientes = new List<Catalogo>();
            string sql = "SELECT IdPaciente, Nombre + ' ' + Apellido + ' (' + Cedula + ')' FROM PACIENTES ORDER BY Apellido";

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

        public List<Catalogo> ObtenerMedicos()
        {
            List<Catalogo> medicos = new List<Catalogo>();
            string sql = @"
                SELECT M.IdMedico, E.Nombre + ' ' + E.Apellido + ' - ' + ESP.NombreEspecialidad
                FROM MEDICOS M
                INNER JOIN EMPLEADOS E ON M.IdEmpleado = E.IdEmpleado
                LEFT JOIN CAT_ESPECIALIDADES ESP ON M.IdEspecialidad = ESP.IdEspecialidad
                ORDER BY E.Apellido";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
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
            return medicos;
        }

        public List<Catalogo> ObtenerEmpleados()
        {
            List<Catalogo> empleados = new List<Catalogo>();
            string sql = "SELECT IdEmpleado, Nombre + ' ' + Apellido FROM EMPLEADOS ORDER BY Apellido";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    empleados.Add(new Catalogo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            return empleados;
        }

        public List<Examen> ObtenerExamenesDisponibles()
        {
            List<Examen> examenes = new List<Examen>();
            string sql = "SELECT IdExamen, NombreExamen, UnidadMedida, ValorReferencia FROM CAT_EXAMENES ORDER BY NombreExamen";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    examenes.Add(new Examen
                    {
                        IdExamen = reader.GetInt32(0),
                        NombreExamen = reader.GetString(1),
                        UnidadMedida = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        ValorReferencia = reader.IsDBNull(3) ? "" : reader.GetString(3)
                    });
                }
            }
            return examenes;
        }

        public List<Catalogo> ObtenerOrdenesPendientes()
        {
            List<Catalogo> ordenes = new List<Catalogo>();
            string sql = @"
                SELECT OL.IdOrdenLab, 
                       'Orden #' + CAST(OL.IdOrdenLab AS VARCHAR) + ' - ' + 
                       P.Nombre + ' ' + P.Apellido + ' (' + 
                       CONVERT(VARCHAR, OL.FechaSolicitud, 103) + ')'
                FROM ORDENES_LABORATORIO OL
                INNER JOIN PACIENTES P ON OL.IdPaciente = P.IdPaciente
                WHERE OL.EstadoOrden IN ('Pendiente', 'Procesando')
                ORDER BY OL.FechaSolicitud DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ordenes.Add(new Catalogo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            return ordenes;
        }

        // Insertar orden de laboratorio
        public int InsertarOrdenLaboratorio(OrdenLaboratorio orden)
        {
            int idOrdenGenerada = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insertar la orden principal
                    string sqlOrden = @"
                        INSERT INTO ORDENES_LABORATORIO 
                        (IdPaciente, IdMedico, FechaSolicitud, TipoMuestra, Prioridad, IndicacionesClinicas, EstadoOrden)
                        VALUES (@IdPaciente, @IdMedico, @FechaSolicitud, @TipoMuestra, @Prioridad, @Indicaciones, @Estado);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    SqlCommand cmdOrden = new SqlCommand(sqlOrden, conn, transaction);
                    cmdOrden.Parameters.AddWithValue("@IdPaciente", orden.IdPaciente);
                    cmdOrden.Parameters.AddWithValue("@IdMedico", orden.IdMedico);
                    cmdOrden.Parameters.AddWithValue("@FechaSolicitud", orden.FechaSolicitud);
                    cmdOrden.Parameters.AddWithValue("@TipoMuestra", orden.TipoMuestra);
                    cmdOrden.Parameters.AddWithValue("@Prioridad", orden.Prioridad);
                    cmdOrden.Parameters.AddWithValue("@Indicaciones",
                        string.IsNullOrWhiteSpace(orden.IndicacionesClinicas) ? (object)DBNull.Value : orden.IndicacionesClinicas);
                    cmdOrden.Parameters.AddWithValue("@Estado", orden.EstadoOrden);

                    idOrdenGenerada = (int)cmdOrden.ExecuteScalar();

                    // 2. Insertar los detalles (exámenes seleccionados)
                    string sqlDetalle = @"
                        INSERT INTO DETALLE_ORDEN_LAB 
                        (IdOrdenLab, IdExamen, EstadoResultados)
                        VALUES (@IdOrdenLab, @IdExamen, 'Preliminar')";

                    foreach (int idExamen in orden.ExamenesSeleccionados)
                    {
                        SqlCommand cmdDetalle = new SqlCommand(sqlDetalle, conn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@IdOrdenLab", idOrdenGenerada);
                        cmdDetalle.Parameters.AddWithValue("@IdExamen", idExamen);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return idOrdenGenerada;
        }

        // Obtener detalles de una orden
        public List<DetalleOrdenLab> ObtenerDetallesOrden(int idOrdenLab)
        {
            List<DetalleOrdenLab> detalles = new List<DetalleOrdenLab>();
            string sql = @"
                SELECT 
                    D.IdDetalleLab,
                    D.IdOrdenLab,
                    D.IdExamen,
                    E.NombreExamen,
                    E.UnidadMedida,
                    E.ValorReferencia,
                    D.Resultado,
                    D.FechaProcesamiento,
                    D.IdEmpleadoValidador,
                    D.ComentariosInterpretacion,
                    D.EstadoResultados
                FROM DETALLE_ORDEN_LAB D
                INNER JOIN CAT_EXAMENES E ON D.IdExamen = E.IdExamen
                WHERE D.IdOrdenLab = @IdOrdenLab
                ORDER BY E.NombreExamen";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdOrdenLab", idOrdenLab);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    detalles.Add(new DetalleOrdenLab
                    {
                        IdDetalleLab = reader.GetInt32(0),
                        IdOrdenLab = reader.GetInt32(1),
                        IdExamen = reader.GetInt32(2),
                        NombreExamen = reader.GetString(3),
                        UnidadMedida = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        ValorReferencia = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        Resultado = reader.IsDBNull(6) ? "" : reader.GetString(6),
                        FechaProcesamiento = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                        IdEmpleadoValidador = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                        ComentariosInterpretacion = reader.IsDBNull(9) ? "" : reader.GetString(9),
                        EstadoResultados = reader.GetString(10)
                    });
                }
            }
            return detalles;
        }

        // Obtener información completa de una orden
        public OrdenLaboratorioInfo ObtenerInformacionOrden(int idOrdenLab)
        {
            OrdenLaboratorioInfo info = null;
            string sql = @"
                SELECT 
                    OL.IdOrdenLab,
                    OL.IdPaciente,
                    P.Nombre + ' ' + P.Apellido + ' (' + P.Cedula + ')' AS NombrePaciente,
                    OL.IdMedico,
                    E.Nombre + ' ' + E.Apellido AS NombreMedico,
                    OL.FechaSolicitud,
                    OL.TipoMuestra,
                    OL.Prioridad,
                    OL.EstadoOrden
                FROM ORDENES_LABORATORIO OL
                INNER JOIN PACIENTES P ON OL.IdPaciente = P.IdPaciente
                INNER JOIN MEDICOS M ON OL.IdMedico = M.IdMedico
                INNER JOIN EMPLEADOS E ON M.IdEmpleado = E.IdEmpleado
                WHERE OL.IdOrdenLab = @IdOrdenLab";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdOrdenLab", idOrdenLab);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    info = new OrdenLaboratorioInfo
                    {
                        IdOrdenLab = reader.GetInt32(0),
                        IdPaciente = reader.GetInt32(1),
                        NombrePaciente = reader.GetString(2),
                        IdMedico = reader.GetInt32(3),
                        NombreMedico = reader.GetString(4),
                        FechaSolicitud = reader.GetDateTime(5),
                        TipoMuestra = reader.GetString(6),
                        Prioridad = reader.GetString(7),
                        EstadoOrden = reader.GetString(8)
                    };
                }
            }
            return info;
        }

        // Actualizar resultados de una orden
        public bool ActualizarResultadosOrden(List<DetalleOrdenLab> resultados)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string sql = @"
                        UPDATE DETALLE_ORDEN_LAB 
                        SET Resultado = @Resultado,
                            FechaProcesamiento = @FechaProcesamiento,
                            IdEmpleadoValidador = @IdValidador,
                            ComentariosInterpretacion = @Comentarios,
                            EstadoResultados = @Estado
                        WHERE IdDetalleLab = @IdDetalleLab";

                    foreach (DetalleOrdenLab detalle in resultados)
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn, transaction);
                        cmd.Parameters.AddWithValue("@Resultado",
                            string.IsNullOrWhiteSpace(detalle.Resultado) ? (object)DBNull.Value : detalle.Resultado);
                        cmd.Parameters.AddWithValue("@FechaProcesamiento", detalle.FechaProcesamiento ?? DateTime.Now);
                        cmd.Parameters.AddWithValue("@IdValidador",
                            detalle.IdEmpleadoValidador ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Comentarios",
                            string.IsNullOrWhiteSpace(detalle.ComentariosInterpretacion) ? (object)DBNull.Value : detalle.ComentariosInterpretacion);
                        cmd.Parameters.AddWithValue("@Estado", detalle.EstadoResultados);
                        cmd.Parameters.AddWithValue("@IdDetalleLab", detalle.IdDetalleLab);

                        cmd.ExecuteNonQuery();
                    }

                    // Actualizar el estado de la orden a "Completada" si todos los resultados están validados
                    if (resultados.All(r => r.EstadoResultados == "Validado"))
                    {
                        string sqlUpdateOrden = @"
                            UPDATE ORDENES_LABORATORIO 
                            SET EstadoOrden = 'Completada' 
                            WHERE IdOrdenLab = @IdOrdenLab";

                        SqlCommand cmdOrden = new SqlCommand(sqlUpdateOrden, conn, transaction);
                        cmdOrden.Parameters.AddWithValue("@IdOrdenLab", resultados[0].IdOrdenLab);
                        cmdOrden.ExecuteNonQuery();
                    }
                    else
                    {
                        // Si hay resultados pero no todos están validados, marcar como "Procesando"
                        string sqlUpdateOrden = @"
                            UPDATE ORDENES_LABORATORIO 
                            SET EstadoOrden = 'Procesando' 
                            WHERE IdOrdenLab = @IdOrdenLab";

                        SqlCommand cmdOrden = new SqlCommand(sqlUpdateOrden, conn, transaction);
                        cmdOrden.Parameters.AddWithValue("@IdOrdenLab", resultados[0].IdOrdenLab);
                        cmdOrden.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}