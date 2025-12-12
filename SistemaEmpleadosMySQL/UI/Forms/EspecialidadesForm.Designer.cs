namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class EspecialidadesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;

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
            dgvEspecialidades = new DataGridView();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).BeginInit();
            SuspendLayout();
            // 
            // dgvEspecialidades
            // 
            dgvEspecialidades.BackgroundColor = Color.AliceBlue;
            dgvEspecialidades.Location = new Point(12, 12);
            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.Size = new Size(760, 300);
            dgvEspecialidades.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 320);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(220, 320);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(552, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 351);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(120, 351);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(228, 351);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            // 
            // EspecialidadesForm
            // 
            ClientSize = new Size(784, 409);
            Controls.Add(dgvEspecialidades);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Name = "EspecialidadesForm";
            Text = "Gestión de Especialidades";
            Load += EspecialidadesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
