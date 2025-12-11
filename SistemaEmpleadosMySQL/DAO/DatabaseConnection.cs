using System;
using MySql.Data.MySqlClient;
using SistemaEmpleadosMySQL.Helpers;

namespace SistemaEmpleadosMySQL.DAO
{
    public class DatabaseConnection
    {
        private static DatabaseConnection? _instance;
        private MySqlConnection? _connection;
        private readonly string _connectionString;
        private static readonly object lockObject = new object();

        private const string DEFAULT_CONNECTION_STRING = 
            "server=localhost; database=clinica_san_manotas; Uid=root; pwd=12345;";

        private DatabaseConnection(string connectionString = DEFAULT_CONNECTION_STRING)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection GetInstance(string connectionString = DEFAULT_CONNECTION_STRING)
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection(connectionString);
                    }
                }
            }
            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            if (_connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection.Open();
                    LogHelper.Info("Conexión a BD abierta exitosamente");
                }
                catch (MySqlException ex)
                {
                    LogHelper.Error("Error al conectar a la BD", ex);
                    throw;
                }
            }

            return _connection;
        }

        public bool EstaConectado()
        {
            try
            {
                if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                {
                    GetConnection();
                }
                return _connection?.State == System.Data.ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }

        public void CerrarConexion()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection.Close();
                    LogHelper.Info("Conexión a BD cerrada");
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Error al cerrar la conexión", ex);
                }
            }
        }

        public MySqlDataReader ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                var connection = GetConnection();
                var cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                LogHelper.Debug($"Ejecutando query: {query}");
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al ejecutar consulta", ex);
                throw;
            }
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            try
            {
                var connection = GetConnection();
                var cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                LogHelper.Debug($"Ejecutando scalar query: {query}");
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al ejecutar consulta escalar", ex);
                throw;
            }
        }

        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                var connection = GetConnection();
                var cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                LogHelper.Debug($"Ejecutando non-query: {query}");
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error al ejecutar non-query", ex);
                throw;
            }
        }

        public int ExecuteStoredProcedure(string nombreProcedimiento, params MySqlParameter[] parameters)
        {
            try
            {
                var connection = GetConnection();
                var cmd = new MySqlCommand(nombreProcedimiento, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                LogHelper.Debug($"Ejecutando stored procedure: {nombreProcedimiento}");
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al ejecutar procedimiento: {nombreProcedimiento}", ex);
                throw;
            }
        }

        ~DatabaseConnection()
        {
            CerrarConexion();
            _connection?.Dispose();
        }
    }
}
