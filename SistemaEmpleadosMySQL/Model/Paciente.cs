using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de Paciente
    /// Task: T008 - Create Paciente Model
    /// </summary>
    public class Paciente
    {
        /// <summary>
        /// ID único del paciente
        /// </summary>
        public int PacienteId { get; set; }

        /// <summary>
        /// Nombres del paciente
        /// Validación: Requerido, Min 2, Max 100
        /// </summary>
        public string? Nombres { get; set; }

        /// <summary>
        /// Apellidos del paciente
        /// Validación: Requerido, Min 2, Max 100
        /// </summary>
        public string? Apellidos { get; set; }

        /// <summary>
        /// Email del paciente
        /// Validación: Formato válido, puede ser nulo
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Número de teléfono
        /// Formato: +57XXXXXXXXXX (opcional)
        /// </summary>
        public string? Telefono { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// Validación: Edad entre 0 y 150 años
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Género del paciente
        /// Valores: M (Masculino), F (Femenino), O (Otro)
        /// </summary>
        public string? Genero { get; set; }

        /// <summary>
        /// Número de documento de identidad - ÚNICO
        /// Validación: Documento sin espacios, 5-20 caracteres
        /// </summary>
        public string? Documento { get; set; }

        /// <summary>
        /// ID de la EPS (Empresa Promotora de Salud)
        /// Foreign Key a tabla EPS
        /// </summary>
        public int EPSId { get; set; }

        /// <summary>
        /// Dirección del paciente
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Ciudad de residencia
        /// </summary>
        public string? Ciudad { get; set; }

        /// <summary>
        /// Estado del paciente
        /// Valores: Activo, Inactivo
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Fecha de registro en el sistema
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Paciente()
        {
            Estado = "Activo";
            FechaRegistro = DateTime.Now;
            Genero = "M";
        }

        /// <summary>
        /// Calcula la edad del paciente
        /// </summary>
        public int ObtenerEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }

        /// <summary>
        /// Obtiene nombre completo
        /// </summary>
        public string ObtenerNombreCompleto()
        {
            return $"{Nombres} {Apellidos}".Trim();
        }

        /// <summary>
        /// Valida que el paciente tenga datos válidos
        /// </summary>
        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombres) &&
                   !string.IsNullOrWhiteSpace(Apellidos) &&
                   !string.IsNullOrWhiteSpace(Documento) &&
                   !string.IsNullOrWhiteSpace(Genero) &&
                   Nombres.Length >= 2 &&
                   Apellidos.Length >= 2 &&
                   ObtenerEdad() >= 0 &&
                   ObtenerEdad() <= 150 &&
                   EPSId > 0;
        }

        /// <summary>
        /// Obtiene descripción del género
        /// </summary>
        public string ObtenerNombreGenero()
        {
            return Genero switch
            {
                "M" => "Masculino",
                "F" => "Femenino",
                "O" => "Otro",
                _ => "Desconocido"
            };
        }
    }
}
