using System;

namespace SistemaEmpleadosMySQL.Model
{
    public class AuditLog
    {
        public int AuditId { get; set; }
        public int UserId { get; set; }
        public string? Tabla { get; set; }
        public int RegistroId { get; set; }
        public string? Operacion { get; set; }
        public string? ValoresAnteriores { get; set; }
        public string? ValoresNuevos { get; set; }
        public string? DireccionIP { get; set; }
        public string? UserAgent { get; set; }
        public DateTime FechaOperacion { get; set; }

        public AuditLog()
        {
            FechaOperacion = DateTime.Now;
        }

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
