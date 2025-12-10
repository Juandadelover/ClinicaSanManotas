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
            pnlPanel = new Panel();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContraseña = new Label();
            txtContraseña = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            pnlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPanel
            // 
            pnlPanel.BackColor = SystemColors.Control;
            pnlPanel.Controls.Add(lblTitulo);
            pnlPanel.Controls.Add(lblUsuario);
            pnlPanel.Controls.Add(txtUsuario);
            pnlPanel.Controls.Add(lblContraseña);
            pnlPanel.Controls.Add(txtContraseña);
            pnlPanel.Controls.Add(btnIngresar);
            pnlPanel.Controls.Add(btnSalir);
            pnlPanel.Dock = DockStyle.Fill;
            pnlPanel.Location = new Point(0, 0);
            pnlPanel.Margin = new Padding(4, 3, 4, 3);
            pnlPanel.Name = "pnlPanel";
            pnlPanel.Size = new Size(904, 491);
            pnlPanel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(301, 42);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CLÍNICA SAN MANOTAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Arial", 10F);
            lblUsuario.Location = new Point(268, 111);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 16);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Arial", 10F);
            txtUsuario.Location = new Point(268, 134);
            txtUsuario.Margin = new Padding(4, 3, 4, 3);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(349, 23);
            txtUsuario.TabIndex = 0;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Arial", 10F);
            lblContraseña.Location = new Point(268, 181);
            lblContraseña.Margin = new Padding(4, 0, 4, 0);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(85, 16);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña:";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Arial", 10F);
            txtContraseña.Location = new Point(268, 204);
            txtContraseña.Margin = new Padding(4, 3, 4, 3);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(349, 23);
            txtContraseña.TabIndex = 1;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Green;
            btnIngresar.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(327, 273);
            btnIngresar.Margin = new Padding(4, 3, 4, 3);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(117, 40);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Red;
            btnSalir.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(467, 273);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(117, 40);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 491);
            Controls.Add(pnlPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginForm";
            Text = "CLINICA SAN MANOTAS - Iniciar Sesión";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            pnlPanel.ResumeLayout(false);
            pnlPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
    }
}
