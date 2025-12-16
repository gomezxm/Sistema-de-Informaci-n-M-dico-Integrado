using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Borrador.DBRepository
{
    public class CitaRepository
    {
       

        // ===============================
        // AGREGAR CITA
        // ===============================
        public int AgregarCita(
            int idPaciente,
            int idMedico,
            int? idConsultorio,
            DateTime fecha,
            TimeSpan hora,
            string tipoCita,
            string motivo,
            string estado,
            string observaciones)
        {
            string sql = @"
            INSERT INTO CITAS
            (IdPaciente, IdMedico, IdConsultorio, Fecha, Hora, TipoCita, MotivoConsulta, EstadoCita, Observaciones)
            VALUES
            (@IdPaciente, @IdMedico, @IdConsultorio, @Fecha, @Hora, @TipoCita, @Motivo, @Estado, @Observaciones)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@IdPaciente", idPaciente),
                new SqlParameter("@IdMedico", idMedico),
                new SqlParameter("@IdConsultorio", (object)idConsultorio ?? DBNull.Value),
                new SqlParameter("@Fecha", fecha.Date),
                new SqlParameter("@Hora", hora),
                new SqlParameter("@TipoCita", tipoCita),
                new SqlParameter("@Motivo", motivo),
                new SqlParameter("@Estado", estado),
                new SqlParameter("@Observaciones", observaciones ?? (object)DBNull.Value)
            };

            return ConexionDB.Instancia.EjecutarComando(sql, parametros);
        }

        // ===============================
        // CAMBIAR ESTADO DE CITA
        // ===============================
        public int CambiarEstadoCita(int idCita, string nuevoEstado)
        {
            string sql = @"
            UPDATE CITAS
            SET EstadoCita = @Estado
            WHERE IdCita = @IdCita";

            SqlParameter[] parametros =
            {
                new SqlParameter("@Estado", nuevoEstado),
                new SqlParameter("@IdCita", idCita)
            };

            return ConexionDB.Instancia.EjecutarComando(sql, parametros);
        }

        // ===============================
        // ELIMINAR / CANCELAR CITA
        // ===============================
        public int CancelarCita(int idCita)
        {
            string sql = @"
            UPDATE CITAS
            SET EstadoCita = 'Cancelada'
            WHERE IdCita = @IdCita";

            SqlParameter[] parametros =
            {
                new SqlParameter("@IdCita", idCita)
            };

            return ConexionDB.Instancia.EjecutarComando(sql, parametros);
        }

        public DataTable ListarCitasFiltradas(
           int? idMedico,
           string especialidad,
           string estado,
           DateTime? fecha,  // ahora acepta null
           string vista)
        {
            string sql = @"
    SELECT 
        c.IdCita,
        p.Nombre + ' ' + p.Apellido AS Paciente,
        e.Nombre + ' ' + e.Apellido AS Medico,
        esp.NombreEspecialidad,
        co.NombreConsultorio,
        c.Fecha,
        c.Hora,
        c.TipoCita,
        c.EstadoCita,
        c.MotivoConsulta
    FROM CITAS c
    INNER JOIN PACIENTES p ON c.IdPaciente = p.IdPaciente
    INNER JOIN MEDICOS m ON c.IdMedico = m.IdMedico
    INNER JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado
    LEFT JOIN CAT_ESPECIALIDADES esp ON m.IdEspecialidad = esp.IdEspecialidad
    LEFT JOIN CAT_CONSULTORIOS co ON c.IdConsultorio = co.IdConsultorio
    WHERE
        (@IdMedico IS NULL OR m.IdMedico = @IdMedico)
    AND (@Especialidad IS NULL OR esp.NombreEspecialidad = @Especialidad)
    AND (@Estado IS NULL OR c.EstadoCita = @Estado)
    AND (@Fecha IS NULL OR c.Fecha = @Fecha)
    ORDER BY c.Fecha, c.Hora";

            SqlParameter[] parametros =
            {
        new SqlParameter("@IdMedico", (object)idMedico ?? DBNull.Value),
        new SqlParameter("@Especialidad", (object)especialidad ?? DBNull.Value),
        new SqlParameter("@Estado", (object)estado ?? DBNull.Value),
        new SqlParameter("@Fecha", fecha.HasValue ? (object)fecha.Value.Date : DBNull.Value)
    };

            return ConexionDB.Instancia.EjecutarConsulta(sql, parametros);
        }



        // ===============================
        // ACTUALIZAR CITA
        // ===============================
        public int ActualizarCita(int idCita, int idMedico, DateTime fecha, TimeSpan hora, string estado, string motivo)
{
    string sql = @"
        UPDATE CITAS
        SET 
            IdMedico = @IdMedico,
            Fecha = @Fecha,
            Hora = @Hora,
            EstadoCita = @Estado,
            MotivoConsulta = @Motivo
        WHERE IdCita = @IdCita";

    SqlParameter[] parametros =
    {
        new SqlParameter("@IdCita", idCita),
        new SqlParameter("@IdMedico", idMedico),
        new SqlParameter("@Fecha", fecha.Date),
        new SqlParameter("@Hora", hora),
        new SqlParameter("@Estado", estado),
        new SqlParameter("@Motivo", motivo)
    };

    return ConexionDB.Instancia.EjecutarComando(sql, parametros);
}

        public DataTable ListarTodasLasCitas()
        {
            string sql = @"
    SELECT 
        c.IdCita,
        p.Nombre + ' ' + p.Apellido AS Paciente,
        e.Nombre + ' ' + e.Apellido AS Medico,
        esp.NombreEspecialidad,
        co.NombreConsultorio,
        c.Fecha,
        c.Hora,
        c.TipoCita,
        c.EstadoCita,
        c.MotivoConsulta
    FROM CITAS c
    INNER JOIN PACIENTES p ON c.IdPaciente = p.IdPaciente
    INNER JOIN MEDICOS m ON c.IdMedico = m.IdMedico
    INNER JOIN EMPLEADOS e ON m.IdEmpleado = e.IdEmpleado
    LEFT JOIN CAT_ESPECIALIDADES esp ON m.IdEspecialidad = esp.IdEspecialidad
    LEFT JOIN CAT_CONSULTORIOS co ON c.IdConsultorio = co.IdConsultorio
    ORDER BY c.Fecha, c.Hora";

            return ConexionDB.Instancia.EjecutarConsulta(sql);
        }


    }
}

// Estudiantes: José Ortega y Jesús Rodríguez
