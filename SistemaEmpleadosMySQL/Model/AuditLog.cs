using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de Registro de Auditoría
    /// Task: T013 - Create AuditLog Model
    /// Registra todos los cambios en el sistema para compliance
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// ID único del registro de auditoría
        /// </summary>
        public int AuditId { get; set; }

        /// <summary>
        /// ID del usuario que realizó la operación
        /// Foreign Key a tabla Usuario
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nombre de la tabla afectada
        /// Ej: Paciente, Medico, Cita
        /// </summary>
        public string? Tabla { get; set; }

        /// <summary>
        /// ID del registro afectado en la tabla
        /// </summary>
        public int RegistroId { get; set; }

        /// <summary>
        /// Tipo de operación realizada
        /// Valores: INSERT, UPDATE, DELETE
        /// </summary>
        public string? Operacion { get; set; }

        /// <summary>
        /// Valores anteriores en formato JSON
        /// Se guarda para comparar cambios
        /// </summary>
        public string? ValoresAnteriores { get; set; }

        /// <summary>
        /// Valores nuevos en formato JSON
        /// Se guarda para auditoría
        /// </summary>
        public string? ValoresNuevos { get; set; }

        /// <summary>
        /// Dirección IP del usuario
        /// </summary>
        public string? DireccionIP { get; set; }

        /// <summary>
        /// User Agent del navegador/aplicación
        /// </summary>
        public string? UserAgent { get; set; }

        /// <summary>
        /// Fecha y hora de la operación
        /// </summary>
        public DateTime FechaOperacion { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public AuditLog()
        {
            FechaOperacion = DateTime.Now;
        }

        /// <summary>
        /// Crea un registro de auditoría para INSERT
        /// </summary>
        public static AuditLog CrearInsert(int userId, string tabla, int registroId, string valoresNuevos, string ip = "", string userAgent = "")
        {
            return new AuditLog
            {
                UserId = userId,
                Tabla = tabla,
                RegistroId = registroId,
                Operacion = "INSERT",
                ValoresAnteriores = "",
                ValoresNuevos = valoresNuevos,
                DireccionIP = ip,
                UserAgent = userAgent,
                FechaOperacion = DateTime.Now
            };
        }

        /// <summary>
        /// Crea un registro de auditoría para UPDATE
        /// </summary>
        public static AuditLog CrearUpdate(int userId, string tabla, int registroId, string valoresAnteriores, string valoresNuevos, string ip = "", string userAgent = "")
        {
            return new AuditLog
            {
                UserId = userId,
                Tabla = tabla,
                RegistroId = registroId,
                Operacion = "UPDATE",
                ValoresAnteriores = valoresAnteriores,
                ValoresNuevos = valoresNuevos,
                DireccionIP = ip,
                UserAgent = userAgent,
                FechaOperacion = DateTime.Now
            };
        }

        /// <summary>
        /// Crea un registro de auditoría para DELETE
        /// </summary>
        public static AuditLog CrearDelete(int userId, string tabla, int registroId, string valoresAnteriores, string ip = "", string userAgent = "")
        {
            return new AuditLog
            {
                UserId = userId,
                Tabla = tabla,
                RegistroId = registroId,
                Operacion = "DELETE",
                ValoresAnteriores = valoresAnteriores,
                ValoresNuevos = "",
                DireccionIP = ip,
                UserAgent = userAgent,
                FechaOperacion = DateTime.Now
            };
        }

        /// <summary>
        /// Obtiene descripción de la operación
        /// </summary>
        public string ObtenerDescripcionOperacion()
        {
            return Operacion switch
            {
                "INSERT" => "Creación",
                "UPDATE" => "Modificación",
                "DELETE" => "Eliminación",
                _ => "Desconocida"
            };
        }

        /// <summary>
        /// Valida que el registro de auditoría tenga datos válidos
        /// </summary>
        public bool EsValido()
        {
            return UserId > 0 &&
                   !string.IsNullOrWhiteSpace(Tabla) &&
                   RegistroId > 0 &&
                   !string.IsNullOrWhiteSpace(Operacion) &&
                   (Operacion == "INSERT" || Operacion == "UPDATE" || Operacion == "DELETE");
        }
    }
}
