using System;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.Helpers;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario principal para Administradores
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "CLINICA SAN MANOTAS - Panel Administrativo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            ActualizarEtiquetaUsuario();
            LogHelper.Info($"Panel administrativo abierto para usuario: {SessionManager.UsuarioActual?.Username}");
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
            if (SessionManager.TienePermiso("GestionarPacientes"))
            {
                PacientesForm pacientesForm = new PacientesForm();
                pacientesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a Pacientes.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            if (SessionManager.TienePermiso("GestionarMedicos"))
            {
                MedicosForm medicosForm = new MedicosForm();
                medicosForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a Médicos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            if (SessionManager.TienePermiso("GestionarCitas"))
            {
                CitasForm citasForm = new CitasForm();
                citasForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a Citas.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (SessionManager.TienePermiso("AdministrarUsuarios"))
            {
                UsuariosForm usuariosForm = new UsuariosForm();
                usuariosForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a Usuarios.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            if (SessionManager.TienePermiso("GestionarEspecialidades"))
            {
                EspecialidadesForm especialidadesForm = new EspecialidadesForm();
                especialidadesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a Especialidades.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEPS_Click(object sender, EventArgs e)
        {
            if (SessionManager.TienePermiso("GestionarEPS"))
            {
                EPSForm epsForm = new EPSForm();
                epsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a EPS.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}

