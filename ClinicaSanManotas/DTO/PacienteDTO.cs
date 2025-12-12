using System;

namespace ClinicaSanManotas.DTO
{
    /// <summary>
    /// DTO para crear/actualizar Paciente
    /// Task: T014 - Create DTOs
    /// </summary>
    public class PacienteCreateUpdateDTO
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? Documento { get; set; }
        public int EPSId { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
    }

    /// <summary>
    /// DTO de respuesta para Paciente
    /// </summary>
    public class PacienteResponseDTO
    {
        public int PacienteId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public int Edad { get; set; }
        public string? Genero { get; set; }
        public string? NombreGenero { get; set; }
        public string? Documento { get; set; }
        public int EPSId { get; set; }
        public string? NombreEPS { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    /// <summary>
    /// DTO para búsqueda de pacientes
    /// </summary>
    public class PacienteSearchDTO
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Documento { get; set; }
        public int? Edad { get; set; }
        public int? EPSId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    /// <summary>
    /// DTO para respuesta paginada de pacientes
    /// </summary>
    public class PaginatedPacienteDTO
    {
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<PacienteResponseDTO>? Data { get; set; }
    }
}
