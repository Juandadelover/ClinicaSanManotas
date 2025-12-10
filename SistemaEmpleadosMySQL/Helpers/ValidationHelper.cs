using System;
using System.Text.RegularExpressions;

namespace SistemaEmpleadosMySQL.Helpers
{
    /// <summary>
    /// Helper para validaciones de datos
    /// Task: T027 - Implement Centralized Validation Framework
    /// </summary>
    public class ValidationHelper
    {
        /// <summary>
        /// Valida un email
        /// </summary>
        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida un formato de teléfono
        /// </summary>
        public static bool EsTelefonoValido(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return true; // Es opcional

            // Acepta formatos: +57XXXXXXXXXX, 3XXXXXXXXXX, etc
            return Regex.IsMatch(telefono, @"^(\+57|0)?[1-9]\d{1,14}$");
        }

        /// <summary>
        /// Valida un documento de identidad
        /// </summary>
        public static bool EsDocumentoValido(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            // Documento sin espacios, 5-20 caracteres, alfanumérico
            var documentoLimpio = documento.Replace(" ", "").Replace("-", "");
            return documentoLimpio.Length >= 5 && documentoLimpio.Length <= 20 &&
                   Regex.IsMatch(documentoLimpio, @"^[A-Z0-9]+$");
        }

        /// <summary>
        /// Valida un NIT
        /// </summary>
        public static bool EsNITValido(string nit)
        {
            if (string.IsNullOrWhiteSpace(nit))
                return false;

            var nitLimpio = nit.Replace(".", "").Replace("-", "");
            return nitLimpio.Length >= 8 && Regex.IsMatch(nitLimpio, @"^[0-9]+$");
        }

        /// <summary>
        /// Valida una hora en formato HH:mm
        /// </summary>
        public static bool EsHoraValida(string hora)
        {
            if (string.IsNullOrWhiteSpace(hora))
                return false;

            return TimeSpan.TryParse(hora, out var resultado) &&
                   resultado.TotalHours >= 0 &&
                   resultado.TotalHours < 24;
        }

        /// <summary>
        /// Valida que una fecha no esté en el pasado
        /// </summary>
        public static bool EsFechaValida(DateTime fecha)
        {
            return fecha.Date >= DateTime.Now.Date;
        }

        /// <summary>
        /// Calcula edad a partir de fecha de nacimiento
        /// </summary>
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }

        /// <summary>
        /// Valida que la edad esté dentro de rango permitido
        /// </summary>
        public static bool EsEdadValida(DateTime fechaNacimiento, int edadMinima = 0, int edadMaxima = 150)
        {
            var edad = CalcularEdad(fechaNacimiento);
            return edad >= edadMinima && edad <= edadMaxima;
        }

        /// <summary>
        /// Valida longitud de string
        /// </summary>
        public static bool EsLongitudValida(string texto, int minimo, int maximo)
        {
            if (texto == null)
                return minimo == 0;

            var longitud = texto.Trim().Length;
            return longitud >= minimo && longitud <= maximo;
        }

        /// <summary>
        /// Valida que un rol sea válido
        /// </summary>
        public static bool EsRolValido(string rol)
        {
            return rol == "Admin" || rol == "Recepcionista" || rol == "Doctor";
        }

        /// <summary>
        /// Valida que un género sea válido
        /// </summary>
        public static bool EsGeneroValido(string genero)
        {
            return genero == "M" || genero == "F" || genero == "O";
        }

        /// <summary>
        /// Valida que un estado sea válido
        /// </summary>
        public static bool EsEstadoValido(string estado)
        {
            return estado == "Activo" || estado == "Inactivo";
        }

        /// <summary>
        /// Valida que un estado de cita sea válido
        /// </summary>
        public static bool EsEstadoCitaValido(string estado)
        {
            return estado == "Pendiente" || estado == "Confirmada" ||
                   estado == "Cancelada" || estado == "Realizada";
        }

        /// <summary>
        /// Limpia un string para evitar inyecciones
        /// </summary>
        public static string LimpiarEntrada(string entrada)
        {
            if (string.IsNullOrEmpty(entrada))
                return entrada;

            // Remover caracteres especiales peligrosos
            return Regex.Replace(entrada, @"[<>\""'\-;]", "").Trim();
        }

        /// <summary>
        /// Valida todo un modelo de Usuario
        /// </summary>
        public static List<string> ValidarUsuario(string username, string email, string password, string rol)
        {
            var errores = new List<string>();

            if (!EsLongitudValida(username, 4, 50))
                errores.Add("Username debe tener entre 4 y 50 caracteres");

            if (!EsEmailValido(email))
                errores.Add("Email no es válido");

            var validezContraseña = SecurityHelper.ValidarFortalezaContraseña(password);
            if (!validezContraseña.Exitoso)
                errores.AddRange(validezContraseña.Errores);

            if (!EsRolValido(rol))
                errores.Add("Rol no es válido");

            return errores;
        }
    }
}
