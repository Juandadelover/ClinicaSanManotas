using System;

namespace SistemaEmpleadosMySQL.DTO
{
    /// <summary>
    /// DTO para crear/actualizar Cita
    /// Task: T014 - Create DTOs
    /// </summary>
    public class CitaCreateUpdateDTO
    {
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Motivo { get; set; }
        public string? Notas { get; set; }
    }

    /// <summary>
    /// DTO de respuesta para Cita
    /// </summary>
    public class CitaResponseDTO
    {
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public string? NombrePaciente { get; set; }
        public int MedicoId { get; set; }
        public string? NombreMedico { get; set; }
        public string? Especialidad { get; set; }
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Motivo { get; set; }
        public string? Estado { get; set; }
        public string? EstadoDisplay { get; set; }
        public string? Notas { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    /// <summary>
    /// DTO para búsqueda de citas
    /// </summary>
    public class CitaSearchDTO
    {
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Estado { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    /// <summary>
    /// DTO para respuesta paginada de citas
    /// </summary>
    public class PaginatedCitaDTO
    {
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<CitaResponseDTO>? Data { get; set; }
    }

    /// <summary>
    /// DTO para cambiar estado de cita
    /// </summary>
    public class CitaChangeStateDTO
    {
        public int CitaId { get; set; }
        public string? NuevoEstado { get; set; }
        public string? Razon { get; set; }
    }
}
