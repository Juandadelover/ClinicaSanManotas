using System;

namespace ClinicaSanManotas.Model
{
    public class Usuario
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaUltimoLogin { get; set; }

        public Usuario()
        {
            Estado = "Activo";
            FechaCreacion = DateTime.Now;
        }

        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(PasswordHash) &&
                   !string.IsNullOrWhiteSpace(Role) &&
                   Username.Length >= 4 &&
                   Username.Length <= 50;
        }

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
