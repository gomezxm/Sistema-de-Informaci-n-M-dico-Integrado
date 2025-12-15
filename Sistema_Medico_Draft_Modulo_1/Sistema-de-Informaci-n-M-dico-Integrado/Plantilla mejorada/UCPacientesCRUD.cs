using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Borrador
{
    // ---------------------------
    // UserControl: UCPacientesCRUD
    // ---------------------------
    public partial class UCPacientesCRUD : UserControl
    {
        private DataGridView dgvPacientes;
        private Button btnAgregar;
        private Button btnVerHistoria;
        private BindingSource bsPacientes;

        // Muestra datos de ejemplo; en tu app reemplaza por conexión a DB
        private List<Dictionary<string, object>> listaPacientes = new List<Dictionary<string, object>>();

        public UCPacientesCRUD()
        {
            InitializeComponent();
            CargarDatosPrueba();
            RefrescarGrilla();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.Padding = new Padding(10);

            // ADD / ACTIONS panel
            Panel topPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(6),
                BackColor = Color.FromArgb(240, 240, 240)
            };

            btnAgregar = new Button()
            {
                Text = "Añadir Paciente",
                AutoSize = false,
                Size = new Size(150, 32),
                Location = new Point(6, 8),
                BackColor = Color.FromArgb(41, 83, 130),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Click += BtnAgregar_Click;

            btnVerHistoria = new Button()
            {
                Text = "Ver Historia (Paciente seleccionado)",
                AutoSize = false,
                Size = new Size(240, 32),
                Location = new Point(170, 8),
                BackColor = Color.FromArgb(96, 146, 211),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnVerHistoria.FlatAppearance.BorderSize = 0;
            btnVerHistoria.Click += BtnVerHistoria_Click;

            topPanel.Controls.Add(btnAgregar);
            topPanel.Controls.Add(btnVerHistoria);

            // DataGridView
            dgvPacientes = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Columns
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Nombre",
                DataPropertyName = "NombreCompleto",
                Width = 220
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Cédula",
                DataPropertyName = "Cedula",
                Width = 120
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Nacimiento",
                DataPropertyName = "FechaNacimiento",
                Width = 110
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 120
            });

            // Edit button
            var colEditar = new DataGridViewButtonColumn()
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvPacientes.Columns.Add(colEditar);

            // Delete button
            var colEliminar = new DataGridViewButtonColumn()
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvPacientes.Columns.Add(colEliminar);

            dgvPacientes.CellClick += DgvPacientes_CellClick;

            // BindingSource
            bsPacientes = new BindingSource();
            dgvPacientes.DataSource = bsPacientes;

            // Add controls (topPanel docked top, grid fills rest)
            this.Controls.Add(dgvPacientes);
            this.Controls.Add(topPanel);
        }

        private void CargarDatosPrueba()
        {
            listaPacientes.Clear();
            listaPacientes.Add(new Dictionary<string, object>()
            {
                ["Id"] = 1,
                ["NombreCompleto"] = "Carlos Gómez",
                ["Nombre"] = "Carlos",
                ["Apellido"] = "Gómez",
                ["Cedula"] = "8-123-4567",
                ["FechaNacimiento"] = new DateTime(1992, 4, 15).ToShortDateString(),
                ["Sexo"] = "Masculino",
                ["EstadoCivil"] = "Soltero",
                ["Telefono"] = "6000-1111",
                ["ContactoEmergencia"] = "Ana Gómez - 6000-2222",
                ["Alergias"] = "Ninguna",
                ["Antecedentes"] = "Hipertensión familiar",
                ["Seguro"] = "Seguro XYZ",
                ["Poliza"] = "POL-0001"
            });

            listaPacientes.Add(new Dictionary<string, object>()
            {
                ["Id"] = 2,
                ["NombreCompleto"] = "María López",
                ["Nombre"] = "María",
                ["Apellido"] = "López",
                ["Cedula"] = "8-765-4321",
                ["FechaNacimiento"] = new DateTime(1997, 9, 30).ToShortDateString(),
                ["Sexo"] = "Femenino",
                ["EstadoCivil"] = "Casado",
                ["Telefono"] = "7000-2222",
                ["ContactoEmergencia"] = "Pedro López - 7000-3333",
                ["Alergias"] = "Penicilina",
                ["Antecedentes"] = "Asma",
                ["Seguro"] = "Seguro ABC",
                ["Poliza"] = "POL-0102"
            });
        }

        private void RefrescarGrilla()
        {
            // Para simplificar, transformamos la lista en objetos anónimos con las propiedades usadas
            var listaAnonima = new List<object>();
            foreach (var d in listaPacientes)
            {
                listaAnonima.Add(new
                {
                    Id = d["Id"],
                    NombreCompleto = $"{d["Nombre"]} {d["Apellido"]}",
                    Cedula = d["Cedula"],
                    FechaNacimiento = d["FechaNacimiento"],
                    Telefono = d["Telefono"]
                });
            }

            bsPacientes.DataSource = listaAnonima;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir formulario de paciente en modo 'nuevo'
            using (var frm = new FrmPacientesCRUD())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Recuperar datos desde frm.PacienteData (diccionario) - aquí agregamos a la lista local de prueba
                    var nuevo = frm.PacienteData;
                    if (nuevo != null)
                    {
                        // asignar nuevo Id (simple)
                        int nuevoId = listaPacientes.Count > 0 ? (int)listaPacientes[listaPacientes.Count - 1]["Id"] + 1 : 1;
                        nuevo["Id"] = nuevoId;
                        listaPacientes.Add(nuevo);
                        RefrescarGrilla();
                    }
                }
            }
        }

        private void BtnVerHistoria_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un paciente primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idx = dgvPacientes.CurrentRow.Index;
            var id = (int)dgvPacientes.Rows[idx].Cells[0].Value;
            var pac = listaPacientes.Find(p => (int)p["Id"] == id);
            if (pac != null)
            {
                using (var frm = new FrmHistoriaClinicaPaciente(pac))
                {
                    frm.ShowDialog();
                }
            }
        }

        private void DgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Column indices according to creation order:
            // 0:ID,1:Nombre,2:Cédula,3:Nacimiento,4:Teléfono,5:Editar,6:Eliminar
            if (e.ColumnIndex == 5) // Editar
            {
                int id = (int)dgvPacientes.Rows[e.RowIndex].Cells[0].Value;
                var pac = listaPacientes.Find(p => (int)p["Id"] == id);
                if (pac != null)
                {
                    using (var frm = new FrmPacientesCRUD(pac))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // Actualizar datos con los devueltos por el formulario
                            var actualizado = frm.PacienteData;
                            if (actualizado != null)
                            {
                                // Mantener Id
                                actualizado["Id"] = id;
                                int pos = listaPacientes.FindIndex(x => (int)x["Id"] == id);
                                if (pos >= 0)
                                {
                                    listaPacientes[pos] = actualizado;
                                    RefrescarGrilla();
                                }
                            }
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 6) // Eliminar
            {
                int id = (int)dgvPacientes.Rows[e.RowIndex].Cells[0].Value;
                var pac = listaPacientes.Find(p => (int)p["Id"] == id);
                if (pac != null)
                {
                    var respuesta = MessageBox.Show($"¿Eliminar al paciente {pac["NombreCompleto"] ?? (pac["Nombre"] + " " + pac["Apellido"])} ?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        listaPacientes.RemoveAll(x => (int)x["Id"] == id);
                        RefrescarGrilla();
                    }
                }
            }
        }

        // --------------------------------
        // Formulario: FrmPacientesCRUD (Registro / Edición)
        // --------------------------------
        public class FrmPacientesCRUD : Form
        {
            // Campos del formulario
            private TextBox txtNombre;
            private TextBox txtApellido;
            private TextBox txtCedula;
            private DateTimePicker dtpFechaNacimiento;
            private ComboBox cbSexo;
            private ComboBox cbEstadoCivil;
            private TextBox txtTelefono;
            private TextBox txtContactoEmergencia;
            private TextBox txtAlergias;
            private TextBox txtAntecedentes;
            private TextBox txtSeguro;
            private TextBox txtPoliza;

            private Button btnGuardar;
            private Button btnCancelar;

            // Para devolver datos al control llamador
            public Dictionary<string, object> PacienteData { get; private set; }

            // Modo: nuevo o editar (si se pasa un diccionario de paciente)
            public FrmPacientesCRUD(Dictionary<string, object> paciente = null)
            {
                this.Text = paciente == null ? "Nuevo Paciente" : "Editar Paciente";
                this.Size = new Size(720, 600);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                InitializeComponents();

                if (paciente != null)
                    CargarDesdeDiccionario(paciente);
            }

            private void InitializeComponents()
            {
                // Paleta básica
                var paletteDark = Color.FromArgb(22, 39, 89);
                var palettePrimary = Color.FromArgb(41, 83, 130);

                var main = new TableLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 10,
                    Padding = new Padding(12),
                    AutoScroll = true
                };
                main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                // Labels + Controls
                txtNombre = new TextBox() { Font = new Font("Segoe UI", 9F) };
                txtApellido = new TextBox() { Font = new Font("Segoe UI", 9F) };
                txtCedula = new TextBox() { Font = new Font("Segoe UI", 9F) };
                dtpFechaNacimiento = new DateTimePicker() { Format = DateTimePickerFormat.Short };
                cbSexo = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
                cbEstadoCivil = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
                txtTelefono = new TextBox() { Font = new Font("Segoe UI", 9F) };
                txtContactoEmergencia = new TextBox() { Font = new Font("Segoe UI", 9F) };
                txtAlergias = new TextBox() { Font = new Font("Segoe UI", 9F), Multiline = true, Height = 60, ScrollBars = ScrollBars.Vertical };
                txtAntecedentes = new TextBox() { Font = new Font("Segoe UI", 9F), Multiline = true, Height = 80, ScrollBars = ScrollBars.Vertical };
                txtSeguro = new TextBox() { Font = new Font("Segoe UI", 9F) };
                txtPoliza = new TextBox() { Font = new Font("Segoe UI", 9F) };

                cbSexo.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
                cbEstadoCivil.Items.AddRange(new object[] { "Soltero/a", "Casado/a", "Divorciado/a", "Viudo/a" });

                // Helper para agregar label+control
                void AddRow(string labelText, Control control, int row)
                {
                    var lbl = new Label() { Text = labelText, AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Regular) };
                    var panel = new Panel() { Dock = DockStyle.Fill };
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
                AddRow("Contacto emergencia:", txtContactoEmergencia, 7);
                AddRow("Alergias:", txtAlergias, 8);
                AddRow("Antecedentes:", txtAntecedentes, 9);

                // Segunda column additional fields
                var rightPanel = new Panel() { Dock = DockStyle.Fill };
                var rightLayout = new TableLayoutPanel() { Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 1, Padding = new Padding(6) };
                rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

                var lblSeguro = new Label() { Text = "Seguro:", AutoSize = true, Font = new Font("Segoe UI", 9F) };
                var lblPoliza = new Label() { Text = "Póliza:", AutoSize = true, Font = new Font("Segoe UI", 9F) };

                rightLayout.Controls.Add(lblSeguro);
                rightLayout.Controls.Add(txtSeguro);
                rightLayout.Controls.Add(lblPoliza);
                rightLayout.Controls.Add(txtPoliza);

                rightPanel.Controls.Add(rightLayout);

                // Buttons bottom
                Panel buttonsPanel = new Panel() { Dock = DockStyle.Bottom, Height = 56, Padding = new Padding(12) };
                btnGuardar = new Button()
                {
                    Text = "Guardar",
                    Size = new Size(100, 36),
                    Location = new Point(260, 10),
                    BackColor = Color.FromArgb(41, 83, 130),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnGuardar.FlatAppearance.BorderSize = 0;
                btnGuardar.Click += BtnGuardar_Click;

                btnCancelar = new Button()
                {
                    Text = "Cancelar",
                    Size = new Size(100, 36),
                    Location = new Point(380, 10),
                    BackColor = Color.Gray,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnCancelar.FlatAppearance.BorderSize = 0;
                btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

                buttonsPanel.Controls.Add(btnGuardar);
                buttonsPanel.Controls.Add(btnCancelar);

                // Compose layout: left main + right panel under same form
                var outer = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2 };
                outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
                outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                outer.Controls.Add(main, 0, 0);
                outer.Controls.Add(rightPanel, 1, 0);

                this.Controls.Add(outer);
                this.Controls.Add(buttonsPanel);
            }

            private void CargarDesdeDiccionario(Dictionary<string, object> pac)
            {
                if (pac == null) return;
                txtNombre.Text = pac.ContainsKey("Nombre") ? pac["Nombre"].ToString() : "";
                txtApellido.Text = pac.ContainsKey("Apellido") ? pac["Apellido"].ToString() : "";
                txtCedula.Text = pac.ContainsKey("Cedula") ? pac["Cedula"].ToString() : "";
                if (pac.ContainsKey("FechaNacimiento"))
                {
                    DateTime dt;
                    if (DateTime.TryParse(pac["FechaNacimiento"]?.ToString(), out dt))
                        dtpFechaNacimiento.Value = dt;
                }
                if (pac.ContainsKey("Sexo")) cbSexo.SelectedItem = pac["Sexo"];
                if (pac.ContainsKey("EstadoCivil")) cbEstadoCivil.SelectedItem = pac["EstadoCivil"];
                txtTelefono.Text = pac.ContainsKey("Telefono") ? pac["Telefono"].ToString() : "";
                txtContactoEmergencia.Text = pac.ContainsKey("ContactoEmergencia") ? pac["ContactoEmergencia"].ToString() : "";
                txtAlergias.Text = pac.ContainsKey("Alergias") ? pac["Alergias"].ToString() : "";
                txtAntecedentes.Text = pac.ContainsKey("Antecedentes") ? pac["Antecedentes"].ToString() : "";
                txtSeguro.Text = pac.ContainsKey("Seguro") ? pac["Seguro"].ToString() : "";
                txtPoliza.Text = pac.ContainsKey("Poliza") ? pac["Poliza"].ToString() : "";
            }

            private void BtnGuardar_Click(object sender, EventArgs e)
            {
                // Validación mínima
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Nombre y Apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Empaquetar datos en diccionario para retornar al control llamador
                var datos = new Dictionary<string, object>();
                datos["Nombre"] = txtNombre.Text.Trim();
                datos["Apellido"] = txtApellido.Text.Trim();
                datos["NombreCompleto"] = $"{txtNombre.Text.Trim()} {txtApellido.Text.Trim()}";
                datos["Cedula"] = txtCedula.Text.Trim();
                datos["FechaNacimiento"] = dtpFechaNacimiento.Value.ToShortDateString();
                datos["Sexo"] = cbSexo.SelectedItem ?? "";
                datos["EstadoCivil"] = cbEstadoCivil.SelectedItem ?? "";
                datos["Telefono"] = txtTelefono.Text.Trim();
                datos["ContactoEmergencia"] = txtContactoEmergencia.Text.Trim();
                datos["Alergias"] = txtAlergias.Text.Trim();
                datos["Antecedentes"] = txtAntecedentes.Text.Trim();
                datos["Seguro"] = txtSeguro.Text.Trim();
                datos["Poliza"] = txtPoliza.Text.Trim();

                this.PacienteData = datos;
                this.DialogResult = DialogResult.OK;
            }
        }

        // --------------------------------
        // Formulario: FrmHistoriaClinicaPaciente
        // --------------------------------
        public class FrmHistoriaClinicaPaciente : Form
        {
            private TextBox txtResumenAntecedentes;
            private TextBox txtAlergias;
            private TextBox txtCirugias;
            private TextBox txtMedicacionHabitual;
            private TextBox txtObservaciones;
            private Button btnExportar;
            private Button btnImprimir;

            public FrmHistoriaClinicaPaciente(Dictionary<string, object> paciente = null)
            {
                this.Text = "Historia Clínica - " + (paciente != null ? (paciente.ContainsKey("NombreCompleto") ? paciente["NombreCompleto"] : paciente["Nombre"]) : "");
                this.Size = new Size(700, 600);
                this.StartPosition = FormStartPosition.CenterParent;
                InitializeComponents();

                if (paciente != null)
                    CargarDesdePaciente(paciente);
            }

            private void InitializeComponents()
            {
                var main = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 6, Padding = new Padding(10) };
                main.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
                main.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                main.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                main.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                main.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                main.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));

                // Labels + textboxes
                var lblRes = new Label() { Text = "Resumen de antecedentes", Dock = DockStyle.Fill };
                txtResumenAntecedentes = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

                var lblAler = new Label() { Text = "Alergias", Dock = DockStyle.Fill };
                txtAlergias = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

                var lblCir = new Label() { Text = "Cirugías", Dock = DockStyle.Fill };
                txtCirugias = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

                var lblMed = new Label() { Text = "Medicación habitual", Dock = DockStyle.Fill };
                txtMedicacionHabitual = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

                var lblObs = new Label() { Text = "Observaciones generales", Dock = DockStyle.Fill };
                txtObservaciones = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

                main.Controls.Add(lblRes, 0, 0);
                main.Controls.Add(txtResumenAntecedentes, 0, 1);
                main.Controls.Add(lblAler, 0, 2);
                main.Controls.Add(txtAlergias, 0, 3);
                main.Controls.Add(lblCir, 0, 4);
                main.Controls.Add(txtCirugias, 0, 5);

                // Ajuste: usar panel con scroll para medicación y observaciones
                var lower = new Panel() { Dock = DockStyle.Bottom, Height = 120 };
                var lowerLayout = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2 };
                lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                var pMed = new Panel() { Dock = DockStyle.Fill };
                var pObs = new Panel() { Dock = DockStyle.Fill };
                pMed.Controls.Add(new Label() { Text = "Medicación habitual", Dock = DockStyle.Top });
                txtMedicacionHabitual.Dock = DockStyle.Fill;
                pMed.Controls.Add(txtMedicacionHabitual);
                pObs.Controls.Add(new Label() { Text = "Observaciones generales", Dock = DockStyle.Top });
                txtObservaciones.Dock = DockStyle.Fill;
                pObs.Controls.Add(txtObservaciones);

                lowerLayout.Controls.Add(pMed, 0, 0);
                lowerLayout.Controls.Add(pObs, 1, 0);
                lower.Controls.Add(lowerLayout);

                // Buttons export/print
                Panel btnPanel = new Panel() { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(8) };
                btnExportar = new Button() { Text = "Exportar (TXT)", Size = new Size(110, 32), Location = new Point(8, 8), BackColor = Color.FromArgb(96, 146, 211), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnImprimir = new Button() { Text = "Imprimir", Size = new Size(110, 32), Location = new Point(128, 8), BackColor = Color.FromArgb(41, 83, 130), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

                btnExportar.FlatAppearance.BorderSize = 0;
                btnImprimir.FlatAppearance.BorderSize = 0;
                btnExportar.Click += BtnExportar_Click;
                btnImprimir.Click += BtnImprimir_Click;

                btnPanel.Controls.Add(btnExportar);
                btnPanel.Controls.Add(btnImprimir);

                // Agregar todo al form
                this.Controls.Add(main);
                this.Controls.Add(lower);
                this.Controls.Add(btnPanel);
            }

            private void CargarDesdePaciente(Dictionary<string, object> pac)
            {
                txtResumenAntecedentes.Text = pac.ContainsKey("Antecedentes") ? pac["Antecedentes"].ToString() : "";
                txtAlergias.Text = pac.ContainsKey("Alergias") ? pac["Alergias"].ToString() : "";
                txtCirugias.Text = pac.ContainsKey("Cirugias") ? pac["Cirugias"].ToString() : ""; // en ejemplo no hay, queda vacío
                txtMedicacionHabitual.Text = pac.ContainsKey("MedicacionHabitual") ? pac["MedicacionHabitual"].ToString() : "";
                txtObservaciones.Text = pac.ContainsKey("Observaciones") ? pac["Observaciones"].ToString() : "";
            }

            private void BtnExportar_Click(object sender, EventArgs e)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text files|*.txt", FileName = "historia_clinica.txt" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var sw = new StreamWriter(sfd.FileName))
                            {
                                sw.WriteLine("Resumen de antecedentes:");
                                sw.WriteLine(txtResumenAntecedentes.Text);
                                sw.WriteLine();
                                sw.WriteLine("Alergias:");
                                sw.WriteLine(txtAlergias.Text);
                                sw.WriteLine();
                                sw.WriteLine("Cirugías:");
                                sw.WriteLine(txtCirugias.Text);
                                sw.WriteLine();
                                sw.WriteLine("Medicación habitual:");
                                sw.WriteLine(txtMedicacionHabitual.Text);
                                sw.WriteLine();
                                sw.WriteLine("Observaciones generales:");
                                sw.WriteLine(txtObservaciones.Text);
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

            private void BtnImprimir_Click(object sender, EventArgs e)
            {
                // Interfaz: abrimos PrintPreviewDialog con contenido de texto simple
                PrintPreviewDialog preview = new PrintPreviewDialog();
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.PrintPage += (s, ev) =>
                {
                    float y = 20;
                    var font = new Font("Segoe UI", 10);
                    ev.Graphics.DrawString("Resumen de antecedentes:", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, 20, y);
                    y += 26;
                    ev.Graphics.DrawString(txtResumenAntecedentes.Text, font, Brushes.Black, new RectangleF(20, y, ev.MarginBounds.Width, 200));
                    // Para simplificar no paginamos en este ejemplo
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
        }
    }
}
