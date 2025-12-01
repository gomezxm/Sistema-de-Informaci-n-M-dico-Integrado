using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Borrador
{
    public partial class Modulo1 : UserControl
    {
        // Datos en memoria (reemplazar por DB en producción)
        private readonly List<Dictionary<string, object>> listaPacientes = new List<Dictionary<string, object>>();
        private BindingSource bsPacientes;

        // Controles para "Ver pacientes"
        private DataGridView dgvPacientes;
        private Button btnAgregar;
        private Button btnVerHistoria;

        // Controles para "Añadir/Editar paciente"
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
            InicializarPacientesTabs();
            CargarDatosPrueba();
            RefrescarGrilla();
            // Mostrar por defecto la lista de pacientes
            tabControl1.SelectedTab = tabPage3;
        }

        private void InicializarPacientesTabs()
        {
            // Tab "Ver pacientes"
            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(6),
                BackColor = Color.FromArgb(240, 240, 240)
            };

            btnAgregar = new Button
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
            btnAgregar.Click += (s, e) => IrATabAgregarNuevo();

            btnVerHistoria = new Button
            {
                Text = "Ver Historia (seleccionado)",
                AutoSize = false,
                Size = new Size(200, 32),
                Location = new Point(166, 8),
                BackColor = Color.FromArgb(96, 146, 211),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnVerHistoria.FlatAppearance.BorderSize = 0;
            btnVerHistoria.Click += (s, e) => IrATabHistoriaDesdeSeleccion();

            topPanel.Controls.Add(btnAgregar);
            topPanel.Controls.Add(btnVerHistoria);

            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 60 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "NombreCompleto", Width = 220 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cédula", DataPropertyName = "Cedula", Width = 120 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nacimiento", DataPropertyName = "FechaNacimiento", Width = 110 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "Telefono", Width = 120 });

            var colEditar = new DataGridViewButtonColumn { HeaderText = "Editar", Text = "Editar", UseColumnTextForButtonValue = true, Width = 80 };
            var colEliminar = new DataGridViewButtonColumn { HeaderText = "Eliminar", Text = "Eliminar", UseColumnTextForButtonValue = true, Width = 80 };
            dgvPacientes.Columns.Add(colEditar);
            dgvPacientes.Columns.Add(colEliminar);

            dgvPacientes.CellClick += DgvPacientes_CellClick;

            bsPacientes = new BindingSource();
            dgvPacientes.DataSource = bsPacientes;

            tabPage3.Controls.Clear();
            tabPage3.Controls.Add(dgvPacientes);
            tabPage3.Controls.Add(topPanel);

            // Tab "Añadir paciente" (formulario)
            ConstruirFormularioPaciente(tabPage1);

            // Tab "Historia" (solo lectura)
            ConstruirHistoriaPaciente(tabPage2);
        }

        private void ConstruirFormularioPaciente(TabPage tab)
        {
            tab.Controls.Clear();

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 10,
                Padding = new Padding(12),
                AutoScroll = true
            };
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCedula = new TextBox();
            dtpFechaNacimiento = new DateTimePicker { Format = DateTimePickerFormat.Short };
            cbSexo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbEstadoCivil = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            txtTelefono = new TextBox();
            txtContactoEmergencia = new TextBox();
            txtAlergias = new TextBox { Multiline = true, Height = 60, ScrollBars = ScrollBars.Vertical };
            txtAntecedentes = new TextBox { Multiline = true, Height = 80, ScrollBars = ScrollBars.Vertical };
            txtSeguro = new TextBox();
            txtPoliza = new TextBox();

            cbSexo.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            cbEstadoCivil.Items.AddRange(new object[] { "Soltero/a", "Casado/a", "Divorciado/a", "Viudo/a" });

            void AddRow(string labelText, Control control, int row)
            {
                var lbl = new Label { Text = labelText, AutoSize = true };
                var panel = new Panel { Dock = DockStyle.Fill };
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

            var rightPanel = new Panel { Dock = DockStyle.Fill };
            var rightLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 1, Padding = new Padding(6) };
            rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            rightLayout.Controls.Add(new Label { Text = "Seguro:", AutoSize = true });
            rightLayout.Controls.Add(txtSeguro);
            rightLayout.Controls.Add(new Label { Text = "Póliza:", AutoSize = true });
            rightLayout.Controls.Add(txtPoliza);
            rightPanel.Controls.Add(rightLayout);

            var outer = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            outer.Controls.Add(main, 0, 0);
            outer.Controls.Add(rightPanel, 1, 0);

            var buttonsPanel = new Panel { Dock = DockStyle.Bottom, Height = 56, Padding = new Padding(12) };
            btnGuardar = new Button
            {
                Text = "Guardar",
                Size = new Size(100, 36),
                Location = new Point(12, 10),
                BackColor = Color.FromArgb(41, 83, 130),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Size = new Size(100, 36),
                Location = new Point(122, 10),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) =>
            {
                LimpiarFormulario();
                editingId = null;
                tabControl1.SelectedTab = tabPage3; // volver a lista
            };

            buttonsPanel.Controls.Add(btnGuardar);
            buttonsPanel.Controls.Add(btnCancelar);

            tab.Controls.Add(outer);
            tab.Controls.Add(buttonsPanel);
        }

        private void ConstruirHistoriaPaciente(TabPage tab)
        {
            tab.Controls.Clear();

            var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 6, Padding = new Padding(10) };
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            txtHistAntecedentes = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            txtHistAlergias = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            txtHistCirugias = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            txtHistMedicacion = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            txtHistObservaciones = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

            main.Controls.Add(new Label { Text = "Resumen de antecedentes", AutoSize = true }, 0, 0);
            main.Controls.Add(txtHistAntecedentes, 0, 1);
            main.Controls.Add(new Label { Text = "Alergias", AutoSize = true }, 0, 2);
            main.Controls.Add(txtHistAlergias, 0, 3);
            main.Controls.Add(new Label { Text = "Cirugías / Medicación / Observaciones", AutoSize = true }, 0, 4);

            var lowerLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3 };
            lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            lowerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            lowerLayout.Controls.Add(txtHistCirugias, 0, 0);
            lowerLayout.Controls.Add(txtHistMedicacion, 1, 0);
            lowerLayout.Controls.Add(txtHistObservaciones, 2, 0);
            main.Controls.Add(lowerLayout, 0, 5);

            var btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(8) };
            btnExportarHistoria = new Button { Text = "Exportar (TXT)", Size = new Size(110, 32), Location = new Point(8, 8), BackColor = Color.FromArgb(96, 146, 211), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnImprimirHistoria = new Button { Text = "Imprimir", Size = new Size(110, 32), Location = new Point(128, 8), BackColor = Color.FromArgb(41, 83, 130), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnExportarHistoria.FlatAppearance.BorderSize = 0;
            btnImprimirHistoria.FlatAppearance.BorderSize = 0;
            btnExportarHistoria.Click += BtnExportarHistoria_Click;
            btnImprimirHistoria.Click += BtnImprimirHistoria_Click;

            btnPanel.Controls.Add(btnExportarHistoria);
            btnPanel.Controls.Add(btnImprimirHistoria);

            tab.Controls.Add(main);
            tab.Controls.Add(btnPanel);
        }

        private void CargarDatosPrueba()
        {
            listaPacientes.Clear();
            listaPacientes.Add(new Dictionary<string, object>
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

            listaPacientes.Add(new Dictionary<string, object>
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
            int id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value);
            return listaPacientes.Find(p => Convert.ToInt32(p["Id"]) == id);
        }

        private void DgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // 0..4 datos, 5 Editar, 6 Eliminar
            if (e.ColumnIndex == 5)
            {
                int id = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells[0].Value);
                var pac = listaPacientes.Find(p => Convert.ToInt32(p["Id"]) == id);
                if (pac != null)
                {
                    editingId = id;
                    CargarFormularioDesdeDiccionario(pac);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            else if (e.ColumnIndex == 6)
            {
                int id = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells[0].Value);
                var pac = listaPacientes.Find(p => Convert.ToInt32(p["Id"]) == id);
                if (pac != null)
                {
                    string nombre = pac.ContainsKey("NombreCompleto") && pac["NombreCompleto"] != null
                        ? pac["NombreCompleto"].ToString()
                        : ($"{pac["Nombre"]} {pac["Apellido"]}");
                    var respuesta = MessageBox.Show($"¿Eliminar al paciente {nombre} ?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        listaPacientes.RemoveAll(x => Convert.ToInt32(x["Id"]) == id);
                        RefrescarGrilla();
                    }
                }
            }
        }

        private void CargarFormularioDesdeDiccionario(Dictionary<string, object> pac)
        {
            txtNombre.Text = pac.ContainsKey("Nombre") ? pac["Nombre"].ToString() : string.Empty;
            txtApellido.Text = pac.ContainsKey("Apellido") ? pac["Apellido"].ToString() : string.Empty;
            txtCedula.Text = pac.ContainsKey("Cedula") ? pac["Cedula"].ToString() : string.Empty;
            if (pac.ContainsKey("FechaNacimiento"))
            {
                if (DateTime.TryParse(pac["FechaNacimiento"]?.ToString(), out var dt))
                    dtpFechaNacimiento.Value = dt;
            }
            cbSexo.SelectedItem = pac.ContainsKey("Sexo") ? pac["Sexo"] : null;
            cbEstadoCivil.SelectedItem = pac.ContainsKey("EstadoCivil") ? pac["EstadoCivil"] : null;
            txtTelefono.Text = pac.ContainsKey("Telefono") ? pac["Telefono"].ToString() : string.Empty;
            txtContactoEmergencia.Text = pac.ContainsKey("ContactoEmergencia") ? pac["ContactoEmergencia"].ToString() : string.Empty;
            txtAlergias.Text = pac.ContainsKey("Alergias") ? pac["Alergias"].ToString() : string.Empty;
            txtAntecedentes.Text = pac.ContainsKey("Antecedentes") ? pac["Antecedentes"].ToString() : string.Empty;
            txtSeguro.Text = pac.ContainsKey("Seguro") ? pac["Seguro"].ToString() : string.Empty;
            txtPoliza.Text = pac.ContainsKey("Poliza") ? pac["Poliza"].ToString() : string.Empty;
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
            datos["ContactoEmergencia"] = txtContactoEmergencia.Text.Trim();
            datos["Alergias"] = txtAlergias.Text.Trim();
            datos["Antecedentes"] = txtAntecedentes.Text.Trim();
            datos["Seguro"] = txtSeguro.Text.Trim();
            datos["Poliza"] = txtPoliza.Text.Trim();
            return datos;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Nombre y Apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var datos = ObtenerDatosFormulario();
            if (editingId.HasValue)
            {
                // actualizar
                var idx = listaPacientes.FindIndex(p => Convert.ToInt32(p["Id"]) == editingId.Value);
                if (idx >= 0)
                {
                    datos["Id"] = editingId.Value;
                    listaPacientes[idx] = datos;
                }
            }
            else
            {
                // crear nuevo
                int nuevoId = listaPacientes.Count > 0 ? Convert.ToInt32(listaPacientes[listaPacientes.Count - 1]["Id"]) + 1 : 1;
                datos["Id"] = nuevoId;
                listaPacientes.Add(datos);
            }

            editingId = null;
            RefrescarGrilla();
            LimpiarFormulario();
            tabControl1.SelectedTab = tabPage3; // volver a lista
        }

        private void CargarHistoriaDesdePaciente(Dictionary<string, object> pac)
        {
            txtHistAntecedentes.Text = pac.ContainsKey("Antecedentes") ? pac["Antecedentes"].ToString() : string.Empty;
            txtHistAlergias.Text = pac.ContainsKey("Alergias") ? pac["Alergias"].ToString() : string.Empty;
            txtHistCirugias.Text = pac.ContainsKey("Cirugias") ? pac["Cirugias"].ToString() : string.Empty;
            txtHistMedicacion.Text = pac.ContainsKey("MedicacionHabitual") ? pac["MedicacionHabitual"].ToString() : string.Empty;
            txtHistObservaciones.Text = pac.ContainsKey("Observaciones") ? pac["Observaciones"].ToString() : string.Empty;
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
                            sw.WriteLine("Cirugías:");
                            sw.WriteLine(txtHistCirugias.Text);
                            sw.WriteLine();
                            sw.WriteLine("Medicación habitual:");
                            sw.WriteLine(txtHistMedicacion.Text);
                            sw.WriteLine();
                            sw.WriteLine("Observaciones generales:");
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
    }
}
