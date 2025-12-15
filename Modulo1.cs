using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Borrador
{
    public partial class Modulo1 : UserControl
    {
        // Colores del tema
        private readonly Color PrimaryBlue = Color.FromArgb(41, 68, 123);
        private readonly Color SecondaryBlue = Color.FromArgb(56, 97, 181);
        private readonly Color AccentBlue = Color.FromArgb(66, 117, 206);
        private readonly Color LightBlue = Color.FromArgb(100, 149, 237);
        private readonly Color BackgroundGray = Color.FromArgb(248, 249, 251);
        private readonly Color CardWhite = Color.White;
        private readonly Color BorderGray = Color.FromArgb(226, 232, 240);
        private readonly Color TextDark = Color.FromArgb(30, 41, 59);
        private readonly Color TextGray = Color.FromArgb(100, 116, 139);

        // Datos
        private readonly List<Dictionary<string, object>> listaPacientes = new List<Dictionary<string, object>>();
        private BindingSource bsPacientes;
        private readonly PacienteRepository _repo = new PacienteRepository();

        // Controles para "Ver pacientes"
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtSearch;
        private DataGridView dgvPacientes;
        private Button btnAgregar;
        private Button btnVerHistoria;
        
        private Panel pnlStats;

        // Controles para "Añadir/Editar paciente"
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCedula;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cbSexo;
        private ComboBox cbEstadoCivil;
        private TextBox txtTelefono;
        private TextBox txtCelular;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private TextBox txtContactoEmergencia;
        private TextBox txtAlergias;
        private TextBox txtAntecedentes;
        private TextBox txtSeguro;
        private TextBox txtPoliza;
        private Button btnGuardar;
        private Button btnCancelar;

        // Estado de edición
        private int? editingId = null;

        // Controles para "Historia"
        private TextBox txtHistAntecedentes;
        private TextBox txtHistAlergias;
        private TextBox txtHistCirugias;
        private TextBox txtHistMedicacion;
        private TextBox txtHistObservaciones;
        private Button btnExportarHistoria;
        private Button btnImprimirHistoria;

        public Modulo1()
        {
            InitializeComponent();
            this.BackColor = BackgroundGray;
            InicializarPacientesTabs();
            try
            {
                // Cargar pacientes desde la base de datos
                CargarPacientesDesdeDB();
            }
            catch (Exception ex)
            {
                var baseEx = ex;
                while (baseEx.InnerException != null) baseEx = baseEx.InnerException;
                MessageBox.Show("No se pudieron cargar los pacientes: " + baseEx.Message, "Conexión BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            RefrescarGrilla();
            tabControl1.SelectedTab = tabPage3;
        }

        private void InicializarPacientesTabs()
        {
            // Estilo del TabControl
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(230, 40);
            tabControl1.Padding = new Point(12, 6);
            tabControl1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Tab "Ver pacientes"
            ConstruirVistaListaPacientes(tabPage3);

            // Tab "Añadir paciente"
            ConstruirFormularioPaciente(tabPage1);

            // Tab "Historia"
            ConstruirHistoriaPaciente(tabPage2);

            // Mostrar historia automáticamente al cambiar a la pestaña
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                var pac = ObtenerPacienteSeleccionado();
                if (pac != null)
                {
                    CargarHistoriaDesdePaciente(pac);
                }
            }
        }

        private void ConstruirVistaListaPacientes(TabPage tab)
        {
            tab.Controls.Clear();
            tab.BackColor = BackgroundGray;

            // Panel principal con padding
            var mainContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                BackColor = BackgroundGray
            };

            // Header con título y subtítulo
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = BackgroundGray
            };

            lblTitle = new Label
            {
                Text = "Gestión de Pacientes",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = TextDark,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            lblSubtitle = new Label
            {
                Text = "Gestione los registros de los pacientes, las admisiones y el historial médico de manera eficiente",
                Font = new Font("Segoe UI", 10F),
                ForeColor = TextGray,
                AutoSize = true,
                Location = new Point(0, 40)
            };

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // Panel de estadísticas (cards superiores)
            pnlStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = BackgroundGray,
                Padding = new Padding(0, 12, 0, 12)
            };

            var statCard1 = CrearStatCard("TOTAL DE PACIENTES", listaPacientes.Count.ToString(), "+12% since last month");

            statCard1.Location = new Point(0, 12);
            statCard1.Width = 280;

            pnlStats.Controls.Add(statCard1);


            // Barra de acciones (búsqueda y botones)
            var actionBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = BackgroundGray,
                Padding = new Padding(0, 8, 0, 8)
            };

            // Búsqueda
            txtSearch = new TextBox
            {
                Width = 350,
                Height = 38,
                Location = new Point(0, 16),
                Font = new Font("Segoe UI", 10F),
                ForeColor = TextGray,
                Text = "Buscar por cédula o nombre...",
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Buscar por cédula o nombre...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = TextDark;
                }
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Buscar por cédula o nombre...";
                    txtSearch.ForeColor = TextGray;
                }
            };
            txtSearch.TextChanged += (s, e) => RefrescarGrilla();

            // Botones de acción
            btnAgregar = CrearBotonModerno("+ Añadir Paciente", SecondaryBlue);
            btnAgregar.Size = new Size(160, 38);
            btnAgregar.Click += (s, e) => IrATabAgregarNuevo();

            // (Eliminado) Botón Filtros

            btnVerHistoria = CrearBotonModerno("📋 Ver Historia", LightBlue);
            // Aumentar tamaño para que el texto sea legible
            btnVerHistoria.Size = new Size(160, 38);
            btnVerHistoria.Click += (s, e) => IrATabHistoriaDesdeSeleccion();

            // (Eliminado) Botón Probar BD

            actionBar.Controls.Add(txtSearch);
            actionBar.Controls.Add(btnAgregar);
            actionBar.Controls.Add(btnVerHistoria);

            // Posicionamiento dinámico: controlar con base en los anchos actuales
            actionBar.Resize += (s, e) =>
            {
                // colocar el botón "Ver Historia" pegado al borde derecho con un pequeño margen
                btnVerHistoria.Location = new Point(actionBar.Width - btnVerHistoria.Width - 16, 16);
                // colocar el botón "Añadir Paciente" a la izquierda del botón de historia
                btnAgregar.Location = new Point(btnVerHistoria.Left - btnAgregar.Width - 12, 16);
            };

            // DataGridView con estilo moderno
            var dgvContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = CardWhite,
                Padding = new Padding(1)
            };

            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                BackgroundColor = CardWhite,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                EnableHeadersVisualStyles = false,
                GridColor = BorderGray,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 9.5F),
                RowTemplate = { Height = 50 }
            };

            // Estilo del header
            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = BackgroundGray;
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = TextGray;
            dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPacientes.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvPacientes.ColumnHeadersHeight = 45;

            // Estilo de las celdas
            // Selección ligeramente más intensa para mejorar contraste (azul un poco más fuerte)
            dgvPacientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvPacientes.DefaultCellStyle.SelectionForeColor = TextDark;
            dgvPacientes.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            // Asegurar contraste en encabezados seleccionados
            dgvPacientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor;
            dgvPacientes.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor;

            // Columnas
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 80
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NOMBRE",
                DataPropertyName = "NombreCompleto",
                Width = 200
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "CÉDULA)",
                DataPropertyName = "Cedula",
                Width = 150
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "FECHA DE NACIMIENTO",
                DataPropertyName = "FechaNacimiento",
                Width = 120
            });

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TELÉFONO",
                DataPropertyName = "Telefono",
                Width = 130
            });

            var colEditar = new DataGridViewButtonColumn
            {
                HeaderText = "ACCIONES",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };

            var colEliminar = new DataGridViewButtonColumn
            {
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };

            dgvPacientes.Columns.Add(colEditar);
            dgvPacientes.Columns.Add(colEliminar);

            dgvPacientes.CellClick += DgvPacientes_CellClick;

            bsPacientes = new BindingSource();
            dgvPacientes.DataSource = bsPacientes;

            dgvContainer.Controls.Add(dgvPacientes);

            mainContainer.Controls.Add(dgvContainer);
            mainContainer.Controls.Add(actionBar);
            mainContainer.Controls.Add(pnlStats);
            mainContainer.Controls.Add(pnlHeader);

            tab.Controls.Add(mainContainer);
        }

        private Panel CrearStatCard(string titulo, string valor, string detalle)
        {
            var card = new Panel
            {
                Height = 76,
                BackColor = CardWhite,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(16)
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = TextGray,
                AutoSize = true,
                Location = new Point(16, 12)
            };

            var lblValor = new Label
            {
                Text = valor,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = PrimaryBlue,
                AutoSize = true,
                Location = new Point(16, 30)
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblValor);

            return card;
        }

        private Button CrearBotonModerno(string texto, Color colorFondo)
        {
            var btn = new Button
            {
                Text = texto,
                BackColor = colorFondo,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AjustarBrillo(colorFondo, -20);
            return btn;
        }

        private Color AjustarBrillo(Color color, int ajuste)
        {
            return Color.FromArgb(
                Math.Max(0, Math.Min(255, color.R + ajuste)),
                Math.Max(0, Math.Min(255, color.G + ajuste)),
                Math.Max(0, Math.Min(255, color.B + ajuste))
            );
        }

        private void ConstruirFormularioPaciente(TabPage tab)
        {
            tab.Controls.Clear();
            tab.BackColor = BackgroundGray;

            var mainContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                BackColor = BackgroundGray,
                AutoScroll = true
            };

            // Card principal con el formulario
            var formCard = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = CardWhite,
                Padding = new Padding(24)
            };

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 16
            };
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            txtNombre = CrearTextBoxModerno();
            txtApellido = CrearTextBoxModerno();
            txtCedula = CrearTextBoxModerno();
            dtpFechaNacimiento = new DateTimePicker { Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10F) };
            cbSexo = CrearComboBoxModerno();
            cbEstadoCivil = CrearComboBoxModerno();
            txtTelefono = CrearTextBoxModerno();
            txtCelular = CrearTextBoxModerno();
            txtEmail = CrearTextBoxModerno();
            txtDireccion = new TextBox { Multiline = true, Height = 60, ScrollBars = ScrollBars.None, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle };
            txtContactoEmergencia = CrearTextBoxModerno();
            txtAlergias = new TextBox { Multiline = true, Height = 80, ScrollBars = ScrollBars.None, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle };
            txtAntecedentes = new TextBox { Multiline = true, Height = 80, ScrollBars = ScrollBars.None, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle };
            txtSeguro = CrearTextBoxModerno();
            txtPoliza = CrearTextBoxModerno();

            cbSexo.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            cbEstadoCivil.Items.AddRange(new object[] { "Soltero/a", "Casado/a", "Divorciado/a", "Viudo/a" });
            // Aplicar estilo visible y seleccionar por defecto para que se note
            EstilizarCombo(cbSexo);
            EstilizarCombo(cbEstadoCivil);
            if (cbSexo.Items.Count > 0 && cbSexo.SelectedIndex < 0) cbSexo.SelectedIndex = 0;
            if (cbEstadoCivil.Items.Count > 0 && cbEstadoCivil.SelectedIndex < 0) cbEstadoCivil.SelectedIndex = 0;

            void AddRow(string labelText, Control control, int row)
            {
                var lbl = new Label
                {
                    Text = labelText,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = TextDark
                };
                var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 5, 10, 5) };
                control.Dock = DockStyle.Top;
                panel.Controls.Add(control);
                main.Controls.Add(lbl, 0, row);
                main.Controls.Add(panel, 1, row);
            }

            AddRow("Nombre:", txtNombre, 0);
            AddRow("Apellido:", txtApellido, 1);
            AddRow("Cédula:", txtCedula, 2);
            AddRow("Fecha nacimiento:", dtpFechaNacimiento, 3);
            AddRow("Sexo:", cbSexo, 4);
            AddRow("Estado civil:", cbEstadoCivil, 5);
            AddRow("Teléfono:", txtTelefono, 6);
            AddRow("Celular:", txtCelular, 7);
            AddRow("Email:", txtEmail, 8);
                        // Placeholders y validación visual básica
                        AplicarPlaceholder(txtNombre, "Ingrese nombre");
                        AplicarPlaceholder(txtApellido, "Ingrese apellido");
                        AplicarPlaceholder(txtCedula, "Ingrese cédula");
                        AplicarPlaceholder(txtTelefono, "Ingrese teléfono");
                        AplicarPlaceholder(txtCelular, "Ingrese celular");
                        AplicarPlaceholder(txtEmail, "Ingrese email");
                        AplicarPlaceholder(txtContactoEmergencia, "Nombre - Teléfono");
                        AplicarValidacionObligatoria(txtNombre);
                        AplicarValidacionObligatoria(txtApellido);
                        AplicarValidacionObligatoria(txtCedula);
            AddRow("Dirección:", txtDireccion, 9);
            AddRow("Contacto emergencia:", txtContactoEmergencia, 10);
            AddRow("Alergias:", txtAlergias, 11);
            AddRow("Antecedentes:", txtAntecedentes, 12);
            AddRow("Seguro:", txtSeguro, 13);
            AddRow("Póliza:", txtPoliza, 14);

            // Fila final: botones al final del scroll
            var botonesLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 12, 0, 12),
                AutoSize = true
            };

            btnGuardar = CrearBotonModerno("Guardar", SecondaryBlue);
            btnGuardar.Size = new Size(130, 42);
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = CrearBotonModerno("Cancelar", Color.Gray);
            btnCancelar.Size = new Size(130, 42);
            btnCancelar.Click += (s, e) =>
            {
                LimpiarFormulario();
                editingId = null;
                tabControl1.SelectedTab = tabPage3;
            };

            botonesLayout.Controls.Add(btnGuardar);
            botonesLayout.Controls.Add(btnCancelar);

            // añadir layout de botones como última fila, ocupando ambas columnas
            main.Controls.Add(new Label { Text = "", AutoSize = true }, 0, 15);
            main.Controls.Add(botonesLayout, 1, 15);

            formCard.Controls.Add(main);

            mainContainer.Controls.Add(formCard);
            tab.Controls.Add(mainContainer);
        }

        private TextBox CrearTextBoxModerno()
        {
            var tb = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                Height = 32,
                BackColor = Color.White,
                ForeColor = TextDark
            };
            // Mejora visual: margen interno mediante Padding simulado con Panel contenedor si se usa AddRow
            return tb;
        }

        private void AplicarPlaceholder(TextBox tb, string placeholder)
        {
            tb.ForeColor = TextGray;
            tb.Text = placeholder;
            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.Text = string.Empty;
                    tb.ForeColor = TextDark;
                }
                tb.BackColor = Color.FromArgb(250, 253, 255);
            };
            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = TextGray;
                }
                bool vacio = tb.Text == placeholder || string.IsNullOrWhiteSpace(tb.Text);
                tb.BackColor = vacio ? Color.FromArgb(255, 245, 245) : Color.White;
            };
        }

        private void AplicarValidacionObligatoria(TextBox tb)
        {
            tb.Leave += (s, e) =>
            {
                bool invalido = string.IsNullOrWhiteSpace(tb.Text) || tb.ForeColor == TextGray;
                tb.BackColor = invalido ? Color.FromArgb(255, 245, 245) : Color.White;
            };
        }

        private ComboBox CrearComboBoxModerno()
        {
            var cb = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                FlatStyle = FlatStyle.Standard,
                BackColor = Color.White,
                ForeColor = TextDark
            };
            cb.Enter += (s, e) => { cb.BackColor = Color.FromArgb(250, 253, 255); };
            cb.Leave += (s, e) => { cb.BackColor = Color.White; };
            return cb;
        }

        private void EstilizarCombo(ComboBox cb)
        {
            if (cb == null) return;
            cb.FlatStyle = FlatStyle.Standard;
            cb.BackColor = Color.White;
            cb.ForeColor = TextDark;
            cb.Enter += (s, e) => { cb.BackColor = Color.FromArgb(250, 253, 255); };
            cb.Leave += (s, e) => { cb.BackColor = Color.White; };
        }

        private void ConstruirHistoriaPaciente(TabPage tab)
        {
            tab.Controls.Clear();
            tab.BackColor = BackgroundGray;

            var mainContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                BackColor = BackgroundGray
            };

            var historyCard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = CardWhite,
                Padding = new Padding(24)
            };

            var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 6, Padding = new Padding(10) };
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            txtHistAntecedentes = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle, BackColor = BackgroundGray };
            txtHistAlergias = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle, BackColor = BackgroundGray };
            txtHistCirugias = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle, BackColor = BackgroundGray };
            txtHistMedicacion = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle, BackColor = BackgroundGray };
            txtHistObservaciones = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 10F), BorderStyle = BorderStyle.FixedSingle, BackColor = BackgroundGray };

            var lblAntecedentes = new Label { Text = "Resumen de antecedentes", AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = TextDark };
            var lblAlergias = new Label { Text = "Alergias", AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = TextDark };
            var lblOtros = new Label { Text = "Datos de contacto / Seguro / Estado", AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = TextDark };

            main.Controls.Add(lblAntecedentes, 0, 0);
            main.Controls.Add(txtHistAntecedentes, 0, 1);
            main.Controls.Add(lblAlergias, 0, 2);
            main.Controls.Add(txtHistAlergias, 0, 3);
            main.Controls.Add(lblOtros, 0, 4);

            var lowerLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3 };
            lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            lowerLayout.Controls.Add(txtHistCirugias, 0, 0);
            lowerLayout.Controls.Add(txtHistMedicacion, 1, 0);
            lowerLayout.Controls.Add(txtHistObservaciones, 2, 0);
            main.Controls.Add(lowerLayout, 0, 5);

            var btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 70, Padding = new Padding(24, 12, 24, 12), BackColor = CardWhite };

            btnExportarHistoria = CrearBotonModerno("📄 Exportar (TXT)", SecondaryBlue);
            btnExportarHistoria.Size = new Size(150, 42);
            btnExportarHistoria.Location = new Point(24, 14);
            btnExportarHistoria.Click += BtnExportarHistoria_Click;

            btnImprimirHistoria = CrearBotonModerno("🖨️ Imprimir", AccentBlue);
            btnImprimirHistoria.Size = new Size(130, 42);
            btnImprimirHistoria.Location = new Point(184, 14);
            btnImprimirHistoria.Click += BtnImprimirHistoria_Click;

            btnPanel.Controls.Add(btnExportarHistoria);
            btnPanel.Controls.Add(btnImprimirHistoria);

            historyCard.Controls.Add(main);
            historyCard.Controls.Add(btnPanel);

            mainContainer.Controls.Add(historyCard);
            tab.Controls.Add(mainContainer);
        }

        private void CargarPacientesDesdeDB()
        {
            listaPacientes.Clear();
            DataTable dt = _repo.ListarPacientes();
            foreach (DataRow row in dt.Rows)
            {
                var d = new Dictionary<string, object>();
                int id = Convert.ToInt32(row["IdPaciente"]);
                d["Id"] = id;
                d["Nombre"] = row["Nombre"]?.ToString();
                d["Apellido"] = row["Apellido"]?.ToString();
                d["NombreCompleto"] = $"{d["Nombre"]} {d["Apellido"]}".Trim();
                d["Cedula"] = row["Cedula"]?.ToString();
                d["FechaNacimiento"] = row["FechaNacimiento"]?.ToString();
                d["Sexo"] = row["Sexo"]?.ToString();
                d["EstadoCivil"] = row["EstadoCivil"]?.ToString();
                d["Telefono"] = row["Telefono"]?.ToString();
                d["Celular"] = row["Celular"]?.ToString();
                d["Email"] = row["Email"]?.ToString();
                d["Direccion"] = row["Direccion"]?.ToString();
                d["Alergias"] = row["AlergiasConocidas"]?.ToString();
                d["Antecedentes"] = row["AntecedentesMedicos"]?.ToString();
                d["IdSeguro"] = row["IdSeguro"] == DBNull.Value ? null : (object)Convert.ToInt32(row["IdSeguro"]);
                d["Seguro"] = row["NombreSeguro"]?.ToString();
                d["Poliza"] = row["NumeroPoliza"]?.ToString();
                d["EstadoPaciente"] = row["EstadoPaciente"]?.ToString();
                listaPacientes.Add(d);
            }
        }

        private void RefrescarGrilla()
        {
            // Filtrar por cédula o nombre según el texto de búsqueda
            string placeholder = "Buscar por cédula o nombre...";
            string q = (txtSearch?.Text ?? string.Empty).Trim();
            IEnumerable<Dictionary<string, object>> fuente = listaPacientes;
            if (!string.IsNullOrEmpty(q) && q != placeholder)
            {
                string ql = q.ToLowerInvariant();
                fuente = fuente.Where(d =>
                    (d.ContainsKey("Cedula") && d["Cedula"] != null && d["Cedula"].ToString().ToLowerInvariant().Contains(ql)) ||
                    (d.ContainsKey("NombreCompleto") && d["NombreCompleto"] != null && d["NombreCompleto"].ToString().ToLowerInvariant().Contains(ql)) ||
                    (d.ContainsKey("Nombre") && d.ContainsKey("Apellido") &&
                        ($"{(d["Nombre"] ?? "").ToString()} {(d["Apellido"] ?? "").ToString()}".ToLowerInvariant().Contains(ql)))
                );
            }

            var listaAnonima = new List<object>();
            foreach (var d in fuente)
            {
                listaAnonima.Add(new
                {
                    Id = $"#{d["Id"]}",
                    NombreCompleto = $"{d["Nombre"]} {d["Apellido"]}",
                    Cedula = d.ContainsKey("Cedula") ? d["Cedula"] : "",
                    FechaNacimiento = d.ContainsKey("FechaNacimiento") ? d["FechaNacimiento"] : "",
                    Telefono = d.ContainsKey("Telefono") ? $"📞 {d["Telefono"]}" : ""
                });
            }
            bsPacientes.DataSource = listaAnonima;

            // Actualizar estadísticas (solo total de pacientes)
            if (pnlStats != null && pnlStats.Controls.Count > 0)
            {
                var cardTotal = pnlStats.Controls[0] as Panel;
                if (cardTotal != null && cardTotal.Controls.Count > 1)
                {
                    var lblValor = cardTotal.Controls[1] as Label;
                    if (lblValor != null)
                    {
                        lblValor.Text = listaPacientes.Count.ToString();
                    }
                }
                // Solo actualiza el total
            }
        }

        private void IrATabAgregarNuevo()
        {
            editingId = null;
            LimpiarFormulario();
            tabControl1.SelectedTab = tabPage1;
            txtNombre.Focus();
        }

        private void IrATabHistoriaDesdeSeleccion()
        {
            var pac = ObtenerPacienteSeleccionado();
            if (pac == null)
            {
                MessageBox.Show("Selecciona un paciente primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CargarHistoriaDesdePaciente(pac);
            tabControl1.SelectedTab = tabPage2;
        }

        private Dictionary<string, object> ObtenerPacienteSeleccionado()
        {
            if (dgvPacientes?.CurrentRow == null) return null;
            string idStr = dgvPacientes.CurrentRow.Cells[0].Value.ToString().Replace("#", "");
            int id = Convert.ToInt32(idStr);
            return listaPacientes.Find(p => Convert.ToInt32(p["Id"]) == id);
        }

        private void DgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 5) // Editar
            {
                string idStr = dgvPacientes.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("#", "");
                int id = Convert.ToInt32(idStr);
                var pac = listaPacientes.Find(p => Convert.ToInt32(p["Id"]) == id);
                if (pac != null)
                {
                    editingId = id;
                    CargarFormularioDesdeDiccionario(pac);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            else if (e.ColumnIndex == 6) // Eliminar
            {
                string idStr = dgvPacientes.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("#", "");
                int id = Convert.ToInt32(idStr);
                var pac = listaPacientes.Find(p => Convert.ToInt32(p["Id"]) == id);
                if (pac != null)
                {
                    string nombre = pac.ContainsKey("NombreCompleto") && pac["NombreCompleto"] != null
                        ? pac["NombreCompleto"].ToString()
                        : ($"{pac["Nombre"]} {pac["Apellido"]}");
                    var respuesta = MessageBox.Show($"¿Eliminar al paciente {nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        try
                        {
                            _repo.EliminarPaciente(id);
                            CargarPacientesDesdeDB();
                            RefrescarGrilla();
                        }
                        catch (Exception exDel)
                        {
                            MessageBox.Show("Error al eliminar: " + exDel.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void CargarFormularioDesdeDiccionario(Dictionary<string, object> pac)
        {
            txtNombre.Text = pac.ContainsKey("Nombre") && pac["Nombre"] != null ? pac["Nombre"].ToString() : string.Empty;
            txtApellido.Text = pac.ContainsKey("Apellido") && pac["Apellido"] != null ? pac["Apellido"].ToString() : string.Empty;
            txtCedula.Text = pac.ContainsKey("Cedula") && pac["Cedula"] != null ? pac["Cedula"].ToString() : string.Empty;
            if (pac.ContainsKey("FechaNacimiento"))
            {
                var val = pac["FechaNacimiento"];
                if (val != null && DateTime.TryParse(val.ToString(), out var dt))
                    dtpFechaNacimiento.Value = dt;
            }
            cbSexo.SelectedItem = MapSexoDbToUi(pac.ContainsKey("Sexo") ? pac["Sexo"]?.ToString() : null);
            cbEstadoCivil.SelectedItem = pac.ContainsKey("EstadoCivil") && pac["EstadoCivil"] != null ? pac["EstadoCivil"] : null;
            txtTelefono.Text = pac.ContainsKey("Telefono") && pac["Telefono"] != null ? pac["Telefono"].ToString() : string.Empty;
            txtCelular.Text = pac.ContainsKey("Celular") && pac["Celular"] != null ? pac["Celular"].ToString() : string.Empty;
            txtEmail.Text = pac.ContainsKey("Email") && pac["Email"] != null ? pac["Email"].ToString() : string.Empty;
            txtDireccion.Text = pac.ContainsKey("Direccion") && pac["Direccion"] != null ? pac["Direccion"].ToString() : string.Empty;
            // Nota: contacto emergencia se gestiona aparte; se deja vacío al editar si no se carga explícito
            txtContactoEmergencia.Text = string.Empty;
            txtAlergias.Text = pac.ContainsKey("Alergias") && pac["Alergias"] != null ? pac["Alergias"].ToString() : string.Empty;
            txtAntecedentes.Text = pac.ContainsKey("Antecedentes") && pac["Antecedentes"] != null ? pac["Antecedentes"].ToString() : string.Empty;
            txtSeguro.Text = pac.ContainsKey("Seguro") && pac["Seguro"] != null ? pac["Seguro"].ToString() : string.Empty;
            txtPoliza.Text = pac.ContainsKey("Poliza") && pac["Poliza"] != null ? pac["Poliza"].ToString() : string.Empty;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCedula.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Today;
            cbSexo.SelectedIndex = -1;
            cbEstadoCivil.SelectedIndex = -1;
            txtTelefono.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtContactoEmergencia.Text = string.Empty;
            txtAlergias.Text = string.Empty;
            txtAntecedentes.Text = string.Empty;
            txtSeguro.Text = string.Empty;
            txtPoliza.Text = string.Empty;
        }

        private Dictionary<string, object> ObtenerDatosFormulario()
        {
            var datos = new Dictionary<string, object>();
            datos["Nombre"] = txtNombre.Text.Trim();
            datos["Apellido"] = txtApellido.Text.Trim();
            datos["NombreCompleto"] = $"{txtNombre.Text.Trim()} {txtApellido.Text.Trim()}".Trim();
            datos["Cedula"] = txtCedula.Text.Trim();
            datos["FechaNacimiento"] = dtpFechaNacimiento.Value.ToShortDateString();
            datos["Sexo"] = cbSexo.SelectedItem ?? string.Empty;
            datos["EstadoCivil"] = cbEstadoCivil.SelectedItem ?? string.Empty;
            datos["Telefono"] = txtTelefono.Text.Trim();
            datos["Celular"] = txtCelular.Text.Trim();
            datos["Email"] = txtEmail.Text.Trim();
            datos["Direccion"] = txtDireccion.Text.Trim();
            datos["ContactoEmergencia"] = txtContactoEmergencia.Text.Trim();
            datos["Alergias"] = txtAlergias.Text.Trim();
            datos["Antecedentes"] = txtAntecedentes.Text.Trim();
            datos["Seguro"] = txtSeguro.Text.Trim();
            datos["Poliza"] = txtPoliza.Text.Trim();
            return datos;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Campos obligatorios (todos excepto: Contacto emergencia, Alergias, Antecedentes)
            var faltantes = new List<string>();
            // Resetear colores
            var controlesARestablecer = new Control[] { txtNombre, txtApellido, txtCedula, txtTelefono, txtCelular, txtEmail, txtDireccion, txtSeguro, txtPoliza, cbSexo, cbEstadoCivil };
            foreach (var c in controlesARestablecer)
            {
                if (c is TextBox tb) tb.BackColor = Color.White;
                if (c is ComboBox cb) cb.BackColor = Color.White;
            }

            if (EsTextoVacioOPlaceholder(txtNombre)) faltantes.Add("Nombre");
            if (EsTextoVacioOPlaceholder(txtApellido)) faltantes.Add("Apellido");
            if (EsTextoVacioOPlaceholder(txtCedula)) faltantes.Add("Cédula");
            if (cbSexo == null || cbSexo.SelectedIndex < 0) faltantes.Add("Sexo");
            if (cbEstadoCivil == null || cbEstadoCivil.SelectedIndex < 0) faltantes.Add("Estado civil");
            if (EsTextoVacioOPlaceholder(txtTelefono)) faltantes.Add("Teléfono");
            if (EsTextoVacioOPlaceholder(txtCelular)) faltantes.Add("Celular");
            if (EsTextoVacioOPlaceholder(txtEmail)) faltantes.Add("Email");
            if (EsTextoVacioOPlaceholder(txtDireccion)) faltantes.Add("Dirección");
            if (EsTextoVacioOPlaceholder(txtSeguro)) faltantes.Add("Seguro");
            if (EsTextoVacioOPlaceholder(txtPoliza)) faltantes.Add("Póliza");

            // Validaciones específicas
            var errores = new List<string>();
            if (!EsTextoVacioOPlaceholder(txtCedula) && !ValidarCedula(ObtenerTextoSeguro(txtCedula)))
                errores.Add("Formato de cédula inválido (dígitos y hasta 2 guiones, entre 6 y 15 dígitos)");

            if (!EsTextoVacioOPlaceholder(txtTelefono) && !ValidarTelefono(ObtenerTextoSeguro(txtTelefono)))
                errores.Add("Teléfono inválido (debe contener al menos 7 dígitos)");

            if (!EsTextoVacioOPlaceholder(txtCelular) && !ValidarTelefono(ObtenerTextoSeguro(txtCelular)))
                errores.Add("Celular inválido (debe contener al menos 7 dígitos)");

            if (!EsTextoVacioOPlaceholder(txtEmail) && !ValidarEmail(ObtenerTextoSeguro(txtEmail)))
                errores.Add("Email con formato inválido");

            // Validar fecha de nacimiento razonable
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
                errores.Add("La fecha de nacimiento no puede ser futura");
            else if ((DateTime.Today - dtpFechaNacimiento.Value.Date).TotalDays / 365.25 > 120)
                errores.Add("La fecha de nacimiento parece inválida (edad mayor a 120 años)");

            if (faltantes.Count > 0 || errores.Count > 0)
            {
                // Marcar controles faltantes
                foreach (var campo in faltantes)
                {
                    switch (campo)
                    {
                        case "Nombre": txtNombre.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Apellido": txtApellido.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Cédula": txtCedula.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Teléfono": txtTelefono.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Celular": txtCelular.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Email": txtEmail.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Dirección": txtDireccion.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Seguro": txtSeguro.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Póliza": txtPoliza.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Sexo": cbSexo.BackColor = Color.FromArgb(255, 245, 245); break;
                        case "Estado civil": cbEstadoCivil.BackColor = Color.FromArgb(255, 245, 245); break;
                    }
                }

                var mensajes = new List<string>();
                if (faltantes.Count > 0) mensajes.Add("Campos obligatorios incompletos:\n- " + string.Join("\n- ", faltantes));
                if (errores.Count > 0) mensajes.Add("Errores de validación:\n- " + string.Join("\n- ", errores));

                MessageBox.Show(string.Join("\n\n", mensajes), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datos = ObtenerDatosFormulario();
            try
            {
                var dto = new PacienteDTO
                {
                    IdPaciente = editingId ?? 0,
                    Nombre = ObtenerTextoSeguro(txtNombre),
                    Apellido = ObtenerTextoSeguro(txtApellido),
                    Cedula = ObtenerTextoSeguro(txtCedula),
                    FechaNacimiento = dtpFechaNacimiento.Value.Date,
                    Sexo = MapSexoUiToDb(cbSexo.SelectedItem?.ToString()),
                    EstadoCivil = cbEstadoCivil.SelectedItem?.ToString(),
                    Telefono = ObtenerTextoSeguro(txtTelefono),
                    Celular = ObtenerTextoSeguro(txtCelular),
                    Email = ObtenerTextoSeguro(txtEmail),
                    Direccion = ObtenerTextoSeguro(txtDireccion),
                    AlergiasConocidas = ObtenerTextoSeguro(txtAlergias),
                    AntecedentesMedicos = ObtenerTextoSeguro(txtAntecedentes),
                    IdSeguro = null,
                    NumeroPoliza = ObtenerTextoSeguro(txtPoliza),
                    EstadoPaciente = "Activo"
                };

                // Seguro: si el usuario escribió un nombre, intentar resolver/crear
                string nombreSeguro = txtSeguro.Text.Trim();
                if (!string.IsNullOrWhiteSpace(nombreSeguro))
                {
                    dto.IdSeguro = _repo.CrearSeguroSiNoExiste(nombreSeguro);
                }

                // Contacto emergencia (formato libre: "Nombre - Telefono")
                var contacto = ParseContacto(txtContactoEmergencia.Text.Trim());

                // Validar cédula única
                if (_repo.CedulaExiste(dto.Cedula, editingId))
                {
                    MessageBox.Show("La cédula ya existe para otro paciente.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (editingId.HasValue)
                {
                    _repo.ActualizarPaciente(dto, contacto);
                }
                else
                {
                    int nuevoId = _repo.InsertarPaciente(dto, contacto);
                    datos["Id"] = nuevoId;
                }

                editingId = null;
                CargarPacientesDesdeDB();
                RefrescarGrilla();
                LimpiarFormulario();
                tabControl1.SelectedTab = tabPage3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsTextoVacioOPlaceholder(TextBox tb)
        {
            if (tb == null) return true;
            // Si el control está en color de placeholder, lo tratamos como vacío
            if (tb.ForeColor == TextGray) return true;
            return string.IsNullOrWhiteSpace(tb.Text);
        }

        private string ObtenerTextoSeguro(TextBox tb)
        {
            if (tb == null) return string.Empty;
            if (tb.ForeColor == TextGray) return string.Empty;
            return tb.Text.Trim();
        }

        private bool ValidarCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;
            // Permitimos dígitos y hasta 2 guiones. Contar solo los dígitos para validar longitud entre 6 y 15.
            if (cedula.Any(c => !(char.IsDigit(c) || c == '-'))) return false;
            var guiones = cedula.Count(c => c == '-');
            if (guiones > 2) return false;
            var digits = new string(cedula.Where(char.IsDigit).ToArray());
            if (digits.Length < 6 || digits.Length > 15) return false;
            return true;
        }

        private bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return false;
            // Contar dígitos en la cadena
            var digits = new string(telefono.Where(char.IsDigit).ToArray());
            return digits.Length >= 7 && digits.Length <= 15;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            // Validación simple de email
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void CargarHistoriaDesdePaciente(Dictionary<string, object> pac)
        {
            string GetStr(string key)
            {
                return pac.ContainsKey(key) && pac[key] != null ? pac[key].ToString() : string.Empty;
            }

            txtHistAntecedentes.Text = GetStr("Antecedentes");
            txtHistAlergias.Text = GetStr("Alergias");
            // Reutilizamos los campos inferiores para mostrar información relevante
            // 1) Datos de contacto
            var telefono = GetStr("Telefono");
            var celular = GetStr("Celular");
            var email = GetStr("Email");
            var direccion = GetStr("Direccion");
            var contacto = "";
            if (!string.IsNullOrWhiteSpace(telefono)) contacto += "Teléfono: " + telefono + Environment.NewLine;
            if (!string.IsNullOrWhiteSpace(celular)) contacto += "Celular: " + celular + Environment.NewLine;
            if (!string.IsNullOrWhiteSpace(email)) contacto += "Email: " + email + Environment.NewLine;
            if (!string.IsNullOrWhiteSpace(direccion)) contacto += "Dirección: " + direccion + Environment.NewLine;
            txtHistCirugias.Text = contacto.Trim();

            // 2) Seguro y póliza
            var seguro = GetStr("Seguro");
            var poliza = GetStr("Poliza");
            var seguroInfo = "";
            if (!string.IsNullOrWhiteSpace(seguro)) seguroInfo += "Seguro: " + seguro + Environment.NewLine;
            if (!string.IsNullOrWhiteSpace(poliza)) seguroInfo += "Póliza: " + poliza + Environment.NewLine;
            txtHistMedicacion.Text = seguroInfo.Trim();

            // 3) Estado del paciente
            var estado = GetStr("EstadoPaciente");
            txtHistObservaciones.Text = string.IsNullOrWhiteSpace(estado) ? "" : ("Estado: " + estado);
        }

        private void BtnExportarHistoria_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Text files|*.txt", FileName = "historia_clinica.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLine("Resumen de antecedentes:");
                            sw.WriteLine(txtHistAntecedentes.Text);
                            sw.WriteLine();
                            sw.WriteLine("Alergias:");
                            sw.WriteLine(txtHistAlergias.Text);
                            sw.WriteLine();
                            sw.WriteLine("Datos de contacto:");
                            sw.WriteLine(txtHistCirugias.Text);
                            sw.WriteLine();
                            sw.WriteLine("Seguro y póliza:");
                            sw.WriteLine(txtHistMedicacion.Text);
                            sw.WriteLine();
                            sw.WriteLine("Estado del paciente:");
                            sw.WriteLine(txtHistObservaciones.Text);
                        }
                        MessageBox.Show("Exportado correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnImprimirHistoria_Click(object sender, EventArgs e)
        {
            var preview = new PrintPreviewDialog();
            var pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = 20;
                var font = new Font("Segoe UI", 10);
                ev.Graphics.DrawString("Resumen de antecedentes:", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, 20, y);
                y += 26;
                ev.Graphics.DrawString(txtHistAntecedentes.Text, font, Brushes.Black, new RectangleF(20, y, ev.MarginBounds.Width, 200));
            };
            preview.Document = pd;
            try
            {
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar la impresión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private string MapSexoUiToDb(string ui)
        {
            if (string.IsNullOrWhiteSpace(ui)) return "O";
            ui = ui.Trim().ToLowerInvariant();
            if (ui.StartsWith("masc")) return "M";
            if (ui.StartsWith("fem")) return "F";
            return "O";
        }

        private object MapSexoDbToUi(string db)
        {
            switch ((db ?? "O").ToUpperInvariant())
            {
                case "M": return "Masculino";
                case "F": return "Femenino";
                default: return "Otro";
            }
        }

        private ContactoEmergenciaDTO ParseContacto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;
            string nombre = texto;
            string tel = "";
            var partes = texto.Split(new[] { '-' }, 2);
            if (partes.Length == 2)
            {
                nombre = partes[0].Trim();
                tel = partes[1].Trim();
            }
            return new ContactoEmergenciaDTO { NombreContacto = nombre, TelefonoContacto = tel };
        }
    }
}