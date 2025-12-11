namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class MedicosForm
    {
        private System.ComponentModel.IContainer components = null;

        // Título
        private System.Windows.Forms.Label lblTitulo;

        // DataGridView
        private System.Windows.Forms.DataGridView dgvMedicos;

        // Panel de Filtros
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label lblFiltroEspecialidad;
        private System.Windows.Forms.ComboBox cmbFiltroEspecialidad;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;

        // Panel de Formulario
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblLicencia;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label lblHorarioInicio;
        private System.Windows.Forms.DateTimePicker dtpHorarioInicio;
        private System.Windows.Forms.Label lblHorarioFin;
        private System.Windows.Forms.DateTimePicker dtpHorarioFin;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Panel pnlDias;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkDomingo;

        // Panel de Botones
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;

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
            dgvMedicos = new DataGridView();
            pnlFiltros = new Panel();
            lblFiltroNombre = new Label();
            txtFiltroNombre = new TextBox();
            lblFiltroEspecialidad = new Label();
            cmbFiltroEspecialidad = new ComboBox();
            btnAplicarFiltros = new Button();
            btnLimpiarFiltros = new Button();
            pnlFormulario = new Panel();
            lblNombres = new Label();
            txtNombres = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblLicencia = new Label();
            txtLicencia = new TextBox();
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            lblHorarioInicio = new Label();
            dtpHorarioInicio = new DateTimePicker();
            lblHorarioFin = new Label();
            dtpHorarioFin = new DateTimePicker();
            lblDias = new Label();
            pnlDias = new Panel();
            chkLunes = new CheckBox();
            chkMartes = new CheckBox();
            chkMiercoles = new CheckBox();
            chkJueves = new CheckBox();
            chkViernes = new CheckBox();
            chkSabado = new CheckBox();
            chkDomingo = new CheckBox();
            pnlBotones = new Panel();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).BeginInit();
            pnlFiltros.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = false;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new Point(12, 12);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(400, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Médicos";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;

            // dgvMedicos
            dgvMedicos.BackgroundColor = Color.White;
            dgvMedicos.BorderStyle = BorderStyle.FixedSingle;
            dgvMedicos.ColumnHeadersHeight = 35;
            dgvMedicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMedicos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvMedicos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMedicos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMedicos.EnableHeadersVisualStyles = false;
            dgvMedicos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgvMedicos.Location = new Point(12, 50);
            dgvMedicos.Margin = new Padding(4, 3, 4, 3);
            dgvMedicos.Name = "dgvMedicos";
            dgvMedicos.Size = new Size(1050, 200);
            dgvMedicos.TabIndex = 1;
            dgvMedicos.SelectionChanged += dgvMedicos_SelectionChanged;

            // pnlFiltros
            pnlFiltros.BackColor = Color.FromArgb(236, 240, 241);
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(lblFiltroNombre);
            pnlFiltros.Controls.Add(txtFiltroNombre);
            pnlFiltros.Controls.Add(lblFiltroEspecialidad);
            pnlFiltros.Controls.Add(cmbFiltroEspecialidad);
            pnlFiltros.Controls.Add(btnAplicarFiltros);
            pnlFiltros.Controls.Add(btnLimpiarFiltros);
            pnlFiltros.Location = new Point(12, 256);
            pnlFiltros.Margin = new Padding(4, 3, 4, 3);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1050, 60);
            pnlFiltros.TabIndex = 2;

            // lblFiltroNombre
            lblFiltroNombre.AutoSize = true;
            lblFiltroNombre.Location = new Point(12, 12);
            lblFiltroNombre.Margin = new Padding(4, 0, 4, 0);
            lblFiltroNombre.Name = "lblFiltroNombre";
            lblFiltroNombre.Size = new Size(53, 15);
            lblFiltroNombre.TabIndex = 0;
            lblFiltroNombre.Text = "Nombre:";

            // txtFiltroNombre
            txtFiltroNombre.Location = new Point(70, 9);
            txtFiltroNombre.Margin = new Padding(4, 3, 4, 3);
            txtFiltroNombre.Name = "txtFiltroNombre";
            txtFiltroNombre.Size = new Size(150, 23);
            txtFiltroNombre.TabIndex = 1;

            // lblFiltroEspecialidad
            lblFiltroEspecialidad.AutoSize = true;
            lblFiltroEspecialidad.Location = new Point(230, 12);
            lblFiltroEspecialidad.Margin = new Padding(4, 0, 4, 0);
            lblFiltroEspecialidad.Name = "lblFiltroEspecialidad";
            lblFiltroEspecialidad.Size = new Size(79, 15);
            lblFiltroEspecialidad.TabIndex = 2;
            lblFiltroEspecialidad.Text = "Especialidad:";

            // cmbFiltroEspecialidad
            cmbFiltroEspecialidad.Location = new Point(318, 9);
            cmbFiltroEspecialidad.Margin = new Padding(4, 3, 4, 3);
            cmbFiltroEspecialidad.Name = "cmbFiltroEspecialidad";
            cmbFiltroEspecialidad.Size = new Size(150, 23);
            cmbFiltroEspecialidad.TabIndex = 3;

            // btnAplicarFiltros
            btnAplicarFiltros.Location = new Point(478, 9);
            btnAplicarFiltros.Margin = new Padding(4, 3, 4, 3);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(100, 27);
            btnAplicarFiltros.TabIndex = 4;
            btnAplicarFiltros.Text = "🔍 Filtrar";
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            btnAplicarFiltros.Click += BtnAplicarFiltros_Click;

            // btnLimpiarFiltros
            btnLimpiarFiltros.Location = new Point(586, 9);
            btnLimpiarFiltros.Margin = new Padding(4, 3, 4, 3);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(100, 27);
            btnLimpiarFiltros.TabIndex = 5;
            btnLimpiarFiltros.Text = "⟲ Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += BtnLimpiarFiltros_Click;

            // pnlFormulario
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.BackColor = Color.FromArgb(250, 250, 250);
            pnlFormulario.Controls.Add(lblNombres);
            pnlFormulario.Controls.Add(txtNombres);
            pnlFormulario.Controls.Add(lblApellidos);
            pnlFormulario.Controls.Add(txtApellidos);
            pnlFormulario.Controls.Add(lblEmail);
            pnlFormulario.Controls.Add(txtEmail);
            pnlFormulario.Controls.Add(lblTelefono);
            pnlFormulario.Controls.Add(txtTelefono);
            pnlFormulario.Controls.Add(lblLicencia);
            pnlFormulario.Controls.Add(txtLicencia);
            pnlFormulario.Controls.Add(lblEspecialidad);
            pnlFormulario.Controls.Add(cmbEspecialidad);
            pnlFormulario.Controls.Add(lblHorarioInicio);
            pnlFormulario.Controls.Add(dtpHorarioInicio);
            pnlFormulario.Controls.Add(lblHorarioFin);
            pnlFormulario.Controls.Add(dtpHorarioFin);
            pnlFormulario.Controls.Add(lblDias);
            pnlFormulario.Controls.Add(pnlDias);
            pnlFormulario.Location = new Point(12, 322);
            pnlFormulario.Margin = new Padding(4, 3, 4, 3);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(1050, 140);
            pnlFormulario.TabIndex = 3;

            // lblNombres
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(12, 12);
            lblNombres.Margin = new Padding(4, 0, 4, 0);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(59, 15);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres:";

            // txtNombres
            txtNombres.Location = new Point(12, 30);
            txtNombres.Margin = new Padding(4, 3, 4, 3);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(150, 23);
            txtNombres.TabIndex = 1;

            // lblApellidos
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(170, 12);
            lblApellidos.Margin = new Padding(4, 0, 4, 0);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 2;
            lblApellidos.Text = "Apellidos:";

            // txtApellidos
            txtApellidos.Location = new Point(170, 30);
            txtApellidos.Margin = new Padding(4, 3, 4, 3);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(150, 23);
            txtApellidos.TabIndex = 3;

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(328, 12);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";

            // txtEmail
            txtEmail.Location = new Point(328, 30);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 5;

            // lblTelefono
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(536, 12);
            lblTelefono.Margin = new Padding(4, 0, 4, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono:";

            // txtTelefono
            txtTelefono.Location = new Point(536, 30);
            txtTelefono.Margin = new Padding(4, 3, 4, 3);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 23);
            txtTelefono.TabIndex = 7;

            // lblLicencia
            lblLicencia.AutoSize = true;
            lblLicencia.Location = new Point(694, 12);
            lblLicencia.Margin = new Padding(4, 0, 4, 0);
            lblLicencia.Name = "lblLicencia";
            lblLicencia.Size = new Size(54, 15);
            lblLicencia.TabIndex = 8;
            lblLicencia.Text = "Licencia:";

            // txtLicencia
            txtLicencia.Location = new Point(694, 30);
            txtLicencia.Margin = new Padding(4, 3, 4, 3);
            txtLicencia.Name = "txtLicencia";
            txtLicencia.Size = new Size(120, 23);
            txtLicencia.TabIndex = 9;

            // lblEspecialidad
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(822, 12);
            lblEspecialidad.Margin = new Padding(4, 0, 4, 0);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(79, 15);
            lblEspecialidad.TabIndex = 10;
            lblEspecialidad.Text = "Especialidad:";

            // cmbEspecialidad
            cmbEspecialidad.Location = new Point(822, 30);
            cmbEspecialidad.Margin = new Padding(4, 3, 4, 3);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(150, 23);
            cmbEspecialidad.TabIndex = 11;

            // lblHorarioInicio
            lblHorarioInicio.AutoSize = true;
            lblHorarioInicio.Location = new Point(12, 65);
            lblHorarioInicio.Margin = new Padding(4, 0, 4, 0);
            lblHorarioInicio.Name = "lblHorarioInicio";
            lblHorarioInicio.Size = new Size(88, 15);
            lblHorarioInicio.TabIndex = 12;
            lblHorarioInicio.Text = "Horario Inicio:";

            // dtpHorarioInicio
            dtpHorarioInicio.Format = DateTimePickerFormat.Time;
            dtpHorarioInicio.Location = new Point(12, 83);
            dtpHorarioInicio.Margin = new Padding(4, 3, 4, 3);
            dtpHorarioInicio.Name = "dtpHorarioInicio";
            dtpHorarioInicio.ShowUpDown = true;
            dtpHorarioInicio.Size = new Size(150, 23);
            dtpHorarioInicio.TabIndex = 13;

            // lblHorarioFin
            lblHorarioFin.AutoSize = true;
            lblHorarioFin.Location = new Point(170, 65);
            lblHorarioFin.Margin = new Padding(4, 0, 4, 0);
            lblHorarioFin.Name = "lblHorarioFin";
            lblHorarioFin.Size = new Size(75, 15);
            lblHorarioFin.TabIndex = 14;
            lblHorarioFin.Text = "Horario Fin:";

            // dtpHorarioFin
            dtpHorarioFin.Format = DateTimePickerFormat.Time;
            dtpHorarioFin.Location = new Point(170, 83);
            dtpHorarioFin.Margin = new Padding(4, 3, 4, 3);
            dtpHorarioFin.Name = "dtpHorarioFin";
            dtpHorarioFin.ShowUpDown = true;
            dtpHorarioFin.Size = new Size(150, 23);
            dtpHorarioFin.TabIndex = 15;

            // lblDias
            lblDias.AutoSize = true;
            lblDias.Location = new Point(328, 65);
            lblDias.Margin = new Padding(4, 0, 4, 0);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(103, 15);
            lblDias.TabIndex = 16;
            lblDias.Text = "Días de Atención:";

            // pnlDias
            pnlDias.Location = new Point(328, 83);
            pnlDias.Margin = new Padding(4, 3, 4, 3);
            pnlDias.Name = "pnlDias";
            pnlDias.Size = new Size(700, 30);
            pnlDias.TabIndex = 17;
            pnlDias.Controls.Add(chkLunes);
            pnlDias.Controls.Add(chkMartes);
            pnlDias.Controls.Add(chkMiercoles);
            pnlDias.Controls.Add(chkJueves);
            pnlDias.Controls.Add(chkViernes);
            pnlDias.Controls.Add(chkSabado);
            pnlDias.Controls.Add(chkDomingo);

            // chkLunes
            chkLunes.AutoSize = true;
            chkLunes.Location = new Point(5, 5);
            chkLunes.Name = "chkLunes";
            chkLunes.Size = new Size(58, 19);
            chkLunes.TabIndex = 0;
            chkLunes.Text = "Lunes";

            // chkMartes
            chkMartes.AutoSize = true;
            chkMartes.Location = new Point(70, 5);
            chkMartes.Name = "chkMartes";
            chkMartes.Size = new Size(62, 19);
            chkMartes.TabIndex = 1;
            chkMartes.Text = "Martes";

            // chkMiercoles
            chkMiercoles.AutoSize = true;
            chkMiercoles.Location = new Point(140, 5);
            chkMiercoles.Name = "chkMiercoles";
            chkMiercoles.Size = new Size(76, 19);
            chkMiercoles.TabIndex = 2;
            chkMiercoles.Text = "Miércoles";

            // chkJueves
            chkJueves.AutoSize = true;
            chkJueves.Location = new Point(225, 5);
            chkJueves.Name = "chkJueves";
            chkJueves.Size = new Size(60, 19);
            chkJueves.TabIndex = 3;
            chkJueves.Text = "Jueves";

            // chkViernes
            chkViernes.AutoSize = true;
            chkViernes.Location = new Point(295, 5);
            chkViernes.Name = "chkViernes";
            chkViernes.Size = new Size(63, 19);
            chkViernes.TabIndex = 4;
            chkViernes.Text = "Viernes";

            // chkSabado
            chkSabado.AutoSize = true;
            chkSabado.Location = new Point(370, 5);
            chkSabado.Name = "chkSabado";
            chkSabado.Size = new Size(61, 19);
            chkSabado.TabIndex = 5;
            chkSabado.Text = "Sábado";

            // chkDomingo
            chkDomingo.AutoSize = true;
            chkDomingo.Location = new Point(440, 5);
            chkDomingo.Name = "chkDomingo";
            chkDomingo.Size = new Size(70, 19);
            chkDomingo.TabIndex = 6;
            chkDomingo.Text = "Domingo";

            // pnlBotones
            pnlBotones.Controls.Add(btnAgregar);
            pnlBotones.Controls.Add(btnActualizar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnLimpiar);
            pnlBotones.Location = new Point(12, 468);
            pnlBotones.Margin = new Padding(4, 3, 4, 3);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(1050, 50);
            pnlBotones.TabIndex = 4;

            // btnAgregar
            btnAgregar.Location = new Point(12, 12);
            btnAgregar.Margin = new Padding(4, 3, 4, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 30);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "✚ Agregar";
            btnAgregar.BackColor = Color.FromArgb(76, 175, 80);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;

            // btnActualizar
            btnActualizar.Location = new Point(140, 12);
            btnActualizar.Margin = new Padding(4, 3, 4, 3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 30);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "✎ Actualizar";
            btnActualizar.BackColor = Color.FromArgb(33, 150, 243);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;

            // btnEliminar
            btnEliminar.Location = new Point(268, 12);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 30);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "✖ Eliminar";
            btnEliminar.BackColor = Color.FromArgb(244, 67, 54);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            // btnLimpiar
            btnLimpiar.Location = new Point(396, 12);
            btnLimpiar.Margin = new Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 30);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "⟲ Limpiar";
            btnLimpiar.BackColor = Color.FromArgb(158, 158, 158);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // MedicosForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 534);
            Controls.Add(lblTitulo);
            Controls.Add(dgvMedicos);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlBotones);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MedicosForm";
            Text = "Gestión de Médicos";
            BackColor = Color.FromArgb(250, 250, 250);
            Load += MedicosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).EndInit();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
