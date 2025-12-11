namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class UsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRestablecerContraseña;

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
            dgvUsuarios = new DataGridView();
            cmbRol = new ComboBox();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnRestablecerContraseña = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Location = new Point(278, 12);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(760, 250);
            dgvUsuarios.TabIndex = 0;
            // 
            // cmbRol
            // 
            cmbRol.Location = new Point(278, 270);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(150, 23);
            cmbRol.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(436, 270);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(594, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(444, 23);
            txtEmail.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(278, 301);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(386, 301);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(494, 301);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            // 
            // btnRestablecerContraseña
            // 
            btnRestablecerContraseña.Location = new Point(602, 301);
            btnRestablecerContraseña.Name = "btnRestablecerContraseña";
            btnRestablecerContraseña.Size = new Size(150, 30);
            btnRestablecerContraseña.TabIndex = 7;
            btnRestablecerContraseña.Text = "Restablecer Contraseña";
            // 
            // UsuariosForm
            // 
            ClientSize = new Size(1277, 492);
            Controls.Add(dgvUsuarios);
            Controls.Add(cmbRol);
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnRestablecerContraseña);
            Name = "UsuariosForm";
            Text = "Administración de Usuarios";
            Load += UsuariosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
