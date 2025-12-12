namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class EPSForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvEPS;
        private System.Windows.Forms.Panel pnlFormulario;
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            dgvEPS = new DataGridView();
            pnlFormulario = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEPS).BeginInit();
            pnlFormulario.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(18, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(350, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de EPS";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvEPS
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(245, 248, 250);
            dgvEPS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvEPS.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvEPS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvEPS.ColumnHeadersHeight = 35;
            dgvEPS.EnableHeadersVisualStyles = false;
            dgvEPS.Location = new Point(18, 47);
            dgvEPS.Name = "dgvEPS";
            dgvEPS.RowTemplate.Height = 28;
            dgvEPS.Size = new Size(752, 281);
            dgvEPS.TabIndex = 1;
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.AliceBlue;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(lblNombre);
            pnlFormulario.Controls.Add(txtNombre);
            pnlFormulario.Controls.Add(lblTelefono);
            pnlFormulario.Controls.Add(txtTelefono);
            pnlFormulario.Controls.Add(lblEmail);
            pnlFormulario.Controls.Add(txtEmail);
            pnlFormulario.Controls.Add(lblEstado);
            pnlFormulario.Controls.Add(cmbEstado);
            pnlFormulario.Controls.Add(btnAgregar);
            pnlFormulario.Controls.Add(btnEditar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Location = new Point(18, 342);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(753, 131);
            pnlFormulario.TabIndex = 2;
            pnlFormulario.Paint += pnlFormulario_Paint;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(52, 73, 94);
            lblNombre.Location = new Point(13, 14);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(13, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(219, 25);
            txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(52, 73, 94);
            lblTelefono.Location = new Point(249, 14);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(59, 15);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtTelefono.Location = new Point(249, 33);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(158, 25);
            txtTelefono.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(52, 73, 94);
            lblEmail.Location = new Point(424, 14);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(424, 33);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 25);
            txtEmail.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstado.Location = new Point(661, 14);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(46, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 10F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(661, 33);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(79, 25);
            cmbEstado.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Green;
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(13, 80);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 33);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.SteelBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(127, 80);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(105, 33);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(241, 80);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 33);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(354, 80);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(105, 33);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "🔄 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // EPSForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(788, 488);
            Controls.Add(lblTitulo);
            Controls.Add(dgvEPS);
            Controls.Add(pnlFormulario);
            Name = "EPSForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de EPS";
            Load += EPSForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEPS).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ResumeLayout(false);
        }
    }
}
