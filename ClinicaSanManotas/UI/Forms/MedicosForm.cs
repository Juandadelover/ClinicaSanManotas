using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClinicaSanManotas.DTO;
using ClinicaSanManotas.Helpers;
using ClinicaSanManotas.Model;
using ClinicaSanManotas.Repositories;

namespace ClinicaSanManotas.UI.Forms
{
    /// <summary>
    /// Formulario de gestión de Médicos - CRUD Completo
    /// </summary>
    public partial class MedicosForm : Form
    {
        private UnitOfWork _unitOfWork;
        private Medico? _medicoActual;
        private int _paginaActual = 1;
        private const int ITEMS_POR_PAGINA = 10;

        public MedicosForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void MedicosForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "CLINICA SAN MANOTAS - Gestión de Médicos";
                this.StartPosition = FormStartPosition.CenterScreen;
                
                LogHelper.Info("Iniciando carga de formulario de médicos");
                
                ConfigurarDataGridView();
                LogHelper.Info("DataGridView configurado");
                
                CargarEspecialidades();
                LogHelper.Info("Especialidades cargadas");
                
                CargarMedicos();
                LogHelper.Info("Médicos cargados");
                
                CargarFiltrosMedicos();
                LogHelper.Info("Filtros de médicos cargados");
                
