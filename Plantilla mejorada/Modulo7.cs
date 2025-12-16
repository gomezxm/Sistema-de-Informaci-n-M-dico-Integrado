using Borrador.DBRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static Borrador.DBRepository.RecetasRepository;

namespace Borrador
{
    public partial class Modulo7 : UserControl
    {
        public Modulo7()
        {
            InitializeComponent();

            // Metodo de cargar pacientes en el comboBox
            CargarPacientes();
            // Cargar lista de medicamentos
            ConfigurarGridMedicamentos();
            // Cargar metodos de pago
            CargarMetodosPago();

            // Configuración segura de NumericUpDown
            nudStockActual.Maximum = 100000;
            nudStockMin.Maximum = 100000;

            CargarProveedores();
            CargarInventario();
        }

        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        //Variable de contador del ID 
        private int _idRecetaSeleccionada = 0;

        // Combo de llenar la lista de paciente 
        private void cmbPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPacientes.SelectedIndex == -1)
                return;

            if (cmbPacientes.SelectedValue == null)
                return;

            if (!int.TryParse(cmbPacientes.SelectedValue.ToString(), out int idPaciente))
                return;

            RecetasRepository repo = new RecetasRepository();
            var receta = repo.ObtenerRecetaPorPaciente(idPaciente);

            if (receta == null)
            {
                MessageBox.Show("El paciente no tiene receta.");
                return;
            }

            _idRecetaSeleccionada = receta.IdReceta;
            txtMedicos.Text = receta.Medico;
            txtNumeroRecetas.Text = receta.NumeroReceta;
            txtFechas.Text = receta.FechaReceta.ToString("dd/MM/yyyy");

