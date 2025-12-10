namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class EPSForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvEPS;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEstado;

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
            this.dgvEPS = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPS)).BeginInit();
            this.SuspendLayout();

            // dgvEPS
            this.dgvEPS.Name = "dgvEPS";
            this.dgvEPS.Location = new System.Drawing.Point(12, 12);
            this.dgvEPS.Size = new System.Drawing.Size(760, 300);
            this.dgvEPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // lblNombre
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(12, 320);
            this.lblNombre.Size = new System.Drawing.Size(80, 23);

            // txtNombre
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(100, 320);
            this.txtNombre.Size = new System.Drawing.Size(200, 23);

            // lblTelefono
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(320, 320);
            this.lblTelefono.Size = new System.Drawing.Size(80, 23);

            // txtTelefono
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new System.Drawing.Point(408, 320);
            this.txtTelefono.Size = new System.Drawing.Size(150, 23);

            // lblEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(12, 355);
            this.lblEmail.Size = new System.Drawing.Size(80, 23);

            // txtEmail
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Location = new System.Drawing.Point(100, 355);
            this.txtEmail.Size = new System.Drawing.Size(250, 23);

            // lblEstado
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Location = new System.Drawing.Point(370, 355);
            this.lblEstado.Size = new System.Drawing.Size(80, 23);

            // cmbEstado
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Location = new System.Drawing.Point(458, 355);
            this.cmbEstado.Size = new System.Drawing.Size(100, 23);
            this.cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnAgregar
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(12, 390);
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // btnEditar
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(120, 390);
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnEliminar
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(228, 390);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnLimpiar
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location = new System.Drawing.Point(336, 390);
            this.btnLimpiar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // EPSForm
            this.Controls.Add(this.dgvEPS);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);

            this.Name = "EPSForm";
            this.Text = "Gestión de EPS";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.EPSForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
