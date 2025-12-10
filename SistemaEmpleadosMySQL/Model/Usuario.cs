using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de Usuario del sistema
    /// Task: T007 - Create Usuario Model
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// ID único del usuario
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nombre de usuario - Debe ser único
        /// Validación: Min 4 caracteres, Max 50
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Correo electrónico - Debe ser único
        /// Validación: Formato válido de email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Hash de contraseña - Almacenado con BCrypt
        /// NUNCA almacenar contraseña en texto plano
        /// </summary>
        public string? PasswordHash { get; set; }

        /// <summary>
        /// Rol del usuario
        /// Valores permitidos: Admin, Recepcionista, Doctor
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Estado del usuario
        /// Valores: Activo, Inactivo
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Fecha de creación de la cuenta
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Última fecha de login
        /// </summary>
        public DateTime? FechaUltimoLogin { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Usuario()
        {
            Estado = "Activo";
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Valida que el usuario tenga datos válidos
        /// </summary>
        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(PasswordHash) &&
                   !string.IsNullOrWhiteSpace(Role) &&
                   Username.Length >= 4 &&
                   Username.Length <= 50;
        }

        /// <summary>
        /// Obtiene el nombre completo del rol para display
        /// </summary>
        public string ObtenerNombreRol()
        {
            return Role switch
            {
                "Admin" => "Administrador",
                "Recepcionista" => "Recepcionista",
                "Doctor" => "Doctor",
                _ => "Desconocido"
            };
        }
    }
}
