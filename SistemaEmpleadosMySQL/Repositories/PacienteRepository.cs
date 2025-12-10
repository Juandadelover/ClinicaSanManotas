using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using SistemaEmpleadosMySQL.DAO;
using SistemaEmpleadosMySQL.Helpers;
using SistemaEmpleadosMySQL.Model;

namespace SistemaEmpleadosMySQL.Repositories
{
    /// <summary>
    /// Repositorio específico para Paciente
    /// Proporciona todas las operaciones CRUD para gestión de pacientes
    /// </summary>
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository() : base("Paciente") { }

        /// <summary>
        /// Obtiene todos los pacientes activos
        /// </summary>
        public override IEnumerable<Paciente> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Paciente WHERE Estado = 'Activo'";
                var reader = _db.ExecuteQuery(query);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug("GetAll Pacientes");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetAll de Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene pacientes con paginación
        /// </summary>
        public override IEnumerable<Paciente> GetAllPaged(int pageNumber, int pageSize)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = $@"SELECT * FROM Paciente 
                                 WHERE Estado = 'Activo'
                                 ORDER BY PacienteId
                                 LIMIT {pageSize} OFFSET {offset}";
                
                var reader = _db.ExecuteQuery(query);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug($"GetAllPaged Pacientes - Page: {pageNumber}, Size: {pageSize}");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error en GetAllPaged de Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un paciente por ID
        /// </summary>
        public override Paciente GetById(int id)
        {
            try
            {
                string query = "SELECT * FROM Paciente WHERE PacienteId = @id";
                var param = new MySqlParameter("@id", id);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var paciente = MapearPaciente(reader);
                    reader.Close();
                    LogHelper.Debug($"GetById Paciente - ID: {id}");
                    return paciente;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetById de Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Busca pacientes por nombre o apellido
        /// </summary>
        public IEnumerable<Paciente> BuscarPorNombre(string nombre, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    return GetAllPaged(pageNumber, pageSize);

                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Paciente 
                               WHERE Estado = 'Activo'
                               AND (Nombres LIKE @nombre OR Apellidos LIKE @nombre)
                               ORDER BY Nombres
                               LIMIT @pageSize OFFSET @offset";
                
                var param1 = new MySqlParameter("@nombre", "%" + nombre + "%");
                var param2 = new MySqlParameter("@pageSize", pageSize);
                var param3 = new MySqlParameter("@offset", offset);
                
                var reader = _db.ExecuteQuery(query, param1, param2, param3);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug($"BuscarPorNombre Paciente - Criterio: {nombre}");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en BuscarPorNombre de Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene pacientes por documento
        /// </summary>
        public Paciente GetByDocumento(string documento)
        {
            try
            {
                string query = "SELECT * FROM Paciente WHERE Documento = @documento";
                var param = new MySqlParameter("@documento", documento);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var paciente = MapearPaciente(reader);
                    reader.Close();
                    LogHelper.Debug($"ObtenerPorDocumento - Documento: {documento}");
                    return paciente;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en ObtenerPorDocumento", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene pacientes por EPS
        /// </summary>
        public IEnumerable<Paciente> BuscarPorEPS(int epsId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Paciente 
                               WHERE EPSId = @epsId AND Estado = 'Activo'
                               LIMIT @size OFFSET @offset";
                var parameters = new[]
                {
                    new MySqlParameter("@epsId", epsId),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };
                var reader = _db.ExecuteQuery(query, parameters);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug($"BuscarPorEPS - EPSId: {epsId}, Page: {pageNumber}");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en BuscarPorEPS", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene pacientes por género
        /// </summary>
        public IEnumerable<Paciente> ObtenerPorGenero(string genero)
        {
            try
            {
                string query = "SELECT * FROM Paciente WHERE Genero = @genero AND Estado = 'Activo'";
                var param = new MySqlParameter("@genero", genero);
                var reader = _db.ExecuteQuery(query, param);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug($"ObtenerPorGenero - Genero: {genero}");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en ObtenerPorGenero", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene pacientes dentro de un rango de edad
        /// </summary>
        public IEnumerable<Paciente> BuscarPorEdad(int edadMin, int edadMax, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string query = @"SELECT * FROM Paciente 
                               WHERE Estado = 'Activo'
                               AND (YEAR(CURDATE()) - YEAR(FechaNacimiento)) BETWEEN @edadMin AND @edadMax
                               LIMIT @size OFFSET @offset";
                
                var parameters = new[]
                {
                    new MySqlParameter("@edadMin", edadMin),
                    new MySqlParameter("@edadMax", edadMax),
                    new MySqlParameter("@size", pageSize),
                    new MySqlParameter("@offset", offset)
                };
                
                var reader = _db.ExecuteQuery(query, parameters);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug($"BuscarPorEdad - {edadMin}-{edadMax}, Page: {pageNumber}");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en BuscarPorEdad", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene pacientes por ciudad
        /// </summary>
        public IEnumerable<Paciente> ObtenerPorCiudad(string ciudad)
        {
            try
            {
                string query = "SELECT * FROM Paciente WHERE Ciudad = @ciudad AND Estado = 'Activo'";
                var param = new MySqlParameter("@ciudad", ciudad);
                var reader = _db.ExecuteQuery(query, param);
                var pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    pacientes.Add(MapearPaciente(reader));
                }
                reader.Close();

                LogHelper.Debug($"ObtenerPorCiudad - Ciudad: {ciudad}");
                return pacientes;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en ObtenerPorCiudad", ex);
                throw;
            }
        }

        /// <summary>
        /// Agrega un nuevo paciente
        /// </summary>
        public override void Add(Paciente entity)
        {
            try
            {
                if (!entity.EsValido())
                {
                    LogHelper.Warning("Paciente inválido para agregar");
                    throw new Exception("Paciente inválido");
                }

                string query = @"INSERT INTO Paciente 
                               (Nombres, Apellidos, Email, Telefono, FechaNacimiento, 
                                Genero, Documento, EPSId, Direccion, Ciudad, Estado)
                               VALUES 
                               (@nombres, @apellidos, @email, @telefono, @fechaNacimiento,
                                @genero, @documento, @epsId, @direccion, @ciudad, @estado)";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@nombres", entity.Nombres),
                    new MySqlParameter("@apellidos", entity.Apellidos),
                    new MySqlParameter("@email", entity.Email ?? ""),
                    new MySqlParameter("@telefono", entity.Telefono),
                    new MySqlParameter("@fechaNacimiento", entity.FechaNacimiento),
                    new MySqlParameter("@genero", entity.Genero),
                    new MySqlParameter("@documento", entity.Documento),
                    new MySqlParameter("@epsId", entity.EPSId),
                    new MySqlParameter("@direccion", entity.Direccion),
                    new MySqlParameter("@ciudad", entity.Ciudad),
                    new MySqlParameter("@estado", entity.Estado)
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Paciente agregado: {entity.Nombres} {entity.Apellidos}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al agregar Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un paciente existente
        /// </summary>
        public override void Update(Paciente entity)
        {
            try
            {
                if (!entity.EsValido())
                {
                    LogHelper.Warning("Paciente inválido para actualizar");
                    throw new Exception("Paciente inválido");
                }

                string query = @"UPDATE Paciente SET 
                               Nombres = @nombres,
                               Apellidos = @apellidos,
                               Email = @email,
                               Telefono = @telefono,
                               FechaNacimiento = @fechaNacimiento,
                               Genero = @genero,
                               Documento = @documento,
                               EPSId = @epsId,
                               Direccion = @direccion,
                               Ciudad = @ciudad,
                               Estado = @estado
                               WHERE PacienteId = @id";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@nombres", entity.Nombres),
                    new MySqlParameter("@apellidos", entity.Apellidos),
                    new MySqlParameter("@email", entity.Email ?? ""),
                    new MySqlParameter("@telefono", entity.Telefono),
                    new MySqlParameter("@fechaNacimiento", entity.FechaNacimiento),
                    new MySqlParameter("@genero", entity.Genero),
                    new MySqlParameter("@documento", entity.Documento),
                    new MySqlParameter("@epsId", entity.EPSId),
                    new MySqlParameter("@direccion", entity.Direccion),
                    new MySqlParameter("@ciudad", entity.Ciudad),
                    new MySqlParameter("@estado", entity.Estado),
                    new MySqlParameter("@id", entity.PacienteId)
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Paciente actualizado: {entity.Nombres} {entity.Apellidos}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al actualizar Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Elimina un paciente (soft delete - marca como inactivo)
        /// </summary>
        public override void Remove(Paciente entity)
        {
            try
            {
                string query = "UPDATE Paciente SET Estado = 'Inactivo' WHERE PacienteId = @id";
                var param = new MySqlParameter("@id", entity.PacienteId);
                _db.ExecuteNonQuery(query, param);
                LogHelper.Info($"Paciente eliminado (soft delete): {entity.Nombres}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al eliminar Paciente", ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene el total de pacientes activos
        /// </summary>
        public int ObtenerTotal()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Paciente WHERE Estado = 'Activo'";
                var result = _db.ExecuteScalar(query);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en ObtenerTotal", ex);
                throw;
            }
        }

        /// <summary>
        /// Mapea un MySqlDataReader a un objeto Paciente
        /// </summary>
        private Paciente MapearPaciente(MySqlDataReader reader)
        {
            return new Paciente
            {
                PacienteId = (int)reader["PacienteId"],
                Nombres = reader["Nombres"].ToString(),
                Apellidos = reader["Apellidos"].ToString(),
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                Telefono = reader["Telefono"].ToString(),
                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                Genero = reader["Genero"].ToString(),
                Documento = reader["Documento"].ToString(),
                EPSId = (int)reader["EPSId"],
                Direccion = reader["Direccion"].ToString(),
                Ciudad = reader["Ciudad"].ToString(),
                FechaRegistro = (DateTime)reader["FechaRegistro"],
                Estado = reader["Estado"].ToString()
            };
        }
    }
}