            CargarMedicamentos(_idRecetaSeleccionada);
        }


        // Metodo de cargar los pacientes 
        private void CargarPacientes()
        {
            CirugiaRepository repo = new CirugiaRepository();
            DataTable dt = repo.ObtenerPacientes();

            cmbPacientes.DataSource = dt;
            cmbPacientes.DisplayMember = "Display";   
            cmbPacientes.ValueMember = "IdPaciente";  
            cmbPacientes.SelectedIndex = -1;         
        }

        // Metodo para cargar la Lista
        private void CargarMedicamentos(int idConsulta)
        {
            RecetasRepository repo = new RecetasRepository();

            List<RecetasRepository.MedicamentoDispensacionDTO> lista =
                repo.ObtenerMedicamentosPorConsulta(idConsulta);

            ListaMedicamentos.DataSource = lista;
        }

        // Metodo de cargar las opciones de pago
        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta de crédito");
            cmbMetodoPago.Items.Add("Tarjeta de débito");
            cmbMetodoPago.Items.Add("Transferencia bancaria");
            cmbMetodoPago.SelectedIndex = -1; // Ninguno seleccionado por defecto
        }



        // Metodo para configurar la lista de medicamentos Prescritos
        private void ConfigurarGridMedicamentos()
        {
            ListaMedicamentos.AutoGenerateColumns = false;
            ListaMedicamentos.Columns.Clear();

            ListaMedicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Medicamento",
                HeaderText = "Medicamento",
                ReadOnly = true
            });

            ListaMedicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dosis",
                HeaderText = "Dosis",
                ReadOnly = true
            });

            ListaMedicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Frecuencia",
                HeaderText = "Frecuencia",
                ReadOnly = true
            });

            ListaMedicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadPrescrita",
                HeaderText = "Cantidad Prescrita",
                ReadOnly = true
            });

            ListaMedicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadEntregar", 
                HeaderText = "Cantidad a entregar"
            });

        }

        // Boton de confirmar 
        private void button2_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una receta
            if (_idRecetaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione un paciente con receta.");
                return;
            }

            // Validar que se haya seleccionado un método de pago
            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            // Obtener lista de medicamentos del DataGridView
            var listaMedicamentos = ListaMedicamentos.DataSource
                as List<RecetasRepository.MedicamentoDispensacionDTO>;

            if (listaMedicamentos == null || listaMedicamentos.Count == 0)
            {
                MessageBox.Show("No hay medicamentos para dispensar.");
                return;
            }

            // Crear DTO con los datos de la dispensación
            PagoDispensacionDTO pago = new PagoDispensacionDTO
            {
                IdReceta = _idRecetaSeleccionada,              // Id de la receta seleccionada
                MetodoPago = cmbMetodoPago.Text,              // Se guardará en FormaPago
                ObservacionCaja = txbObservaciones.Text,     // Observaciones
                Medicamentos = listaMedicamentos             // Lista de medicamentos
            };

            try
            {
                // Guardar dispensación
                RecetasRepository repo = new RecetasRepository();
                repo.GuardarDispensacion(pago);

                MessageBox.Show("Dispensación guardada correctamente.");

                // Limpiar formulario si deseas
                ListaMedicamentos.DataSource = null;
                cmbMetodoPago.SelectedIndex = -1;
                txbObservaciones.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar dispensación: " + ex.Message);
            }
        }

        //Boton de imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_idRecetaSeleccionada == 0)
                return;

            var lista = ListaMedicamentos.DataSource
                as List<RecetasRepository.MedicamentoDispensacionDTO>;

            string texto = "";
            texto += "RECETA MÉDICA\n";
            texto += "============================\n";
            texto += $"Médico: {txtMedicos.Text}\n";
            texto += $"Receta: {txtNumeroRecetas.Text}\n";
            texto += $"Fecha: {txtFechas.Text}\n\n";

            texto += "MEDICAMENTOS\n";

            foreach (var m in lista)
            {
                texto += $"{m.Medicamento} - {m.Dosis} - {m.Frecuencia} - Entregar: {m.CantidadEntregar}\n";
            }

            texto += "\nMétodo de Pago: " + cmbMetodoPago.Text;
            texto += "\nObservación: " + txbObservaciones.Text;

            MessageBox.Show(texto, "Impresión");
        }

        // Implementacion de Inventario
        // =========================
        // CARGA DE DATOS
        // =========================

        void CargarInventario()
        {
            string query = @"SELECT
                IdMedicamentoInv,
                CodigoInterno,
                NombreMedicamento,
                Presentacion,
                UnidadMedida,
                ExistenciaActual,
                ExistenciaMinima,
                FechaVencimiento,
                Lote,
                IdProveedor,
                Estado
            FROM INVENTARIO_FARMACIA";

            dgvInventario.DataSource = ConexionDB.Instancia.EjecutarConsulta(query);
        }

        void CargarProveedores()
        {
            string query = "SELECT IdProveedor, NombreProveedor FROM CAT_PROVEEDORES";

            cmbProveedor.DataSource = ConexionDB.Instancia.EjecutarConsulta(query);
            cmbProveedor.DisplayMember = "NombreProveedor";
            cmbProveedor.ValueMember = "IdProveedor";
            cmbProveedor.SelectedIndex = -1;
        }

        // =========================
        // EVENTOS
        // =========================

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvInventario.Rows[e.RowIndex];

            txtCodigo.Text = fila.Cells["CodigoInterno"].Value?.ToString() ?? "";
            txtMedicamento.Text = fila.Cells["NombreMedicamento"].Value?.ToString() ?? "";
            txtLote.Text = fila.Cells["Lote"].Value?.ToString() ?? "";

            cmbPresentacion.Text = fila.Cells["Presentacion"].Value?.ToString() ?? "";
            cmbUnidadMedida.Text = fila.Cells["UnidadMedida"].Value?.ToString() ?? "";
            cmbEstado.Text = fila.Cells["Estado"].Value?.ToString() ?? "";

            nudStockActual.Value = Convert.ToDecimal(fila.Cells["ExistenciaActual"].Value);
            nudStockMin.Value = Convert.ToDecimal(fila.Cells["ExistenciaMinima"].Value);

            if (fila.Cells["FechaVencimiento"].Value != DBNull.Value)
                dtpVencimiento.Value = Convert.ToDateTime(fila.Cells["FechaVencimiento"].Value);
            else
                dtpVencimiento.Value = DateTime.Now;

            if (fila.Cells["IdProveedor"].Value != DBNull.Value)
                cmbProveedor.SelectedValue = fila.Cells["IdProveedor"].Value;
            else
                cmbProveedor.SelectedIndex = -1;
        }

        private void btnStockBajo_Click(object sender, EventArgs e)
        {
            string query = @"SELECT *
                             FROM INVENTARIO_FARMACIA
                             WHERE ExistenciaActual <= ExistenciaMinima";

            dgvInventario.DataSource = ConexionDB.Instancia.EjecutarConsulta(query);
        }

        
        // =========================
        // LIMPIAR
        // =========================

        void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtMedicamento.Clear();
            txtLote.Clear();

            cmbPresentacion.SelectedIndex = -1;
            cmbUnidadMedida.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            nudStockActual.Value = 0;
            nudStockMin.Value = 0;

            dtpVencimiento.Value = DateTime.Now;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicamento.Text))
            {
                MessageBox.Show("Ingrese el nombre del medicamento");
                return;
            }

            string query = @"INSERT INTO INVENTARIO_FARMACIA
            (NombreMedicamento, CodigoInterno, Presentacion, UnidadMedida,
             ExistenciaActual, ExistenciaMinima, FechaVencimiento,
             Lote, IdProveedor, Estado)
            VALUES
            (@Nombre, @Codigo, @Presentacion, @Unidad,
             @Stock, @Minimo, @Fecha,
             @Lote, @Proveedor, @Estado)";

            var parametros = ConexionDB.Instancia.CrearParametros(
                ("@Nombre", txtMedicamento.Text),
                ("@Codigo", txtCodigo.Text),
                ("@Presentacion", cmbPresentacion.Text),
                ("@Unidad", cmbUnidadMedida.Text),
                ("@Stock", nudStockActual.Value),
                ("@Minimo", nudStockMin.Value),
                ("@Fecha", dtpVencimiento.Value),
                ("@Lote", txtLote.Text),
                ("@Proveedor", cmbProveedor.SelectedValue ?? (object)DBNull.Value),
                ("@Estado", cmbEstado.Text)
            );

            ConexionDB.Instancia.EjecutarComando(query, parametros);

            MessageBox.Show("Medicamento agregado correctamente");
            CargarInventario();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un medicamento");
                return;
            }

            int id = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdMedicamentoInv"].Value);

            string query = @"UPDATE INVENTARIO_FARMACIA SET
                NombreMedicamento = @Nombre,
                CodigoInterno = @Codigo,
                Presentacion = @Presentacion,
                UnidadMedida = @Unidad,
                ExistenciaActual = @Stock,
                ExistenciaMinima = @Minimo,
                FechaVencimiento = @Fecha,
                Lote = @Lote,
                IdProveedor = @Proveedor,
                Estado = @Estado
            WHERE IdMedicamentoInv = @Id";

            var parametros = ConexionDB.Instancia.CrearParametros(
                ("@Nombre", txtMedicamento.Text),
                ("@Codigo", txtCodigo.Text),
                ("@Presentacion", cmbPresentacion.Text),
                ("@Unidad", cmbUnidadMedida.Text),
                ("@Stock", nudStockActual.Value),
                ("@Minimo", nudStockMin.Value),
                ("@Fecha", dtpVencimiento.Value),
                ("@Lote", txtLote.Text),
                ("@Proveedor", cmbProveedor.SelectedValue ?? (object)DBNull.Value),
                ("@Estado", cmbEstado.Text),
                ("@Id", id)
            );

            ConexionDB.Instancia.EjecutarComando(query, parametros);

            MessageBox.Show("Medicamento actualizado");
            CargarInventario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un medicamento");
                return;
            }

            int id = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdMedicamentoInv"].Value);

            if (MessageBox.Show("¿Eliminar medicamento?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string query = "DELETE FROM INVENTARIO_FARMACIA WHERE IdMedicamentoInv = @Id";

                var parametros = ConexionDB.Instancia.CrearParametros(
                    ("@Id", id)
                );

                ConexionDB.Instancia.EjecutarComando(query, parametros);

                CargarInventario();
                LimpiarCampos();
            }
        }

        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarInventario();
            btnAtras.Visible = false;  // en CargarInventario
        }

        private void btnVersotckBajo_Click(object sender, EventArgs e)
        {
            btnAtras.Visible = true;   // en Stock Bajo
        }
    }
}
