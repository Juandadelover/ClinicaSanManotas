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
            _contraseña = contraseña;
            this.Text = "Contraseña Temporal Generada";
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(500, 400);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            
            ConfigurarControles(usuario, contraseña);
        }

        private void ConfigurarControles(string usuario, string contraseña)
        {
            // Panel principal con padding
            Panel pnlPrincipal = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = System.Drawing.Color.White
            };

            int yPos = 15;

            // Título
            Label lblTitulo = new Label
            {
                Text = "✓ Usuario creado exitosamente",
                Font = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, yPos),
                ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
            };
            pnlPrincipal.Controls.Add(lblTitulo);
            yPos += 40;

            // Información del usuario
            Label lblUsuarioLabel = new Label
            {
                Text = "Usuario:",
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, yPos)
            };
            pnlPrincipal.Controls.Add(lblUsuarioLabel);
            yPos += 25;

            Label lblUsuarioValor = new Label
            {
                Text = usuario,
                Font = new System.Drawing.Font("Arial", 10),
                AutoSize = true,
                Location = new System.Drawing.Point(20, yPos)
            };
            pnlPrincipal.Controls.Add(lblUsuarioValor);
            yPos += 35;

            // Label para contraseña
            Label lblContraseñaLabel = new Label
            {
                Text = "Contraseña Temporal (Seleccionable):",
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, yPos)
            };
            pnlPrincipal.Controls.Add(lblContraseñaLabel);
            yPos += 25;

            // TextBox con la contraseña (seleccionable)
            TextBox txtContraseña = new TextBox
            {
                Text = contraseña,
                ReadOnly = false,
                Font = new System.Drawing.Font("Courier New", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.FromArgb(51, 51, 51),
                Location = new System.Drawing.Point(20, yPos),
                Size = new System.Drawing.Size(440, 40),
                BorderStyle = BorderStyle.Fixed3D,
                Multiline = false
            };
            pnlPrincipal.Controls.Add(txtContraseña);
            yPos += 55;

            // Botón Copiar
            Button btnCopiar = new Button
            {
                Text = "📋 Copiar Contraseña",
                Font = new System.Drawing.Font("Arial", 10),
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, yPos),
                Size = new System.Drawing.Size(200, 35),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };

            btnCopiar.Click += (s, e) =>
            {
                try
                {
                    Clipboard.SetText(contraseña);
                    MessageBox.Show("✓ Contraseña copiada al portapapeles", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogHelper.Info($"Contraseña temporal copiada para usuario '{usuario}'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al copiar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            pnlPrincipal.Controls.Add(btnCopiar);
            yPos += 50;

            // Información importante
            TextBox txtInformacion = new TextBox
            {
                Text = "⚠ IMPORTANTE:\r\n• Esta contraseña se muestra solo esta vez\r\n• Guarde la contraseña de forma segura\r\n• El usuario DEBE cambiarla en el primer login\r\n• Puede seleccionar y copiar el texto con Ctrl+C",
                ReadOnly = true,
                Multiline = true,
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.FromArgb(255, 250, 205),
                ForeColor = System.Drawing.Color.FromArgb(128, 64, 0),
                Location = new System.Drawing.Point(20, yPos),
                Size = new System.Drawing.Size(440, 80),
                BorderStyle = BorderStyle.Fixed3D,
                WordWrap = true
            };
            pnlPrincipal.Controls.Add(txtInformacion);

            // Botón Aceptar en la parte inferior
            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Font = new System.Drawing.Font("Arial", 10),
                BackColor = System.Drawing.Color.FromArgb(0, 150, 76),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(380, 360),
                Size = new System.Drawing.Size(80, 30),
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnAceptar.Click += (s, e) =>
            {
                this.Close();
            };

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
