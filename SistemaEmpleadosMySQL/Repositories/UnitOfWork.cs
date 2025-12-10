using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SistemaEmpleadosMySQL.DAO;
using SistemaEmpleadosMySQL.Helpers;
using SistemaEmpleadosMySQL.Model;

namespace SistemaEmpleadosMySQL.Repositories
{
    /// <summary>
    /// Unit of Work Pattern
    /// Task: T019 - Implement Unit of Work Pattern
    /// Gestiona transacciones y múltiples repositorios como una unidad
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IPacienteRepository Pacientes { get; }
        IMedicoRepository Medicos { get; }
        ICitaRepository Citas { get; }
        IEspecialidadRepository Especialidades { get; }
        IEPSRepository EPS { get; }
        IAuditLogRepository AuditLogs { get; }

        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }

    /// <summary>
    /// Implementación de Unit of Work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseConnection _db;
        private IUsuarioRepository _usuarioRepository;
        private IPacienteRepository _pacienteRepository;
        private IMedicoRepository _medicoRepository;
        private ICitaRepository _citaRepository;
        private IEspecialidadRepository _especialidadRepository;
        private IEPSRepository _epsRepository;
        private IAuditLogRepository _auditLogRepository;
        private MySqlTransaction _transaction;
        private bool _disposed = false;

        public UnitOfWork()
        {
            _db = DatabaseConnection.GetInstance();
        }

        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepository();
                }
                return _usuarioRepository;
            }
        }

        public IPacienteRepository Pacientes
        {
            get
            {
                if (_pacienteRepository == null)
                {
                    _pacienteRepository = new PacienteRepository();
                }
                return _pacienteRepository;
            }
        }

        public IMedicoRepository Medicos
        {
            get
            {
                if (_medicoRepository == null)
                {
                    _medicoRepository = new MedicoRepository();
                }
                return _medicoRepository;
            }
        }

        public ICitaRepository Citas
        {
            get
            {
                if (_citaRepository == null)
                {
                    _citaRepository = new CitaRepository();
                }
                return _citaRepository;
            }
        }

        public IEspecialidadRepository Especialidades
        {
            get
            {
                if (_especialidadRepository == null)
                {
                    _especialidadRepository = new EspecialidadRepository();
                }
                return _especialidadRepository;
            }
        }

        public IEPSRepository EPS
        {
            get
            {
                if (_epsRepository == null)
                {
                    _epsRepository = new EPSRepository();
                }
                return _epsRepository;
            }
        }

        public IAuditLogRepository AuditLogs
        {
            get
            {
                if (_auditLogRepository == null)
                {
                    _auditLogRepository = new AuditLogRepository();
                }
                return _auditLogRepository;
            }
        }

        public void BeginTransaction()
        {
            try
            {
                if (_db.EstaConectado())
                {
                    _transaction = _db.GetConnection().BeginTransaction();
                    LogHelper.Info("Transacción iniciada");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al iniciar transacción", ex);
                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                LogHelper.Info("SaveChanges ejecutado");
                return 1; // Número de registros afectados
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en SaveChanges", ex);
                throw;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _transaction = null;
                    LogHelper.Info("Transacción confirmada");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al confirmar transacción", ex);
                throw;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;
                    LogHelper.Warning("Transacción revertida");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al revertir transacción", ex);
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Rollback();
                        _transaction.Dispose();
                    }
                    _db.CerrarConexion();
                }
                _disposed = true;
                LogHelper.Info("UnitOfWork disposado");
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }

    /// <summary>
    /// Repositorio para Médico
    /// </summary>
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository() : base("Medico") { }

        public override IEnumerable<Medico> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Medico WHERE Estado = 'Activo' ORDER BY MedicoId";
                var reader = _db.ExecuteQuery(query);
                var medicos = new List<Medico>();

                while (reader.Read())
                {
                    medicos.Add(MapearMedico(reader));
                }
                reader.Close();

                return medicos;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetAll de Medico", ex);
                throw;
            }
        }

        public override IEnumerable<Medico> GetAllPaged(int pageNumber, int pageSize)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Medico 
                               WHERE Estado = 'Activo'
                               ORDER BY MedicoId
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var medicos = new List<Medico>();

                while (reader.Read())
                {
                    medicos.Add(MapearMedico(reader));
                }
                reader.Close();

                return medicos;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetAllPaged de Medico", ex);
                throw;
            }
        }

        public Medico GetByLicencia(string licencia)
        {
            try
            {
                string query = "SELECT * FROM Medico WHERE Licencia = @lic AND Estado = 'Activo'";
                var param = new MySqlParameter("@lic", licencia);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var medico = MapearMedico(reader);
                    reader.Close();
                    return medico;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByLicencia", ex);
                throw;
            }
        }

        public IEnumerable<Medico> GetByEspecialidad(int especialidadId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Medico 
                               WHERE EspecialidadId = @espId AND Estado = 'Activo'
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@espId", especialidadId),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var medicos = new List<Medico>();

                while (reader.Read())
                {
                    medicos.Add(MapearMedico(reader));
                }
                reader.Close();

                return medicos;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByEspecialidad", ex);
                throw;
            }
        }

        public IEnumerable<Medico> GetDisponibles(DateTime fecha, string hora)
        {
            try
            {
                string diaNombre = fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
                string query = @"SELECT * FROM Medico 
                               WHERE FIND_IN_SET(@dia, DiasAtencion) > 0 
                               AND Estado = 'Activo'";

                var param = new MySqlParameter("@dia", diaNombre);
                var reader = _db.ExecuteQuery(query, param);

                var medicos = new List<Medico>();
                while (reader.Read())
                {
                    var medico = MapearMedico(reader);
                    // Verificar si la hora está dentro del horario
                    if (HoraEstaDisponible(medico, hora))
                    {
                        medicos.Add(medico);
                    }
                }
                reader.Close();

                return medicos;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetDisponibles", ex);
                throw;
            }
        }

        public bool EstaDisponible(int medicoId, DateTime fecha, string hora)
        {
            try
            {
                var medico = GetById(medicoId);
                if (medico == null)
                    return false;

                // Verificar día
                string diaNombre = fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
                if (!medico.EstaDisponibleEnDia(diaNombre))
                    return false;

                // Verificar hora
                return HoraEstaDisponible(medico, hora);
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en EstaDisponible", ex);
                throw;
            }
        }

        private bool HoraEstaDisponible(Medico medico, string hora)
        {
            if (TimeSpan.TryParse(hora, out var horaActual) &&
                TimeSpan.TryParse(medico.HorarioInicio, out var inicio) &&
                TimeSpan.TryParse(medico.HorarioFin, out var fin))
            {
                return horaActual >= inicio && horaActual < fin;
            }
            return false;
        }

        public override Medico GetById(int id)
        {
            try
            {
                string query = "SELECT * FROM Medico WHERE MedicoId = @id";
                var param = new MySqlParameter("@id", id);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var medico = MapearMedico(reader);
                    reader.Close();
                    return medico;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetById de Medico", ex);
                throw;
            }
        }

        /// <summary>
        /// Agrega un nuevo médico
        /// </summary>
        public override void Add(Medico entity)
        {
            try
            {
                if (!entity.EsValido())
                {
                    LogHelper.Warning("Médico inválido para agregar");
                    throw new Exception("Datos del médico inválidos");
                }

                string query = @"INSERT INTO Medico 
                               (Nombres, Apellidos, Email, Telefono, Licencia, 
                                EspecialidadId, HorarioInicio, HorarioFin, DiasAtencion, Estado)
                               VALUES 
                               (@nombres, @apellidos, @email, @telefono, @licencia,
                                @especialidadId, @horarioInicio, @horarioFin, @diasAtencion, @estado)";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@nombres", entity.Nombres),
                    new MySqlParameter("@apellidos", entity.Apellidos),
                    new MySqlParameter("@email", entity.Email),
                    new MySqlParameter("@telefono", entity.Telefono ?? ""),
                    new MySqlParameter("@licencia", entity.Licencia),
                    new MySqlParameter("@especialidadId", entity.EspecialidadId),
                    new MySqlParameter("@horarioInicio", entity.HorarioInicio),
                    new MySqlParameter("@horarioFin", entity.HorarioFin),
                    new MySqlParameter("@diasAtencion", entity.DiasAtencion ?? "Lunes-Viernes"),
                    new MySqlParameter("@estado", entity.Estado ?? "Activo")
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Médico agregado: {entity.Nombres} {entity.Apellidos}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al agregar Médico", ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un médico existente
        /// </summary>
        public override void Update(Medico entity)
        {
            try
            {
                if (!entity.EsValido())
                {
                    LogHelper.Warning("Médico inválido para actualizar");
                    throw new Exception("Datos del médico inválidos");
                }

                string query = @"UPDATE Medico SET 
                               Nombres = @nombres,
                               Apellidos = @apellidos,
                               Email = @email,
                               Telefono = @telefono,
                               Licencia = @licencia,
                               EspecialidadId = @especialidadId,
                               HorarioInicio = @horarioInicio,
                               HorarioFin = @horarioFin,
                               DiasAtencion = @diasAtencion,
                               Estado = @estado
                               WHERE MedicoId = @id";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@nombres", entity.Nombres),
                    new MySqlParameter("@apellidos", entity.Apellidos),
                    new MySqlParameter("@email", entity.Email),
                    new MySqlParameter("@telefono", entity.Telefono ?? ""),
                    new MySqlParameter("@licencia", entity.Licencia),
                    new MySqlParameter("@especialidadId", entity.EspecialidadId),
                    new MySqlParameter("@horarioInicio", entity.HorarioInicio),
                    new MySqlParameter("@horarioFin", entity.HorarioFin),
                    new MySqlParameter("@diasAtencion", entity.DiasAtencion ?? "Lunes-Viernes"),
                    new MySqlParameter("@estado", entity.Estado ?? "Activo"),
                    new MySqlParameter("@id", entity.MedicoId)
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Médico actualizado: {entity.Nombres} {entity.Apellidos}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al actualizar Médico", ex);
                throw;
            }
        }

        /// <summary>
        /// Elimina un médico (soft delete - marca como inactivo)
        /// </summary>
        public override void Remove(Medico entity)
        {
            try
            {
                string query = "UPDATE Medico SET Estado = 'Inactivo' WHERE MedicoId = @id";
                var param = new MySqlParameter("@id", entity.MedicoId);
                _db.ExecuteNonQuery(query, param);
                LogHelper.Info($"Médico eliminado (soft delete): {entity.Nombres} {entity.Apellidos}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al eliminar Médico", ex);
                throw;
            }
        }

        private Medico MapearMedico(MySqlDataReader reader)
        {
            return new Medico
            {
                MedicoId = reader.GetInt32("MedicoId"),
                Nombres = reader.GetString("Nombres"),
                Apellidos = reader.GetString("Apellidos"),
                Email = reader.GetString("Email"),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString("Telefono"),
                Licencia = reader.GetString("Licencia"),
                EspecialidadId = reader.GetInt32("EspecialidadId"),
                HorarioInicio = reader.GetString("HorarioInicio"),
                HorarioFin = reader.GetString("HorarioFin"),
                DiasAtencion = reader.GetString("DiasAtencion"),
                FechaRegistro = reader.GetDateTime("FechaRegistro"),
                Estado = reader.GetString("Estado")
            };
        }
    }

    /// <summary>
    /// Repositorio para Cita
    /// </summary>
    public class CitaRepository : Repository<Cita>, ICitaRepository
    {
        public CitaRepository() : base("Cita") { }

        /// <summary>
        /// Obtiene todas las citas SIN filtrar por Estado (devuelve todas las citas)
        /// </summary>
        public override IEnumerable<Cita> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Cita ORDER BY Fecha DESC";
                LogHelper.Info($"CitaRepository.GetAll() ejecutando: {query}");
                
                var reader = _db.ExecuteQuery(query);
                var citas = new List<Cita>();

                int rowCount = 0;
                while (reader.Read())
                {
                    rowCount++;
                    var cita = MapearCita(reader);
                    citas.Add(cita);
                    LogHelper.Debug($"Cita {rowCount}: ID={cita.CitaId}, Paciente={cita.PacienteId}, Medico={cita.MedicoId}");
                }
                reader.Close();

                LogHelper.Info($"GetAll Citas completado - Total: {citas.Count} citas cargadas");
                return citas;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error en GetAll de Cita: {ex.Message} - Stack: {ex.StackTrace}", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene una cita por su ID
        /// </summary>
        public override Cita GetById(int id)
        {
            try
            {
                string query = "SELECT * FROM Cita WHERE CitaId = @id";
                var param = new MySqlParameter("@id", id);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var cita = MapearCita(reader);
                    reader.Close();
                    return cita;
                }
                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetById de Cita", ex);
                throw;
            }
        }

        /// <summary>
        /// Agrega una nueva cita
        /// </summary>
        public override void Add(Cita entity)
        {
            try
            {
                string query = @"INSERT INTO Cita (PacienteId, MedicoId, Fecha, Hora, Motivo, Estado, Notas, FechaCreacion, FechaActualizacion)
                                VALUES (@pacienteId, @medicoId, @fecha, @hora, @motivo, @estado, @notas, NOW(), NOW())";
                
                var parameters = new[]
                {
                    new MySqlParameter("@pacienteId", entity.PacienteId),
                    new MySqlParameter("@medicoId", entity.MedicoId),
                    new MySqlParameter("@fecha", entity.Fecha),
                    new MySqlParameter("@hora", entity.Hora ?? ""),
                    new MySqlParameter("@motivo", entity.Motivo ?? ""),
                    new MySqlParameter("@estado", entity.Estado ?? "Pendiente"),
                    new MySqlParameter("@notas", entity.Notas ?? "")
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Cita agregada - Paciente: {entity.PacienteId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en Add de Cita", ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        public override void Update(Cita entity)
        {
            try
            {
                string query = @"UPDATE Cita 
                                SET PacienteId = @pacienteId,
                                    MedicoId = @medicoId,
                                    Fecha = @fecha,
                                    Hora = @hora,
                                    Motivo = @motivo,
                                    Estado = @estado,
                                    Notas = @notas,
                                    FechaActualizacion = NOW()
                                WHERE CitaId = @id";
                
                var parameters = new[]
                {
                    new MySqlParameter("@id", entity.CitaId),
                    new MySqlParameter("@pacienteId", entity.PacienteId),
                    new MySqlParameter("@medicoId", entity.MedicoId),
                    new MySqlParameter("@fecha", entity.Fecha),
                    new MySqlParameter("@hora", entity.Hora ?? ""),
                    new MySqlParameter("@motivo", entity.Motivo ?? ""),
                    new MySqlParameter("@estado", entity.Estado ?? "Pendiente"),
                    new MySqlParameter("@notas", entity.Notas ?? "")
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Cita actualizada - ID: {entity.CitaId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en Update de Cita", ex);
                throw;
            }
        }

        /// <summary>
        /// Elimina una cita
        /// </summary>
        public override void Remove(Cita entity)
        {
            try
            {
                string query = "DELETE FROM Cita WHERE CitaId = @id";
                var param = new MySqlParameter("@id", entity.CitaId);

                _db.ExecuteNonQuery(query, param);
                LogHelper.Info($"Cita eliminada - ID: {entity.CitaId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en Remove de Cita", ex);
                throw;
            }
        }

        public IEnumerable<Cita> GetByPaciente(int pacienteId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Cita 
                               WHERE PacienteId = @pacId
                               ORDER BY Fecha DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@pacId", pacienteId),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var citas = new List<Cita>();

                while (reader.Read())
                {
                    citas.Add(MapearCita(reader));
                }
                reader.Close();

                return citas;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByPaciente", ex);
                throw;
            }
        }

        public IEnumerable<Cita> GetByMedico(int medicoId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Cita 
                               WHERE MedicoId = @medId
                               ORDER BY Fecha DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@medId", medicoId),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var citas = new List<Cita>();

                while (reader.Read())
                {
                    citas.Add(MapearCita(reader));
                }
                reader.Close();

                return citas;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByMedico", ex);
                throw;
            }
        }

        public IEnumerable<Cita> GetByFecha(DateTime fecha, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Cita 
                               WHERE DATE(Fecha) = @fecha
                               ORDER BY Hora
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@fecha", fecha.Date),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var citas = new List<Cita>();

                while (reader.Read())
                {
                    citas.Add(MapearCita(reader));
                }
                reader.Close();

                return citas;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByFecha", ex);
                throw;
            }
        }

        public IEnumerable<Cita> GetByEstado(string estado, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Cita 
                               WHERE Estado = @estado
                               ORDER BY Fecha DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@estado", estado),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var citas = new List<Cita>();

                while (reader.Read())
                {
                    citas.Add(MapearCita(reader));
                }
                reader.Close();

                return citas;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByEstado", ex);
                throw;
            }
        }

        public int CountByMedicoAndFechaAndHora(int medicoId, DateTime fecha, string hora)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM Cita 
                               WHERE MedicoId = @medId 
                               AND DATE(Fecha) = @fecha 
                               AND Hora = @hora 
                               AND Estado IN ('Pendiente', 'Confirmada')";

                var parameters = new[]
                {
                    new MySqlParameter("@medId", medicoId),
                    new MySqlParameter("@fecha", fecha.Date),
                    new MySqlParameter("@hora", hora)
                };

                var result = _db.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en CountByMedicoAndFechaAndHora", ex);
                throw;
            }
        }

        public IEnumerable<Cita> GetProximas(int dias = 7)
        {
            try
            {
                string query = @"SELECT * FROM Cita 
                               WHERE Fecha BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL @dias DAY)
                               AND Estado IN ('Pendiente', 'Confirmada')
                               ORDER BY Fecha, Hora";

                var param = new MySqlParameter("@dias", dias);
                var reader = _db.ExecuteQuery(query, param);

                var citas = new List<Cita>();
                while (reader.Read())
                {
                    citas.Add(MapearCita(reader));
                }
                reader.Close();

                return citas;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetProximas", ex);
                throw;
            }
        }

        private Cita MapearCita(MySqlDataReader reader)
        {
            return new Cita
            {
                CitaId = reader.GetInt32("CitaId"),
                PacienteId = reader.GetInt32("PacienteId"),
                MedicoId = reader.GetInt32("MedicoId"),
                Fecha = reader.GetDateTime("Fecha"),
                Hora = reader.GetString("Hora"),
                Motivo = reader.GetString("Motivo"),
                Estado = reader.GetString("Estado"),
                Notas = reader.IsDBNull(reader.GetOrdinal("Notas")) ? null : reader.GetString("Notas"),
                FechaCreacion = reader.GetDateTime("FechaCreacion"),
                FechaActualizacion = reader.GetDateTime("FechaActualizacion")
            };
        }
    }

    /// <summary>
    /// Repositorio para Especialidad
    /// </summary>
    public class EspecialidadRepository : Repository<Especialidad>, IEspecialidadRepository
    {
        public EspecialidadRepository() : base("Especialidad") { }

        public override IEnumerable<Especialidad> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Especialidad ORDER BY Nombre";
                var reader = _db.ExecuteQuery(query);
                var especialidades = new List<Especialidad>();

                while (reader.Read())
                {
                    especialidades.Add(MapearEspecialidad(reader));
                }
                reader.Close();

                return especialidades;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetAll de Especialidad", ex);
                throw;
            }
        }

        public override Especialidad GetById(int id)
        {
            try
            {
                string query = "SELECT * FROM Especialidad WHERE EspecialidadId = @id";
                var param = new MySqlParameter("@id", id);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var esp = MapearEspecialidad(reader);
                    reader.Close();
                    return esp;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetById de Especialidad", ex);
                throw;
            }
        }

        public Especialidad GetByNombre(string nombre)
        {
            try
            {
                string query = "SELECT * FROM Especialidad WHERE Nombre = @nom";
                var param = new MySqlParameter("@nom", nombre);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var esp = MapearEspecialidad(reader);
                    reader.Close();
                    return esp;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByNombre", ex);
                throw;
            }
        }

        private Especialidad MapearEspecialidad(MySqlDataReader reader)
        {
            return new Especialidad
            {
                EspecialidadId = reader.GetInt32("EspecialidadId"),
                Nombre = reader.GetString("Nombre"),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion")
            };
        }
    }

    /// <summary>
    /// Repositorio para EPS
    /// </summary>
    public class EPSRepository : Repository<EPS>, IEPSRepository
    {
        public EPSRepository() : base("EPS") { }

        public override IEnumerable<EPS> GetAll()
        {
            try
            {
                string query = "SELECT * FROM EPS WHERE Estado = 'Activa' ORDER BY Nombre";
                var reader = _db.ExecuteQuery(query);
                var listadoEPS = new List<EPS>();

                while (reader.Read())
                {
                    listadoEPS.Add(MapearEPS(reader));
                }
                reader.Close();

                return listadoEPS;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetAll de EPS", ex);
                throw;
            }
        }

        public EPS GetByNombre(string nombre)
        {
            try
            {
                string query = "SELECT * FROM EPS WHERE Nombre = @nom AND Estado = 'Activa'";
                var param = new MySqlParameter("@nom", nombre);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var eps = MapearEPS(reader);
                    reader.Close();
                    return eps;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByNombre de EPS", ex);
                throw;
            }
        }

        public EPS GetByNIT(string nit)
        {
            try
            {
                string query = "SELECT * FROM EPS WHERE NIT = @nit AND Estado = 'Activa'";
                var param = new MySqlParameter("@nit", nit);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var eps = MapearEPS(reader);
                    reader.Close();
                    return eps;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByNIT", ex);
                throw;
            }
        }

        private EPS MapearEPS(MySqlDataReader reader)
        {
            return new EPS
            {
                EPSId = reader.GetInt32("EPSId"),
                Nombre = reader.GetString("Nombre"),
                NIT = reader.GetString("NIT"),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString("Telefono"),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                Contacto = reader.IsDBNull(reader.GetOrdinal("Contacto")) ? null : reader.GetString("Contacto"),
                Estado = reader.GetString("Estado"),
                FechaRegistro = reader.GetDateTime("FechaRegistro")
            };
        }
    }

    /// <summary>
    /// Repositorio para AuditLog
    /// </summary>
    public class AuditLogRepository : Repository<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository() : base("AuditLog") { }

        public IEnumerable<AuditLog> GetByUsuario(int usuarioId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM AuditLog 
                               WHERE UserId = @userId
                               ORDER BY FechaOperacion DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@userId", usuarioId),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var logs = new List<AuditLog>();

                while (reader.Read())
                {
                    logs.Add(MapearAuditLog(reader));
                }
                reader.Close();

                return logs;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByUsuario", ex);
                throw;
            }
        }

        public IEnumerable<AuditLog> GetByTabla(string tabla, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM AuditLog 
                               WHERE Tabla = @tabla
                               ORDER BY FechaOperacion DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@tabla", tabla),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var logs = new List<AuditLog>();

                while (reader.Read())
                {
                    logs.Add(MapearAuditLog(reader));
                }
                reader.Close();

                return logs;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByTabla", ex);
                throw;
            }
        }

        public IEnumerable<AuditLog> GetByOperacion(string operacion, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM AuditLog 
                               WHERE Operacion = @op
                               ORDER BY FechaOperacion DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@op", operacion),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var logs = new List<AuditLog>();

                while (reader.Read())
                {
                    logs.Add(MapearAuditLog(reader));
                }
                reader.Close();

                return logs;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByOperacion", ex);
                throw;
            }
        }

        public IEnumerable<AuditLog> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM AuditLog 
                               WHERE FechaOperacion BETWEEN @inicio AND @fin
                               ORDER BY FechaOperacion DESC
                               LIMIT @size OFFSET @offset";

                var parameters = new[]
                {
                    new MySqlParameter("@inicio", fechaInicio),
                    new MySqlParameter("@fin", fechaFin),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };

                var reader = _db.ExecuteQuery(query, parameters);
                var logs = new List<AuditLog>();

                while (reader.Read())
                {
                    logs.Add(MapearAuditLog(reader));
                }
                reader.Close();

                return logs;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByFechaRango", ex);
                throw;
            }
        }

        private AuditLog MapearAuditLog(MySqlDataReader reader)
        {
            return new AuditLog
            {
                AuditId = reader.GetInt32("AuditId"),
                UserId = reader.GetInt32("UserId"),
                Tabla = reader.GetString("Tabla"),
                RegistroId = reader.GetInt32("RegistroId"),
                Operacion = reader.GetString("Operacion"),
                ValoresAnteriores = reader.IsDBNull(reader.GetOrdinal("ValoresAnteriores")) ? null : reader.GetString("ValoresAnteriores"),
                ValoresNuevos = reader.IsDBNull(reader.GetOrdinal("ValoresNuevos")) ? null : reader.GetString("ValoresNuevos"),
                DireccionIP = reader.IsDBNull(reader.GetOrdinal("DireccionIP")) ? null : reader.GetString("DireccionIP"),
                UserAgent = reader.IsDBNull(reader.GetOrdinal("UserAgent")) ? null : reader.GetString("UserAgent"),
                FechaOperacion = reader.GetDateTime("FechaOperacion")
            };
        }
    }
}
