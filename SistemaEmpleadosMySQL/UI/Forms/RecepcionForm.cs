using System;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.Helpers;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario principal para Recepcionistas
    /// </summary>
    public partial class RecepcionForm : Form
    {
        public RecepcionForm()
        {
            InitializeComponent();
        }

        private void RecepcionForm_Load(object sender, EventArgs e)
        {
            this.Text = "CLINICA SAN MANOTAS - Panel de Recepción";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            ActualizarEtiquetaUsuario();
            LogHelper.Info($"Panel de recepción abierto para usuario: {SessionManager.UsuarioActual?.Username}");
        }

        private void ActualizarEtiquetaUsuario()
        {
            if (SessionManager.EstaAutenticado)
            {
                lblUsuario.Text = $"Usuario: {SessionManager.UsuarioActual.Username} ({SessionManager.UsuarioActual.ObtenerNombreRol()})";
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            PacientesForm pacientesForm = new PacientesForm();
            pacientesForm.ShowDialog();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            CitasForm citasForm = new CitasForm();
            citasForm.ShowDialog();
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

        private void RecepcionForm_FormClosing(object sender, FormClosingEventArgs e)
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

