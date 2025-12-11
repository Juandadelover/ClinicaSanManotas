using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.Helpers;
using SistemaEmpleadosMySQL.Model;
using SistemaEmpleadosMySQL.DAO;
using SistemaEmpleadosMySQL.Repositories;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario de administración de Usuarios
    /// </summary>
    public partial class UsuariosForm : Form
    {
        private UnitOfWork _unitOfWork;
        private Usuario? _usuarioActual;

        public UsuariosForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Administración de Usuarios";
                ConfigurarDataGridView();
                CargarRoles();
                CargarUsuarios();
                LimpiarFormulario();
                LogHelper.Info("Formulario de usuarios cargado exitosamente");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar formulario de usuarios: {ex.Message}");
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "UsuarioId", Width = 50, ReadOnly = true });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Usuario", DataPropertyName = "Username", Width = 120, ReadOnly = true });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Width = 150, ReadOnly = true });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rol", DataPropertyName = "Rol", Width = 100, ReadOnly = true });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "Estado", Width = 100, ReadOnly = true });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Último Login", DataPropertyName = "UltimoLogin", Width = 150, ReadOnly = true });

            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
        }

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("Recepcionista");
            cmbRol.Items.Add("Doctor");
            cmbRol.SelectedIndex = -1;
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.Rows.Clear();
                var usuarios = _unitOfWork.Usuarios.GetAll();

                if (usuarios != null)
                {
                    foreach (var usuario in usuarios)
                    {
                        dgvUsuarios.Rows.Add(
                            usuario.UserId,
                            usuario.Username,
                            usuario.Email,
                            usuario.Role,
                            usuario.Estado,
                            usuario.FechaUltimoLogin?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Nunca"
                        );
                    }
                    
                    lblTotal.Text = $"Total: {dgvUsuarios.Rows.Count}";
                }

                if (dgvUsuarios.Rows.Count == 0)
                {
                    lblTotal.Text = "Total: 0";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar usuarios: {ex.Message}");
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                    return;

                var nuevoUsuario = new Usuario
                {
                    Username = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Role = cmbRol.SelectedItem.ToString(),
                    Estado = "Activo",
                    FechaCreacion = DateTime.Now
                };

                // Usar la contraseña ingresada por el admin
                string contraseña = txtContraseña.Text.Trim();
                nuevoUsuario.PasswordHash = SecurityHelper.GenerarHashContraseña(contraseña);

                _unitOfWork.Usuarios.Add(nuevoUsuario);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Usuario '{nuevoUsuario.Username}' creado exitosamente por {SessionManager.UsuarioActual?.Username} con contraseña definida por el administrador.");

                MessageBox.Show(
                    $"✓ Usuario '{nuevoUsuario.Username}' creado exitosamente.\n\nPuede iniciar sesión con la contraseña proporcionada.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al agregar usuario: {ex.Message}");
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioActual == null)
                {
                    MessageBox.Show("Por favor selecciona un usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ValidarDatos())
                    return;

                _usuarioActual.Email = txtEmail.Text.Trim();
                _usuarioActual.Role = cmbRol.SelectedItem.ToString();

                _unitOfWork.Usuarios.Update(_usuarioActual);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Usuario '{_usuarioActual.Username}' actualizado por {SessionManager.UsuarioActual?.Username}");
                MessageBox.Show("Usuario actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al actualizar usuario: {ex.Message}");
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioActual == null)
                {
                    MessageBox.Show("Por favor selecciona un usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show($"¿Estás seguro de que deseas eliminar al usuario '{_usuarioActual.Username}'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _unitOfWork.Usuarios.Remove(_usuarioActual);
                    _unitOfWork.SaveChanges();

                    LogHelper.Info($"Usuario '{_usuarioActual.Username}' eliminado por {SessionManager.UsuarioActual?.Username}");
                    MessageBox.Show("Usuario eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al eliminar usuario: {ex.Message}");
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    int usuarioId = (int)dgvUsuarios.SelectedRows[0].Cells[0].Value;
                    _usuarioActual = _unitOfWork.Usuarios.GetById(usuarioId);

                    if (_usuarioActual != null)
                    {
                        txtUsername.Text = _usuarioActual.Username ?? string.Empty;
                        txtEmail.Text = _usuarioActual.Email ?? string.Empty;
                        cmbRol.SelectedItem = _usuarioActual.Role;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al seleccionar usuario: {ex.Message}");
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El nombre de usuario es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El email es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidationHelper.EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El email no es válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecciona un rol", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("La contraseña es requerida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtContraseña.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;
            _usuarioActual = null;
            dgvUsuarios.ClearSelection();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            btnAgregar_Click(sender, e);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar_Click(sender, e);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuarioSeguro();
        }

        private void BtnRestablecerContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioActual == null)
                {
                    MessageBox.Show("Por favor selecciona un usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string nuevaContraseña = "Usuario123!";
                _usuarioActual.PasswordHash = SecurityHelper.GenerarHashContraseña(nuevaContraseña);

                _unitOfWork.Usuarios.Update(_usuarioActual);
                _unitOfWork.SaveChanges();

                LogHelper.Info($"Contraseña del usuario '{_usuarioActual.Username}' restablecida por {SessionManager.UsuarioActual?.Username}");
                MessageBox.Show($"Contraseña restablecida exitosamente.\nNueva contraseña: {nuevaContraseña}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al restablecer contraseña: {ex.Message}");
                MessageBox.Show($"Error al restablecer la contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento para eliminar usuario (con validación)
        /// </summary>
        public void EliminarUsuarioSeguro()
        {
            try
            {
                if (_usuarioActual == null)
                {
                    MessageBox.Show("Por favor selecciona un usuario para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validar que no sea el último admin
                if (_usuarioActual.Role == "Admin")
                {
                    var admins = _unitOfWork.Usuarios.GetAll()?.Where(u => u.Role == "Admin").Count() ?? 0;
                    if (admins <= 1)
                    {
                        MessageBox.Show("No puedes eliminar el último usuario Admin del sistema", "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Confirmar eliminación
                if (MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar al usuario '{_usuarioActual.Username}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Eliminar usuario
                    _unitOfWork.Usuarios.Remove(_usuarioActual);
                    _unitOfWork.SaveChanges();

                    LogHelper.Info($"Usuario '{_usuarioActual.Username}' eliminado por {SessionManager.UsuarioActual?.Username}");
                    MessageBox.Show("Usuario eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al eliminar usuario: {ex.Message}");
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}\n\nDetalles: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}

