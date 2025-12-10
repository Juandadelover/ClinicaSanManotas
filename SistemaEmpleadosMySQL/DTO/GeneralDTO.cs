using System;

namespace SistemaEmpleadosMySQL.DTO
{
    /// <summary>
    /// DTO para Especialidad
    /// Task: T014 - Create DTOs
    /// </summary>
    public class EspecialidadDTO
    {
        public int EspecialidadId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }

    /// <summary>
    /// DTO para EPS
    /// </summary>
    public class EPSDTO
    {
        public int EPSId { get; set; }
        public string? Nombre { get; set; }
        public string? NIT { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Contacto { get; set; }
        public string? Estado { get; set; }
    }

    /// <summary>
    /// DTO genérico para respuesta de operaciones
    /// </summary>
    public class ResponseDTO<T>
    {
        public bool Exitoso { get; set; }
        public string? Mensaje { get; set; }
        public T? Data { get; set; }
        public List<string>? Errores { get; set; }

        public ResponseDTO()
        {
            Errores = new List<string>();
        }

        public ResponseDTO(bool exitoso, string mensaje, T? data = default)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
            Data = data;
            Errores = new List<string>();
        }

        public ResponseDTO(bool exitoso, string mensaje, T? data, List<string>? errores)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
            Data = data;
            Errores = errores ?? new List<string>();
        }
    }

    /// <summary>
    /// DTO para respuesta sin datos genéricos
    /// </summary>
    public class ResponseDTO
    {
        public bool Exitoso { get; set; }
        public string? Mensaje { get; set; }
        public List<string>? Errores { get; set; }

        public ResponseDTO()
        {
            Errores = new List<string>();
        }

        public ResponseDTO(bool exitoso, string mensaje)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
            Errores = new List<string>();
        }

        public ResponseDTO(bool exitoso, string mensaje, List<string> errores)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
            Errores = errores ?? new List<string>();
        }
    }
}
