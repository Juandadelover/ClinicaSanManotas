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
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.SuspendLayout();

            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.Location = new System.Drawing.Point(12, 12);
            this.dgvEspecialidades.Size = new System.Drawing.Size(760, 300);

            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(12, 320);
            this.txtNombre.Size = new System.Drawing.Size(200, 23);

            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Location = new System.Drawing.Point(220, 320);
            this.txtDescripcion.Size = new System.Drawing.Size(552, 23);

            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(12, 351);
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);

            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(120, 351);
            this.btnActualizar.Size = new System.Drawing.Size(100, 30);

            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(228, 351);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);

            this.Controls.Add(this.dgvEspecialidades);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);

            this.Name = "EspecialidadesForm";
            this.Text = "Gestión de Especialidades";
            this.Size = new System.Drawing.Size(800, 400);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
