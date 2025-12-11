using System;

namespace SistemaEmpleadosMySQL.Model
{
    public class Especialidad
    {
        public int EspecialidadId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Especialidad()
        {
            Estado = "Activo";
            FechaCreacion = DateTime.Now;
        }

        public bool EsValida()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   Nombre.Length >= 3 &&
                   Nombre.Length <= 100 &&
                   !string.IsNullOrWhiteSpace(Estado);
        }
    }
}
