namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class CitasForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvCitas;
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
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCitas
            // 
            dgvCitas.Location = new Point(12, 100);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.Size = new Size(760, 250);
            dgvCitas.TabIndex = 1;
            // 
            // cmbPaciente
            // 
            cmbPaciente.Location = new Point(12, 370);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(150, 23);
            cmbPaciente.TabIndex = 2;
            // 
            // cmbMedico
            // 
            cmbMedico.Location = new Point(170, 370);
            cmbMedico.Name = "cmbMedico";
            cmbMedico.Size = new Size(150, 23);
            cmbMedico.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.Location = new Point(328, 370);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.TabIndex = 4;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(486, 370);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 5;
            // 
            // txtHora
            // 
            txtHora.Location = new Point(644, 370);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(128, 23);
            txtHora.TabIndex = 6;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(12, 401);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(760, 23);
            txtMotivo.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 430);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(120, 430);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(228, 430);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(336, 430);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 30);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(12, 465);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total: 0";
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
            pnlFiltros.Location = new Point(12, 12);
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
            btnAplicarFiltros.BackColor = SystemColors.ControlDark;
            btnAplicarFiltros.Location = new Point(555, 10);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(95, 23);
            btnAplicarFiltros.TabIndex = 6;
            btnAplicarFiltros.Text = "🔍 Filtrar";
            btnAplicarFiltros.UseVisualStyleBackColor = false;
            btnAplicarFiltros.Click += BtnAplicarFiltros_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(660, 10);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(95, 23);
            btnLimpiarFiltros.TabIndex = 7;
            btnLimpiarFiltros.Text = "⟲ Limpiar";
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
            ClientSize = new Size(783, 477);
            Controls.Add(pnlFiltros);
            Controls.Add(dgvCitas);
            Controls.Add(cmbPaciente);
            Controls.Add(cmbMedico);
            Controls.Add(cmbEstado);
            Controls.Add(dtpFecha);
            Controls.Add(txtHora);
            Controls.Add(txtMotivo);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblTotal);
            Name = "CitasForm";
            Text = "Gestión de Citas";
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            pnlFiltros.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
