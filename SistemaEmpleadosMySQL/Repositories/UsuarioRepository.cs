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
    /// Repositorio específico para Usuario
    /// Task: T017 - Implement Specific Repositories
    /// </summary>
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository() : base("Usuario") { }

        public override IEnumerable<Usuario> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE Estado = 'Activo'";
                var reader = _db.ExecuteQuery(query);
                var usuarios = new List<Usuario>();

                while (reader.Read())
                {
                    usuarios.Add(MapearUsuario(reader));
                }
                reader.Close();

                LogHelper.Debug("GetAll Usuarios");
                return usuarios;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetAll de Usuario", ex);
                throw;
            }
        }

        public override Usuario GetById(int id)
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE UserId = @id";
                var param = new MySqlParameter("@id", id);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var usuario = MapearUsuario(reader);
                    reader.Close();
                    LogHelper.Debug($"GetById Usuario - ID: {id}");
                    return usuario;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetById de Usuario", ex);
                throw;
            }
        }

        public Usuario GetByUsername(string username)
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE Username = @username AND Estado = 'Activo'";
                var param = new MySqlParameter("@username", username);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var usuario = MapearUsuario(reader);
                    reader.Close();
                    LogHelper.Debug($"GetByUsername - Username: {username}");
                    return usuario;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByUsername", ex);
                throw;
            }
        }

        public Usuario GetByEmail(string email)
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE Email = @email AND Estado = 'Activo'";
                var param = new MySqlParameter("@email", email);
                var reader = _db.ExecuteQuery(query, param);

                if (reader.Read())
                {
                    var usuario = MapearUsuario(reader);
                    reader.Close();
                    LogHelper.Debug($"GetByEmail - Email: {email}");
                    return usuario;
                }

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en GetByEmail", ex);
                throw;
            }
        }

        public bool VerificarCredenciales(string username, string password)
        {
            try
            {
                var usuario = GetByUsername(username);
                if (usuario == null)
                {
                    LogHelper.Warning($"Intento de login con usuario inexistente: {username}");
                    return false;
                }

                bool valido = SecurityHelper.VerificarContraseña(password, usuario.PasswordHash);
                LogHelper.LogAcceso(usuario.UserId, username, "LOGIN", valido);

                return valido;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en VerificarCredenciales", ex);
                throw;
            }
        }

        public void ActualizarUltimoLogin(int usuarioId)
        {
            try
            {
                string query = "UPDATE Usuario SET FechaUltimoLogin = NOW() WHERE UserId = @id";
                var param = new MySqlParameter("@id", usuarioId);
                _db.ExecuteNonQuery(query, param);

                LogHelper.Info($"Actualizado último login para Usuario ID: {usuarioId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al actualizar último login", ex);
                throw;
            }
        }

        public override void Add(Usuario entity)
        {
            try
            {
                // Validar
                if (!entity.EsValido())
                    throw new InvalidOperationException("Usuario no es válido");

                // Encriptar contraseña
                entity.PasswordHash = SecurityHelper.GenerarHashContraseña(entity.PasswordHash);

                string query = @"INSERT INTO Usuario (Username, Email, PasswordHash, Role, Estado, FechaCreacion)
                               VALUES (@username, @email, @hash, @role, @estado, @fecha)";

                var parameters = new[]
                {
                    new MySqlParameter("@username", entity.Username),
                    new MySqlParameter("@email", entity.Email),
                    new MySqlParameter("@hash", entity.PasswordHash),
                    new MySqlParameter("@role", entity.Role),
                    new MySqlParameter("@estado", entity.Estado),
                    new MySqlParameter("@fecha", DateTime.Now)
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Usuario creado: {entity.Username}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al agregar Usuario", ex);
                throw;
            }
        }

        public override void Update(Usuario entity)
        {
            try
            {
                string query = @"UPDATE Usuario SET Email = @email, Role = @role, Estado = @estado
                               WHERE UserId = @id";

                var parameters = new[]
                {
                    new MySqlParameter("@email", entity.Email),
                    new MySqlParameter("@role", entity.Role),
                    new MySqlParameter("@estado", entity.Estado),
                    new MySqlParameter("@id", entity.UserId)
                };

                _db.ExecuteNonQuery(query, parameters);
                LogHelper.Info($"Usuario actualizado: {entity.UserId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al actualizar Usuario", ex);
                throw;
            }
        }

        private Usuario MapearUsuario(MySqlDataReader reader)
        {
            return new Usuario
            {
                UserId = reader.GetInt32("UserId"),
                Username = reader.GetString("Username"),
                Email = reader.GetString("Email"),
                PasswordHash = reader.GetString("PasswordHash"),
                Role = reader.GetString("Role"),
                Estado = reader.GetString("Estado"),
                FechaCreacion = reader.GetDateTime("FechaCreacion"),
                FechaUltimoLogin = reader.IsDBNull(reader.GetOrdinal("FechaUltimoLogin")) ? 
                    (DateTime?)null : reader.GetDateTime("FechaUltimoLogin")
            };
        }
    }
}
