using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
<<<<<<< HEAD
=======
using System.Data.SqlClient;
>>>>>>> Dev
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
<<<<<<< HEAD
        }

        private void label1_Click(object sender, EventArgs e)
=======
            CargarCombos();
        }

        // =======================
        // CARGA DE COMBOS
        // =======================
        private void CargarCombos()
        {
            CargarPacientes();
            CargarSalas();
            CargarMedicos();

            comboBox3.SelectedIndex = 0; // Hospitalizado
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
                    "SELECT IdCama, NumeroCama FROM CAMAS WHERE IdSala=@Sala AND EstadoCama='Libres'", cn);

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

            CargarCamas(Convert.ToInt32(cBSala.SelectedValue));
        }

        // =======================
        // ADMITIR
        // =======================
        private void bttAdmitir_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO HOSPITALIZACION
                    (IdPaciente, IdMedicoResponsable, IdCama, DiagnosticoIngreso,
                     FechaHoraIngreso, MotivoHospitalizacion, TipoRegimen, Estado)
                    VALUES
                    (@Paciente, @Medico, @Cama, @Diag, @Fecha, @Motivo, @Regimen, 'Hospitalizado');
                    SELECT SCOPE_IDENTITY();", cn);

                cmd.Parameters.AddWithValue("@Paciente", cBPaciente.SelectedValue);
                cmd.Parameters.AddWithValue("@Medico", cBMedicoR.SelectedValue);
                cmd.Parameters.AddWithValue("@Cama", cBCama.SelectedValue);
                cmd.Parameters.AddWithValue("@Diag", txtbDiagnostico.Text);
                cmd.Parameters.AddWithValue("@Fecha", dateTimer.Value);
                cmd.Parameters.AddWithValue("@Motivo", txtBMotivo.Text);
                cmd.Parameters.AddWithValue("@Regimen", comboBox2.Text);

                txtBIdHospitalizacion.Text = cmd.ExecuteScalar().ToString();
            }

            MessageBox.Show("Paciente admitido correctamente");
        }

        // =======================
        // TRASLADAR
        // =======================
        private void bttTasladar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE HOSPITALIZACION SET IdCama=@Cama WHERE IdHospitalizacion=@Id", cn);

                cmd.Parameters.AddWithValue("@Cama", cBCama.SelectedValue);
                cmd.Parameters.AddWithValue("@Id", txtBIdHospitalizacion.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Paciente trasladado de cama");
        }

        // =======================
        // DAR ALTA
        // =======================
        private void bttAlta_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = ConexionDB.Instancia.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE HOSPITALIZACION
                      SET Estado='Alta', FechaHoraEgreso=GETDATE()
                      WHERE IdHospitalizacion=@Id", cn);

                cmd.Parameters.AddWithValue("@Id", txtBIdHospitalizacion.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Alta hospitalaria registrada");
        }

        private void label13_Click(object sender, EventArgs e)
>>>>>>> Dev
        {

        }

<<<<<<< HEAD
        private void label3_Click(object sender, EventArgs e)
=======
        private void label4_Click(object sender, EventArgs e)
>>>>>>> Dev
        {

        }

<<<<<<< HEAD
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbDiagnostico_TextChanged(object sender, EventArgs e)
=======
        private void label10_Click(object sender, EventArgs e)
>>>>>>> Dev
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
