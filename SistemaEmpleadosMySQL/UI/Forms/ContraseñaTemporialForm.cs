using System;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.Helpers;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario para mostrar la contraseña temporal de forma segura
    /// Permite al usuario seleccionar y copiar la contraseña
    /// </summary>
    public partial class ContraseñaTemporialForm : Form
    {
        private string _contraseña;

        public ContraseñaTemporialForm(string usuario, string contraseña)
        {
            InitializeComponent();
            _contraseña = contraseña;
            this.Text = "Contraseña Temporal Generada";
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(500, 350);
            
            ConfigurarControles(usuario, contraseña);
        }

        private void ConfigurarControles(string usuario, string contraseña)
        {
            // Panel principal
            Panel pnlPrincipal = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            // Icono/Titulo
            PictureBox pbIcono = new PictureBox
            {
                Size = new System.Drawing.Size(40, 40),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215),
                Location = new System.Drawing.Point(15, 15)
            };

            Label lblTitulo = new Label
            {
                Text = "✓ Usuario creado exitosamente",
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(65, 20)
            };

            // Información del usuario
            Label lblUsuarioInfo = new Label
            {
                Text = $"Usuario: {usuario}",
                Font = new System.Drawing.Font("Arial", 10),
                AutoSize = true,
                Location = new System.Drawing.Point(15, 65),
                ForeColor = System.Drawing.Color.Black
            };

            // Label para contraseña
            Label lblContraseña = new Label
            {
                Text = "Contraseña Temporal:",
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(15, 100)
            };

            // TextBox con la contraseña (seleccionable)
            TextBox txtContraseña = new TextBox
            {
                Text = contraseña,
                ReadOnly = true,
                Font = new System.Drawing.Font("Courier New", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.FromArgb(51, 51, 51),
                Location = new System.Drawing.Point(15, 130),
                Size = new System.Drawing.Size(450, 35),
                BorderStyle = BorderStyle.Fixed3D
            };

            // Botón Copiar
            Button btnCopiar = new Button
            {
                Text = "📋 Copiar Contraseña",
                Font = new System.Drawing.Font("Arial", 10),
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(15, 180),
                Size = new System.Drawing.Size(220, 35),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };

            btnCopiar.Click += (s, e) =>
            {
                try
                {
                    Clipboard.SetText(contraseña);
                    MessageBox.Show("Contraseña copiada al portapapeles", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogHelper.Info($"Contraseña temporal copiada para usuario '{usuario}'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al copiar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Información importante
            Label lblImportante = new Label
            {
                Text = "⚠ IMPORTANTE:",
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(15, 230),
                ForeColor = System.Drawing.Color.FromArgb(255, 140, 0)
            };

            TextBox txtInformacion = new TextBox
            {
                Text = "• Esta contraseña se muestra solo esta vez\n• Guarde la contraseña de forma segura\n• El usuario DEBE cambiarla en el primer login\n• Puede seleccionar el texto para copiar",
                ReadOnly = true,
                Multiline = true,
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.FromArgb(245, 245, 245),
                Location = new System.Drawing.Point(15, 255),
                Size = new System.Drawing.Size(450, 70),
                BorderStyle = BorderStyle.Fixed3D
            };

            // Botón Aceptar
            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Font = new System.Drawing.Font("Arial", 10),
                BackColor = System.Drawing.Color.FromArgb(0, 150, 76),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(385, 330),
                Size = new System.Drawing.Size(80, 30),
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnAceptar.Click += (s, e) =>
            {
                this.Close();
            };

            // Agregar controles al panel
            pnlPrincipal.Controls.Add(lblTitulo);
            pnlPrincipal.Controls.Add(lblUsuarioInfo);
            pnlPrincipal.Controls.Add(lblContraseña);
            pnlPrincipal.Controls.Add(txtContraseña);
            pnlPrincipal.Controls.Add(btnCopiar);
            pnlPrincipal.Controls.Add(lblImportante);
            pnlPrincipal.Controls.Add(txtInformacion);
            pnlPrincipal.Controls.Add(btnAceptar);

            this.Controls.Add(pnlPrincipal);

            // Permitir que el usuario seleccione la contraseña al abrir el formulario
            this.Load += (s, e) =>
            {
                txtContraseña.Focus();
                txtContraseña.SelectAll();
            };
        }
    }
}
