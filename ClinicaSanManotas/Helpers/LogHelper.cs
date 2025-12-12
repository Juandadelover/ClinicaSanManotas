using System;
using System.IO;

namespace ClinicaSanManotas.Helpers
{
    /// <summary>
    /// Helper para logging y auditoría
    /// Task: T031 - Implement Logging and Audit Framework
    /// </summary>
    public class LogHelper
    {
        private static readonly string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly object lockObject = new object();

        static LogHelper()
        {
            // Crear carpeta de logs si no existe
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }
        }

        /// <summary>
        /// Niveles de log
        /// </summary>
        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error,
            Critical
        }

        /// <summary>
        /// Escribe un mensaje en el log
        /// </summary>
        public static void Log(string mensaje, LogLevel nivel = LogLevel.Info, Exception? excepcion = null)
        {
            try
            {
                lock (lockObject)
                {
                    string nombreArchivo = Path.Combine(logFolder, $"log-{DateTime.Now:yyyy-MM-dd}.txt");

                    using (var writer = new StreamWriter(nombreArchivo, true))
                    {
                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string linea = $"[{timestamp}] [{nivel}] {mensaje}";

                        if (excepcion != null)
                        {
                            linea += Environment.NewLine + $"Exception: {excepcion.Message}" +
                                   Environment.NewLine + $"StackTrace: {excepcion.StackTrace}";
                        }

                        writer.WriteLine(linea);
                        writer.WriteLine(new string('-', 80));
                    }
                }
            }
            catch
            {
                // Fallar silenciosamente para no afectar la aplicación
            }
        }

        /// <summary>
        /// Log de debug
        /// </summary>
        public static void Debug(string mensaje)
        {
            Log(mensaje, LogLevel.Debug);
        }

        /// <summary>
        /// Log de información
        /// </summary>
        public static void Info(string mensaje)
        {
            Log(mensaje, LogLevel.Info);
        }

        /// <summary>
        /// Log de advertencia
        /// </summary>
        public static void Warning(string mensaje)
        {
            Log(mensaje, LogLevel.Warning);
        }

        /// <summary>
        /// Log de error
        /// </summary>
        public static void Error(string mensaje, Exception? excepcion = null)
        {
            Log(mensaje, LogLevel.Error, excepcion);
        }

        /// <summary>
        /// Log crítico
        /// </summary>
        public static void Critical(string mensaje, Exception? excepcion = null)
        {
            Log(mensaje, LogLevel.Critical, excepcion);
        }

        /// <summary>
        /// Log de acceso del usuario
        /// </summary>
        public static void LogAcceso(int usuarioId, string username, string accion, bool exitoso)
        {
            string mensaje = $"Usuario: {username} (ID: {usuarioId}) - Acción: {accion} - Exitoso: {exitoso}";
            Info(mensaje);
        }

        /// <summary>
        /// Log de cambio de datos
        /// </summary>
        public static void LogCambio(int usuarioId, string tabla, int registroId, string operacion, string detalles = "")
        {
            string mensaje = $"Usuario ID: {usuarioId} - Tabla: {tabla} - Registro ID: {registroId} - Operación: {operacion}";
            if (!string.IsNullOrEmpty(detalles))
                mensaje += $" - Detalles: {detalles}";

            Info(mensaje);
        }
    }
}
