using System;

namespace ClinicaSanManotas.DTO
{
    /// <summary>
    /// DTO para crear/actualizar Médico
    /// Task: T014 - Create DTOs
    /// </summary>
    public class MedicoCreateUpdateDTO
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Licencia { get; set; }
        public int EspecialidadId { get; set; }
        public string? HorarioInicio { get; set; }
        public string? HorarioFin { get; set; }
        public string? DiasAtencion { get; set; }
    }

    /// <summary>
    /// DTO de respuesta para Médico
    /// </summary>
    public class MedicoResponseDTO
    {
        public int MedicoId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Licencia { get; set; }
        public int EspecialidadId { get; set; }
        public string? Especialidad { get; set; }
        public string? HorarioInicio { get; set; }
        public string? HorarioFin { get; set; }
        public string? DiasAtencion { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    /// <summary>
    /// DTO para búsqueda de médicos disponibles
    /// </summary>
    public class MedicoSearchDTO
    {
        public int? EspecialidadId { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Hora { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    /// <summary>
    /// DTO para respuesta paginada de médicos
    /// </summary>
    public class PaginatedMedicoDTO
    {
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<MedicoResponseDTO>? Data { get; set; }
    }
}
