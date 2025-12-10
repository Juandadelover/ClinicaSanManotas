using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de Especialidad Médica
    /// Task: T010 - Create Especialidad Model
    /// </summary>
    public class Especialidad
    {
        /// <summary>
        /// ID único de la especialidad
        /// </summary>
        public int EspecialidadId { get; set; }

        /// <summary>
        /// Nombre de la especialidad - ÚNICO
        /// Validación: Requerido, Min 3, Max 100
        /// Ejemplos: Cardiología, Dermatología, Medicina General
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Descripción de la especialidad
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Estado de la especialidad
        /// Valores: Activo, Inactivo
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Especialidad()
        {
            Estado = "Activo";
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Valida que la especialidad tenga datos válidos
        /// </summary>
        public bool EsValida()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   Nombre.Length >= 3 &&
                   Nombre.Length <= 100 &&
                   !string.IsNullOrWhiteSpace(Estado);
        }
    }
}
