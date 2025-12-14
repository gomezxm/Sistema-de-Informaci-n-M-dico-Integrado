using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Borrador
{
    /// <summary>
    /// Repositorio para gestión de cirugías (Módulo 10)
    /// </summary>
    public class CirugiaRepository
    {
        // Ya no necesitamos _connectionString porque usamos ConexionDB.Instancia directamente

        public CirugiaRepository()
        {
            // Constructor vacío - usaremos ConexionDB.Instancia en cada método
        }

        #region Métodos para Agenda de Cirugías

        /// <summary>
        /// Obtiene todas las cirugías programadas
        /// </summary>
        public DataTable ObtenerCirugiasAgenda()
        {
            string query = @"
                SELECT 
                    e.IdEvento,
                    e.IdPaciente,
                    CONCAT(p.Nombre, ' ', p.Apellido) AS NombrePaciente,
                    e.IdResponsable,
                    CONCAT(m.Nombre, ' ', m.Apellido) AS NombreCirujano,
                    e.FechaInicio,
                    e.FechaFin,
                    e.Estado,
                    JSON_VALUE(e.DatosClinicosJson, '$.TipoCirugia') AS TipoCirugia,
                    JSON_VALUE(e.DatosClinicosJson, '$.DiagnosticoPreoperatorio') AS DiagnosticoPreoperatorio,
                    JSON_VALUE(e.DatosClinicosJson, '$.Prioridad') AS Prioridad,
                    i.Nombre AS Sala
                FROM App.EventoMedico e
                INNER JOIN App.Persona p ON e.IdPaciente = p.IdPersona
                LEFT JOIN App.Persona m ON e.IdResponsable = m.IdPersona
                LEFT JOIN App.Infraestructura i ON e.IdUbicacion = i.IdLugar
                WHERE e.TipoEvento = 'CIRUGIA'
                ORDER BY e.FechaInicio DESC";

            return ConexionDB.Instancia.EjecutarConsulta(query);
        }

        /// <summary>
        /// Obtiene lista de pacientes para programar cirugía
        /// </summary>
        public DataTable ObtenerPacientes()
        {
            string query = @"
                SELECT 
                    IdPersona,
                    CONCAT(Identificacion, ' - ', Nombre, ' ', Apellido) AS Display
                FROM App.Persona
                WHERE TipoPersona = 'PACIENTE' AND Estado = 'ACTIVO'
                ORDER BY Apellido, Nombre";

            return ConexionDB.Instancia.EjecutarConsulta(query);
        }

        /// <summary>
        /// Obtiene lista de cirujanos
        /// </summary>
        public DataTable ObtenerCirujanos()
        {
            string query = @"
                SELECT 
                    IdPersona,
                    CONCAT(Nombre, ' ', Apellido, ' - ', JSON_VALUE(DatosExtendidosJson, '$.Especialidad')) AS Display
                FROM App.Persona
                WHERE TipoPersona = 'MEDICO' 
                    AND Estado = 'ACTIVO'
                    AND (JSON_VALUE(DatosExtendidosJson, '$.Especialidad') = 'CIR' 
                         OR JSON_VALUE(DatosExtendidosJson, '$.Especialidad') LIKE '%CIR%')
                ORDER BY Apellido, Nombre";

            return ConexionDB.Instancia.EjecutarConsulta(query);
        }

        /// <summary>
        /// Obtiene tipos de cirugía del catálogo
        /// </summary>
        public DataTable ObtenerTiposCirugia()
        {
            string query = @"
                SELECT Codigo, Nombre
                FROM App.Configuracion
                WHERE Categoria = 'TIPO_CIRUGIA' AND IsActive = 1
                ORDER BY Nombre";

            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(query);

            // Si no hay tipos configurados, agregar algunos por defecto
            if (dt.Rows.Count == 0)
            {
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Nombre");
                dt.Rows.Add("APEN", "Apendicectomía");
                dt.Rows.Add("COLEC", "Colecistectomía");
                dt.Rows.Add("HERN", "Hernioplastia");
                dt.Rows.Add("CESAR", "Cesárea");
                dt.Rows.Add("OTRA", "Otra");
            }
            return dt;
        }

        /// <summary>
        /// Obtiene salas quirúrgicas disponibles
        /// </summary>
        public DataTable ObtenerSalasQuirurgicas()
        {
            string query = @"
                SELECT IdLugar, Nombre, Estado
                FROM App.Infraestructura
                WHERE Tipo = 'QUIROFANO'
                ORDER BY Nombre";

            return ConexionDB.Instancia.EjecutarConsulta(query);
        }

        /// <summary>
        /// Inserta o actualiza una cirugía programada
        /// </summary>
        public int GuardarCirugia(CirugiaDTO cirugia)
        {
            int resultado = 0;
            string mensajeError;

            bool exito = ConexionDB.Instancia.EjecutarTransaccion((conn, trans) =>
            {
                string query;
                if (cirugia.IdEvento == 0)
                {
                    // INSERT
                    query = @"
                        INSERT INTO App.EventoMedico 
                        (TipoEvento, IdPaciente, IdResponsable, IdUbicacion, FechaInicio, FechaFin, Motivo, Estado, DatosClinicosJson)
                        VALUES 
                        ('CIRUGIA', @IdPaciente, @IdResponsable, @IdUbicacion, @FechaInicio, @FechaFin, @Motivo, @Estado, @DatosJson);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
                }
                else
                {
                    // UPDATE
                    query = @"
                        UPDATE App.EventoMedico
                        SET IdPaciente = @IdPaciente,
                            IdResponsable = @IdResponsable,
                            IdUbicacion = @IdUbicacion,
                            FechaInicio = @FechaInicio,
                            FechaFin = @FechaFin,
                            Motivo = @Motivo,
                            Estado = @Estado,
                            DatosClinicosJson = @DatosJson
                        WHERE IdEvento = @IdEvento;
                        SELECT @IdEvento;";
                }

                using (var cmd = new SqlCommand(query, conn, trans))
                {
                    if (cirugia.IdEvento > 0)
                        cmd.Parameters.AddWithValue("@IdEvento", cirugia.IdEvento);

                    cmd.Parameters.AddWithValue("@IdPaciente", cirugia.IdPaciente);
                    cmd.Parameters.AddWithValue("@IdResponsable", cirugia.IdCirujano);
                    cmd.Parameters.AddWithValue("@IdUbicacion", (object)cirugia.IdSala ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaInicio", cirugia.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", (object)cirugia.FechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Motivo", cirugia.TipoCirugia ?? "");
                    cmd.Parameters.AddWithValue("@Estado", cirugia.Estado);
                    cmd.Parameters.AddWithValue("@DatosJson", cirugia.GenerarJsonDatos());

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }, out mensajeError);

            if (!exito)
            {
                throw new Exception($"Error al guardar cirugía: {mensajeError}");
            }

            return resultado;
        }

        #endregion

        #region Métodos para Nota Operatoria

        /// <summary>
        /// Obtiene cirugías para seleccionar en nota operatoria
        /// </summary>
        public DataTable ObtenerCirugiasParaNota()
        {
            string query = @"
                SELECT 
                    e.IdEvento,
                    CONCAT(p.Nombre, ' ', p.Apellido, ' - ', 
                           FORMAT(e.FechaInicio, 'dd/MM/yyyy HH:mm'), ' - ',
                           JSON_VALUE(e.DatosClinicosJson, '$.TipoCirugia')) AS Display,
                    e.Estado
                FROM App.EventoMedico e
                INNER JOIN App.Persona p ON e.IdPaciente = p.IdPersona
                WHERE e.TipoEvento = 'CIRUGIA'
                    AND e.Estado IN ('PROGRAMADO', 'EN_CURSO', 'FINALIZADO')
                ORDER BY e.FechaInicio DESC";

            return ConexionDB.Instancia.EjecutarConsulta(query);
        }

        /// <summary>
        /// Obtiene datos completos de una cirugía para la nota operatoria
        /// </summary>
        public CirugiaDetalleDTO ObtenerDetalleCirugia(int idEvento)
        {
            string query = @"
                SELECT 
                    e.IdEvento,
                    e.IdPaciente,
                    CONCAT(p.Nombre, ' ', p.Apellido) AS NombrePaciente,
                    e.IdResponsable,
                    e.FechaInicio,
                    e.FechaFin,
                    e.Estado,
                    e.DatosClinicosJson
                FROM App.EventoMedico e
                INNER JOIN App.Persona p ON e.IdPaciente = p.IdPersona
                WHERE e.IdEvento = @IdEvento AND e.TipoEvento = 'CIRUGIA'";

            SqlParameter[] parametros = { ConexionDB.Instancia.CrearParametro("@IdEvento", idEvento) };
            DataTable dt = ConexionDB.Instancia.EjecutarConsulta(query, parametros);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new CirugiaDetalleDTO
                {
                    IdEvento = Convert.ToInt32(row["IdEvento"]),
                    IdPaciente = Convert.ToInt32(row["IdPaciente"]),
                    NombrePaciente = row["NombrePaciente"].ToString(),
                    IdResponsable = row["IdResponsable"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdResponsable"]),
                    FechaInicio = Convert.ToDateTime(row["FechaInicio"]),
                    FechaFin = row["FechaFin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["FechaFin"]),
                    Estado = row["Estado"].ToString(),
                    DatosClinicosJson = row["DatosClinicosJson"] == DBNull.Value ? null : row["DatosClinicosJson"].ToString()
                };
            }
            return null;
        }

        /// <summary>
        /// Obtiene profesionales para la nota operatoria
        /// </summary>
        public DataTable ObtenerProfesionalesMedicos()
        {
            string query = @"
                SELECT 
                    IdPersona,
                    CONCAT(Nombre, ' ', Apellido, ' - ', TipoPersona) AS Display
                FROM App.Persona
                WHERE TipoPersona IN ('MEDICO', 'ENFERMERO') 
                    AND Estado = 'ACTIVO'
                ORDER BY TipoPersona, Apellido, Nombre";

            return ConexionDB.Instancia.EjecutarConsulta(query);
        }

        /// <summary>
        /// Guarda o actualiza la nota operatoria
        /// </summary>
        public bool GuardarNotaOperatoria(NotaOperatoriaDTO nota)
        {
            string mensajeError;

            bool exito = ConexionDB.Instancia.EjecutarTransaccion((conn, trans) =>
            {
                // Actualizar el evento de cirugía con los datos de la nota
                string query = @"
                    UPDATE App.EventoMedico
                    SET FechaInicio = @InicioReal,
                        FechaFin = @FinReal,
                        Estado = @Estado,
                        DatosClinicosJson = JSON_MODIFY(
                            ISNULL(DatosClinicosJson, '{}'),
                            '$.DiagnosticoPostoperatorio', @DiagPost
                        ),
                        DatosClinicosJson = JSON_MODIFY(
                            DatosClinicosJson,
                            '$.TecnicaOperatoria', @Tecnica
                        ),
                        DatosClinicosJson = JSON_MODIFY(
                            DatosClinicosJson,
                            '$.Hallazgos', @Hallazgos
                        ),
                        DatosClinicosJson = JSON_MODIFY(
                            DatosClinicosJson,
                            '$.Complicaciones', @Complicaciones
                        ),
                        DatosClinicosJson = JSON_MODIFY(
                            DatosClinicosJson,
                            '$.MaterialesUtilizados', @Materiales
                        )
                    WHERE IdEvento = @IdEvento";

                using (var cmd = new SqlCommand(query, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@IdEvento", nota.IdEvento);
                    cmd.Parameters.AddWithValue("@InicioReal", nota.InicioReal);
                    cmd.Parameters.AddWithValue("@FinReal", (object)nota.FinReal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", nota.EstadoNota == "Final" ? "FINALIZADO" : "EN_CURSO");
                    cmd.Parameters.AddWithValue("@DiagPost", nota.DiagnosticoPostoperatorio ?? "");
                    cmd.Parameters.AddWithValue("@Tecnica", nota.TecnicaOperatoria ?? "");
                    cmd.Parameters.AddWithValue("@Hallazgos", nota.Hallazgos ?? "");
                    cmd.Parameters.AddWithValue("@Complicaciones", nota.Complicaciones ?? "");
                    cmd.Parameters.AddWithValue("@Materiales", nota.MaterialesJson ?? "[]");

                    cmd.ExecuteNonQuery();
                }
            }, out mensajeError);

            if (!exito)
            {
                throw new Exception($"Error al guardar nota operatoria: {mensajeError}");
            }

            return exito;
        }

        #endregion
    }

    #region DTOs

    public class CirugiaDTO
    {
        public int IdEvento { get; set; }
        public int IdPaciente { get; set; }
        public int IdCirujano { get; set; }
        public string EquipoQuirurgico { get; set; }
        public string TipoCirugia { get; set; }
        public string DiagnosticoPreoperatorio { get; set; }
        public int? IdSala { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int DuracionMinutos { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public string GenerarJsonDatos()
        {
            return $@"{{
                ""TipoCirugia"": ""{TipoCirugia ?? ""}"",
                ""DiagnosticoPreoperatorio"": ""{DiagnosticoPreoperatorio ?? ""}"",
                ""Prioridad"": ""{Prioridad ?? "ELEC"}"",
                ""EquipoQuirurgico"": ""{EquipoQuirurgico ?? ""}"",
                ""DuracionEstimada"": {DuracionMinutos},
                ""Observaciones"": ""{Observaciones ?? ""}""
            }}";
        }
    }

    public class CirugiaDetalleDTO
    {
        public int IdEvento { get; set; }
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public int IdResponsable { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; }
        public string DatosClinicosJson { get; set; }
    }

    public class NotaOperatoriaDTO
    {
        public int IdEvento { get; set; }
        public DateTime InicioReal { get; set; }
        public DateTime? FinReal { get; set; }
        public string DiagnosticoPostoperatorio { get; set; }
        public string TecnicaOperatoria { get; set; }
        public string Hallazgos { get; set; }
        public string Complicaciones { get; set; }
        public string MaterialesJson { get; set; }
        public int IdProfesionalRegistra { get; set; }
        public string EstadoNota { get; set; }
    }

    #endregion
}