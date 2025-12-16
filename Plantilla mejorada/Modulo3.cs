using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Borrador
{
    
    public partial class Modulo3 : UserControl
    {
        private readonly string cn =
     "Data Source=hospitalserver.database.windows.net;" +
                    "Initial Catalog=BD-Hospital;" +
                    "User ID=SuperAdmin;" +
                    "Password=Hospital.123;" +
                    "Integrated Security=False;" +
                    "MultipleActiveResultSets=True;" +
                    "Connect Timeout=30;" +
                    "Encrypt=True;" +
                    "TrustServerCertificate=False;";

        private DataTable dtCIE10_Principal;
        private DataTable dtCIE10_Secundario;
        private PrintDocument printDocument1;
        private bool cargandoConsulta = false;



        public Modulo3()
        {
            InitializeComponent();
            this.Load += Modulo3_Load;
        }


        private void Modulo3_Load(object sender, EventArgs e)
        {
            ConfigurarGridBase();

            CargarCombosConsulta();
            CargarCIE10();
            ConfigurarGridDiagnosticos();

            CmboxDiagprinc.SelectedIndexChanged += CmboxDiagprinc_SelectedIndexChanged;
            dtaGriewsec.CellValidating += dtaGriewsec_CellValidating;

            dtaGriewsec.RowsAdded += dtaGriewsec_RowsAdded;
            dtaGriewsec.DataError += dtaGriewsec_DataError;
            ConfigurarGridPrescripciones();

            dtaGriewsec.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (dtaGriewsec.IsCurrentCellDirty)
                    dtaGriewsec.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };


            dtpickdesde.Value = DateTime.Today.AddDays(-7);
            dtpickhasta.Value = DateTime.Today;
            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += printDocument1_PrintPage;

            ConfigurarGridHistorial();
            CargarCombosHistorial();
            // FILTRADO AUTOMÁTICO DEL HISTORIAL
            cmboxpachist.SelectedIndexChanged += (s, e2) =>
            {
                if (tabforms.SelectedIndex == 1)
                    CargarHistorialConsultas();
            };

            cmboxmedichist.SelectedIndexChanged += (s, e2) =>
            {
                if (tabforms.SelectedIndex == 1)
                    CargarHistorialConsultas();
            };

            dtpickdesde.ValueChanged += (s, e2) =>
            {
                if (tabforms.SelectedIndex == 1)
                    CargarHistorialConsultas();
            };

            dtpickhasta.ValueChanged += (s, e2) =>
            {
                if (tabforms.SelectedIndex == 1)
                    CargarHistorialConsultas();
            };

        }

        private void ConfigurarGridBase()
        {
            dtaGriewsec.DataSource = null;
            dtaGriewsec.Rows.Clear();
            dtaGriewsec.Columns.Clear();

            dtaGriewsec.AutoGenerateColumns = false;
            dtaGriewsec.AllowUserToAddRows = true;
            dtaGriewsec.AllowUserToDeleteRows = true;
            dtaGriewsec.AllowUserToResizeRows = false;
            dtaGriewsec.AllowUserToResizeColumns = false;

            dtaGriewsec.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dtaGriewsec.MultiSelect = false;
            dtaGriewsec.RowHeadersVisible = false;
            dtaGriewsec.ScrollBars = ScrollBars.Vertical;

            dtaGriewsec.Height = 140;
            dtaGriewsec.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dtaGriewsec.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
        }
        private void dtaGriewsec_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            // Limpia visualmente la celda
            dtaGriewsec.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
        }

        private void dtaGriewsec_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cargandoConsulta) return;
            if (e.RowIndex < 0) return;
            if (dtaGriewsec.Columns[e.ColumnIndex].Name != "CodigoCIE10") return;

            var cell = dtaGriewsec.Rows[e.RowIndex].Cells["CodigoCIE10"];
            if (cell.Value == null) return;

            string codigo = cell.Value.ToString();

            //  No permitir diagnóstico principal
            if (CmboxDiagprinc.SelectedValue != null &&
                CmboxDiagprinc.SelectedValue.ToString() == codigo)
            {
                MessageBox.Show("El diagnóstico principal no puede repetirse.");
                dtaGriewsec.Rows[e.RowIndex].Cells["CodigoCIE10"].Value = DBNull.Value;
                return;
            }

            //  No permitir duplicados
            for (int i = 0; i < dtaGriewsec.Rows.Count; i++)
            {
                if (i == e.RowIndex) continue;

                var val = dtaGriewsec.Rows[i].Cells["CodigoCIE10"].Value;
                if (val != null && val.ToString() == codigo)
                {
                    MessageBox.Show("Este diagnóstico secundario ya fue agregado.");
                    dtaGriewsec.Rows[e.RowIndex].Cells["CodigoCIE10"].Value = DBNull.Value;
                    return;
                }
            }
        }

        private void CargarCombosConsulta()
        {
            // Pacientes
            SqlDataAdapter daPac = new SqlDataAdapter(
                "SELECT IdPaciente, Nombre + ' ' + Apellido AS Nombre FROM PACIENTES WHERE EstadoPaciente='Activo'", cn);

            DataTable dtPac = new DataTable();
            daPac.Fill(dtPac);

            Comboxpac.DataSource = dtPac;
            Comboxpac.DisplayMember = "Nombre";
            Comboxpac.ValueMember = "IdPaciente";
            Comboxpac.SelectedIndex = -1;

            // Médicos
            SqlDataAdapter daMed = new SqlDataAdapter(@"
                SELECT m.IdMedico, e.Nombre + ' ' + e.Apellido AS Nombre
                FROM MEDICOS m
                JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado", cn);

            DataTable dtMed = new DataTable();
            daMed.Fill(dtMed);

            CmboxMed.DataSource = dtMed;
            CmboxMed.DisplayMember = "Nombre";
            CmboxMed.ValueMember = "IdMedico";
            CmboxMed.SelectedIndex = -1;
        }
        private void CargarCIE10()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT CodigoCIE10, Descripcion FROM VW_CIE10_DIAGNOSTICOS ORDER BY Descripcion",
                cn);

            dtCIE10_Principal = new DataTable();
            dtCIE10_Secundario = new DataTable();

            da.Fill(dtCIE10_Principal);
            da.Fill(dtCIE10_Secundario);

            // Diagnóstico principal
            CmboxDiagprinc.DataSource = dtCIE10_Principal;
            CmboxDiagprinc.DisplayMember = "Descripcion";
            CmboxDiagprinc.ValueMember = "CodigoCIE10";
            CmboxDiagprinc.SelectedIndex = -1;
        }

        private void ConfigurarGridDiagnosticos()
        {
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Name = "CodigoCIE10";
            col.HeaderText = "Diagnóstico secundario";
            col.DataSource = dtCIE10_Secundario;
            col.DisplayMember = "Descripcion";
            col.ValueMember = "CodigoCIE10";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtaGriewsec.Columns.Add(col);
        }

        private void dtaGriewsec_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dtaGriewsec.Rows.Count > 6) // 5 + fila nueva
            {
                MessageBox.Show("Máximo 5 diagnósticos secundarios permitidos.");
                dtaGriewsec.Rows.RemoveAt(dtaGriewsec.Rows.Count - 2);
            }
        }


        private void dtaGriewsec_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (cargandoConsulta) return;
            if (e.RowIndex < 0) return;
            if (dtaGriewsec.Columns[e.ColumnIndex].Name != "CodigoCIE10") return;

            // ❌ NO validaciones clínicas aquí
            // SOLO evitar valores vacíos raros
            if (e.FormattedValue == null || string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                e.Cancel = false;
            }
        }




        private void CmboxDiagprinc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoConsulta) return; //  MUY IMPORTANTE
            if (CmboxDiagprinc.SelectedValue == null) return;

            string principal = CmboxDiagprinc.SelectedValue.ToString();

            foreach (DataGridViewRow row in dtaGriewsec.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["CodigoCIE10"].Value?.ToString() == principal)
                    row.Cells["CodigoCIE10"].Value = null;
            }
        }



        private void ConfigurarGridPrescripciones()
        {
            DtaGriewprees.DataSource = null;
            DtaGriewprees.Rows.Clear();
            DtaGriewprees.Columns.Clear();

            DtaGriewprees.AutoGenerateColumns = false;
            DtaGriewprees.AllowUserToAddRows = true;
            DtaGriewprees.AllowUserToDeleteRows = true;
            DtaGriewprees.ReadOnly = false;

            DtaGriewprees.RowHeadersVisible = false;
            DtaGriewprees.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DtaGriewprees.AllowUserToResizeRows = false;
            DtaGriewprees.AllowUserToResizeColumns = false;

            DtaGriewprees.ColumnHeadersHeight = 30;
            DtaGriewprees.RowTemplate.Height = 26;

            DtaGriewprees.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            DtaGriewprees.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            // =========================
            // COLUMNAS
            // =========================
            DtaGriewprees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Medicamento",
                HeaderText = "Medicamento",
                Width = 200
            });

            DtaGriewprees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Dosis",
                HeaderText = "Dosis",
                Width = 90
            });

            DtaGriewprees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Frecuencia",
                HeaderText = "Frecuencia",
                Width = 110
            });

            DtaGriewprees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Dias",
                HeaderText = "Días",
                Width = 60
            });

            DtaGriewprees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ViaAdministracion",
                HeaderText = "Vía",
                Width = 90
            });
        }

        private void ConfigurarGridHistorial()
        {
            // Limpieza base
            dtagriwlistaconsulta.DataSource = null;
            dtagriwlistaconsulta.Rows.Clear();
            dtagriwlistaconsulta.Columns.Clear();

            dtagriwlistaconsulta.AutoGenerateColumns = false;
            dtagriwlistaconsulta.AllowUserToAddRows = false;
            dtagriwlistaconsulta.AllowUserToDeleteRows = false;
            dtagriwlistaconsulta.ReadOnly = true;

            dtagriwlistaconsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtagriwlistaconsulta.MultiSelect = false;
            dtagriwlistaconsulta.RowHeadersVisible = false;

            //  Tamaños
            dtagriwlistaconsulta.ColumnHeadersHeight = 32;
            dtagriwlistaconsulta.RowTemplate.Height = 26;

            //  Fuentes
            dtagriwlistaconsulta.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dtagriwlistaconsulta.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            //  Colores 
            dtagriwlistaconsulta.EnableHeadersVisualStyles = false;
            dtagriwlistaconsulta.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(230, 230, 230);
            dtagriwlistaconsulta.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Black;

            dtagriwlistaconsulta.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 120, 215);
            dtagriwlistaconsulta.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dtagriwlistaconsulta.GridColor = Color.LightGray;

            //  Filas alternas
            dtagriwlistaconsulta.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            //  Scroll limpio
            dtagriwlistaconsulta.ScrollBars = ScrollBars.Vertical;

            // =========================
            //  COLUMNAS MANUALES
            // =========================
            dtagriwlistaconsulta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdConsulta",
                HeaderText = "ID",
                DataPropertyName = "IdConsulta",
                Width = 50
            });

            dtagriwlistaconsulta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha",
                DataPropertyName = "FechaConsulta",
                Width = 100,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dtagriwlistaconsulta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Paciente",
                HeaderText = "Paciente",
                DataPropertyName = "Paciente",
                Width = 180
            });

            dtagriwlistaconsulta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Medico",
                HeaderText = "Médico",
                DataPropertyName = "Medico",
                Width = 180
            });

            dtagriwlistaconsulta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Diagnostico",
                HeaderText = "Diagnóstico",
                DataPropertyName = "Diagnostico",
                Width = 130
            });

            dtagriwlistaconsulta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "EstadoConsulta",
                Width = 90
            });

            // Ajuste automático de columnas
            dtagriwlistaconsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Que la última columna ocupe el espacio sobrante
            dtagriwlistaconsulta.Columns["Estado"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

        }


        private void CargarHistorialConsultas()
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT
                c.IdConsulta,
                c.FechaConsulta,
                p.Nombre + ' ' + p.Apellido AS Paciente,
                e.Nombre + ' ' + e.Apellido AS Medico,
                c.DiagnosticoPrincipal_CIE10 AS Diagnostico,
                ISNULL(c.EstadoConsulta, 'Activa') AS EstadoConsulta
            FROM CONSULTAS_MEDICAS c
            JOIN PACIENTES p ON c.IdPaciente = p.IdPaciente
            JOIN MEDICOS m ON c.IdMedico = m.IdMedico
            JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado
            WHERE
                (@IdPaciente IS NULL OR c.IdPaciente = @IdPaciente)
                AND (@IdMedico IS NULL OR c.IdMedico = @IdMedico)
                AND c.FechaConsulta BETWEEN @Desde AND @Hasta
            ORDER BY c.FechaConsulta DESC", con);

                cmd.Parameters.Add("@IdPaciente", SqlDbType.Int).Value =
                cmboxpachist.SelectedIndex == -1
                    ? DBNull.Value
                    : cmboxpachist.SelectedValue;

                cmd.Parameters.Add("@IdMedico", SqlDbType.Int).Value =
                cmboxmedichist.SelectedIndex == -1
                    ? DBNull.Value
                    : cmboxmedichist.SelectedValue;


                cmd.Parameters.AddWithValue("@Desde", dtpickdesde.Value.Date);
                cmd.Parameters.AddWithValue("@Hasta", dtpickhasta.Value.Date.AddDays(1).AddSeconds(-1));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtagriwlistaconsulta.DataSource = dt;
                dtagriwlistaconsulta.Sort(
                    dtagriwlistaconsulta.Columns["IdConsulta"],
                    ListSortDirection.Ascending
                );

            }
        }

        private void BtnConsul_Click(object sender, EventArgs e)
        {

        }

        private void Gpoboxhistorial_Enter(object sender, EventArgs e)
        {

        }

        private void BtnConsul_Click_1(object sender, EventArgs e)
        {
            tabforms.SelectedIndex = 0; // volver a consulta médica

            LimpiarFormulario();
        }

        private void Btnhist_Click(object sender, EventArgs e)
        {
            tabforms.SelectedIndex = 1; // ir al historial
            CargarHistorialConsultas();
        }

        private void DtaGriewprees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grpbxform1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btnguar_Click(object sender, EventArgs e)
        {
            if (!ValidarConsulta())
                return;

            if (!ValidarSignosVitales())
                return;

            bool resultado = ConexionDB.Instancia.EjecutarTransaccion((cnx, tx) =>
            {
                // =========================
                // 1. CONSULTA MÉDICA
                // =========================
                SqlCommand cmdConsulta = new SqlCommand(@"
            INSERT INTO CONSULTAS_MEDICAS
            (IdPaciente, IdMedico, FechaConsulta, MotivoConsulta,
             TA, FC, FR, Temperatura,
             DiagnosticoPrincipal_CIE10, EvolucionNotaMedica)
            VALUES
            (@IdPaciente, @IdMedico, @Fecha, @Motivo,
             @TA, @FC, @FR, @Temp,
             @DiagPrincipal, @Evolucion);
            SELECT SCOPE_IDENTITY();", cnx, tx);

                cmdConsulta.Parameters.AddWithValue("@IdPaciente", Comboxpac.SelectedValue);
                cmdConsulta.Parameters.AddWithValue("@IdMedico", CmboxMed.SelectedValue);
                cmdConsulta.Parameters.AddWithValue("@Fecha", Fechaconsult.Value);
                cmdConsulta.Parameters.AddWithValue("@Motivo", TxtBoxConsul.Text);
                cmdConsulta.Parameters.AddWithValue("@TA", ValorONull(TxtTA.Text));
                cmdConsulta.Parameters.AddWithValue("@FC", ParseInt(txtFC.Text));
                cmdConsulta.Parameters.AddWithValue("@FR", ParseInt(txtFR.Text));
                cmdConsulta.Parameters.AddWithValue("@Temp", ParseDecimal(txtTemperatura.Text));
                cmdConsulta.Parameters.AddWithValue("@DiagPrincipal", CmboxDiagprinc.SelectedValue);
                cmdConsulta.Parameters.AddWithValue("@Evolucion", txtEvo.Text);

                int idConsulta = Convert.ToInt32(cmdConsulta.ExecuteScalar());
                txtIdconsulta.Text = idConsulta.ToString();

                // =========================
                // 2. DIAGNÓSTICOS SECUNDARIOS
                // =========================
                foreach (DataGridViewRow row in dtaGriewsec.Rows)
                {
                    if (row.IsNewRow || row.Cells["CodigoCIE10"].Value == null)
                        continue;

                    SqlCommand cmdDiag = new SqlCommand(
                        "INSERT INTO CONSULTA_DIAGNOSTICOS (IdConsulta, CodigoCIE10) VALUES (@IdConsulta, @Codigo)",
                        cnx, tx);

                    cmdDiag.Parameters.AddWithValue("@IdConsulta", idConsulta);
                    cmdDiag.Parameters.AddWithValue("@Codigo", row.Cells["CodigoCIE10"].Value);
                    cmdDiag.ExecuteNonQuery();
                }

                // =========================
                // 3. PRESCRIPCIONES  ✅ CORREGIDO
                // =========================
                foreach (DataGridViewRow row in DtaGriewprees.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Medicamento"].Value == null) continue;

                    SqlCommand cmdPres = new SqlCommand(@"
                INSERT INTO PRESCRIPCIONES
                (IdConsulta, Medicamento, Dosis, Frecuencia, Dias, ViaAdministracion)
                VALUES
                (@IdConsulta, @Medicamento, @Dosis, @Frecuencia, @Dias, @Via)",
                        cnx, tx);

                    cmdPres.Parameters.AddWithValue("@IdConsulta", idConsulta);
                    cmdPres.Parameters.AddWithValue("@Medicamento",
                        row.Cells["Medicamento"].Value.ToString());

                    cmdPres.Parameters.AddWithValue("@Dosis",
                        row.Cells["Dosis"].Value ?? DBNull.Value);

                    cmdPres.Parameters.AddWithValue("@Frecuencia",
                        row.Cells["Frecuencia"].Value ?? DBNull.Value);

                    cmdPres.Parameters.AddWithValue("@Dias",
                        int.TryParse(row.Cells["Dias"].Value?.ToString(), out int d)
                            ? d
                            : (object)DBNull.Value);

                    cmdPres.Parameters.AddWithValue("@Via",
                        row.Cells["ViaAdministracion"].Value ?? DBNull.Value);

                    cmdPres.ExecuteNonQuery();
                }

                // =========================
                // 4. ÓRDENES
                // =========================
                if (Chckbxord.Checked)
                    InsertarOrden(cnx, tx, idConsulta, "LAB");

                if (chckbximg.Checked)
                    InsertarOrden(cnx, tx, idConsulta, "IMG");

            }, out string error);

            if (resultado)
                MessageBox.Show("Consulta guardada correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InsertarOrden(SqlConnection cn, SqlTransaction tx, int idConsulta, string tipo)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO CONSULTA_ORDENES (IdConsulta, TipoOrden, Estado) VALUES (@IdConsulta, @Tipo, 'Pendiente')",
                cn, tx);

            cmd.Parameters.AddWithValue("@IdConsulta", idConsulta);
            cmd.Parameters.AddWithValue("@Tipo", tipo);
            cmd.ExecuteNonQuery();
        }

        private bool ValidarConsulta()
        {
            if (Comboxpac.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un paciente");
                return false;
            }

            if (CmboxMed.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un médico");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBoxConsul.Text))
            {
                MessageBox.Show("Ingrese el motivo de la consulta");
                return false;
            }

            if (CmboxDiagprinc.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione diagnóstico principal");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEvo.Text))
            {
                MessageBox.Show("Ingrese la evolución médica");
                return false;
            }
            foreach (DataGridViewRow row in dtaGriewsec.Rows)
            {
                if (row.IsNewRow || row.Cells["CodigoCIE10"].Value == null)
                    continue;

                string secundario = row.Cells["CodigoCIE10"].Value.ToString();
                string principal = CmboxDiagprinc.SelectedValue.ToString();

                //  principal = secundario
                if (principal == secundario)
                {
                    MessageBox.Show(
                        "El diagnóstico secundario no puede ser igual al diagnóstico principal.");
                    return false;
                }

            }

            return true;
        }
        private bool ValidarSignosVitales()
        {
            // ======================
            // TA (OBLIGATORIO)
            // ======================
            if (string.IsNullOrWhiteSpace(TxtTA.Text))
            {
                MessageBox.Show("Debe ingresar la Tensión Arterial (TA).");
                TxtTA.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(
                TxtTA.Text.Trim(), @"^\d{2,3}/\d{2,3}$"))
            {
                MessageBox.Show("La TA debe tener formato válido (ej: 120/80).");
                TxtTA.Focus();
                return false;
            }

            // ======================
            // FC (OBLIGATORIO)
            // ======================
            if (string.IsNullOrWhiteSpace(txtFC.Text))
            {
                MessageBox.Show("Debe ingresar la Frecuencia Cardíaca (FC).");
                txtFC.Focus();
                return false;
            }

            if (!int.TryParse(txtFC.Text, out int fc) || fc < 30 || fc > 200)
            {
                MessageBox.Show("La FC debe estar entre 30 y 200 lpm.");
                txtFC.Focus();
                return false;
            }

            // ======================
            // FR (OBLIGATORIO)
            // ======================
            if (string.IsNullOrWhiteSpace(txtFR.Text))
            {
                MessageBox.Show("Debe ingresar la Frecuencia Respiratoria (FR).");
                txtFR.Focus();
                return false;
            }

            if (!int.TryParse(txtFR.Text, out int fr) || fr < 10 || fr > 60)
            {
                MessageBox.Show("La FR debe estar entre 10 y 60 rpm.");
                txtFR.Focus();
                return false;
            }

            // ======================
            // TEMPERATURA (OBLIGATORIA)
            // ======================
            if (string.IsNullOrWhiteSpace(txtTemperatura.Text))
            {
                MessageBox.Show("Debe ingresar la Temperatura.");
                txtTemperatura.Focus();
                return false;
            }

            if (!decimal.TryParse(txtTemperatura.Text, out decimal temp) ||
                temp < 34 || temp > 42)
            {
                MessageBox.Show("La temperatura debe estar entre 34 y 42 °C.");
                txtTemperatura.Focus();
                return false;
            }

            return true;
        }


        private object ValorONull(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return DBNull.Value;

            return valor;
        }


        private object ParseInt(string valor)
        {
            if (int.TryParse(valor, out int r))
                return r;
            return DBNull.Value;
        }

        private object ParseDecimal(string valor)
        {
            if (decimal.TryParse(valor, out decimal r))
                return r;
            return DBNull.Value;
        }

        private void Btnfin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdconsulta.Text))
            {
                MessageBox.Show("Debe guardar la consulta antes de finalizar.");
                return;
            }

            int idConsulta = int.Parse(txtIdconsulta.Text);

            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
            UPDATE CONSULTAS_MEDICAS
            SET EstadoConsulta = 'Finalizada'
            WHERE IdConsulta = @IdConsulta", con);

                cmd.Parameters.AddWithValue("@IdConsulta", idConsulta);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Consulta finalizada. Puede iniciar una nueva.",
                "Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtIdconsulta.Clear();

            Comboxpac.SelectedIndex = -1;
            CmboxMed.SelectedIndex = -1;
            CmboxDiagprinc.SelectedIndex = -1;

            TxtBoxConsul.Clear();
            txtEvo.Clear();

            TxtTA.Clear();
            txtFC.Clear();
            txtFR.Clear();
            txtTemperatura.Clear();

            dtaGriewsec.Rows.Clear();
            DtaGriewprees.Rows.Clear();

            Chckbxord.Checked = false;
            chckbximg.Checked = false;

            Fechaconsult.Value = DateTime.Now;

            TxtBoxConsul.Focus();
            ActivarModoSoloLectura(false);

        }

        private void Btnimp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdconsulta.Text))
            {
                MessageBox.Show(
                    "Debe guardar la consulta antes de imprimir.",
                    "Impresión no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2️⃣ Mostrar vista previa
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument1;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 30;
            float left = 40;
            float width = e.PageBounds.Width - 80;

            Font titulo = new Font("Segoe UI", 14, FontStyle.Bold);
            Font subtitulo = new Font("Segoe UI", 10, FontStyle.Bold);
            Font normal = new Font("Segoe UI", 10);

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };

            // =======================
            // TÍTULO
            // =======================
            e.Graphics.DrawString("CONSULTA MÉDICA", titulo, Brushes.Black,
                new RectangleF(left, y, width, 40), format);
            y += 50;

            // =======================
            // DATOS GENERALES
            // =======================
            e.Graphics.DrawString($"ID Consulta: {txtIdconsulta.Text}", normal, Brushes.Black, left, y); y += 20;
            e.Graphics.DrawString($"Paciente: {Comboxpac.Text}", normal, Brushes.Black, left, y); y += 20;
            e.Graphics.DrawString($"Médico: {CmboxMed.Text}", normal, Brushes.Black, left, y); y += 20;
            e.Graphics.DrawString($"Fecha: {Fechaconsult.Value:dd/MM/yyyy HH:mm}", normal, Brushes.Black, left, y);
            y += 30;

            // =======================
            // MOTIVO
            // =======================
            e.Graphics.DrawString("Motivo de consulta:", subtitulo, Brushes.Black, left, y);
            y += 20;

            RectangleF rectMotivo = new RectangleF(left + 20, y, width - 20, 200);
            e.Graphics.DrawString(TxtBoxConsul.Text, normal, Brushes.Black, rectMotivo, format);
            y += e.Graphics.MeasureString(TxtBoxConsul.Text, normal, (int)(width - 20)).Height + 20;

            // =======================
            // DIAGNÓSTICO
            // =======================
            e.Graphics.DrawString("Diagnóstico principal:", subtitulo, Brushes.Black, left, y);
            y += 20;

            e.Graphics.DrawString(CmboxDiagprinc.Text, normal, Brushes.Black, left + 20, y);
            y += 30;

            // =======================
            // EVOLUCIÓN
            // =======================
            e.Graphics.DrawString("Evolución:", subtitulo, Brushes.Black, left, y);
            y += 20;

            RectangleF rectEvo = new RectangleF(left + 20, y, width - 20, 300);
            e.Graphics.DrawString(txtEvo.Text, normal, Brushes.Black, rectEvo, format);
            y += e.Graphics.MeasureString(txtEvo.Text, normal, (int)(width - 20)).Height + 30;

            // =======================
            // PRESCRIPCIONES
            // =======================
            e.Graphics.DrawString("PRESCRIPCIONES", subtitulo, Brushes.Black, left, y);
            y += 25;

            foreach (DataGridViewRow row in DtaGriewprees.Rows)
            {
                if (row.IsNewRow || row.Cells["Medicamento"].Value == null) continue;

                string linea =
                    $"{row.Cells["Medicamento"].Value} | " +
                    $"{row.Cells["Dosis"].Value} | " +
                    $"{row.Cells["Frecuencia"].Value} | " +
                    $"{row.Cells["Dias"].Value} días";

                RectangleF rectLinea = new RectangleF(left + 20, y, width - 20, 50);
                e.Graphics.DrawString(linea, normal, Brushes.Black, rectLinea, format);

                y += e.Graphics.MeasureString(linea, normal, (int)(width - 20)).Height + 5;
            }
        }

        private void CargarCombosHistorial()
        {
            // Pacientes
            SqlDataAdapter daPac = new SqlDataAdapter(
                "SELECT IdPaciente, Nombre + ' ' + Apellido AS Nombre FROM PACIENTES", cn);

            DataTable dtPac = new DataTable();
            daPac.Fill(dtPac);

            cmboxpachist.DataSource = dtPac;
            cmboxpachist.DisplayMember = "Nombre";
            cmboxpachist.ValueMember = "IdPaciente";
            cmboxpachist.SelectedIndex = -1;

            // Médicos
            SqlDataAdapter daMed = new SqlDataAdapter(@"
        SELECT m.IdMedico, e.Nombre + ' ' + e.Apellido AS Nombre
        FROM MEDICOS m
        JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado", cn);

            DataTable dtMed = new DataTable();
            daMed.Fill(dtMed);

            cmboxmedichist.DataSource = dtMed;
            cmboxmedichist.DisplayMember = "Nombre";
            cmboxmedichist.ValueMember = "IdMedico";
            cmboxmedichist.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtagriwlistaconsulta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una consulta.");
                return;
            }

            int idConsulta = Convert.ToInt32(
                dtagriwlistaconsulta.SelectedRows[0].Cells["IdConsulta"].Value
            );

            //  Ir al formulario de consulta
            tabforms.SelectedIndex = 0;

            //  Cargar la consulta en modo solo lectura
            CargarConsultaPorId(idConsulta);
        }

        private void CargarConsultaPorId(int idConsulta)
        {
            cargandoConsulta = true;
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();

                // =========================
                // CONSULTA PRINCIPAL
                // =========================
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                c.IdConsulta,
                c.IdPaciente,
                c.IdMedico,
                c.FechaConsulta,
                c.MotivoConsulta,
                c.TA,
                c.FC,
                c.FR,
                c.Temperatura,
                c.DiagnosticoPrincipal_CIE10,
                c.EvolucionNotaMedica
            FROM CONSULTAS_MEDICAS c
            WHERE c.IdConsulta = @IdConsulta", con);

                cmd.Parameters.AddWithValue("@IdConsulta", idConsulta);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    MessageBox.Show("No se encontró la consulta.");
                    return;
                }

                //  Cargar datos en el formulario
                txtIdconsulta.Text = dr["IdConsulta"].ToString();
                Comboxpac.SelectedValue = dr["IdPaciente"];
                CmboxMed.SelectedValue = dr["IdMedico"];
                Fechaconsult.Value = Convert.ToDateTime(dr["FechaConsulta"]);

                TxtBoxConsul.Text = dr["MotivoConsulta"].ToString();
                TxtTA.Text = dr["TA"]?.ToString();
                txtFC.Text = dr["FC"]?.ToString();
                txtFR.Text = dr["FR"]?.ToString();
                txtTemperatura.Text = dr["Temperatura"]?.ToString();

                CmboxDiagprinc.SelectedValue = dr["DiagnosticoPrincipal_CIE10"];
                txtEvo.Text = dr["EvolucionNotaMedica"].ToString();

                dr.Close();

                // =========================
                // DIAGNÓSTICOS SECUNDARIOS
                // =========================
                dtaGriewsec.Rows.Clear();

                SqlCommand cmdDiag = new SqlCommand(@"
            SELECT CodigoCIE10
            FROM CONSULTA_DIAGNOSTICOS
            WHERE IdConsulta = @IdConsulta", con);

                cmdDiag.Parameters.AddWithValue("@IdConsulta", idConsulta);

                SqlDataReader drDiag = cmdDiag.ExecuteReader();
                while (drDiag.Read())
                {
                    dtaGriewsec.Rows.Add(drDiag["CodigoCIE10"]);
                }
                drDiag.Close();

            }
            // =========================
            // PRESCRIPCIONES (CORRECTO)
            // =========================
            CargarPrescripciones(idConsulta);

            //  BLOQUEAR FORMULARIO (solo lectura)
            ActivarModoSoloLectura(true);
            cargandoConsulta = false;
        }
        private void ActivarModoSoloLectura(bool soloLectura)
        {
            Comboxpac.Enabled = !soloLectura;
            CmboxMed.Enabled = !soloLectura;
            Fechaconsult.Enabled = !soloLectura;

            TxtBoxConsul.ReadOnly = soloLectura;
            txtEvo.ReadOnly = soloLectura;

            TxtTA.ReadOnly = soloLectura;
            txtFC.ReadOnly = soloLectura;
            txtFR.ReadOnly = soloLectura;
            txtTemperatura.ReadOnly = soloLectura;

            CmboxDiagprinc.Enabled = !soloLectura;
            dtaGriewsec.ReadOnly = soloLectura;
            DtaGriewprees.ReadOnly = soloLectura;

            Btnguar.Enabled = !soloLectura;
            Btnfin.Enabled = !soloLectura;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtagriwlistaconsulta.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = "HistorialConsultas_" + DateTime.Now.ToString("yyyyMMdd_HHmm");

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    // =========================
                    // ENCABEZADOS
                    // =========================
                    for (int i = 0; i < dtagriwlistaconsulta.Columns.Count; i++)
                    {
                        sw.Write(dtagriwlistaconsulta.Columns[i].HeaderText);
                        if (i < dtagriwlistaconsulta.Columns.Count - 1)
                            sw.Write(";");
                    }
                    sw.WriteLine();

                    // =========================
                    // FILAS
                    // =========================
                    foreach (DataGridViewRow row in dtagriwlistaconsulta.Rows)
                    {
                        if (row.IsNewRow) continue;

                        for (int i = 0; i < dtagriwlistaconsulta.Columns.Count; i++)
                        {
                            var value = row.Cells[i].Value?.ToString()?.Replace(";", ",");
                            sw.Write(value);
                            if (i < dtagriwlistaconsulta.Columns.Count - 1)
                                sw.Write(";");
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show("Listado exportado correctamente.",
                    "Exportación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }


        private void Reestablecer_Click(object sender, EventArgs e)
        {
            // Evita disparar recargas múltiples
            cmboxpachist.SelectedIndexChanged -= (s, e2) => CargarHistorialConsultas();
            cmboxmedichist.SelectedIndexChanged -= (s, e2) => CargarHistorialConsultas();

          
            // LIMPIAR FILTROS
            cmboxpachist.SelectedIndex = -1;
            cmboxmedichist.SelectedIndex = -1;

            dtpickdesde.Value = DateTime.Today.AddDays(-7);
            dtpickhasta.Value = DateTime.Today;

            // RECARGAR HISTORIAL
            CargarHistorialConsultas();


            // FEEDBACK VISUAL
            dtagriwlistaconsulta.ClearSelection();
        }

        private string ObtenerDescripcionCIE10(string codigo)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Descripcion FROM VW_CIE10_DIAGNOSTICOS WHERE CodigoCIE10 = @Cod", con);
                cmd.Parameters.AddWithValue("@Cod", codigo);

                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }
        private bool CompartenSintoma(string diagPrincipal, string diagSecundario)
        {
            string descPrincipal = ObtenerDescripcionCIE10(diagPrincipal).ToLower();
            string descSec = ObtenerDescripcionCIE10(diagSecundario).ToLower();

            // Palabras clave clínicas básicas
            string[] sintomasClave =
            {
        "dolor", "cefalea", "migraña",
        "asma", "respir",
        "fiebre",
        "torácico",
        "gripe",
        "alérg"
    };

            return sintomasClave.Any(s =>
                descPrincipal.Contains(s) && descSec.Contains(s));
        }

        private void CargarPrescripciones(int idConsulta)
        {
            DtaGriewprees.Rows.Clear();

            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT Medicamento, Dosis, Frecuencia, Dias, ViaAdministracion
            FROM PRESCRIPCIONES
            WHERE IdConsulta = @IdConsulta", con);

                cmd.Parameters.AddWithValue("@IdConsulta", idConsulta);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DtaGriewprees.Rows.Add(
                        dr["Medicamento"],
                        dr["Dosis"],
                        dr["Frecuencia"],
                        dr["Dias"],
                        dr["ViaAdministracion"]
                    );
                }
            }
        }



    }
}