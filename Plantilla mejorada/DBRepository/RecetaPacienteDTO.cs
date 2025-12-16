using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Borrador.DBRepository
{
    public class RecetasRepository
    {
        // Obtener la última receta de un paciente
        public RecetaPacienteDTO ObtenerRecetaPorPaciente(int idPaciente)
        {
            string query = @"
                SELECT TOP 1
                    r.IdReceta,
                    CONCAT(e.Nombre, ' ', e.Apellido) AS Medico,
                    r.NumeroReceta,
                    r.FechaReceta,
                    r.Observaciones
                FROM RECETAS r
                INNER JOIN EMPLEADOS e ON r.IdMedico = e.IdEmpleado
                WHERE r.IdPaciente = @IdPaciente
                ORDER BY r.FechaReceta DESC";

            SqlParameter[] parametros =
            {
                ConexionDB.Instancia.CrearParametro("@IdPaciente", idPaciente)
            };

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(query, parametros);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new RecetaPacienteDTO
            {
                IdReceta = Convert.ToInt32(row["IdReceta"]),
                Medico = row["Medico"].ToString(),
                NumeroReceta = row["NumeroReceta"].ToString(),
                FechaReceta = Convert.ToDateTime(row["FechaReceta"]),
                Observacion = row["Observaciones"].ToString()
            };
        }

        // Obtener medicamentos prescritos por consulta
        public List<MedicamentoDispensacionDTO> ObtenerMedicamentosPorConsulta(int idConsulta)
        {
            List<MedicamentoDispensacionDTO> lista = new List<MedicamentoDispensacionDTO>();

            string query = @"
        SELECT
            p.IdPrescripcion,
            p.Medicamento,
            p.Dosis,
            p.Frecuencia,
            ISNULL(d.CantidadPrescrita, 0) AS CantidadPrescrita,
            ISNULL(d.CantidadEntregada, 0) AS CantidadEntregada
        FROM PRESCRIPCIONES p
        LEFT JOIN DETALLE_DISPENSACION d 
            ON p.IdPrescripcion = d.IdMedicamentoInv
        WHERE p.IdConsulta = @IdConsulta";

            SqlParameter[] parametros =
            {
        ConexionDB.Instancia.CrearParametro("@IdConsulta", idConsulta)
    };

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(query, parametros);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new MedicamentoDispensacionDTO
                {
                    IdPrescripcion = Convert.ToInt32(row["IdPrescripcion"]),
                    Medicamento = row["Medicamento"].ToString(),
                    Dosis = row["Dosis"].ToString(),
                    Frecuencia = row["Frecuencia"].ToString(),
                    CantidadPrescrita = Convert.ToInt32(row["CantidadPrescrita"]),
                    CantidadEntregar = Convert.ToInt32(row["CantidadEntregada"])
                });
            }

            return lista;
        }


        // Método para obtener el siguiente IdFactura
        private int ObtenerNuevoIdFactura()
        {
            string query = "SELECT ISNULL(MAX(IdFactura), 0) + 1 FROM PAGOS";
            return Convert.ToInt32(ConexionDB.Instancia.EjecutarEscalar(query));
        }

        // Guardar confirmación de dispensación
        public bool GuardarDispensacion(PagoDispensacionDTO pago)
        {
            string error;

            bool ok = ConexionDB.Instancia.EjecutarTransaccion((conn, trans) =>
            {
                // Generar IdFactura
                int idFactura = ObtenerNuevoIdFactura();

                // Insertar pago en PAGOS
                string queryPago = @"
            INSERT INTO PAGOS 
            (IdFactura, IdReceta, FormaPago, ObservacionesCaja, FechaPago)
            VALUES 
            (@IdFactura, @IdReceta, @FormaPago, @Observacion, GETDATE());";

                int idPago;
                using (SqlCommand cmd = new SqlCommand(queryPago, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                    cmd.Parameters.AddWithValue("@IdReceta", pago.IdReceta); // Si IdReceta no existe, reemplazar con columna correspondiente
                    cmd.Parameters.AddWithValue("@FormaPago", pago.MetodoPago ?? "");
                    cmd.Parameters.AddWithValue("@Observacion", pago.ObservacionCaja ?? "");

                    cmd.ExecuteNonQuery();
                }

                // IdPago se puede usar igual que IdFactura
                idPago = idFactura;

                // Guardar medicamentos dispensados
                string queryDetalle = @"
            INSERT INTO DETALLESDISPENSACION
            (IdPago, IdMedicamentoInv, CantidadEntregada)
            VALUES (@IdPago, @IdMedicamento, @Cantidad)";

                foreach (var med in pago.Medicamentos)
                {
                    using (SqlCommand cmd = new SqlCommand(queryDetalle, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@IdPago", idPago);
                        cmd.Parameters.AddWithValue("@IdMedicamento", med.IdPrescripcion);
                        cmd.Parameters.AddWithValue("@Cantidad", med.CantidadEntregar);
                        cmd.ExecuteNonQuery();
                    }
                }

            }, out error);

            if (!ok)
                throw new Exception("Error en transacción: " + error);

            return ok;
        }


        // DTOs
        public class RecetaPacienteDTO
        {
            public int IdReceta { get; set; }
            public string Medico { get; set; }
            public string NumeroReceta { get; set; }
            public DateTime FechaReceta { get; set; }
            public string Observacion { get; set; }
        }

        public class MedicamentoDispensacionDTO
        {
            public int IdPrescripcion { get; set; }
            public string Medicamento { get; set; }
            public string Dosis { get; set; }
            public string Frecuencia { get; set; }
            public int CantidadPrescrita { get; set; }
            public int CantidadEntregar { get; set; }
        }

        public class PagoDispensacionDTO
        {
            public int IdReceta { get; set; }
            public string MetodoPago { get; set; }
            public string ObservacionCaja { get; set; }
            public List<MedicamentoDispensacionDTO> Medicamentos { get; set; }
        }
    }
}
