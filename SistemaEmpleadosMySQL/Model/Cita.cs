using System;

namespace SistemaEmpleadosMySQL.Model
{
    /// <summary>
    /// Modelo de Cita Médica
    /// Task: T012 - Create Cita Model
    /// </summary>
    public class Cita
    {
        /// <summary>
        /// ID único de la cita
        /// </summary>
        public int CitaId { get; set; }

        /// <summary>
        /// ID del paciente que tiene la cita
        /// Foreign Key a tabla Paciente
        /// </summary>
        public int PacienteId { get; set; }

        /// <summary>
        /// ID del médico que atiende la cita
        /// Foreign Key a tabla Medico
        /// </summary>
        public int MedicoId { get; set; }

        /// <summary>
        /// Fecha de la cita
        /// Validación: No puede ser en el pasado
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Hora de la cita
        /// Formato: HH:mm (ej: 14:30)
        /// </summary>
        public string? Hora { get; set; }

        /// <summary>
        /// Motivo de la consulta
        /// Validación: Min 5, Max 500 caracteres
        /// </summary>
        public string? Motivo { get; set; }

        /// <summary>
        /// Estado de la cita
        /// Valores: Pendiente, Confirmada, Cancelada, Realizada
        /// Estado inicial: Pendiente
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Notas adicionales sobre la cita
        /// Opcional
        /// </summary>
        public string? Notas { get; set; }

        /// <summary>
        /// Fecha y hora de creación de la cita
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha y hora de última actualización
        /// </summary>
        public DateTime FechaActualizacion { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Cita()
        {
            Estado = "Pendiente";
            FechaCreacion = DateTime.Now;
            FechaActualizacion = DateTime.Now;
        }

        /// <summary>
        /// Valida que la cita tenga datos válidos
        /// </summary>
        public bool EsValida()
        {
            return PacienteId > 0 &&
                   MedicoId > 0 &&
                   Fecha >= DateTime.Now.Date &&
                   !string.IsNullOrWhiteSpace(Hora) &&
                   !string.IsNullOrWhiteSpace(Motivo) &&
                   !string.IsNullOrWhiteSpace(Estado) &&
                   Motivo.Length >= 5 &&
                   Motivo.Length <= 500 &&
                   ValidarHora() &&
                   ValidarEstado();
        }

        /// <summary>
        /// Valida que la hora sea un formato válido HH:mm
        /// </summary>
        private bool ValidarHora()
        {
            return TimeSpan.TryParse(Hora, out _);
        }

        /// <summary>
        /// Valida que el estado sea uno de los permitidos
        /// </summary>
        private bool ValidarEstado()
        {
            return Estado == "Pendiente" ||
                   Estado == "Confirmada" ||
                   Estado == "Cancelada" ||
                   Estado == "Realizada";
        }

        /// <summary>
        /// Confirma la cita (Pendiente → Confirmada)
        /// </summary>
        public bool Confirmar()
        {
            if (Estado == "Pendiente")
            {
                Estado = "Confirmada";
                FechaActualizacion = DateTime.Now;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cancela la cita
        /// </summary>
        public bool Cancelar()
        {
            if (Estado != "Realizada")
            {
                Estado = "Cancelada";
                FechaActualizacion = DateTime.Now;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Marca la cita como realizada
        /// </summary>
        public bool Realizar()
        {
            if (Estado == "Confirmada")
            {
                Estado = "Realizada";
                FechaActualizacion = DateTime.Now;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obtiene descripción del estado
        /// </summary>
        public string ObtenerEstadoDisplay()
        {
            return Estado switch
            {
                "Pendiente" => "Pendiente de confirmación",
                "Confirmada" => "Confirmada",
                "Realizada" => "Completada",
                "Cancelada" => "Cancelada",
                _ => "Desconocido"
            };
        }

        /// <summary>
        /// Obtiene fecha y hora juntas
        /// </summary>
        public DateTime ObtenerFechaHora()
        {
            if (DateTime.TryParse($"{Fecha:yyyy-MM-dd} {Hora}", out var fechaHora))
            {
                return fechaHora;
            }
            return Fecha;
        }
    }
}