                LimpiarFormulario();
                LogHelper.Info("Formulario limpiado");
                LogHelper.Info("Formulario de médicos cargado exitosamente");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando formulario de médicos", ex);
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}\n\n{ex.StackTrace}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas del DataGridView
            if (dgvMedicos.Columns.Count == 0)
            {
                dgvMedicos.Columns.Add("MedicoId", "ID");
                dgvMedicos.Columns.Add("NombreCompleto", "Nombre Completo");
                dgvMedicos.Columns.Add("Email", "Email");
                dgvMedicos.Columns.Add("Telefono", "Teléfono");
                dgvMedicos.Columns.Add("Licencia", "Licencia");
                dgvMedicos.Columns.Add("Especialidad", "Especialidad");
                dgvMedicos.Columns.Add("HorarioInicio", "Inicio");
                dgvMedicos.Columns.Add("HorarioFin", "Fin");
                dgvMedicos.Columns.Add("Estado", "Estado");

                dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
                LogHelper.Info("Iniciando CargarEspecialidades");
                
                try
                {
                    var especialidades = _unitOfWork.Especialidades.GetAll();
                    LogHelper.Info($"GetAll retornó: {(especialidades == null ? "NULL" : especialidades.Count() + " items")}");
                    
                    if (especialidades != null)
                    {
                        var listaEsp = especialidades.ToList();
                        LogHelper.Info($"Lista convertida: {listaEsp.Count} especialidades");
                        
                        if (listaEsp.Count > 0)
                        {
                            cmbEspecialidad.DataSource = listaEsp;
                            cmbEspecialidad.DisplayMember = "Nombre";
                            cmbEspecialidad.ValueMember = "EspecialidadId";
                            LogHelper.Info("ComboBox de especialidades cargado correctamente");
                        }
                        else
                        {
                            LogHelper.Warning("La lista de especialidades está vacía");
                            MessageBox.Show("No hay especialidades en la BD", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        LogHelper.Warning("GetAll retornó NULL");
                        MessageBox.Show("GetAll retornó NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exInner)
                {
                    LogHelper.Error("Excepción en GetAll o datasource", exInner);
                    MessageBox.Show($"Error en GetAll: {exInner.GetType().Name}: {exInner.Message}\n{exInner.StackTrace}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error general en CargarEspecialidades", ex);
                MessageBox.Show($"Error general: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMedicos()
        {
            try
            {
                dgvMedicos.Rows.Clear();
                var medicos = _unitOfWork.Medicos.GetAll();

                LogHelper.Info($"Se obtuvieron {medicos?.Count() ?? 0} médicos de la BD");

                if (medicos != null)
                {
                    var listaMedicos = medicos.ToList();
                    LogHelper.Info($"Lista de médicos convertida: {listaMedicos.Count} médicos");
                    
                    foreach (var medico in listaMedicos)
                    {
                        LogHelper.Debug($"Médico: ID={medico.MedicoId}, Nombre={medico.Nombres} {medico.Apellidos}, Estado={medico.Estado}");
                        
                        var especialidad = _unitOfWork.Especialidades.GetById(medico.EspecialidadId);
                        dgvMedicos.Rows.Add(
                            medico.MedicoId,
                            $"{medico.Nombres} {medico.Apellidos}",
                            medico.Email,
                            medico.Telefono,
                            medico.Licencia,
                            especialidad?.Nombre ?? "N/A",
                            medico.HorarioInicio,
                            medico.HorarioFin,
                            medico.Estado
                        );
                    }
                    LogHelper.Info($"Se cargaron {dgvMedicos.Rows.Count} médicos en la tabla");
                }
                else
                {
                    LogHelper.Warning("GetAll retornó null");
                    MessageBox.Show("No se pudieron cargar los médicos (null)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando médicos", ex);
                MessageBox.Show($"Error al cargar médicos: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                var medico = new Medico
                {
                    Nombres = txtNombres.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Licencia = txtLicencia.Text.Trim(),
                    EspecialidadId = (int)cmbEspecialidad.SelectedValue,
                    HorarioInicio = dtpHorarioInicio.Value.ToString("HH:mm"),
                    HorarioFin = dtpHorarioFin.Value.ToString("HH:mm"),
                    DiasAtencion = ObtenerDiasSeleccionados(),
                    Estado = "Activo"
                };

                _unitOfWork.Medicos.Add(medico);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Médico agregado: {medico.Nombres} {medico.Apellidos}");
                MessageBox.Show("Médico agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarMedicos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error agregando médico", ex);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_medicoActual == null)
            {
                MessageBox.Show("Selecciona un médico primero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDatos())
                return;

            try
            {
                _medicoActual.Nombres = txtNombres.Text.Trim();
                _medicoActual.Apellidos = txtApellidos.Text.Trim();
                _medicoActual.Email = txtEmail.Text.Trim();
                _medicoActual.Telefono = txtTelefono.Text.Trim();
                _medicoActual.Licencia = txtLicencia.Text.Trim();
                _medicoActual.EspecialidadId = (int)cmbEspecialidad.SelectedValue;
                _medicoActual.HorarioInicio = dtpHorarioInicio.Value.ToString("HH:mm");
                _medicoActual.HorarioFin = dtpHorarioFin.Value.ToString("HH:mm");
                _medicoActual.DiasAtencion = ObtenerDiasSeleccionados();

                _unitOfWork.Medicos.Update(_medicoActual);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Médico actualizado: {_medicoActual.Nombres} {_medicoActual.Apellidos}");
                MessageBox.Show("Médico actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarMedicos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error actualizando médico", ex);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_medicoActual == null)
            {
                MessageBox.Show("Selecciona un médico primero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Eliminar a {_medicoActual.Nombres} {_medicoActual.Apellidos}?", 
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _unitOfWork.Medicos.Remove(_medicoActual);
                    _unitOfWork.SaveChanges();

                    LogHelper.Info($"Médico eliminado: {_medicoActual.Nombres} {_medicoActual.Apellidos}");
                    MessageBox.Show("Médico eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarMedicos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Error eliminando médico", ex);
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMedicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicos.SelectedRows.Count > 0)
            {
                int medicoId = (int)dgvMedicos.SelectedRows[0].Cells["MedicoId"].Value;
                _medicoActual = _unitOfWork.Medicos.GetById(medicoId);

                if (_medicoActual != null)
                {
                    txtNombres.Text = _medicoActual.Nombres ?? "";
                    txtApellidos.Text = _medicoActual.Apellidos ?? "";
                    txtEmail.Text = _medicoActual.Email ?? "";
                    txtTelefono.Text = _medicoActual.Telefono ?? "";
                    txtLicencia.Text = _medicoActual.Licencia ?? "";
                    cmbEspecialidad.SelectedValue = _medicoActual.EspecialidadId;
                    
                    // Cargar horarios
                    if (TimeSpan.TryParse(_medicoActual.HorarioInicio ?? "08:00", out var horaInicio))
                        dtpHorarioInicio.Value = DateTime.Today.Add(horaInicio);
                    if (TimeSpan.TryParse(_medicoActual.HorarioFin ?? "17:00", out var horaFin))
                        dtpHorarioFin.Value = DateTime.Today.Add(horaFin);
                    
                    // Cargar días
                    EstablecerDiasSeleccionados(_medicoActual.DiasAtencion ?? "");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtLicencia.Clear();
            
            // Reset horarios a valores por defecto
            dtpHorarioInicio.Value = DateTime.Today.AddHours(8);
            dtpHorarioFin.Value = DateTime.Today.AddHours(17);
            
            // Desseleccionar todos los días
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;
            
            cmbEspecialidad.SelectedIndex = 0;
            _medicoActual = null;
            dgvMedicos.ClearSelection();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El apellido es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (!ValidationHelper.EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("Email inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("La licencia es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicencia.Focus();
                return false;
            }

            // Validar que al menos un día esté seleccionado
            if (string.IsNullOrWhiteSpace(ObtenerDiasSeleccionados()))
            {
                MessageBox.Show("Debes seleccionar al menos un día de atención", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Carga e inicializa los controles de filtro para médicos
        /// </summary>
        private void CargarFiltrosMedicos()
        {
            try
            {
                // Inicializar ComboBox de especialidad con "Todos"
                var especialidades = _unitOfWork.Especialidades.GetAll();
                
                // Crear lista con opción "Todas" al inicio
                var listaEspecialidades = new List<Especialidad>();
                listaEspecialidades.Add(new Especialidad { EspecialidadId = 0, Nombre = "Todas" });
                
                if (especialidades != null)
                {
                    foreach (var esp in especialidades)
                    {
                        listaEspecialidades.Add(esp);
                    }
                }

                cmbFiltroEspecialidad.DataSource = listaEspecialidades;
                cmbFiltroEspecialidad.DisplayMember = "Nombre";
                cmbFiltroEspecialidad.ValueMember = "EspecialidadId";
                cmbFiltroEspecialidad.SelectedIndex = 0;

                // TextBox de nombre limpio
                txtFiltroNombre.Text = "";
                txtFiltroNombre.PlaceholderText = "Buscar por nombre...";

                LogHelper.Info("Filtros de médicos cargados");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando filtros de médicos", ex);
            }
        }

        /// <summary>
        /// Aplica los filtros seleccionados a la lista de médicos
        /// </summary>
        private void BtnAplicarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los médicos
                var medicos = _unitOfWork.Medicos.GetAll();

                if (medicos == null)
                {
                    MessageBox.Show("No hay médicos disponibles", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var nombreFiltro = txtFiltroNombre.Text.Trim().ToLower();
                
                // Obtener EspecialidadId correctamente
                int especialidadId = 0;
                if (cmbFiltroEspecialidad.SelectedValue != null)
                {
                    especialidadId = Convert.ToInt32(cmbFiltroEspecialidad.SelectedValue);
                }

                // Aplicar filtros con lógica AND
                var medicosFiltered = medicos
                    .Where(m =>
                        (string.IsNullOrEmpty(nombreFiltro) || 
                         ($"{m.Nombres} {m.Apellidos}".ToLower().Contains(nombreFiltro))) &&
                        (especialidadId == 0 || m.EspecialidadId == especialidadId)
                    )
                    .ToList();

                // Actualizar DataGridView
                dgvMedicos.Rows.Clear();
                foreach (var medico in medicosFiltered)
                {
                    var especialidad = _unitOfWork.Especialidades.GetById(medico.EspecialidadId);
                    dgvMedicos.Rows.Add(
                        medico.MedicoId,
                        $"{medico.Nombres} {medico.Apellidos}",
                        medico.Email,
                        medico.Telefono,
                        medico.Licencia,
                        especialidad?.Nombre ?? "N/A",
                        medico.HorarioInicio,
                        medico.HorarioFin,
                        medico.Estado
                    );
                }

                LogHelper.Info($"Filtros aplicados - {medicosFiltered.Count} médicos encontrados");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error aplicando filtros de médicos", ex);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia los filtros y recarga la lista completa de médicos
        /// </summary>
        private void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltroNombre.Text = "";
                cmbFiltroEspecialidad.SelectedIndex = 0;

                CargarMedicos();

                LogHelper.Info("Filtros de médicos limpiados");
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error limpiando filtros de médicos", ex);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene los días seleccionados como texto separado por comas
        /// </summary>
        private string ObtenerDiasSeleccionados()
        {
            var dias = new List<string>();
            if (chkLunes.Checked) dias.Add("Lunes");
            if (chkMartes.Checked) dias.Add("Martes");
            if (chkMiercoles.Checked) dias.Add("Miércoles");
            if (chkJueves.Checked) dias.Add("Jueves");
            if (chkViernes.Checked) dias.Add("Viernes");
            if (chkSabado.Checked) dias.Add("Sábado");
            if (chkDomingo.Checked) dias.Add("Domingo");
            return string.Join(", ", dias);
        }

        /// <summary>
        /// Establece los CheckBoxes de días basado en un texto separado por comas
        /// </summary>
        private void EstablecerDiasSeleccionados(string diasTexto)
        {
            // Limpiar todos primero
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;
            
            if (string.IsNullOrEmpty(diasTexto)) return;
            
            var dias = diasTexto.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim())
                .ToList();
            
            if (dias.Contains("Lunes")) chkLunes.Checked = true;
            if (dias.Contains("Martes")) chkMartes.Checked = true;
            if (dias.Contains("Miércoles")) chkMiercoles.Checked = true;
            if (dias.Contains("Jueves")) chkJueves.Checked = true;
            if (dias.Contains("Viernes")) chkViernes.Checked = true;
            if (dias.Contains("Sábado")) chkSabado.Checked = true;
            if (dias.Contains("Domingo")) chkDomingo.Checked = true;
        }
    }
}

