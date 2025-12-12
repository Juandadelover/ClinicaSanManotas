using System;

namespace ClinicaSanManotas.Model
{
    public class EPS
    {
        public int EPSId { get; set; }
        public string? Nombre { get; set; }
        public string? NIT { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Contacto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Estado { get; set; }

        public EPS()
        {
            Estado = "Activo";
            FechaRegistro = DateTime.Now;
        }

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
