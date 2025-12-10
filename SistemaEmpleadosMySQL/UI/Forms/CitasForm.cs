using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.DTO;
using SistemaEmpleadosMySQL.Helpers;
using SistemaEmpleadosMySQL.Model;
using SistemaEmpleadosMySQL.Repositories;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario de gestión de Citas - CRUD Completo
    /// </summary>
    public partial class CitasForm : Form
    {
        private UnitOfWork _unitOfWork;
        private Cita? _citaActual;

        public CitasForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void CitasForm_Load(object sender, EventArgs e)
        {
            this.Text = "CLINICA SAN MANOTAS - Gestión de Citas";
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigurarDataGridView();
            CargarPacientes();
            CargarMedicos();
            CargarEstados();
            CargarCitasEnFiltros();
            CargarCitas();
            LimpiarFormulario();

            LogHelper.Info("Formulario de citas cargado");
        }

        private void ConfigurarDataGridView()
        {
            if (dgvCitas.Columns.Count == 0)
            {
                dgvCitas.Columns.Add("CitaId", "ID");
                dgvCitas.Columns.Add("NombrePaciente", "Paciente");
                dgvCitas.Columns.Add("NombreMedico", "Médico");
                dgvCitas.Columns.Add("Especialidad", "Especialidad");
                dgvCitas.Columns.Add("Fecha", "Fecha");
                dgvCitas.Columns.Add("Hora", "Hora");
                dgvCitas.Columns.Add("Motivo", "Motivo");
                dgvCitas.Columns.Add("Estado", "Estado");

                dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void CargarPacientes()
        {
            try
            {
                var pacientes = _unitOfWork.Pacientes.GetAll();
                if (pacientes != null)
                {
                    cmbPaciente.DataSource = pacientes;
                    cmbPaciente.DisplayMember = "Nombres";
                    cmbPaciente.ValueMember = "PacienteId";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando pacientes", ex);
            }
        }

        private void CargarMedicos()
        {
            try
            {
                var medicos = _unitOfWork.Medicos.GetAll();
                if (medicos != null)
                {
                    cmbMedico.DataSource = medicos;
                    cmbMedico.DisplayMember = "Nombres";
                    cmbMedico.ValueMember = "MedicoId";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando médicos", ex);
            }
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmada");
            cmbEstado.Items.Add("Realizada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0;

            // Cargar estados en combo de filtro
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Pendiente");
            cmbFiltroEstado.Items.Add("Confirmada");
            cmbFiltroEstado.Items.Add("Realizada");
            cmbFiltroEstado.Items.Add("Cancelada");
            cmbFiltroEstado.SelectedIndex = 0;
        }

        private void CargarCitasEnFiltros()
        {
            try
            {
                cmbFiltroPaciente.Items.Add("Todos");
                var pacientes = _unitOfWork.Pacientes.GetAll();
                if (pacientes != null)
                {
                    foreach (var p in pacientes)
                    {
                        cmbFiltroPaciente.Items.Add(p);
                    }
                }

                cmbFiltroMedico.Items.Add("Todos");
                var medicos = _unitOfWork.Medicos.GetAll();
                if (medicos != null)
                {
                    foreach (var m in medicos)
                    {
                        cmbFiltroMedico.Items.Add(m);
                    }
                }

                cmbFiltroPaciente.SelectedIndex = 0;
                cmbFiltroMedico.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando combos de filtro", ex);
            }
        }

        private void CargarCitas()
        {
            try
            {
                dgvCitas.Rows.Clear();
                
                var citas = _unitOfWork.Citas.GetAll();

                int totalCitas = 0;
                if (citas != null)
                {
                    totalCitas = citas.Count();
                    
                    foreach (var cita in citas)
                    {
                        var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                        var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                        var especialidad = medico != null ? _unitOfWork.Especialidades.GetById(medico.EspecialidadId) : null;

                        dgvCitas.Rows.Add(
                            cita.CitaId,
                            paciente?.Nombres ?? "N/A",
                            medico?.Nombres ?? "N/A",
                            especialidad?.Nombre ?? "N/A",
                            cita.Fecha.ToShortDateString(),
                            cita.Hora,
                            cita.Motivo,
                            cita.Estado
                        );
                    }
                }
                lblTotal.Text = $"Total: {totalCitas}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR al cargar citas:\n\n{ex.Message}\n\nTipo: {ex.GetType().Name}\n\nStack:\n{ex.StackTrace}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotal.Text = "Total: ERROR";
            }
        }

        /// <summary>
        /// Filtrar citas por estado
        /// </summary>
        public void FiltrarPorEstado(string estado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(estado))
                {
                    CargarCitas();
                    return;
                }

                dgvCitas.Rows.Clear();
                var citas = _unitOfWork.Citas.GetAll();

                if (citas != null)
                {
                    foreach (var cita in citas)
                    {
                        if (cita.Estado == estado)
                        {
                            var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                            var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                            var especialidad = medico != null ? _unitOfWork.Especialidades.GetById(medico.EspecialidadId) : null;

                            dgvCitas.Rows.Add(
                                cita.CitaId,
                                paciente?.Nombres ?? "N/A",
                                medico?.Nombres ?? "N/A",
                                especialidad?.Nombre ?? "N/A",
                                cita.Fecha.ToShortDateString(),
                                cita.Hora,
                                cita.Motivo,
                                cita.Estado
                            );
                        }
                    }
                }
                lblTotal.Text = $"Total: {dgvCitas.Rows.Count}";
                LogHelper.Info($"Citas filtradas por estado: {estado}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error filtrando citas: {ex.Message}");
            }
        }

        /// <summary>
        /// Filtrar citas por rango de fechas
        /// </summary>
        public void FiltrarPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                dgvCitas.Rows.Clear();
                var citas = _unitOfWork.Citas.GetAll();

                if (citas != null)
                {
                    foreach (var cita in citas)
                    {
                        if (cita.Fecha.Date >= fechaInicio.Date && cita.Fecha.Date <= fechaFin.Date)
                        {
                            var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                            var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                            var especialidad = medico != null ? _unitOfWork.Especialidades.GetById(medico.EspecialidadId) : null;

                            dgvCitas.Rows.Add(
                                cita.CitaId,
                                paciente?.Nombres ?? "N/A",
                                medico?.Nombres ?? "N/A",
                                especialidad?.Nombre ?? "N/A",
                                cita.Fecha.ToShortDateString(),
                                cita.Hora,
                                cita.Motivo,
                                cita.Estado
                            );
                        }
                    }
                }
                lblTotal.Text = $"Total: {dgvCitas.Rows.Count}";
                LogHelper.Info($"Citas filtradas por fechas: {fechaInicio:yyyy-MM-dd} a {fechaFin:yyyy-MM-dd}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error filtrando citas: {ex.Message}");
            }
        }

        /// <summary>
        /// Filtrar citas por paciente
        /// </summary>
        public void FiltrarPorPaciente(int pacienteId)
        {
            try
            {
                if (pacienteId <= 0)
                {
                    CargarCitas();
                    return;
                }

                dgvCitas.Rows.Clear();
                var citas = _unitOfWork.Citas.GetAll();

                if (citas != null)
                {
                    foreach (var cita in citas)
                    {
                        if (cita.PacienteId == pacienteId)
                        {
                            var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                            var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                            var especialidad = medico != null ? _unitOfWork.Especialidades.GetById(medico.EspecialidadId) : null;

                            dgvCitas.Rows.Add(
                                cita.CitaId,
                                paciente?.Nombres ?? "N/A",
                                medico?.Nombres ?? "N/A",
                                especialidad?.Nombre ?? "N/A",
                                cita.Fecha.ToShortDateString(),
                                cita.Hora,
                                cita.Motivo,
                                cita.Estado
                            );
                        }
                    }
                }
                lblTotal.Text = $"Total: {dgvCitas.Rows.Count}";
                LogHelper.Info($"Citas filtradas por paciente ID: {pacienteId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error filtrando citas: {ex.Message}");
            }
        }

        /// <summary>
        /// Filtrar citas por médico
        /// </summary>
        public void FiltrarPorMedico(int medicoId)
        {
            try
            {
                if (medicoId <= 0)
                {
                    CargarCitas();
                    return;
                }

                dgvCitas.Rows.Clear();
                var citas = _unitOfWork.Citas.GetAll();

                if (citas != null)
                {
                    foreach (var cita in citas)
                    {
                        if (cita.MedicoId == medicoId)
                        {
                            var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                            var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                            var especialidad = medico != null ? _unitOfWork.Especialidades.GetById(medico.EspecialidadId) : null;

                            dgvCitas.Rows.Add(
                                cita.CitaId,
                                paciente?.Nombres ?? "N/A",
                                medico?.Nombres ?? "N/A",
                                especialidad?.Nombre ?? "N/A",
                                cita.Fecha.ToShortDateString(),
                                cita.Hora,
                                cita.Motivo,
                                cita.Estado
                            );
                        }
                    }
                }
                lblTotal.Text = $"Total: {dgvCitas.Rows.Count}";
                LogHelper.Info($"Citas filtradas por médico ID: {medicoId}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error filtrando citas: {ex.Message}");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                var cita = new Cita
                {
                    PacienteId = (int)cmbPaciente.SelectedValue,
                    MedicoId = (int)cmbMedico.SelectedValue,
                    Fecha = dtpFecha.Value,
                    Hora = txtHora.Text.Trim(),
                    Motivo = txtMotivo.Text.Trim(),
                    Estado = "Pendiente",
                    Notas = "" // txtNotas control not in Designer
                };

                _unitOfWork.Citas.Add(cita);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Cita agregada para {cmbPaciente.Text}");
                MessageBox.Show("Cita agregada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCitas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error agregando cita", ex);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_citaActual == null)
            {
                MessageBox.Show("Selecciona una cita primero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDatos())
                return;

            try
            {
                _citaActual.PacienteId = (int)cmbPaciente.SelectedValue;
                _citaActual.MedicoId = (int)cmbMedico.SelectedValue;
                _citaActual.Fecha = dtpFecha.Value;
                _citaActual.Hora = txtHora.Text.Trim();
                _citaActual.Motivo = txtMotivo.Text.Trim();
                _citaActual.Estado = cmbEstado.SelectedItem?.ToString() ?? "Pendiente";
                // _citaActual.Notas = txtNotas.Text.Trim(); // Control not in Designer

                _unitOfWork.Citas.Update(_citaActual);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Cita actualizada: ID {_citaActual.CitaId}");
                MessageBox.Show("Cita actualizada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCitas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error actualizando cita", ex);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_citaActual == null)
            {
                MessageBox.Show("Selecciona una cita primero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Eliminar esta cita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _unitOfWork.Citas.Remove(_citaActual);
                    _unitOfWork.SaveChanges();

                    LogHelper.Info($"Cita eliminada: ID {_citaActual.CitaId}");
                    MessageBox.Show("Cita eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCitas();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Error eliminando cita", ex);
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCitas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                int citaId = (int)dgvCitas.SelectedRows[0].Cells["CitaId"].Value;
                _citaActual = _unitOfWork.Citas.GetById(citaId);

                if (_citaActual != null)
                {
                    cmbPaciente.SelectedValue = _citaActual.PacienteId;
                    cmbMedico.SelectedValue = _citaActual.MedicoId;
                    dtpFecha.Value = _citaActual.Fecha;
                    txtHora.Text = _citaActual.Hora ?? "";
                    txtMotivo.Text = _citaActual.Motivo ?? "";
                    cmbEstado.SelectedItem = _citaActual.Estado ?? "Pendiente";
                    // txtNotas.Text = _citaActual.Notas ?? ""; // Control not in Designer
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbPaciente.SelectedIndex = 0;
            cmbMedico.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            txtHora.Clear();
            txtMotivo.Clear();
            // txtNotas.Clear(); // Control not in Designer
            _citaActual = null;
            dgvCitas.ClearSelection();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtHora.Text))
            {
                MessageBox.Show("La hora es obligatoria (HH:mm)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("El motivo es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Event handler para el botón Aplicar Filtros
        /// </summary>
        private void BtnAplicarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCitas.Rows.Clear();
                var citas = _unitOfWork.Citas.GetAll();

                if (citas == null || citas.Count() == 0)
                {
                    lblTotal.Text = "Total: 0";
                    LogHelper.Warning("No hay citas para filtrar");
                    return;
                }

                string filtroEstado = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";
                DateTime fechaInicio = dtpFiltroFechaInicio.Value;
                DateTime fechaFin = dtpFiltroFechaFin.Value;
                
                // Obtener Paciente solo si no es "Todos"
                Paciente pacienteSeleccionado = null;
                if (cmbFiltroPaciente.SelectedIndex > 0)
                {
                    pacienteSeleccionado = cmbFiltroPaciente.SelectedItem as Paciente;
                }
                
                // Obtener Médico solo si no es "Todos"
                Medico medicoSeleccionado = null;
                if (cmbFiltroMedico.SelectedIndex > 0)
                {
                    medicoSeleccionado = cmbFiltroMedico.SelectedItem as Medico;
                }

                foreach (var cita in citas)
                {
                    // Filtro por Estado
                    if (filtroEstado != "Todos" && cita.Estado != filtroEstado)
                        continue;

                    // Filtro por Rango de Fechas
                    if (cita.Fecha.Date < fechaInicio.Date || cita.Fecha.Date > fechaFin.Date)
                        continue;

                    // Filtro por Paciente
                    if (pacienteSeleccionado != null && cita.PacienteId != pacienteSeleccionado.PacienteId)
                        continue;

                    // Filtro por Médico
                    if (medicoSeleccionado != null && cita.MedicoId != medicoSeleccionado.MedicoId)
                        continue;

                    // Agregar fila si cumple todos los filtros
                    var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                    var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                    var especialidad = medico != null ? _unitOfWork.Especialidades.GetById(medico.EspecialidadId) : null;

                    dgvCitas.Rows.Add(
                        cita.CitaId,
                        paciente?.Nombres ?? "N/A",
                        medico?.Nombres ?? "N/A",
                        especialidad?.Nombre ?? "N/A",
                        cita.Fecha.ToShortDateString(),
                        cita.Hora,
                        cita.Motivo,
                        cita.Estado
                    );
                }

                lblTotal.Text = $"Total: {dgvCitas.Rows.Count}";
                LogHelper.Info($"Filtros aplicados: Estado={filtroEstado}, Fechas={fechaInicio:yyyy-MM-dd} a {fechaFin:yyyy-MM-dd}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error aplicando filtros: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler para el botón Limpiar Filtros
        /// </summary>
        private void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                cmbFiltroEstado.SelectedIndex = 0;
                dtpFiltroFechaInicio.Value = DateTime.Now.AddMonths(-1);
                dtpFiltroFechaFin.Value = DateTime.Now;
                cmbFiltroPaciente.SelectedIndex = 0;
                cmbFiltroMedico.SelectedIndex = 0;

                CargarCitas();
                LogHelper.Info("Filtros limpiados");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error limpiando filtros: {ex.Message}");
            }
        }
    }
}

