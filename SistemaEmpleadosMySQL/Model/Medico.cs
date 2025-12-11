using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de Médico
    /// Task: T009 - Create Medico Model
    /// </summary>
    public class Medico
    {
        /// <summary>
        /// ID único del médico
        /// </summary>
        public int MedicoId { get; set; }

        /// <summary>
        /// Nombres del médico
        /// Validación: Requerido, Min 2, Max 100
        /// </summary>
        public string? Nombres { get; set; }

        /// <summary>
        /// Apellidos del médico
        /// Validación: Requerido, Min 2, Max 100
        /// </summary>
        public string? Apellidos { get; set; }

        /// <summary>
        /// Email profesional - ÚNICO
        /// Validación: Formato válido
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono de contacto
        /// Formato: +57XXXXXXXXXX
        /// </summary>
        public string? Telefono { get; set; }

        /// <summary>
        /// Número de licencia profesional - ÚNICO
        /// Validación: Requerido, sin espacios
        /// </summary>
        public string? Licencia { get; set; }

        /// <summary>
        /// ID de Especialidad (Cardiología, Dermatología, etc)
        /// Foreign Key a tabla Especialidad
        /// </summary>
        public int EspecialidadId { get; set; }

        /// <summary>
        /// Hora de inicio de horario de atención
        /// Formato: HH:mm (ej: 08:00)
        /// </summary>
        public string? HorarioInicio { get; set; }

        /// <summary>
        /// Hora de fin de horario de atención
        /// Formato: HH:mm (ej: 17:00)
        /// Validación: HorarioFin > HorarioInicio
        /// </summary>
        public string? HorarioFin { get; set; }

        /// <summary>
        /// Días de atención
        /// Formato: Lun-Vie (separados por comas)
        /// Ej: "Lunes,Martes,Miércoles,Jueves,Viernes"
        /// </summary>
        public string? DiasAtencion { get; set; }

        /// <summary>
        /// Fecha de registro en el sistema
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Estado del médico
        /// Valores: Activo, Inactivo
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Medico()
        {
            Estado = "Activo";
            FechaRegistro = DateTime.Now;
            DiasAtencion = "Lunes,Martes,Miércoles,Jueves,Viernes";
        }

        /// <summary>
        /// Obtiene nombre completo
        /// </summary>
        public string ObtenerNombreCompleto()
        {
            return $"{Nombres} {Apellidos}".Trim();
        }

        /// <summary>
        /// Valida que el médico tenga datos válidos
        /// </summary>
        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombres) &&
                   !string.IsNullOrWhiteSpace(Apellidos) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Licencia) &&
                   !string.IsNullOrWhiteSpace(HorarioInicio) &&
                   !string.IsNullOrWhiteSpace(HorarioFin) &&
                   Nombres.Length >= 2 &&
                   Apellidos.Length >= 2 &&
                   EspecialidadId > 0 &&
                   CompararHorarios();
        }

        /// <summary>
        /// Valida que HorarioFin > HorarioInicio
        /// </summary>
        private bool CompararHorarios()
        {
            if (TimeSpan.TryParse(HorarioInicio, out var inicio) &&
                TimeSpan.TryParse(HorarioFin, out var fin))
            {
                return fin > inicio;
            }
            return false;
        }

        /// <summary>
        /// Verifica si el médico está disponible en un día determinado
        /// </summary>
        public bool EstaDisponibleEnDia(string dia)
        {
            if (string.IsNullOrWhiteSpace(DiasAtencion))
                return false;

            var dias = DiasAtencion.Split(',');
            return Array.Exists(dias, d => d.Trim().Equals(dia, StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(Nombres) ? Nombres : base.ToString();
        }
    }
}
