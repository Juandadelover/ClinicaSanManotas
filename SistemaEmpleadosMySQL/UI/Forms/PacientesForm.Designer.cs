namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class PacientesForm
    {
        private System.ComponentModel.IContainer components = null;

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
            dgvPacientes = new DataGridView();
            pnlFiltro = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            lblFiltroGenero = new Label();
            cmbFiltroGenero = new ComboBox();
            lblFiltroEdadMin = new Label();
            nudFiltroEdadMin = new NumericUpDown();
            lblFiltroEdadMax = new Label();
            nudFiltroEdadMax = new NumericUpDown();
            lblFiltroEPS = new Label();
            cmbFiltroEPS = new ComboBox();
            lblFiltroFechaReg = new Label();
            dtpFiltroFechaReg = new DateTimePicker();
            btnAplicarFiltrosPac = new Button();
            btnLimpiarFiltrosPac = new Button();
            pnlFormulario = new Panel();
            lblNombres = new Label();
            txtNombres = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            lblEPS = new Label();
            cmbEPS = new ComboBox();
            lblGenero = new Label();
            cmbGenero = new ComboBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            pnlBotones = new Panel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            pnlPaginacion = new Panel();
            lblPagina = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFiltroEdadMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFiltroEdadMax).BeginInit();
            pnlFormulario.SuspendLayout();
            pnlBotones.SuspendLayout();
            pnlPaginacion.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 12);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(178, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión Pacientes";
            // 
            // dgvPacientes
            // 
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Location = new Point(12, 46);
            dgvPacientes.Margin = new Padding(4, 3, 4, 3);
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.Size = new Size(1027, 199);
            dgvPacientes.TabIndex = 1;
            // 
            // pnlFiltro
            // 
            pnlFiltro.BackColor = SystemColors.ControlLight;
            pnlFiltro.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltro.Controls.Add(lblBuscar);
            pnlFiltro.Controls.Add(txtBuscar);
            pnlFiltro.Controls.Add(btnBuscar);
            pnlFiltro.Controls.Add(lblFiltroGenero);
            pnlFiltro.Controls.Add(cmbFiltroGenero);
            pnlFiltro.Controls.Add(lblFiltroEdadMin);
            pnlFiltro.Controls.Add(nudFiltroEdadMin);
            pnlFiltro.Controls.Add(lblFiltroEdadMax);
            pnlFiltro.Controls.Add(nudFiltroEdadMax);
            pnlFiltro.Controls.Add(lblFiltroEPS);
            pnlFiltro.Controls.Add(cmbFiltroEPS);
            pnlFiltro.Controls.Add(lblFiltroFechaReg);
            pnlFiltro.Controls.Add(dtpFiltroFechaReg);
            pnlFiltro.Controls.Add(btnAplicarFiltrosPac);
            pnlFiltro.Controls.Add(btnLimpiarFiltrosPac);
            pnlFiltro.Location = new Point(12, 241);
            pnlFiltro.Margin = new Padding(4, 3, 4, 3);
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.Size = new Size(1026, 69);
            pnlFiltro.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 12);
            lblBuscar.Margin = new Padding(4, 0, 4, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(70, 9);
            txtBuscar.Margin = new Padding(4, 3, 4, 3);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(139, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(216, 9);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(70, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblFiltroGenero
            // 
            lblFiltroGenero.AutoSize = true;
            lblFiltroGenero.Location = new Point(292, 12);
            lblFiltroGenero.Margin = new Padding(4, 0, 4, 0);
            lblFiltroGenero.Name = "lblFiltroGenero";
            lblFiltroGenero.Size = new Size(48, 15);
            lblFiltroGenero.TabIndex = 3;
            lblFiltroGenero.Text = "Género:";
            // 
            // cmbFiltroGenero
            // 
            cmbFiltroGenero.Location = new Point(350, 9);
            cmbFiltroGenero.Margin = new Padding(4, 3, 4, 3);
            cmbFiltroGenero.Name = "cmbFiltroGenero";
            cmbFiltroGenero.Size = new Size(93, 23);
            cmbFiltroGenero.TabIndex = 4;
            // 
            // lblFiltroEdadMin
            // 
            lblFiltroEdadMin.AutoSize = true;
            lblFiltroEdadMin.Location = new Point(449, 12);
            lblFiltroEdadMin.Margin = new Padding(4, 0, 4, 0);
            lblFiltroEdadMin.Name = "lblFiltroEdadMin";
            lblFiltroEdadMin.Size = new Size(60, 15);
            lblFiltroEdadMin.TabIndex = 5;
            lblFiltroEdadMin.Text = "Edad Min:";
            // 
            // nudFiltroEdadMin
            // 
            nudFiltroEdadMin.Location = new Point(519, 9);
            nudFiltroEdadMin.Margin = new Padding(4, 3, 4, 3);
            nudFiltroEdadMin.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudFiltroEdadMin.Name = "nudFiltroEdadMin";
            nudFiltroEdadMin.Size = new Size(58, 23);
            nudFiltroEdadMin.TabIndex = 6;
            // 
            // lblFiltroEdadMax
            // 
            lblFiltroEdadMax.AutoSize = true;
            lblFiltroEdadMax.Location = new Point(581, 12);
            lblFiltroEdadMax.Margin = new Padding(4, 0, 4, 0);
            lblFiltroEdadMax.Name = "lblFiltroEdadMax";
            lblFiltroEdadMax.Size = new Size(61, 15);
            lblFiltroEdadMax.TabIndex = 7;
            lblFiltroEdadMax.Text = "Edad Max:";
            // 
            // nudFiltroEdadMax
            // 
            nudFiltroEdadMax.Location = new Point(651, 9);
            nudFiltroEdadMax.Margin = new Padding(4, 3, 4, 3);
            nudFiltroEdadMax.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudFiltroEdadMax.Name = "nudFiltroEdadMax";
            nudFiltroEdadMax.Size = new Size(58, 23);
            nudFiltroEdadMax.TabIndex = 8;
            nudFiltroEdadMax.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // lblFiltroEPS
            // 
            lblFiltroEPS.AutoSize = true;
            lblFiltroEPS.Location = new Point(712, 12);
            lblFiltroEPS.Margin = new Padding(4, 0, 4, 0);
            lblFiltroEPS.Name = "lblFiltroEPS";
            lblFiltroEPS.Size = new Size(29, 15);
            lblFiltroEPS.TabIndex = 9;
            lblFiltroEPS.Text = "EPS:";
            // 
            // cmbFiltroEPS
            // 
            cmbFiltroEPS.Location = new Point(756, 9);
            cmbFiltroEPS.Margin = new Padding(4, 3, 4, 3);
            cmbFiltroEPS.Name = "cmbFiltroEPS";
            cmbFiltroEPS.Size = new Size(93, 23);
            cmbFiltroEPS.TabIndex = 10;
            // 
            // lblFiltroFechaReg
            // 
            lblFiltroFechaReg.AutoSize = true;
            lblFiltroFechaReg.Location = new Point(12, 29);
            lblFiltroFechaReg.Margin = new Padding(4, 0, 4, 0);
            lblFiltroFechaReg.Name = "lblFiltroFechaReg";
            lblFiltroFechaReg.Size = new Size(42, 15);
            lblFiltroFechaReg.TabIndex = 11;
            lblFiltroFechaReg.Text = "Desde:";
            // 
            // dtpFiltroFechaReg
            // 
            dtpFiltroFechaReg.Format = DateTimePickerFormat.Short;
            dtpFiltroFechaReg.Location = new Point(70, 29);
            dtpFiltroFechaReg.Margin = new Padding(4, 3, 4, 3);
            dtpFiltroFechaReg.Name = "dtpFiltroFechaReg";
            dtpFiltroFechaReg.Size = new Size(139, 23);
            dtpFiltroFechaReg.TabIndex = 12;
            // 
            // btnAplicarFiltrosPac
            // 
            btnAplicarFiltrosPac.Location = new Point(216, 34);
            btnAplicarFiltrosPac.Margin = new Padding(4, 3, 4, 3);
            btnAplicarFiltrosPac.Name = "btnAplicarFiltrosPac";
            btnAplicarFiltrosPac.Size = new Size(88, 27);
            btnAplicarFiltrosPac.TabIndex = 13;
            btnAplicarFiltrosPac.Text = "🔍 Filtrar";
            btnAplicarFiltrosPac.UseVisualStyleBackColor = true;
            btnAplicarFiltrosPac.Click += BtnAplicarFiltrosPac_Click;
            // 
            // btnLimpiarFiltrosPac
            // 
            btnLimpiarFiltrosPac.Location = new Point(308, 33);
            btnLimpiarFiltrosPac.Margin = new Padding(4, 3, 4, 3);
            btnLimpiarFiltrosPac.Name = "btnLimpiarFiltrosPac";
            btnLimpiarFiltrosPac.Size = new Size(88, 27);
            btnLimpiarFiltrosPac.TabIndex = 14;
            btnLimpiarFiltrosPac.Text = "⟲ Limpiar";
            btnLimpiarFiltrosPac.UseVisualStyleBackColor = true;
            btnLimpiarFiltrosPac.Click += BtnLimpiarFiltrosPac_Click;
            // 
            // pnlFormulario
            // 
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(lblNombres);
            pnlFormulario.Controls.Add(txtNombres);
            pnlFormulario.Controls.Add(lblApellidos);
            pnlFormulario.Controls.Add(txtApellidos);
            pnlFormulario.Controls.Add(lblEmail);
            pnlFormulario.Controls.Add(txtEmail);
            pnlFormulario.Controls.Add(lblTelefono);
            pnlFormulario.Controls.Add(txtTelefono);
            pnlFormulario.Controls.Add(lblDocumento);
            pnlFormulario.Controls.Add(txtDocumento);
            pnlFormulario.Controls.Add(lblDireccion);
            pnlFormulario.Controls.Add(txtDireccion);
            pnlFormulario.Controls.Add(lblCiudad);
            pnlFormulario.Controls.Add(txtCiudad);
            pnlFormulario.Controls.Add(lblEPS);
            pnlFormulario.Controls.Add(cmbEPS);
            pnlFormulario.Controls.Add(lblGenero);
            pnlFormulario.Controls.Add(cmbGenero);
            pnlFormulario.Controls.Add(lblFechaNacimiento);
            pnlFormulario.Controls.Add(dtpFechaNacimiento);
            pnlFormulario.Location = new Point(12, 312);
            pnlFormulario.Margin = new Padding(4, 3, 4, 3);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(1026, 161);
            pnlFormulario.TabIndex = 3;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(12, 12);
            lblNombres.Margin = new Padding(4, 0, 4, 0);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(59, 15);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres:";
            // 
            // txtNombres
            // 
            txtNombres.Enabled = false;
            txtNombres.Location = new Point(82, 12);
            txtNombres.Margin = new Padding(4, 3, 4, 3);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(174, 23);
            txtNombres.TabIndex = 1;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(292, 12);
            lblApellidos.Margin = new Padding(4, 0, 4, 0);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 2;
            lblApellidos.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            txtApellidos.Enabled = false;
            txtApellidos.Location = new Point(362, 12);
            txtApellidos.Margin = new Padding(4, 3, 4, 3);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(174, 23);
            txtApellidos.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 46);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(82, 46);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(174, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(292, 46);
            lblTelefono.Margin = new Padding(4, 0, 4, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Enabled = false;
            txtTelefono.Location = new Point(362, 46);
            txtTelefono.Margin = new Padding(4, 3, 4, 3);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(174, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(12, 81);
            lblDocumento.Margin = new Padding(4, 0, 4, 0);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(73, 15);
            lblDocumento.TabIndex = 8;
            lblDocumento.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Enabled = false;
            txtDocumento.Location = new Point(82, 81);
            txtDocumento.Margin = new Padding(4, 3, 4, 3);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(174, 23);
            txtDocumento.TabIndex = 9;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(292, 81);
            lblDireccion.Margin = new Padding(4, 0, 4, 0);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 10;
            lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Enabled = false;
            txtDireccion.Location = new Point(362, 81);
            txtDireccion.Margin = new Padding(4, 3, 4, 3);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(174, 23);
            txtDireccion.TabIndex = 11;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(12, 115);
            lblCiudad.Margin = new Padding(4, 0, 4, 0);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(48, 15);
            lblCiudad.TabIndex = 12;
            lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            txtCiudad.Enabled = false;
            txtCiudad.Location = new Point(82, 115);
            txtCiudad.Margin = new Padding(4, 3, 4, 3);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(174, 23);
            txtCiudad.TabIndex = 13;
            // 
            // lblEPS
            // 
            lblEPS.AutoSize = true;
            lblEPS.Location = new Point(292, 115);
            lblEPS.Margin = new Padding(4, 0, 4, 0);
            lblEPS.Name = "lblEPS";
            lblEPS.Size = new Size(29, 15);
            lblEPS.TabIndex = 14;
            lblEPS.Text = "EPS:";
            // 
            // cmbEPS
            // 
            cmbEPS.Enabled = false;
            cmbEPS.Location = new Point(362, 115);
            cmbEPS.Margin = new Padding(4, 3, 4, 3);
            cmbEPS.Name = "cmbEPS";
            cmbEPS.Size = new Size(174, 23);
            cmbEPS.TabIndex = 15;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(583, 12);
            lblGenero.Margin = new Padding(4, 0, 4, 0);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(48, 15);
            lblGenero.TabIndex = 16;
            lblGenero.Text = "Género:";
            // 
            // cmbGenero
            // 
            cmbGenero.Enabled = false;
            cmbGenero.Items.AddRange(new object[] { "M", "F", "O" });
            cmbGenero.Location = new Point(653, 12);
            cmbGenero.Margin = new Padding(4, 3, 4, 3);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(116, 23);
            cmbGenero.TabIndex = 17;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(544, 52);
            lblFechaNacimiento.Margin = new Padding(4, 0, 4, 0);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(106, 15);
            lblFechaNacimiento.TabIndex = 18;
            lblFechaNacimiento.Text = "Fecha Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Enabled = false;
            dtpFechaNacimiento.Location = new Point(653, 46);
            dtpFechaNacimiento.Margin = new Padding(4, 3, 4, 3);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(116, 23);
            dtpFechaNacimiento.TabIndex = 19;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Location = new Point(12, 531);
            pnlBotones.Margin = new Padding(4, 3, 4, 3);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(1027, 46);
            pnlBotones.TabIndex = 4;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 12);
            btnNuevo.Margin = new Padding(4, 3, 4, 3);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(88, 27);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Enabled = false;
            btnGuardar.Location = new Point(117, 12);
            btnGuardar.Margin = new Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(88, 27);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(222, 12);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(88, 27);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(327, 12);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 27);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Enabled = false;
            btnCancelar.Location = new Point(432, 12);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 27);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlPaginacion
            // 
            pnlPaginacion.Controls.Add(lblPagina);
            pnlPaginacion.Location = new Point(12, 485);
            pnlPaginacion.Margin = new Padding(4, 3, 4, 3);
            pnlPaginacion.Name = "pnlPaginacion";
            pnlPaginacion.Size = new Size(1027, 35);
            pnlPaginacion.TabIndex = 5;
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(12, 12);
            lblPagina.Margin = new Padding(4, 0, 4, 0);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(55, 15);
            lblPagina.TabIndex = 0;
            lblPagina.Text = "Página: 1";
            // 
            // PacientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 600);
            Controls.Add(lblTitulo);
            Controls.Add(dgvPacientes);
            Controls.Add(pnlFiltro);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlBotones);
            Controls.Add(pnlPaginacion);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PacientesForm";
            Text = "Gestión de Pacientes";
            FormClosing += PacientesForm_FormClosing;
            Load += PacientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            pnlFiltro.ResumeLayout(false);
            pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFiltroEdadMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFiltroEdadMax).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlBotones.ResumeLayout(false);
            pnlPaginacion.ResumeLayout(false);
            pnlPaginacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        
        // Controles para Filtros Avanzados
        private System.Windows.Forms.Label lblFiltroGenero;
        private System.Windows.Forms.ComboBox cmbFiltroGenero;
        private System.Windows.Forms.Label lblFiltroEdadMin;
        private System.Windows.Forms.NumericUpDown nudFiltroEdadMin;
        private System.Windows.Forms.Label lblFiltroEdadMax;
        private System.Windows.Forms.NumericUpDown nudFiltroEdadMax;
        private System.Windows.Forms.Label lblFiltroEPS;
        private System.Windows.Forms.ComboBox cmbFiltroEPS;
        private System.Windows.Forms.Label lblFiltroFechaReg;
        private System.Windows.Forms.DateTimePicker dtpFiltroFechaReg;
        private System.Windows.Forms.Button btnAplicarFiltrosPac;
        private System.Windows.Forms.Button btnLimpiarFiltrosPac;
        
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label lblEPS;
        private System.Windows.Forms.ComboBox cmbEPS;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label lblPagina;
    }
}
