using System;

namespace ClinicaSanManotas.Model
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Licencia { get; set; }
        public int EspecialidadId { get; set; }
        public string? HorarioInicio { get; set; }
        public string? HorarioFin { get; set; }
        public string? DiasAtencion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Estado { get; set; }

        public Medico()
        {
            Estado = "Activo";
            FechaRegistro = DateTime.Now;
            DiasAtencion = "Lunes,Martes,Miércoles,Jueves,Viernes";
        }

        public string ObtenerNombreCompleto()
        {
            return $"{Nombres} {Apellidos}".Trim();
        }

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

        private bool CompararHorarios()
        {
            if (TimeSpan.TryParse(HorarioInicio, out var inicio) &&
                TimeSpan.TryParse(HorarioFin, out var fin))
            {
                return fin > inicio;
            }
            return false;
        }

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
