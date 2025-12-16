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
    public partial class Modulo8 : UserControl
    {
        public Modulo8()
        {
            InitializeComponent();
            CargarCombos();
            cBPaciente.SelectedIndexChanged += cBPaciente_SelectedIndexChanged;


            // Suscribir eventos adicionales
            cboxSala.SelectedIndexChanged += cboxSala_SelectedIndexChanged;
            cboxFiltradoC.SelectedIndexChanged += cboxFiltradoC_SelectedIndexChanged;
            btnRefrescar.Click += btnRefrescar_Click;
            btnDetalles_camas.Click += btnDetalles_camas_Click;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            bttAdmitir.Click += bttAdmitir_Click;
            bttTasladar.Click += bttTasladar_Click;
            cBSala.SelectedIndexChanged += cBSala_SelectedIndexChanged;
        }

        // =======================
        // CARGA DE COMBOS
        // =======================
        private void CargarCombos()
        {
            CargarPacientes();
            CargarSalas();
            CargarMedicos();

            // Configurar valores por defecto
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0; // Tipo de régimen

            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0; // Estado: Hospitalizado
        }

        private void CargarPacientes()
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdPaciente, Nombre + ' ' + Apellido AS Paciente FROM PACIENTES WHERE EstadoPaciente='Activo'", cn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cBPaciente.DataSource = dt;
                cBPaciente.DisplayMember = "Paciente";
                cBPaciente.ValueMember = "IdPaciente";
            }
        }

        private void CargarSalas()
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdSala, NombreSala FROM CAT_SALAS", cn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cBSala.DataSource = dt;
                cBSala.DisplayMember = "NombreSala";
                cBSala.ValueMember = "IdSala";
            }
        }

        private void CargarCamas(int idSala)
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdCama, NumeroCama FROM CAMAS WHERE IdSala=@Sala AND EstadoCama='Libre'", cn);

                da.SelectCommand.Parameters.AddWithValue("@Sala", idSala);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cBCama.DataSource = dt;
                cBCama.DisplayMember = "NumeroCama";
                cBCama.ValueMember = "IdCama";
            }
        }

        private void CargarMedicos()
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT M.IdMedico, E.Nombre + ' ' + E.Apellido AS Medico
                      FROM MEDICOS M
                      INNER JOIN EMPLEADOS E ON M.IdEmpleado = E.IdEmpleado", cn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cBMedicoR.DataSource = dt;
                cBMedicoR.DisplayMember = "Medico";
                cBMedicoR.ValueMember = "IdMedico";
            }
        }

        // =======================
        // EVENTOS
        // =======================
        private void cBSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBSala.SelectedValue == null || cBSala.SelectedValue is DataRowView)
                return;

            int idSala = Convert.ToInt32(cBSala.SelectedValue);
            CargarCamas(idSala);

            // Mensaje si no hay camas disponibles
            if (cBCama.Items.Count == 0)
            {
                MessageBox.Show("No hay camas libres disponibles en esta sala.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =======================
        // ADMITIR
        // =======================
        private void bttAdmitir_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cBPaciente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un paciente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cBMedicoR.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un médico responsable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cBCama.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una cama", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtbDiagnostico.Text))
                {
                    MessageBox.Show("Debe ingresar un diagnóstico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtBMotivo.Text))
                {
                    MessageBox.Show("Debe ingresar el motivo de hospitalización", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
                {
                    // Primero actualizar el estado de la cama a Ocupada
                    SqlCommand cmdCama = new SqlCommand(
                        "UPDATE CAMAS SET EstadoCama='Ocupada' WHERE IdCama=@IdCama", cn);
                    cmdCama.Parameters.AddWithValue("@IdCama", cBCama.SelectedValue);
                    cmdCama.ExecuteNonQuery();

                    // Verificar si la tabla tiene la columna TipoRegimen
                    SqlCommand cmdCheck = new SqlCommand(
                        @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS 
                          WHERE TABLE_NAME = 'HOSPITALIZACION' AND COLUMN_NAME = 'TipoRegimen'", cn);
                    int columnExists = (int)cmdCheck.ExecuteScalar();

                    // Luego insertar la hospitalización según las columnas disponibles
                    string query;
                    SqlCommand cmd;

                    if (columnExists > 0)
                    {
                        // Si existe la columna TipoRegimen
                        query = @"INSERT INTO HOSPITALIZACION
                                (IdPaciente, IdMedicoResponsable, IdCama, DiagnosticoIngreso,
                                 FechaHoraIngreso, MotivoHospitalizacion, TipoRegimen, Estado)
                                VALUES
                                (@Paciente, @Medico, @Cama, @Diag, @Fecha, @Motivo, @Regimen, @Estado);
                                SELECT SCOPE_IDENTITY();";

                        cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@Paciente", cBPaciente.SelectedValue);
                        cmd.Parameters.AddWithValue("@Medico", cBMedicoR.SelectedValue);
                        cmd.Parameters.AddWithValue("@Cama", cBCama.SelectedValue);
                        cmd.Parameters.AddWithValue("@Diag", txtbDiagnostico.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fecha", dateTimer.Value);
                        cmd.Parameters.AddWithValue("@Motivo", txtBMotivo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Regimen", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@Estado", comboBox3.Text);
                    }
                    else
                    {
                        // Si NO existe la columna TipoRegimen
                        query = @"INSERT INTO HOSPITALIZACION
                                (IdPaciente, IdMedicoResponsable, IdCama, DiagnosticoIngreso,
                                 FechaHoraIngreso, MotivoHospitalizacion, Estado)
                                VALUES
                                (@Paciente, @Medico, @Cama, @Diag, @Fecha, @Motivo, @Estado);
                                SELECT SCOPE_IDENTITY();";

                        cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@Paciente", cBPaciente.SelectedValue);
                        cmd.Parameters.AddWithValue("@Medico", cBMedicoR.SelectedValue);
                        cmd.Parameters.AddWithValue("@Cama", cBCama.SelectedValue);
                        cmd.Parameters.AddWithValue("@Diag", txtbDiagnostico.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fecha", dateTimer.Value);
                        cmd.Parameters.AddWithValue("@Motivo", txtBMotivo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Estado", comboBox3.Text);
                    }

                    txtBIdHospitalizacion.Text = cmd.ExecuteScalar().ToString();
                }

                MessageBox.Show("Paciente admitido correctamente\nID Hospitalización: " + txtBIdHospitalizacion.Text,
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar las camas disponibles
                if (cBSala.SelectedValue != null && !(cBSala.SelectedValue is DataRowView))
                {
                    CargarCamas(Convert.ToInt32(cBSala.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al admitir paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================
        // TRASLADAR
        // =======================
        private void bttTasladar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBIdHospitalizacion.Text))
                {
                    MessageBox.Show("Debe seleccionar una hospitalización", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
                {
                    // Obtener la cama actual
                    SqlCommand cmdObtener = new SqlCommand(
                        "SELECT IdCama FROM HOSPITALIZACION WHERE IdHospitalizacion=@Id", cn);
                    cmdObtener.Parameters.AddWithValue("@Id", txtBIdHospitalizacion.Text);
                    object camaAnterior = cmdObtener.ExecuteScalar();

                    // Liberar la cama anterior
                    if (camaAnterior != null)
                    {
                        SqlCommand cmdLiberar = new SqlCommand(
                            "UPDATE CAMAS SET EstadoCama='Libre' WHERE IdCama=@IdCama", cn);
                        cmdLiberar.Parameters.AddWithValue("@IdCama", camaAnterior);
                        cmdLiberar.ExecuteNonQuery();
                    }

                    // Ocupar la nueva cama
                    SqlCommand cmdOcupar = new SqlCommand(
                        "UPDATE CAMAS SET EstadoCama='Ocupada' WHERE IdCama=@IdCama", cn);
                    cmdOcupar.Parameters.AddWithValue("@IdCama", cBCama.SelectedValue);
                    cmdOcupar.ExecuteNonQuery();

                    // Actualizar la hospitalización
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE HOSPITALIZACION SET IdCama=@Cama WHERE IdHospitalizacion=@Id", cn);
                    cmd.Parameters.AddWithValue("@Cama", cBCama.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id", txtBIdHospitalizacion.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Paciente trasladado de cama correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar las camas disponibles
                if (cBSala.SelectedValue != null && !(cBSala.SelectedValue is DataRowView))
                {
                    CargarCamas(Convert.ToInt32(cBSala.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al trasladar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================
        // DAR ALTA
        // =======================
        private void bttAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBIdHospitalizacion.Text))
                {
                    MessageBox.Show("Debe seleccionar una hospitalización", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
                {
                    // Obtener la cama del paciente
                    SqlCommand cmdObtener = new SqlCommand(
                        "SELECT IdCama FROM HOSPITALIZACION WHERE IdHospitalizacion=@Id", cn);
                    cmdObtener.Parameters.AddWithValue("@Id", txtBIdHospitalizacion.Text);
                    object idCama = cmdObtener.ExecuteScalar();

                    // Liberar la cama
                    if (idCama != null)
                    {
                        SqlCommand cmdLiberar = new SqlCommand(
                            "UPDATE CAMAS SET EstadoCama='Libre' WHERE IdCama=@IdCama", cn);
                        cmdLiberar.Parameters.AddWithValue("@IdCama", idCama);
                        cmdLiberar.ExecuteNonQuery();
                    }

                    // Actualizar el estado de la hospitalización
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE HOSPITALIZACION
                          SET Estado='Alta', FechaHoraEgreso=GETDATE()
                          WHERE IdHospitalizacion=@Id", cn);
                    cmd.Parameters.AddWithValue("@Id", txtBIdHospitalizacion.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Alta hospitalaria registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                txtBIdHospitalizacion.Clear();
                txtbDiagnostico.Clear();
                txtBMotivo.Clear();

                // Recargar las camas disponibles
                if (cBSala.SelectedValue != null && !(cBSala.SelectedValue is DataRowView))
                {
                    CargarCamas(Convert.ToInt32(cBSala.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de alta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================
        // EVENTOS DE LABELS (generados por el diseñador)
        // =======================
        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        // =======================
        // TAB CAMAS - FUNCIONALIDAD
        // =======================
        private void CargarDataGridCamas()
        {
            try
            {
                using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
                {
                    string query = @"
                        SELECT 
                            C.IdCama,
                            S.NombreSala AS Sala,
                            C.NumeroCama AS [Número Cama],
                            C.EstadoCama AS Estado,
                            CASE 
                                WHEN H.IdHospitalizacion IS NOT NULL 
                                THEN P.Nombre + ' ' + P.Apellido 
                                ELSE '-' 
                            END AS Paciente
                        FROM CAMAS C
                        INNER JOIN CAT_SALAS S ON C.IdSala = S.IdSala
                        LEFT JOIN HOSPITALIZACION H ON C.IdCama = H.IdCama AND H.Estado = 'Hospitalizado'
                        LEFT JOIN PACIENTES P ON H.IdPaciente = P.IdPaciente";

                    // Aplicar filtros
                    List<string> conditions = new List<string>();

                    if (cboxSala.SelectedIndex > 0) // Si no es "Todas"
                    {
                        conditions.Add("S.NombreSala = @Sala");
                    }

                    if (cboxFiltradoC.SelectedIndex > 0) // Si no es "Todas"
                    {
                        string estado = cboxFiltradoC.Text;
                        if (estado == "Libres")
                            conditions.Add("C.EstadoCama = 'Libre'");
                        else if (estado == "Ocupadas")
                            conditions.Add("C.EstadoCama = 'Ocupada'");
                        else if (estado == "Reservadas")
                            conditions.Add("C.EstadoCama = 'Reservada'");
                    }

                    if (conditions.Count > 0)
                    {
                        query += " WHERE " + string.Join(" AND ", conditions);
                    }

                    query += " ORDER BY S.NombreSala, C.NumeroCama";

                    SqlDataAdapter da = new SqlDataAdapter(query, cn);

                    if (cboxSala.SelectedIndex > 0)
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Sala", cboxSala.Text);
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    tableListaC.DataSource = dt;

                    // Ocultar la columna IdCama
                    if (tableListaC.Columns.Contains("IdCama"))
                        tableListaC.Columns["IdCama"].Visible = false;

                    // Ajustar anchos de columnas
                    if (tableListaC.Columns.Count > 0)
                    {
                        tableListaC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las camas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboSalasTab2()
        {
            try
            {
                using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT IdSala, NombreSala FROM CAT_SALAS ORDER BY NombreSala", cn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Agregar opción "Todas"
                    DataRow row = dt.NewRow();
                    row["IdSala"] = 0;
                    row["NombreSala"] = "Todas las salas";
                    dt.Rows.InsertAt(row, 0);

                    cboxSala.DataSource = dt;
                    cboxSala.DisplayMember = "NombreSala";
                    cboxSala.ValueMember = "IdSala";
                    cboxSala.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDataGridCamas();
        }

        private void cboxSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDataGridCamas();
        }

        private void cboxFiltradoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDataGridCamas();
        }

        private void btnDetalles_camas_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableListaC.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una cama",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow row = tableListaC.SelectedRows[0];
                string sala = row.Cells["Sala"].Value.ToString();
                string numeroCama = row.Cells["Número Cama"].Value.ToString();
                string estado = row.Cells["Estado"].Value.ToString();
                string paciente = row.Cells["Paciente"].Value.ToString();

                string mensaje = $"=== DETALLES DE CAMA ===\n\n";
                mensaje += $"Sala: {sala}\n";
                mensaje += $"Número de Cama: {numeroCama}\n";
                mensaje += $"Estado: {estado}\n";
                mensaje += $"Paciente: {paciente}";

                MessageBox.Show(mensaje, "Información de Cama",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar detalles: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se cambia al tab de Camas (índice 1)
            if (tabControl1.SelectedIndex == 1)
            {
                CargarComboSalasTab2();
                if (cboxFiltradoC.Items.Count > 0)
                    cboxFiltradoC.SelectedIndex = 0;
                CargarDataGridCamas();
            }
        }
        private void CargarInfoPaciente(int idPaciente)
        {
            try
            {
                using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
                {
                    string query = @"
                SELECT TOP 1
                    H.IdHospitalizacion,
                    H.DiagnosticoIngreso,
                    H.MotivoHospitalizacion,
                    H.FechaHoraIngreso,
                    H.Estado,
                    H.IdCama,
                    H.IdMedicoResponsable,
                    C.IdSala
                FROM HOSPITALIZACION H
                INNER JOIN CAMAS C ON H.IdCama = C.IdCama
                WHERE H.IdPaciente = @Paciente
                ORDER BY H.FechaHoraIngreso DESC";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Paciente", idPaciente);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        // Hospitalización
                        txtBIdHospitalizacion.Text = dr["IdHospitalizacion"].ToString();
                        txtbDiagnostico.Text = dr["DiagnosticoIngreso"].ToString();
                        txtBMotivo.Text = dr["MotivoHospitalizacion"].ToString();
                        dateTimer.Value = Convert.ToDateTime(dr["FechaHoraIngreso"]);
                        comboBox3.Text = dr["Estado"].ToString();

                        // Médico
                        cBMedicoR.SelectedValue = dr["IdMedicoResponsable"];

                        // Sala y camas
                        int idSala = Convert.ToInt32(dr["IdSala"]);
                        cBSala.SelectedValue = idSala;

                        CargarCamas(idSala);
                        cBCama.SelectedValue = dr["IdCama"];
                    }
                    else
                    {
                        // No hospitalizado → limpiar
                        LimpiarDatosHospitalizacion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar información del paciente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarDatosHospitalizacion()
        {
            txtBIdHospitalizacion.Clear();
            txtbDiagnostico.Clear();
            txtBMotivo.Clear();
            cBCama.DataSource = null;
        }

        private void cBPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBPaciente.SelectedValue == null || cBPaciente.SelectedValue is DataRowView)
                return;

            int idPaciente = Convert.ToInt32(cBPaciente.SelectedValue);
            CargarInfoPaciente(idPaciente);
        }

        private void cBCama_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}