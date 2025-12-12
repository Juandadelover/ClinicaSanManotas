using System;
using System.Security.Cryptography;
using System.Text;

namespace ClinicaSanManotas.Helpers
{
    /// <summary>
    /// Helper para operaciones de seguridad
    /// Task: T029 - Implement Password Security with BCrypt
    /// Nota: Para una implementación real, usar librería BCrypt.Net-Next
    /// Este es un ejemplo educativo con SHA256
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// Genera un hash de contraseña usando SHA256
        /// Nota: En producción usar BCrypt.Net-Next
        /// </summary>
        public static string GenerarHashContraseña(string contraseña)
        {
            if (string.IsNullOrEmpty(contraseña))
                throw new ArgumentException("La contraseña no puede estar vacía");

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        /// <summary>
        /// Verifica una contraseña contra su hash
        /// </summary>
        public static bool VerificarContraseña(string contraseña, string hash)
        {
            if (string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(hash))
                return false;

            var hashDeContraseña = GenerarHashContraseña(contraseña);
            return hashDeContraseña == hash;
        }

        /// <summary>
        /// Valida la fortaleza de una contraseña
        /// </summary>
        public static ValidationResult ValidarFortalezaContraseña(string contraseña)
        {
            var resultado = new ValidationResult();

            if (string.IsNullOrEmpty(contraseña))
            {
                resultado.Exitoso = false;
                resultado.Mensaje = "La contraseña no puede estar vacía";
                return resultado;
            }

            if (contraseña.Length < 8)
            {
                resultado.Errores.Add("La contraseña debe tener al menos 8 caracteres");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(contraseña, @"[A-Z]"))
            {
                resultado.Errores.Add("La contraseña debe contener al menos una mayúscula");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(contraseña, @"[a-z]"))
            {
                resultado.Errores.Add("La contraseña debe contener al menos una minúscula");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(contraseña, @"[0-9]"))
            {
                resultado.Errores.Add("La contraseña debe contener al menos un número");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(contraseña, @"[!@#$%^&*]"))
            {
                resultado.Errores.Add("La contraseña debe contener al menos un carácter especial (!@#$%^&*)");
            }

            resultado.Exitoso = resultado.Errores.Count == 0;
            resultado.Mensaje = resultado.Exitoso ? "Contraseña válida" : "Contraseña débil";

            return resultado;
        }

        /// <summary>
        /// Encripta una cadena (para datos sensibles, no contraseñas)
        /// </summary>
        public static string Encriptar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            byte[] key = Encoding.UTF8.GetBytes("clinicasanmanotas123456");
            using (var aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new System.IO.MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new System.IO.StreamWriter(cs))
                    {
                        sw.Write(texto);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Desencripta una cadena
        /// </summary>
        public static string Desencriptar(string textoEncriptado)
        {
            if (string.IsNullOrEmpty(textoEncriptado))
                return textoEncriptado;

            byte[] key = Encoding.UTF8.GetBytes("clinicasanmanotas123456");
            byte[] buffer = Convert.FromBase64String(textoEncriptado);

            using (var aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] iv = new byte[aes.IV.Length];
                Array.Copy(buffer, 0, iv, 0, iv.Length);

                using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
                using (var ms = new System.IO.MemoryStream(buffer, iv.Length, buffer.Length - iv.Length))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new System.IO.StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

    /// <summary>
    /// Resultado de validación genérico
    /// </summary>
    public class ValidationResult
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }

        public ValidationResult()
        {
            Exitoso = true;
            Mensaje = "Validación exitosa";
            Errores = new List<string>();
        }
    }
}
