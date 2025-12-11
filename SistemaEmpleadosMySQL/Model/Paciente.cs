using System;

namespace SistemaEmpleadosMySQL.Model
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? Documento { get; set; }
        public int EPSId { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Paciente()
        {
            Estado = "Activo";
            FechaRegistro = DateTime.Now;
            Genero = "M";
        }

        public int ObtenerEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }

        public string ObtenerNombreCompleto()
        {
            return $"{Nombres} {Apellidos}".Trim();
        }

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

        public override string ToString()
        {
            return !string.IsNullOrEmpty(Nombres) ? Nombres : base.ToString();
        }
    }
}
