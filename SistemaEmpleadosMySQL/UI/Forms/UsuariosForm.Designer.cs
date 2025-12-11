namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class UsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.GroupBox grpBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRestablecerContraseña;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvUsuarios = new DataGridView();
            grpDatos = new GroupBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRol = new Label();
            cmbRol = new ComboBox();
            lblContraseña = new Label();
            txtContraseña = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            grpBotones = new GroupBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnRestablecerContraseña = new Button();
            btnLimpiar = new Button();
            lblTotal = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDatos.SuspendLayout();
            grpBotones.SuspendLayout();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = false;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(400, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administración de Usuarios";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;

            // dgvUsuarios
            dgvUsuarios.Location = new Point(12, 40);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(900, 250);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;

            // grpDatos
            grpDatos.Controls.Add(lblUsername);
            grpDatos.Controls.Add(txtUsername);
            grpDatos.Controls.Add(lblEmail);
            grpDatos.Controls.Add(txtEmail);
            grpDatos.Controls.Add(lblRol);
            grpDatos.Controls.Add(cmbRol);
            grpDatos.Controls.Add(lblContraseña);
            grpDatos.Controls.Add(txtContraseña);
            grpDatos.Controls.Add(lblEstado);
            grpDatos.Controls.Add(cmbEstado);
            grpDatos.Location = new Point(12, 297);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(900, 130);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "📋 Información del Usuario";

            // lblUsername
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(6, 25);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(59, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Usuario:";

            // txtUsername
            txtUsername.Location = new Point(6, 43);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 1;
            txtUsername.PlaceholderText = "Ej: admin, dr_garcia";

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(220, 25);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";

            // txtEmail
            txtEmail.Location = new Point(220, 43);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 23);
            txtEmail.TabIndex = 3;
            txtEmail.PlaceholderText = "usuario@clinicamanotas.com";

            // lblRol
            lblRol.AutoSize = true;
            lblRol.Location = new Point(520, 25);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(30, 15);
            lblRol.TabIndex = 4;
            lblRol.Text = "Rol:";

            // cmbRol
            cmbRol.Location = new Point(520, 43);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(170, 23);
            cmbRol.TabIndex = 5;

            // lblContraseña
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(6, 75);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(75, 15);
            lblContraseña.TabIndex = 8;
            lblContraseña.Text = "Contraseña:";

            // txtContraseña
            txtContraseña.Location = new Point(6, 93);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(200, 23);
            txtContraseña.TabIndex = 9;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.PlaceholderText = "Ingresa la contraseña";

            // lblEstado
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(710, 25);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(48, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";

            // cmbEstado
            cmbEstado.Location = new Point(710, 43);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(170, 23);
            cmbEstado.TabIndex = 7;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });

            // grpBotones
            grpBotones.Controls.Add(btnAgregar);
            grpBotones.Controls.Add(btnActualizar);
            grpBotones.Controls.Add(btnEliminar);
            grpBotones.Controls.Add(btnRestablecerContraseña);
            grpBotones.Controls.Add(btnLimpiar);
            grpBotones.Location = new Point(12, 463);
            grpBotones.Name = "grpBotones";
            grpBotones.Size = new Size(900, 50);
            grpBotones.TabIndex = 3;
            grpBotones.TabStop = false;
            grpBotones.Text = "⚙️ Acciones";

            // btnAgregar
            btnAgregar.BackColor = Color.LimeGreen;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(6, 18);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 25);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "✚ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += BtnAgregar_Click;

            // btnActualizar
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(110, 18);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 25);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "✎ Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += BtnActualizar_Click;

            // btnEliminar
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(214, 18);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 25);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "✕ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;

            // btnRestablecerContraseña
            btnRestablecerContraseña.BackColor = Color.Orange;
            btnRestablecerContraseña.ForeColor = Color.White;
            btnRestablecerContraseña.Location = new Point(318, 18);
            btnRestablecerContraseña.Name = "btnRestablecerContraseña";
            btnRestablecerContraseña.Size = new Size(150, 25);
            btnRestablecerContraseña.TabIndex = 3;
            btnRestablecerContraseña.Text = "🔑 Restablecer Contraseña";
            btnRestablecerContraseña.UseVisualStyleBackColor = false;
            btnRestablecerContraseña.Click += BtnRestablecerContraseña_Click;

            // btnLimpiar
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(473, 18);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 25);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "⟲ Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 520);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(59, 15);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: 0";

            // UsuariosForm
            ClientSize = new Size(924, 540);
            Controls.Add(lblTitulo);
            Controls.Add(dgvUsuarios);
            Controls.Add(grpDatos);
            Controls.Add(grpBotones);
            Controls.Add(lblTotal);
            Name = "UsuariosForm";
            Text = "Administración de Usuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Load += UsuariosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpBotones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
