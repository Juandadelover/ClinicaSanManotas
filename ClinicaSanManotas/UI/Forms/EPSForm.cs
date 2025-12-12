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
    /// Formulario de gestión de EPS (Entidades Prestadoras de Salud)
    /// </summary>
    public partial class EPSForm : Form
    {
        private UnitOfWork _unitOfWork;
        private EPS? _epsActual;

        public EPSForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void EPSForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Gestión de EPS";
                ConfigurarDataGridView();
                CargarEPS();
                LimpiarFormulario();
                LogHelper.Info("Formulario de EPS cargado exitosamente");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar formulario de EPS: {ex.Message}");
                MessageBox.Show($"Error al cargar las EPS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvEPS.Columns.Clear();
            dgvEPS.AutoGenerateColumns = false;
            dgvEPS.AllowUserToAddRows = false;
            dgvEPS.AllowUserToDeleteRows = false;

            dgvEPS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "EPSId", Width = 50, ReadOnly = true });
            dgvEPS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 200, ReadOnly = true });
            dgvEPS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "Telefono", Width = 120, ReadOnly = true });
            dgvEPS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Width = 200, ReadOnly = true });
            dgvEPS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "Estado", Width = 100, ReadOnly = true });

            dgvEPS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEPS.MultiSelect = false;
            dgvEPS.SelectionChanged += DgvEPS_SelectionChanged;
        }

        private void CargarEPS()
        {
            try
            {
                dgvEPS.Rows.Clear();
                var epsList = _unitOfWork.EPS.GetAll();

                if (epsList != null)
                {
                    foreach (var eps in epsList)
                    {
                        dgvEPS.Rows.Add(
                            eps.EPSId,
                            eps.Nombre,
                            eps.Telefono,
                            eps.Email,
                            eps.Estado
                        );
                    }
                }

                if (dgvEPS.Rows.Count == 0)
                {
                    MessageBox.Show("No hay EPS registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LogHelper.Info("EPS cargadas exitosamente");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar EPS: {ex.Message}");
                MessageBox.Show($"Error al cargar las EPS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEPS_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvEPS.SelectedRows.Count > 0)
            {
                _epsActual = (EPS)dgvEPS.SelectedRows[0].DataBoundItem;
                txtNombre.Text = _epsActual?.Nombre ?? "";
                txtTelefono.Text = _epsActual?.Telefono ?? "";
                txtEmail.Text = _epsActual?.Email ?? "";
                cmbEstado.SelectedItem = _epsActual?.Estado ?? "Activo";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                {
                    return;
                }

                var nuevaEPS = new EPS
                {
                    Nombre = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Estado = cmbEstado.SelectedItem.ToString() ?? "Activo"
                };

                _unitOfWork.EPS.Add(nuevaEPS);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"EPS agregada: {nuevaEPS.Nombre}");
                MessageBox.Show("EPS agregada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEPS();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al agregar EPS: {ex.Message}");
                MessageBox.Show($"Error al agregar la EPS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEPS.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una EPS para editar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarDatos())
                {
                    return;
                }

                _epsActual!.Nombre = txtNombre.Text.Trim();
                _epsActual.Telefono = txtTelefono.Text.Trim();
                _epsActual.Email = txtEmail.Text.Trim();
                _epsActual.Estado = cmbEstado.SelectedItem.ToString() ?? "Activo";

                _unitOfWork.EPS.Update(_epsActual);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"EPS actualizada: {_epsActual.Nombre}");
                MessageBox.Show("EPS actualizada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEPS();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al actualizar EPS: {ex.Message}");
                MessageBox.Show($"Error al actualizar la EPS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEPS.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una EPS para eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Eliminar esta EPS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _unitOfWork.EPS.Remove(_epsActual);
                        _unitOfWork.SaveChanges();

                        LogHelper.Info($"EPS eliminada: {_epsActual?.Nombre}");
                        MessageBox.Show("EPS eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarEPS();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error($"Error al eliminar EPS: {ex.Message}");
                        MessageBox.Show($"Error al eliminar la EPS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error: {ex.Message}");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbEstado.SelectedIndex = 0;
            _epsActual = null;
            dgvEPS.ClearSelection();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la EPS es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombre.Text.Length < 3 || txtNombre.Text.Length > 200)
            {
                MessageBox.Show("El nombre debe tener entre 3 y 200 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                // Validación simple de email
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("El formato del email no es válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void pnlFormulario_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
