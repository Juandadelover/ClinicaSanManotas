using System;

namespace SistemaEmpleadosMySQL.Model
{
    public class Cita
    {
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Motivo { get; set; }
        public string? Estado { get; set; }
        public string? Notas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Cita()
        {
            Estado = "Pendiente";
            FechaCreacion = DateTime.Now;
            FechaActualizacion = DateTime.Now;
        }

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

        private bool ValidarHora()
        {
            return TimeSpan.TryParse(Hora, out _);
        }

        private bool ValidarEstado()
        {
            return Estado == "Pendiente" ||
                   Estado == "Confirmada" ||
                   Estado == "Cancelada" ||
                   Estado == "Realizada";
        }

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
