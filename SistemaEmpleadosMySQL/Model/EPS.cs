using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de EPS (Empresa Promotora de Salud)
    /// Task: T011 - Create EPS Model
    /// </summary>
    public class EPS
    {
        /// <summary>
        /// ID único de la EPS
        /// </summary>
        public int EPSId { get; set; }

        /// <summary>
        /// Nombre de la EPS - ÚNICO
        /// Validación: Requerido, Min 3, Max 200
        /// Ejemplos: SURA, Axa Colpatria, Coomeva, Sanitas
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// NIT de la empresa - ÚNICO
        /// Validación: Requerido, sin puntos ni guiones
        /// </summary>
        public string? NIT { get; set; }

        /// <summary>
        /// Teléfono de contacto
        /// Formato: +57XXXXXXXXXX (opcional)
        /// </summary>
        public string? Telefono { get; set; }

        /// <summary>
        /// Email de contacto
        /// Validación: Formato válido (opcional)
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Persona de contacto principal
        /// </summary>
        public string? Contacto { get; set; }

        /// <summary>
        /// Fecha de registro en el sistema
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Estado de la EPS
        /// Valores: Activo, Inactivo
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public EPS()
        {
            Estado = "Activo";
            FechaRegistro = DateTime.Now;
        }

        /// <summary>
        /// Valida que la EPS tenga datos válidos
        /// </summary>
        public bool EsValida()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(NIT) &&
                   Nombre.Length >= 3 &&
                   Nombre.Length <= 200 &&
                   !string.IsNullOrWhiteSpace(Estado);
        }
    }
}
