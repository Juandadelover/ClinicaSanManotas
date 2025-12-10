using System;

namespace SistemaEmpleadosMySQL.DTO
{
    /// <summary>
    /// DTO para crear/actualizar Usuario
    /// Task: T014 - Create DTOs
    /// </summary>
    public class UsuarioCreateUpdateDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }

    /// <summary>
    /// DTO de respuesta para Usuario (sin contraseña)
    /// </summary>
    public class UsuarioResponseDTO
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? NombreRol { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaUltimoLogin { get; set; }
    }

    /// <summary>
    /// DTO para login
    /// </summary>
    public class LoginDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de login
    /// </summary>
    public class LoginResponseDTO
    {
        public bool Exitoso { get; set; }
        public string? Mensaje { get; set; }
        public UsuarioResponseDTO? Usuario { get; set; }
    }

    /// <summary>
    /// DTO para cambiar contraseña
    /// </summary>
    public class ChangePasswordDTO
    {
        public int UserId { get; set; }
        public string? ContraseñaActual { get; set; }
        public string? ContraseñaNueva { get; set; }
        public string? ConfirmarContraseña { get; set; }
    }
}
