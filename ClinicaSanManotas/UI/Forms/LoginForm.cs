using System;
using System.Windows.Forms;
using ClinicaSanManotas.DTO;
using ClinicaSanManotas.Helpers;
using ClinicaSanManotas.Repositories;

namespace ClinicaSanManotas.UI.Forms
{
    /// <summary>
    /// Formulario de autenticación de usuarios
    /// </summary>
    public partial class LoginForm : Form
    {
        private UnitOfWork _unitOfWork;

        public LoginForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = "CLINICA SAN MANOTAS - Iniciar Sesión";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txtUsuario.Focus();
            LogHelper.Info("Formulario de login cargado");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    string usuario = txtUsuario.Text.Trim();
                    string contraseña = txtContraseña.Text;

                    if (_unitOfWork.Usuarios.VerificarCredenciales(usuario, contraseña))
                    {
                        var usuarioActual = _unitOfWork.Usuarios.GetByUsername(usuario);

                        if (usuarioActual != null && usuarioActual.Estado == "Activo")
                        {
                            // Actualizar último login
                            _unitOfWork.Usuarios.ActualizarUltimoLogin(usuarioActual.UserId);

                            // Log de acceso exitoso
                            LogHelper.LogAcceso(usuarioActual.UserId, usuario, "LOGIN", true);

                            // Guardar datos en sesión
                            SessionManager.UsuarioActual = usuarioActual;
                            SessionManager.FechaLogin = DateTime.Now;

                            MessageBox.Show(
                                $"¡Bienvenido {usuarioActual.ObtenerNombreRol()}!",
                                "Acceso Permitido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // Abrir formulario principal según rol
                            AbrirPrincipalPorRol(usuarioActual.Role ?? "Recepcionista");
                            this.Hide();
                        }
                        else
                        {
                            LogHelper.LogAcceso(0, usuario, "LOGIN", false);
                            MessageBox.Show(
                                "Usuario inactivo. Contacte con administración.",
                                "Acceso Denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        LogHelper.LogAcceso(0, usuario, "LOGIN", false);
                        MessageBox.Show(
                            "Usuario o contraseña incorrectos.",
                            "Error de Autenticación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        txtContraseña.Clear();
                        txtUsuario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error en login: {ex.Message}", ex);
                MessageBox.Show(
                    $"Error al procesar login: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor ingrese usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor ingrese contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }

            return true;
        }

        private void AbrirPrincipalPorRol(string role)
        {
            switch (role.ToUpper())
            {
                case "ADMIN":
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    break;
                case "RECEPCIONISTA":
                    RecepcionForm recepcionForm = new RecepcionForm();
                    recepcionForm.Show();
                    break;
                case "DOCTOR":
                    DoctorForm doctorForm = new DoctorForm();
                    doctorForm.Show();
                    break;
                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _unitOfWork?.Dispose();
            LogHelper.Info("Formulario de login cerrado");
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnIngresar_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void lblSubtitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// Clase para gestionar datos de sesión del usuario
    /// </summary>
    public static class SessionManager
    {
        public static Model.Usuario? UsuarioActual { get; set; }
        public static DateTime FechaLogin { get; set; }

        public static bool EstaAutenticado => UsuarioActual != null;

        public static void CerrarSesion()
        {
            LogHelper.LogAcceso(UsuarioActual?.UserId ?? 0, UsuarioActual?.Username ?? "Unknown", "LOGOUT", true);
            UsuarioActual = null;
            FechaLogin = DateTime.MinValue;
        }

        public static bool TienePermiso(string nombrePermiso)
        {
            if (!EstaAutenticado) return false;

            // Lógica de permisos según rol
            return (UsuarioActual?.Role) switch
            {
                "Admin" => true, // Admin tiene todos los permisos
                "Recepcionista" => nombrePermiso != "AdministrarUsuarios",
                "Doctor" => nombrePermiso.StartsWith("Cita") || nombrePermiso.StartsWith("Paciente"),
                _ => false
            };
        }
    }
}

