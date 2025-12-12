using System;
using System.Windows.Forms;
using ClinicaSanManotas.Helpers;

namespace ClinicaSanManotas.UI.Forms
{
    /// <summary>
    /// Formulario principal para Doctores
    /// </summary>
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            this.Text = "CLINICA SAN MANOTAS - Panel del Doctor";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            ActualizarEtiquetaUsuario();
            LogHelper.Info($"Panel del doctor abierto para usuario: {SessionManager.UsuarioActual?.Username}");
        }

        private void ActualizarEtiquetaUsuario()
        {
            if (SessionManager.EstaAutenticado)
            {
                lblUsuario.Text = $"Usuario: {SessionManager.UsuarioActual.Username} ({SessionManager.UsuarioActual.ObtenerNombreRol()})";
            }
        }

        private void btnMisCitas_Click(object sender, EventArgs e)
        {
            CitasForm citasForm = new CitasForm();
            citasForm.ShowDialog();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            PacientesForm pacientesForm = new PacientesForm();
            pacientesForm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea cerrar sesión?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                SessionManager.CerrarSesion();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void DoctorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SessionManager.EstaAutenticado)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Desea salir de la aplicación?",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    SessionManager.CerrarSesion();
                }
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}

