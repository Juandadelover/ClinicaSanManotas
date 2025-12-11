namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class CitasForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grpEdicion;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblMotivo;

        // Controles para Filtros Avanzados
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Label lblFiltroFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFiltroFechaInicio;
        private System.Windows.Forms.Label lblFiltroFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFiltroFechaFin;
        private System.Windows.Forms.Label lblFiltroPaciente;
        private System.Windows.Forms.ComboBox cmbFiltroPaciente;
        private System.Windows.Forms.Label lblFiltroMedico;
        private System.Windows.Forms.ComboBox cmbFiltroMedico;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;

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
            dgvCitas = new DataGridView();
            cmbPaciente = new ComboBox();
            cmbMedico = new ComboBox();
            cmbEstado = new ComboBox();
            dtpFecha = new DateTimePicker();
            txtHora = new TextBox();
            txtMotivo = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblTotal = new Label();
            grpEdicion = new GroupBox();
            lblPaciente = new Label();
            lblMedico = new Label();
            lblEstado = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            lblMotivo = new Label();
            pnlFiltros = new Panel();
            lblFiltroEstado = new Label();
            cmbFiltroEstado = new ComboBox();
            lblFiltroFechaInicio = new Label();
            dtpFiltroFechaInicio = new DateTimePicker();
            lblFiltroFechaFin = new Label();
            dtpFiltroFechaFin = new DateTimePicker();
            btnAplicarFiltros = new Button();
            btnLimpiarFiltros = new Button();
            lblFiltroPaciente = new Label();
            cmbFiltroPaciente = new ComboBox();
            lblFiltroMedico = new Label();
            cmbFiltroMedico = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            grpEdicion.SuspendLayout();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(11, 12);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Citas";
            // 
            // dgvCitas
            // 
            dgvCitas.Location = new Point(168, 125);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.Size = new Size(760, 250);
            dgvCitas.TabIndex = 1;
            dgvCitas.SelectionChanged += dgvCitas_SelectionChanged;
            // 
            // cmbPaciente
            // 
            cmbPaciente.BackColor = Color.WhiteSmoke;
            cmbPaciente.Location = new Point(6, 38);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(150, 23);
            cmbPaciente.TabIndex = 2;
            // 
            // cmbMedico
            // 
            cmbMedico.BackColor = Color.WhiteSmoke;
            cmbMedico.Location = new Point(164, 38);
            cmbMedico.Name = "cmbMedico";
            cmbMedico.Size = new Size(150, 23);
            cmbMedico.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.BackColor = Color.WhiteSmoke;
            cmbEstado.Location = new Point(322, 38);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.TabIndex = 4;
            // 
            // dtpFecha
            // 
            dtpFecha.BackColor = Color.WhiteSmoke;
            dtpFecha.Location = new Point(480, 38);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 5;
            // 
            // txtHora
            // 
            txtHora.BackColor = Color.WhiteSmoke;
            txtHora.Location = new Point(638, 38);
            txtHora.Name = "txtHora";
            txtHora.PlaceholderText = "09:30";
            txtHora.Size = new Size(128, 23);
            txtHora.TabIndex = 6;
            // 
            // txtMotivo
            // 
            txtMotivo.BackColor = Color.WhiteSmoke;
            txtMotivo.Location = new Point(6, 82);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.PlaceholderText = "Ej: Consulta general, dolor de cabeza...";
            txtMotivo.Size = new Size(760, 23);
            txtMotivo.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(34, 139, 34);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(6, 110);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(30, 144, 255);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(114, 110);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "✏️ Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 20, 60);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(222, 110);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(169, 169, 169);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.Black;
            btnLimpiar.Location = new Point(330, 110);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 30);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "\U0001f9f9 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(168, 490);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total: 0";
            // 
            // grpEdicion
            // 
            grpEdicion.Controls.Add(lblPaciente);
            grpEdicion.Controls.Add(cmbPaciente);
            grpEdicion.Controls.Add(lblMedico);
            grpEdicion.Controls.Add(cmbMedico);
            grpEdicion.Controls.Add(lblEstado);
            grpEdicion.Controls.Add(cmbEstado);
            grpEdicion.Controls.Add(lblFecha);
            grpEdicion.Controls.Add(dtpFecha);
            grpEdicion.Controls.Add(lblHora);
            grpEdicion.Controls.Add(txtHora);
            grpEdicion.Controls.Add(lblMotivo);
            grpEdicion.Controls.Add(txtMotivo);
            grpEdicion.Controls.Add(btnAgregar);
            grpEdicion.Controls.Add(btnActualizar);
            grpEdicion.Controls.Add(btnEliminar);
            grpEdicion.Controls.Add(btnLimpiar);
            grpEdicion.Location = new Point(168, 385);
            grpEdicion.Name = "grpEdicion";
            grpEdicion.Size = new Size(760, 140);
            grpEdicion.TabIndex = 13;
            grpEdicion.TabStop = false;
            grpEdicion.Text = "Editar Cita";
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(6, 20);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(118, 15);
            lblPaciente.TabIndex = 20;
            lblPaciente.Text = "Seleccionar Paciente:";
            // 
            // lblMedico
            // 
            lblMedico.AutoSize = true;
            lblMedico.Location = new Point(164, 20);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(113, 15);
            lblMedico.TabIndex = 21;
            lblMedico.Text = "Seleccionar Médico:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(322, 20);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(97, 15);
            lblEstado.TabIndex = 22;
            lblEstado.Text = "Estado de la Cita:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(480, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(93, 15);
            lblFecha.TabIndex = 23;
            lblFecha.Text = "Fecha de la Cita:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(638, 20);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(142, 15);
            lblHora.TabIndex = 24;
            lblHora.Text = "Hora de la Cita (HH:MM):";
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(6, 64);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(126, 15);
            lblMotivo.TabIndex = 25;
            lblMotivo.Text = "Motivo de la Consulta:";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = SystemColors.ControlLight;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(lblFiltroEstado);
            pnlFiltros.Controls.Add(cmbFiltroEstado);
            pnlFiltros.Controls.Add(lblFiltroFechaInicio);
            pnlFiltros.Controls.Add(dtpFiltroFechaInicio);
            pnlFiltros.Controls.Add(lblFiltroFechaFin);
            pnlFiltros.Controls.Add(dtpFiltroFechaFin);
            pnlFiltros.Controls.Add(btnAplicarFiltros);
            pnlFiltros.Controls.Add(btnLimpiarFiltros);
            pnlFiltros.Controls.Add(lblFiltroPaciente);
            pnlFiltros.Controls.Add(cmbFiltroPaciente);
            pnlFiltros.Controls.Add(lblFiltroMedico);
            pnlFiltros.Controls.Add(cmbFiltroMedico);
            pnlFiltros.Location = new Point(168, 37);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(760, 80);
            pnlFiltros.TabIndex = 0;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.Location = new Point(10, 10);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(50, 20);
            lblFiltroEstado.TabIndex = 0;
            lblFiltroEstado.Text = "Estado:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.Location = new Point(65, 10);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(110, 23);
            cmbFiltroEstado.TabIndex = 1;
            // 
            // lblFiltroFechaInicio
            // 
            lblFiltroFechaInicio.Location = new Point(185, 10);
            lblFiltroFechaInicio.Name = "lblFiltroFechaInicio";
            lblFiltroFechaInicio.Size = new Size(50, 20);
            lblFiltroFechaInicio.TabIndex = 2;
            lblFiltroFechaInicio.Text = "Desde:";
            // 
            // dtpFiltroFechaInicio
            // 
            dtpFiltroFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFiltroFechaInicio.Location = new Point(240, 10);
            dtpFiltroFechaInicio.Name = "dtpFiltroFechaInicio";
            dtpFiltroFechaInicio.Size = new Size(120, 23);
            dtpFiltroFechaInicio.TabIndex = 3;
            // 
            // lblFiltroFechaFin
            // 
            lblFiltroFechaFin.Location = new Point(370, 10);
            lblFiltroFechaFin.Name = "lblFiltroFechaFin";
            lblFiltroFechaFin.Size = new Size(50, 20);
            lblFiltroFechaFin.TabIndex = 4;
            lblFiltroFechaFin.Text = "Hasta:";
            // 
            // dtpFiltroFechaFin
            // 
            dtpFiltroFechaFin.Format = DateTimePickerFormat.Short;
            dtpFiltroFechaFin.Location = new Point(425, 10);
            dtpFiltroFechaFin.Name = "dtpFiltroFechaFin";
            dtpFiltroFechaFin.Size = new Size(120, 23);
            dtpFiltroFechaFin.TabIndex = 5;
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.BackColor = Color.FromArgb(30, 144, 255);
            btnAplicarFiltros.FlatStyle = FlatStyle.Flat;
            btnAplicarFiltros.ForeColor = Color.White;
            btnAplicarFiltros.Location = new Point(555, 10);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(95, 23);
            btnAplicarFiltros.TabIndex = 6;
            btnAplicarFiltros.Text = "🔍 Aplicar";
            btnAplicarFiltros.UseVisualStyleBackColor = false;
            btnAplicarFiltros.Click += BtnAplicarFiltros_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(169, 169, 169);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.ForeColor = Color.Black;
            btnLimpiarFiltros.Location = new Point(660, 10);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(95, 23);
            btnLimpiarFiltros.TabIndex = 7;
            btnLimpiarFiltros.Text = "⟲ Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += BtnLimpiarFiltros_Click;
            // 
            // lblFiltroPaciente
            // 
            lblFiltroPaciente.Location = new Point(10, 40);
            lblFiltroPaciente.Name = "lblFiltroPaciente";
            lblFiltroPaciente.Size = new Size(55, 20);
            lblFiltroPaciente.TabIndex = 8;
            lblFiltroPaciente.Text = "Paciente:";
            // 
            // cmbFiltroPaciente
            // 
            cmbFiltroPaciente.Location = new Point(70, 40);
            cmbFiltroPaciente.Name = "cmbFiltroPaciente";
            cmbFiltroPaciente.Size = new Size(150, 23);
            cmbFiltroPaciente.TabIndex = 9;
            // 
            // lblFiltroMedico
            // 
            lblFiltroMedico.Location = new Point(230, 40);
            lblFiltroMedico.Name = "lblFiltroMedico";
            lblFiltroMedico.Size = new Size(50, 20);
            lblFiltroMedico.TabIndex = 10;
            lblFiltroMedico.Text = "Médico:";
            // 
            // cmbFiltroMedico
            // 
            cmbFiltroMedico.Location = new Point(285, 40);
            cmbFiltroMedico.Name = "cmbFiltroMedico";
            cmbFiltroMedico.Size = new Size(150, 23);
            cmbFiltroMedico.TabIndex = 11;
            // 
            // CitasForm
            // 
            ClientSize = new Size(1047, 533);
            Controls.Add(lblTitulo);
            Controls.Add(pnlFiltros);
            Controls.Add(dgvCitas);
            Controls.Add(grpEdicion);
            Controls.Add(lblTotal);
            Name = "CitasForm";
            Text = "Gestión de Citas";
            Load += CitasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            grpEdicion.ResumeLayout(false);
            grpEdicion.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
