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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRestablecerContraseña = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 250);

            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Location = new System.Drawing.Point(12, 270);
            this.cmbRol.Size = new System.Drawing.Size(150, 23);

            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Location = new System.Drawing.Point(170, 270);
            this.txtUsername.Size = new System.Drawing.Size(150, 23);

            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Location = new System.Drawing.Point(328, 270);
            this.txtEmail.Size = new System.Drawing.Size(444, 23);

            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(12, 301);
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);

            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(120, 301);
            this.btnActualizar.Size = new System.Drawing.Size(100, 30);

            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(228, 301);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);

            this.btnRestablecerContraseña.Name = "btnRestablecerContraseña";
            this.btnRestablecerContraseña.Text = "Restablecer Contraseña";
            this.btnRestablecerContraseña.Location = new System.Drawing.Point(336, 301);
            this.btnRestablecerContraseña.Size = new System.Drawing.Size(150, 30);

            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnRestablecerContraseña);

            this.Name = "UsuariosForm";
            this.Text = "Administración de Usuarios";
            this.Size = new System.Drawing.Size(800, 400);

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
