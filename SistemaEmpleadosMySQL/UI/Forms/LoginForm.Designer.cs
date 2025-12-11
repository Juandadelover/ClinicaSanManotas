namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para admitir el Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContraseña = new Label();
            txtContraseña = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            lblVersion = new Label();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(440, 130);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = false;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(440, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CLÍNICA SAN MANOTAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(0, 70);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(440, 30);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión Médica";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(44, 62, 80);
            lblUsuario.Location = new Point(63, 165);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(65, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(63, 189);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(315, 27);
            txtUsuario.TabIndex = 0;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContraseña.ForeColor = Color.FromArgb(44, 62, 80);
            lblContraseña.Location = new Point(63, 235);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(90, 19);
            lblContraseña.TabIndex = 2;
            lblContraseña.Text = "Contraseña:";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 11F);
            txtContraseña.Location = new Point(63, 259);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '●';
            txtContraseña.Size = new Size(315, 27);
            txtContraseña.TabIndex = 1;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(46, 204, 113);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(63, 320);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(315, 42);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(189, 195, 199);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(44, 62, 80);
            btnSalir.Location = new Point(63, 375);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(315, 42);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = false;
            lblVersion.Font = new Font("Segoe UI", 8F);
            lblVersion.ForeColor = Color.Gray;
            lblVersion.Location = new Point(0, 455);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(440, 20);
            lblVersion.TabIndex = 4;
            lblVersion.Text = "Versión 1.0.0";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(440, 480);
            Controls.Add(pnlHeader);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContraseña);
            Controls.Add(txtContraseña);
            Controls.Add(btnIngresar);
            Controls.Add(btnSalir);
            Controls.Add(lblVersion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLINICA SAN MANOTAS - Iniciar Sesión";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblVersion;
    }
}
