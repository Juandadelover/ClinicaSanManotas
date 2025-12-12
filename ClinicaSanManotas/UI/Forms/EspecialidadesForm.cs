using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClinicaSanManotas.Helpers;
using ClinicaSanManotas.Model;
using ClinicaSanManotas.DAO;
using ClinicaSanManotas.Repositories;

namespace ClinicaSanManotas.UI.Forms
{
    /// <summary>
    /// Formulario de gestión de Especialidades
    /// </summary>
    public partial class EspecialidadesForm : Form
    {
        private UnitOfWork _unitOfWork;
        private Especialidad? _especialidadActual;

        public EspecialidadesForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void EspecialidadesForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Gestión de Especialidades";
                ConfigurarDataGridView();
                CargarEspecialidades();
                LimpiarFormulario();
                LogHelper.Info("Formulario de especialidades cargado exitosamente");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar formulario de especialidades: {ex.Message}");
                MessageBox.Show($"Error al cargar las especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvEspecialidades.Columns.Clear();
            dgvEspecialidades.AutoGenerateColumns = false;
            dgvEspecialidades.AllowUserToAddRows = false;
            dgvEspecialidades.AllowUserToDeleteRows = false;

            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "EspecialidadId", Width = 50, ReadOnly = true });
            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150, ReadOnly = true });
            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "Descripcion", Width = 250, ReadOnly = true });
            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "Estado", Width = 100, ReadOnly = true });

            dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEspecialidades.MultiSelect = false;
            dgvEspecialidades.SelectionChanged += DgvEspecialidades_SelectionChanged;
        }

        private void CargarEspecialidades()
        {
            try
            {
                dgvEspecialidades.Rows.Clear();
                var especialidades = _unitOfWork.Especialidades.GetAll();

                if (especialidades != null)
                {
                    foreach (var especialidad in especialidades)
                    {
                        dgvEspecialidades.Rows.Add(
                            especialidad.EspecialidadId,
                            especialidad.Nombre,
                            especialidad.Descripcion,
                            especialidad.Estado
                        );
                    }
                }

                if (dgvEspecialidades.Rows.Count == 0)
                {
                    MessageBox.Show("No hay especialidades registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar especialidades: {ex.Message}");
                MessageBox.Show($"Error al cargar las especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                    return;

                var nuevaEspecialidad = new Especialidad
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = "Activo"
                };

                _unitOfWork.Especialidades.Add(nuevaEspecialidad);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Especialidad '{nuevaEspecialidad.Nombre}' creada por {SessionManager.UsuarioActual?.Username}");
                MessageBox.Show("Especialidad creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEspecialidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al agregar especialidad: {ex.Message}");
                MessageBox.Show($"Error al agregar la especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_especialidadActual == null)
                {
                    MessageBox.Show("Por favor selecciona una especialidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ValidarDatos())
                    return;

                _especialidadActual.Nombre = txtNombre.Text.Trim();
                _especialidadActual.Descripcion = txtDescripcion.Text.Trim();

                _unitOfWork.Especialidades.Update(_especialidadActual);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Especialidad '{_especialidadActual.Nombre}' actualizada por {SessionManager.UsuarioActual?.Username}");
                MessageBox.Show("Especialidad actualizada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEspecialidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al actualizar especialidad: {ex.Message}");
                MessageBox.Show($"Error al actualizar la especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_especialidadActual == null)
                {
                    MessageBox.Show("Por favor selecciona una especialidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verificar si hay médicos con esta especialidad
                var medicos = _unitOfWork.Medicos.GetAll();
                var medicosAsignados = medicos?.Where(m => m.EspecialidadId == _especialidadActual.EspecialidadId).ToList();

                if (medicosAsignados != null && medicosAsignados.Count > 0)
                {
                    MessageBox.Show($"No se puede eliminar esta especialidad. Hay {medicosAsignados.Count} médico(s) asignado(s).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"¿Estás seguro de que deseas eliminar la especialidad '{_especialidadActual.Nombre}'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _unitOfWork.Especialidades.Remove(_especialidadActual);
                    _unitOfWork.SaveChanges();

                    LogHelper.Info($"Especialidad '{_especialidadActual.Nombre}' eliminada por {SessionManager.UsuarioActual?.Username}");
                    MessageBox.Show("Especialidad eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarEspecialidades();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al eliminar especialidad: {ex.Message}");
                MessageBox.Show($"Error al eliminar la especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvEspecialidades.SelectedRows.Count > 0)
                {
                    int especialidadId = (int)dgvEspecialidades.SelectedRows[0].Cells[0].Value;
                    _especialidadActual = _unitOfWork.Especialidades.GetById(especialidadId);

                    if (_especialidadActual != null)
                    {
                        txtNombre.Text = _especialidadActual.Nombre ?? string.Empty;
                        txtDescripcion.Text = _especialidadActual.Descripcion ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al seleccionar especialidad: {ex.Message}");
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la especialidad es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es requerida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            _especialidadActual = null;
        }
    }
}

