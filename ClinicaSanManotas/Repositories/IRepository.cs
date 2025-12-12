using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClinicaSanManotas.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllPaged(int pageNumber, int pageSize);
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
    }

    public interface IUsuarioRepository : IRepository<Model.Usuario>
    {
        Model.Usuario GetByUsername(string username);
        Model.Usuario GetByEmail(string email);
        bool VerificarCredenciales(string username, string password);
        void ActualizarUltimoLogin(int usuarioId);
    }

    public interface IPacienteRepository : IRepository<Model.Paciente>
    {
        Model.Paciente GetByDocumento(string documento);
        IEnumerable<Model.Paciente> BuscarPorNombre(string nombre, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Paciente> BuscarPorEPS(int epsId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Paciente> BuscarPorEdad(int edadMin, int edadMax, int pageNumber = 1, int pageSize = 10);
    }

    public interface IMedicoRepository : IRepository<Model.Medico>
    {
        Model.Medico GetByLicencia(string licencia);
        IEnumerable<Model.Medico> GetByEspecialidad(int especialidadId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Medico> GetDisponibles(DateTime fecha, string hora);
        bool EstaDisponible(int medicoId, DateTime fecha, string hora);
    }

    public interface ICitaRepository : IRepository<Model.Cita>
    {
        IEnumerable<Model.Cita> GetByPaciente(int pacienteId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Cita> GetByMedico(int medicoId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Cita> GetByFecha(DateTime fecha, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.Cita> GetByEstado(string estado, int pageNumber = 1, int pageSize = 10);
        int CountByMedicoAndFechaAndHora(int medicoId, DateTime fecha, string hora);
        IEnumerable<Model.Cita> GetProximas(int dias = 7);
    }

    public interface IEspecialidadRepository : IRepository<Model.Especialidad>
    {
        Model.Especialidad GetByNombre(string nombre);
    }

    public interface IEPSRepository : IRepository<Model.EPS>
    {
        Model.EPS GetByNombre(string nombre);
        Model.EPS GetByNIT(string nit);
    }

    public interface IAuditLogRepository : IRepository<Model.AuditLog>
    {
        IEnumerable<Model.AuditLog> GetByUsuario(int usuarioId, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.AuditLog> GetByTabla(string tabla, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.AuditLog> GetByOperacion(string operacion, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Model.AuditLog> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin, int pageNumber = 1, int pageSize = 10);
    }
}
