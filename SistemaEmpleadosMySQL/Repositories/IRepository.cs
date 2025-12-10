using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaEmpleadosMySQL.Repositories
{
    /// <summary>
    /// Interfaz genérica de Repositorio
    /// Task: T016 - Create Repository Interfaces
    /// Define el contrato para todas las operaciones de datos
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Obtiene entidades con paginación
        /// </summary>
        IEnumerable<T> GetAllPaged(int pageNumber, int pageSize);

        /// <summary>
        /// Obtiene una entidad por ID
        /// </summary>
        T GetById(int id);

        /// <summary>
        /// Busca entidades con predicado
        /// </summary>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Añade una nueva entidad
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Añade múltiples entidades
        /// </summary>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        void Remove(T entity);

        /// <summary>
        /// Elimina múltiples entidades
        /// </summary>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Obtiene el conteo total de entidades
        /// </summary>
        int Count();

        /// <summary>
        /// Obtiene el conteo con predicado
        /// </summary>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Verifica si existe una entidad
        /// </summary>
        bool Any(Expression<Func<T, bool>> predicate);
    }

    /// <summary>
    /// Interfaz específica para Usuario
    /// </summary>
    public interface IUsuarioRepository : IRepository<Model.Usuario>
    {
        Model.Usuario GetByUsername(string username);
        Model.Usuario GetByEmail(string email);
        bool VerificarCredenciales(string username, string password);
        void ActualizarUltimoLogin(int usuarioId);
    }

    /// <summary>
    /// Interfaz específica para Paciente
    /// </summary>
    public interface IPacienteRepository : IRepository<Model.Paciente>
    {
        Model.Paciente GetByDocumento(string documento);
        IEnumerable<Model.Paciente> BuscarPorNombre(string nombre, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Paciente> BuscarPorEPS(int epsId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Paciente> BuscarPorEdad(int edadMin, int edadMax, int pageNumber = 1, int pageSize = 10);
    }

    /// <summary>
    /// Interfaz específica para Medico
    /// </summary>
    public interface IMedicoRepository : IRepository<Model.Medico>
    {
        Model.Medico GetByLicencia(string licencia);
        IEnumerable<Model.Medico> GetByEspecialidad(int especialidadId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Medico> GetDisponibles(DateTime fecha, string hora);
        bool EstaDisponible(int medicoId, DateTime fecha, string hora);
    }

    /// <summary>
    /// Interfaz específica para Cita
    /// </summary>
    public interface ICitaRepository : IRepository<Model.Cita>
    {
        IEnumerable<Model.Cita> GetByPaciente(int pacienteId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Cita> GetByMedico(int medicoId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Cita> GetByFecha(DateTime fecha, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Cita> GetByEstado(string estado, int pageNumber = 1, int pageSize = 10);
        int CountByMedicoAndFechaAndHora(int medicoId, DateTime fecha, string hora);
        IEnumerable<Model.Cita> GetProximas(int dias = 7);
    }

    /// <summary>
    /// Interfaz específica para Especialidad
    /// </summary>
    public interface IEspecialidadRepository : IRepository<Model.Especialidad>
    {
        Model.Especialidad GetByNombre(string nombre);
    }

    /// <summary>
    /// Interfaz específica para EPS
    /// </summary>
    public interface IEPSRepository : IRepository<Model.EPS>
    {
        Model.EPS GetByNombre(string nombre);
        Model.EPS GetByNIT(string nit);
    }

    /// <summary>
    /// Interfaz específica para AuditLog
    /// </summary>
    public interface IAuditLogRepository : IRepository<Model.AuditLog>
    {
        IEnumerable<Model.AuditLog> GetByUsuario(int usuarioId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.AuditLog> GetByTabla(string tabla, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.AuditLog> GetByOperacion(string operacion, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.AuditLog> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin, int pageNumber = 1, int pageSize = 10);
    }
}
