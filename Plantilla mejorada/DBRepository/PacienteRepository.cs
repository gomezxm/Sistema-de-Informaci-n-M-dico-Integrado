using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Borrador.DBRepository
{
    // <summary>
    /// DTO para transferencia de datos de Paciente
    /// </summary>
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string AlergiasConocidas { get; set; }
        public string AntecedentesMedicos { get; set; }
        public int? IdSeguro { get; set; }
        public string NumeroPoliza { get; set; }
        public string EstadoPaciente { get; set; }
    }

    /// <summary>
    /// DTO para Contacto de Emergencia
    /// </summary>
    public class ContactoEmergenciaDTO
    {
        public int IdContacto { get; set; }
        public int IdPaciente { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
    }

    /// <summary>
    /// Repositorio para operaciones CRUD de Pacientes
    /// Implementa el patrón Repository para acceso a datos
    /// </summary>
    public class PacienteRepository
    {
        private readonly ConexionDB _conexion;

        public PacienteRepository()
        {
            _conexion = ConexionDB.Instancia;
        }

        #region Operaciones CRUD - Pacientes

        /// <summary>
        /// Lista todos los pacientes con información de seguro
        /// </summary>
        public DataTable ListarPacientes()
        {
            string query = @"
                SELECT 
                    p.IdPaciente,
                    p.Nombre,
                    p.Apellido,
                    p.Cedula,
                    CONVERT(VARCHAR(10), p.FechaNacimiento, 103) AS FechaNacimiento,
                    p.Sexo,
                    p.EstadoCivil,
                    p.Telefono,
                    p.Celular,
                    p.Email,
                    p.Direccion,
                    p.AlergiasConocidas,
                    p.AntecedentesMedicos,
                    p.IdSeguro,
                    s.NombreSeguro,
                    p.NumeroPoliza,
                    p.EstadoPaciente
                FROM PACIENTES p
                LEFT JOIN CAT_SEGUROS s ON p.IdSeguro = s.IdSeguro
                WHERE p.EstadoPaciente = 'Activo'
                ORDER BY p.Apellido, p.Nombre";

            return _conexion.EjecutarConsulta(query);
        }

        /// <summary>
        /// Busca pacientes por cédula o nombre
        /// </summary>
        public DataTable BuscarPacientes(string criterio)
        {
            string query = @"
                SELECT 
                    p.IdPaciente,
                    p.Nombre,
                    p.Apellido,
                    p.Cedula,
                    CONVERT(VARCHAR(10), p.FechaNacimiento, 103) AS FechaNacimiento,
                    p.Telefono,
                    p.Celular,
                    p.Email,
                    s.NombreSeguro,
                    p.EstadoPaciente
                FROM PACIENTES p
                LEFT JOIN CAT_SEGUROS s ON p.IdSeguro = s.IdSeguro
                WHERE (p.Cedula LIKE @Criterio 
                       OR p.Nombre LIKE @Criterio 
                       OR p.Apellido LIKE @Criterio
                       OR (p.Nombre + ' ' + p.Apellido) LIKE @Criterio)
                      AND p.EstadoPaciente = 'Activo'
                ORDER BY p.Apellido, p.Nombre";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@Criterio", "%" + criterio + "%")
            };

            return _conexion.EjecutarConsulta(query, parametros);
        }

        /// <summary>
        /// Obtiene un paciente por su ID
        /// </summary>
        public DataRow ObtenerPacientePorId(int idPaciente)
        {
            string query = @"
                SELECT 
                    p.*,
                    s.NombreSeguro
                FROM PACIENTES p
                LEFT JOIN CAT_SEGUROS s ON p.IdSeguro = s.IdSeguro
                WHERE p.IdPaciente = @IdPaciente";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", idPaciente)
            };

            DataTable dt = _conexion.EjecutarConsulta(query, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Obtiene un paciente por su cédula
        /// </summary>
        public DataRow ObtenerPacientePorCedula(string cedula)
        {
            string query = @"
                SELECT 
                    p.*,
                    s.NombreSeguro
                FROM PACIENTES p
                LEFT JOIN CAT_SEGUROS s ON p.IdSeguro = s.IdSeguro
                WHERE p.Cedula = @Cedula";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@Cedula", cedula)
            };

            DataTable dt = _conexion.EjecutarConsulta(query, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Verifica si una cédula ya existe (excluyendo un ID específico para edición)
        /// </summary>
        public bool CedulaExiste(string cedula, int? idPacienteExcluir = null)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM PACIENTES 
                WHERE Cedula = @Cedula 
                      AND (@IdExcluir IS NULL OR IdPaciente != @IdExcluir)";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@Cedula", cedula),
                _conexion.CrearParametro("@IdExcluir", idPacienteExcluir.HasValue ? (object)idPacienteExcluir.Value : DBNull.Value)
            };

            object resultado = _conexion.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        /// <summary>
        /// Inserta un nuevo paciente y retorna su ID
        /// </summary>
        public int InsertarPaciente(PacienteDTO paciente, ContactoEmergenciaDTO contacto = null)
        {
            string queryPaciente = @"
                INSERT INTO PACIENTES (
                    Nombre, Apellido, Cedula, FechaNacimiento, 
                    Sexo, EstadoCivil, Telefono, Celular, Email, 
                    Direccion, AlergiasConocidas, AntecedentesMedicos, 
                    IdSeguro, NumeroPoliza, EstadoPaciente, FechaRegistro
                )
                VALUES (
                    @Nombre, @Apellido, @Cedula, @FechaNacimiento,
                    @Sexo, @EstadoCivil, @Telefono, @Celular, @Email,
                    @Direccion, @Alergias, @Antecedentes,
                    @IdSeguro, @NumeroPoliza, @EstadoPaciente, GETDATE()
                )";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@Nombre", paciente.Nombre),
                _conexion.CrearParametro("@Apellido", paciente.Apellido),
                _conexion.CrearParametro("@Cedula", paciente.Cedula),
                _conexion.CrearParametro("@FechaNacimiento", paciente.FechaNacimiento),
                _conexion.CrearParametro("@Sexo", paciente.Sexo ?? "O"),
                _conexion.CrearParametro("@EstadoCivil", paciente.EstadoCivil ?? "Soltero/a"),
                _conexion.CrearParametro("@Telefono", paciente.Telefono),
                _conexion.CrearParametro("@Celular", paciente.Celular),
                _conexion.CrearParametro("@Email", paciente.Email),
                _conexion.CrearParametro("@Direccion", paciente.Direccion),
                _conexion.CrearParametro("@Alergias", paciente.AlergiasConocidas ?? string.Empty),
                _conexion.CrearParametro("@Antecedentes", paciente.AntecedentesMedicos ?? string.Empty),
                _conexion.CrearParametro("@IdSeguro", paciente.IdSeguro.HasValue ? (object)paciente.IdSeguro.Value : DBNull.Value),
                _conexion.CrearParametro("@NumeroPoliza", paciente.NumeroPoliza ?? string.Empty),
                _conexion.CrearParametro("@EstadoPaciente", paciente.EstadoPaciente ?? "Activo")
            };

            int idPaciente = _conexion.EjecutarComandoConRetorno(queryPaciente, parametros);

            // Insertar contacto de emergencia si existe
            if (contacto != null && !string.IsNullOrWhiteSpace(contacto.NombreContacto))
            {
                InsertarContactoEmergencia(idPaciente, contacto);
            }

            // Crear historia clínica automáticamente
            CrearHistoriaClinica(idPaciente);

            return idPaciente;
        }

        /// <summary>
        /// Actualiza los datos de un paciente existente
        /// </summary>
        public void ActualizarPaciente(PacienteDTO paciente, ContactoEmergenciaDTO contacto = null)
        {
            string query = @"
                UPDATE PACIENTES SET
                    Nombre = @Nombre,
                    Apellido = @Apellido,
                    Cedula = @Cedula,
                    FechaNacimiento = @FechaNacimiento,
                    Sexo = @Sexo,
                    EstadoCivil = @EstadoCivil,
                    Telefono = @Telefono,
                    Celular = @Celular,
                    Email = @Email,
                    Direccion = @Direccion,
                    AlergiasConocidas = @Alergias,
                    AntecedentesMedicos = @Antecedentes,
                    IdSeguro = @IdSeguro,
                    NumeroPoliza = @NumeroPoliza,
                    EstadoPaciente = @EstadoPaciente
                WHERE IdPaciente = @IdPaciente";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", paciente.IdPaciente),
                _conexion.CrearParametro("@Nombre", paciente.Nombre),
                _conexion.CrearParametro("@Apellido", paciente.Apellido),
                _conexion.CrearParametro("@Cedula", paciente.Cedula),
                _conexion.CrearParametro("@FechaNacimiento", paciente.FechaNacimiento),
                _conexion.CrearParametro("@Sexo", paciente.Sexo ?? "O"),
                _conexion.CrearParametro("@EstadoCivil", paciente.EstadoCivil ?? "Soltero/a"),
                _conexion.CrearParametro("@Telefono", paciente.Telefono),
                _conexion.CrearParametro("@Celular", paciente.Celular),
                _conexion.CrearParametro("@Email", paciente.Email),
                _conexion.CrearParametro("@Direccion", paciente.Direccion),
                _conexion.CrearParametro("@Alergias", paciente.AlergiasConocidas ?? string.Empty),
                _conexion.CrearParametro("@Antecedentes", paciente.AntecedentesMedicos ?? string.Empty),
                _conexion.CrearParametro("@IdSeguro", paciente.IdSeguro.HasValue ? (object)paciente.IdSeguro.Value : DBNull.Value),
                _conexion.CrearParametro("@NumeroPoliza", paciente.NumeroPoliza ?? string.Empty),
                _conexion.CrearParametro("@EstadoPaciente", paciente.EstadoPaciente ?? "Activo")
            };

            _conexion.EjecutarComando(query, parametros);

            // Actualizar contacto de emergencia
            if (contacto != null && !string.IsNullOrWhiteSpace(contacto.NombreContacto))
            {
                ActualizarContactoEmergencia(paciente.IdPaciente, contacto);
            }
        }

        /// <summary>
        /// Elimina un paciente (eliminación lógica)
        /// </summary>
        public void EliminarPaciente(int idPaciente)
        {
            string query = @"
                UPDATE PACIENTES 
                SET EstadoPaciente = 'Inactivo'
                WHERE IdPaciente = @IdPaciente";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", idPaciente)
            };

            _conexion.EjecutarComando(query, parametros);
        }

        /// <summary>
        /// Elimina físicamente un paciente (usar con precaución)
        /// </summary>
        public void EliminarPacienteFisico(int idPaciente)
        {
            string mensajeError;
            bool resultado = _conexion.EjecutarTransaccion((conexion, transaccion) =>
            {
                // Eliminar contactos de emergencia
                string queryContactos = "DELETE FROM CONTACTOS_EMERGENCIA WHERE IdPaciente = @IdPaciente";
                using (SqlCommand cmd = new SqlCommand(queryContactos, conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                    cmd.ExecuteNonQuery();
                }

                // Eliminar historia clínica y registros relacionados se manejarán con CASCADE
                // O se pueden eliminar explícitamente aquí si no hay CASCADE configurado

                // Eliminar paciente
                string queryPaciente = "DELETE FROM PACIENTES WHERE IdPaciente = @IdPaciente";
                using (SqlCommand cmd = new SqlCommand(queryPaciente, conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                    cmd.ExecuteNonQuery();
                }
            }, out mensajeError);

            if (!resultado)
            {
                throw new Exception(mensajeError);
            }
        }

        #endregion

        #region Operaciones de Contacto de Emergencia

        /// <summary>
        /// Obtiene los contactos de emergencia de un paciente
        /// </summary>
        public DataTable ObtenerContactosEmergencia(int idPaciente)
        {
            string query = @"
                SELECT * 
                FROM CONTACTOS_EMERGENCIA 
                WHERE IdPaciente = @IdPaciente";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", idPaciente)
            };

            return _conexion.EjecutarConsulta(query, parametros);
        }

        /// <summary>
        /// Inserta un contacto de emergencia
        /// </summary>
        private void InsertarContactoEmergencia(int idPaciente, ContactoEmergenciaDTO contacto)
        {
            string query = @"
                INSERT INTO CONTACTOS_EMERGENCIA (IdPaciente, NombreContacto, TelefonoContacto)
                VALUES (@IdPaciente, @NombreContacto, @TelefonoContacto)";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", idPaciente),
                _conexion.CrearParametro("@NombreContacto", contacto.NombreContacto),
                _conexion.CrearParametro("@TelefonoContacto", contacto.TelefonoContacto ?? string.Empty)
            };

            _conexion.EjecutarComando(query, parametros);
        }

        /// <summary>
        /// Actualiza o inserta el contacto de emergencia
        /// </summary>
        private void ActualizarContactoEmergencia(int idPaciente, ContactoEmergenciaDTO contacto)
        {
            // Verificar si ya existe un contacto
            string queryVerificar = "SELECT COUNT(*) FROM CONTACTOS_EMERGENCIA WHERE IdPaciente = @IdPaciente";
            SqlParameter[] paramVerificar = { _conexion.CrearParametro("@IdPaciente", idPaciente) };

            int existe = Convert.ToInt32(_conexion.EjecutarEscalar(queryVerificar, paramVerificar));

            if (existe > 0)
            {
                // Actualizar
                string query = @"
                    UPDATE CONTACTOS_EMERGENCIA 
                    SET NombreContacto = @NombreContacto,
                        TelefonoContacto = @TelefonoContacto
                    WHERE IdPaciente = @IdPaciente";

                SqlParameter[] parametros = {
                    _conexion.CrearParametro("@IdPaciente", idPaciente),
                    _conexion.CrearParametro("@NombreContacto", contacto.NombreContacto),
                    _conexion.CrearParametro("@TelefonoContacto", contacto.TelefonoContacto ?? string.Empty)
                };

                _conexion.EjecutarComando(query, parametros);
            }
            else
            {
                // Insertar
                InsertarContactoEmergencia(idPaciente, contacto);
            }
        }

        #endregion

        #region Operaciones de Historia Clínica

        /// <summary>
        /// Crea la historia clínica inicial de un paciente
        /// </summary>
        private void CrearHistoriaClinica(int idPaciente)
        {
            string query = @"
                INSERT INTO HISTORIAS_CLINICAS (IdPaciente, NroHistoriaClinica, ResumenAntecedentes, FechaCreacion)
                VALUES (@IdPaciente, @NroHistoria, '', GETDATE())";

            string nroHistoria = "HC-" + idPaciente.ToString("D6");

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", idPaciente),
                _conexion.CrearParametro("@NroHistoria", nroHistoria)
            };

            _conexion.EjecutarComando(query, parametros);
        }

        /// <summary>
        /// Obtiene la historia clínica de un paciente
        /// </summary>
        public DataRow ObtenerHistoriaClinica(int idPaciente)
        {
            string query = @"
                SELECT * 
                FROM HISTORIAS_CLINICAS 
                WHERE IdPaciente = @IdPaciente";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@IdPaciente", idPaciente)
            };

            DataTable dt = _conexion.EjecutarConsulta(query, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        #endregion

        #region Operaciones de Seguros

        /// <summary>
        /// Lista todos los seguros disponibles
        /// </summary>
        public DataTable ListarSeguros()
        {
            string query = "SELECT * FROM CAT_SEGUROS ORDER BY NombreSeguro";
            return _conexion.EjecutarConsulta(query);
        }

        /// <summary>
        /// Busca un seguro por nombre exacto
        /// </summary>
        public int? BuscarSeguroPorNombre(string nombreSeguro)
        {
            string query = "SELECT IdSeguro FROM CAT_SEGUROS WHERE NombreSeguro = @NombreSeguro";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@NombreSeguro", nombreSeguro)
            };

            object resultado = _conexion.EjecutarEscalar(query, parametros);
            return resultado != null ? (int?)Convert.ToInt32(resultado) : null;
        }

        /// <summary>
        /// Crea un seguro si no existe y retorna su ID
        /// </summary>
        public int CrearSeguroSiNoExiste(string nombreSeguro)
        {
            // Primero intentar buscar
            int? idExistente = BuscarSeguroPorNombre(nombreSeguro);
            if (idExistente.HasValue)
            {
                return idExistente.Value;
            }

            // Si no existe, crear
            string query = "INSERT INTO CAT_SEGUROS (NombreSeguro) VALUES (@NombreSeguro)";
            SqlParameter[] parametros = {
                _conexion.CrearParametro("@NombreSeguro", nombreSeguro)
            };

            return _conexion.EjecutarComandoConRetorno(query, parametros);
        }

        #endregion

        #region Estadísticas y Reportes

        /// <summary>
        /// Obtiene el total de pacientes activos
        /// </summary>
        public int ObtenerTotalPacientesActivos()
        {
            string query = "SELECT COUNT(*) FROM PACIENTES WHERE EstadoPaciente = 'Activo'";
            object resultado = _conexion.EjecutarEscalar(query);
            return Convert.ToInt32(resultado);
        }

        /// <summary>
        /// Obtiene estadísticas generales de pacientes
        /// </summary>
        public DataTable ObtenerEstadisticasPacientes()
        {
            string query = @"
                SELECT 
                    COUNT(*) AS TotalPacientes,
                    SUM(CASE WHEN Sexo = 'M' THEN 1 ELSE 0 END) AS Masculinos,
                    SUM(CASE WHEN Sexo = 'F' THEN 1 ELSE 0 END) AS Femeninos,
                    SUM(CASE WHEN IdSeguro IS NOT NULL THEN 1 ELSE 0 END) AS ConSeguro,
                    SUM(CASE WHEN IdSeguro IS NULL THEN 1 ELSE 0 END) AS SinSeguro
                FROM PACIENTES
                WHERE EstadoPaciente = 'Activo'";

            return _conexion.EjecutarConsulta(query);
        }

        /// <summary>
        /// Obtiene pacientes por rango de edad
        /// </summary>
        public DataTable ObtenerPacientesPorEdad(int edadMinima, int edadMaxima)
        {
            string query = @"
                SELECT 
                    IdPaciente,
                    Nombre,
                    Apellido,
                    Cedula,
                    FechaNacimiento,
                    DATEDIFF(YEAR, FechaNacimiento, GETDATE()) AS Edad
                FROM PACIENTES
                WHERE EstadoPaciente = 'Activo'
                      AND DATEDIFF(YEAR, FechaNacimiento, GETDATE()) BETWEEN @EdadMin AND @EdadMax
                ORDER BY FechaNacimiento DESC";

            SqlParameter[] parametros = {
                _conexion.CrearParametro("@EdadMin", edadMinima),
                _conexion.CrearParametro("@EdadMax", edadMaxima)
            };

            return _conexion.EjecutarConsulta(query, parametros);
        }

        #endregion
    }
}
