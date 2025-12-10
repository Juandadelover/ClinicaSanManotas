using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.DTO;
using SistemaEmpleadosMySQL.Helpers;
using SistemaEmpleadosMySQL.Repositories;
using SistemaEmpleadosMySQL.Model;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario de gestión de Pacientes
    /// </summary>
    public partial class PacientesForm : Form
    {
        private UnitOfWork _unitOfWork;
        private Paciente _pacienteActual;
        private int _paginaActual = 1;
        private const int ITEMS_POR_PAGINA = 10;

        public PacientesForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void PacientesForm_Load(object sender, EventArgs e)
        {
            this.Text = "Gestión de Pacientes";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(1200, 700);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // Estilos profesionales
            AplicarEstilosProfesionales();

            CargarEPS();
            CargarFiltrosPacientes();
            CargarPacientes();
            LogHelper.Info("Formulario de pacientes cargado");
        }

        private void AplicarEstilosProfesionales()
        {
            try
            {
                // DataGridView
                dgvPacientes.BackgroundColor = System.Drawing.Color.White;
                dgvPacientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
                dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
                dgvPacientes.ColumnHeadersHeight = 35;
                dgvPacientes.RowTemplate.Height = 28;
                dgvPacientes.EnableHeadersVisualStyles = false;
                dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
                dgvPacientes.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
                dgvPacientes.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);

                // Panel de Filtros
                pnlFiltro.BackColor = System.Drawing.Color.FromArgb(235, 242, 250);
                pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // Panel de Formulario
                pnlFormulario.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
                pnlFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // Panel de Botones
                pnlBotones.BackColor = System.Drawing.Color.FromArgb(235, 242, 250);

                // Botones
                EstilizarBoton(btnBuscar, System.Drawing.Color.FromArgb(0, 102, 204));
                EstilizarBoton(btnAplicarFiltrosPac, System.Drawing.Color.FromArgb(52, 168, 83));
                EstilizarBoton(btnLimpiarFiltrosPac, System.Drawing.Color.FromArgb(200, 200, 200));
                EstilizarBoton(btnNuevo, System.Drawing.Color.FromArgb(52, 168, 83));
                EstilizarBoton(btnGuardar, System.Drawing.Color.FromArgb(0, 102, 204));
                EstilizarBoton(btnEditar, System.Drawing.Color.FromArgb(255, 180, 0));
                EstilizarBoton(btnEliminar, System.Drawing.Color.FromArgb(220, 53, 69));
                EstilizarBoton(btnCancelar, System.Drawing.Color.FromArgb(108, 117, 125));

                // Labels
                foreach (Control control in pnlFormulario.Controls)
                {
                    if (control is System.Windows.Forms.Label lbl && control.Name.StartsWith("lbl"))
                    {
                        lbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
                        lbl.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
                    }
                }

                // TextBox y ComboBox
                foreach (Control control in pnlFormulario.Controls)
                {
                    if (control is System.Windows.Forms.TextBox txt)
                    {
                        txt.Font = new System.Drawing.Font("Arial", 10F);
                        txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control is System.Windows.Forms.ComboBox cmb)
                    {
                        cmb.Font = new System.Drawing.Font("Arial", 10F);
                        cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error aplicando estilos: " + ex.Message);
            }
        }

        private void EstilizarBoton(System.Windows.Forms.Button btn, System.Drawing.Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Height = 35;
        }

        private void CargarEPS()
        {
            try
            {
                cmbEPS.Items.Clear();
                cmbEPS.Items.Add("-- Seleccionar --");

                var listaEPS = _unitOfWork.EPS.GetAll();
                
                if (listaEPS != null && listaEPS.Any())
                {
                    foreach (var eps in listaEPS)
                    {
                        // Guardar en formato "ID|Nombre" para poder recuperar el ID después
                        cmbEPS.Items.Add($"{eps.EPSId}|{eps.Nombre}");
                    }
                }
                else
                {
                    LogHelper.Warning("No se cargaron EPS desde GetAll()");
                }
                
                cmbEPS.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando EPS", ex);
                MessageBox.Show("Error al cargar EPS: " + ex.Message);
            }
        }

        private void CargarFiltrosPacientes()
        {
            try
            {
                // Cargar Géneros
                cmbFiltroGenero.Items.Clear();
                cmbFiltroGenero.Items.Add("Todos");
                cmbFiltroGenero.Items.Add("Masculino");
                cmbFiltroGenero.Items.Add("Femenino");
                cmbFiltroGenero.Items.Add("Otro");
                cmbFiltroGenero.SelectedIndex = 0;

                // Cargar EPS en filtro
                cmbFiltroEPS.Items.Clear();
                cmbFiltroEPS.Items.Add("Todos");
                var listaEPS = _unitOfWork.EPS.GetAll();
                
                if (listaEPS != null && listaEPS.Any())
                {
                    foreach (var eps in listaEPS)
                    {
                        cmbFiltroEPS.Items.Add(eps.Nombre);
                    }
                }
                else
                {
                    LogHelper.Warning("No se cargaron EPS para filtro");
                }
                cmbFiltroEPS.SelectedIndex = 0;

                // Configurar NumericUpDown
                nudFiltroEdadMin.Value = 0;
                nudFiltroEdadMax.Value = 120;
                
                // Configurar DateTimePicker
                dtpFiltroFechaReg.Value = DateTime.Now.AddYears(-1);
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando filtros", ex);
            }
        }

        private void CargarPacientes()
        {
            try
            {
                dgvPacientes.DataSource = null;
                var pacientes = _unitOfWork.Pacientes.GetAllPaged(_paginaActual, ITEMS_POR_PAGINA);

                if (pacientes != null && pacientes.Any())
                {
                    dgvPacientes.DataSource = pacientes.ToList();
                    
                    // Ajustar propiedades de columnas
                    if (dgvPacientes.Columns.Count > 0)
                    {
                        dgvPacientes.Columns["PacienteId"].Width = 80;
                        dgvPacientes.Columns["Nombres"].Width = 100;
                        dgvPacientes.Columns["Apellidos"].Width = 100;
                        dgvPacientes.Columns["Email"].Width = 150;
                        dgvPacientes.Columns["Telefono"].Width = 100;
                        dgvPacientes.Columns["FechaNacimiento"].Width = 100;
                        dgvPacientes.Columns["Genero"].Width = 70;
                        dgvPacientes.Columns["Documento"].Width = 100;
                        dgvPacientes.Columns["EPSId"].Width = 70;
                        dgvPacientes.Columns["Direccion"].Width = 120;
                        
                        // Ocultar columnas innecesarias
                        if (dgvPacientes.Columns.Contains("Ciudad"))
                            dgvPacientes.Columns["Ciudad"].Visible = false;
                        if (dgvPacientes.Columns.Contains("FechaRegistro"))
                            dgvPacientes.Columns["FechaRegistro"].Visible = false;
                        if (dgvPacientes.Columns.Contains("Estado"))
                            dgvPacientes.Columns["Estado"].Visible = false;

                        // Formatear columnas de fecha
                        dgvPacientes.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                else
                {
                    dgvPacientes.DataSource = null;
                }

                ActualizarPaginacion();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error cargando pacientes", ex);
                MessageBox.Show("Error al cargar pacientes: " + ex.Message);
            }
        }

        private void ActualizarPaginacion()
        {
            lblPagina.Text = $"Página: {_paginaActual}";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string criterio = txtBuscar.Text.Trim();

                if (string.IsNullOrEmpty(criterio))
                {
                    CargarPacientes();
                    return;
                }

                _paginaActual = 1;
                var resultados = _unitOfWork.Pacientes.BuscarPorNombre(criterio, _paginaActual, ITEMS_POR_PAGINA);

                dgvPacientes.DataSource = resultados;
                ActualizarPaginacion();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error en búsqueda", ex);
                MessageBox.Show("Error en búsqueda: " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _pacienteActual = null;
            habilitar_controles(true);
            txtNombres.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                    return;

                if (_pacienteActual == null)
                {
                    // Nuevo paciente
                    _pacienteActual = new Paciente();
                }

                // Asignar valores
                _pacienteActual.Nombres = txtNombres.Text.Trim();
                _pacienteActual.Apellidos = txtApellidos.Text.Trim();
                _pacienteActual.Email = txtEmail.Text.Trim();
                _pacienteActual.Telefono = txtTelefono.Text.Trim();
                _pacienteActual.Documento = txtDocumento.Text.Trim();
                _pacienteActual.Direccion = txtDireccion.Text.Trim();
                _pacienteActual.Ciudad = txtCiudad.Text.Trim();
                _pacienteActual.FechaNacimiento = dtpFechaNacimiento.Value;

                if (cmbEPS.SelectedItem != null && cmbEPS.SelectedItem.ToString() != "")
                {
                    string[] partes = cmbEPS.SelectedItem.ToString().Split('|');
                    if (int.TryParse(partes[0], out int epsId))
                    {
                        _pacienteActual.EPSId = epsId;
                    }
                }

                _pacienteActual.Genero = cmbGenero.SelectedItem.ToString();
                _pacienteActual.Estado = "Activo";

                if (!_pacienteActual.EsValido())
                {
                    MostrarMensajeError("Por favor complete todos los campos requeridos con datos válidos.");
                    return;
                }

                // Guardar en BD
                if (_pacienteActual.PacienteId == 0)
                {
                    _unitOfWork.Pacientes.Add(_pacienteActual);
                    LogHelper.LogCambio(SessionManager.UsuarioActual.UserId, "Paciente", 0, "INSERT", $"Nuevo paciente: {_pacienteActual.Nombres}");
                    MostrarMensajeExito($"✓ Paciente '{_pacienteActual.Nombres} {_pacienteActual.Apellidos}' registrado exitosamente.");
                }
                else
                {
                    _unitOfWork.Pacientes.Update(_pacienteActual);
                    LogHelper.LogCambio(SessionManager.UsuarioActual.UserId, "Paciente", _pacienteActual.PacienteId, "UPDATE", $"Actualizado: {_pacienteActual.Nombres}");
                    MostrarMensajeExito($"✓ Paciente '{_pacienteActual.Nombres} {_pacienteActual.Apellidos}' actualizado exitosamente.");
                }

                CargarPacientes();
                LimpiarFormulario();
                habilitar_controles(false);
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error guardando paciente", ex);
                MostrarMensajeError($"Error al guardar paciente: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente para editar.");
                return;
            }

            try
            {
                int pacienteId = (int)dgvPacientes.SelectedRows[0].Cells["PacienteId"].Value;
                _pacienteActual = _unitOfWork.Pacientes.GetById(pacienteId);

                if (_pacienteActual != null)
                {
                    txtNombres.Text = _pacienteActual.Nombres;
                    txtApellidos.Text = _pacienteActual.Apellidos;
                    txtEmail.Text = _pacienteActual.Email;
                    txtTelefono.Text = _pacienteActual.Telefono;
                    txtDocumento.Text = _pacienteActual.Documento;
                    txtDireccion.Text = _pacienteActual.Direccion;
                    txtCiudad.Text = _pacienteActual.Ciudad;
                    dtpFechaNacimiento.Value = _pacienteActual.FechaNacimiento;
                    cmbGenero.SelectedItem = _pacienteActual.Genero;
                    
                    // Seleccionar EPS por ID
                    for (int i = 0; i < cmbEPS.Items.Count; i++)
                    {
                        string item = cmbEPS.Items[i].ToString();
                        if (item.StartsWith(_pacienteActual.EPSId.ToString() + "|"))
                        {
                            cmbEPS.SelectedIndex = i;
                            break;
                        }
                    }

                    habilitar_controles(true);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error editando paciente", ex);
                MostrarMensajeError($"Error al editar paciente: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MostrarMensajeAdverlencia("Seleccione un paciente para eliminar.");
                return;
            }

            var pacientesSeleccionados = dgvPacientes.SelectedRows[0];
            string nombrePaciente = pacientesSeleccionados.Cells["Nombres"].Value?.ToString() + " " + 
                                   pacientesSeleccionados.Cells["Apellidos"].Value?.ToString();

            DialogResult resultado = ConfirmarAccion(
                $"¿Desea eliminar a '{nombrePaciente}'?\n\nEsta acción no se puede deshacer.");

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int pacienteId = (int)dgvPacientes.SelectedRows[0].Cells["PacienteId"].Value;
                    var paciente = _unitOfWork.Pacientes.GetById(pacienteId);
                    
                    if (paciente != null)
                    {
                        _unitOfWork.Pacientes.Remove(paciente);
                        if (SessionManager.UsuarioActual != null)
                        {
                            LogHelper.LogCambio(SessionManager.UsuarioActual.UserId, "Paciente", pacienteId, "DELETE", $"Eliminado: {paciente.Nombres}");
                        }
                        MostrarMensajeExito($"✓ Paciente '{nombrePaciente}' eliminado exitosamente.");
                        CargarPacientes();
                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Error eliminando paciente", ex);
                    MostrarMensajeError($"Error al eliminar: {ex.Message}");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            habilitar_controles(false);
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese nombres.");
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese apellidos.");
                txtApellidos.Focus();
                return false;
            }

            if (!ValidationHelper.EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("Email inválido.");
                txtEmail.Focus();
                return false;
            }

            if (!ValidationHelper.EsDocumentoValido(txtDocumento.Text))
            {
                MessageBox.Show("Documento inválido.");
                txtDocumento.Focus();
                return false;
            }

            if (cmbEPS.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar una EPS válida.");
                cmbEPS.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDocumento.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            cmbEPS.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void habilitar_controles(bool habilitar)
        {
            txtNombres.Enabled = habilitar;
            txtApellidos.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtDocumento.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtCiudad.Enabled = habilitar;
            cmbEPS.Enabled = habilitar;
            cmbGenero.Enabled = habilitar;
            dtpFechaNacimiento.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        /// <summary>
        /// Event handler para aplicar filtros avanzados en PacientesForm
        /// </summary>
        private void BtnAplicarFiltrosPac_Click(object sender, EventArgs e)
        {
            try
            {
                _paginaActual = 1;
                
                string generoFiltro = cmbFiltroGenero.SelectedItem?.ToString() ?? "";
                int edadMin = (int)nudFiltroEdadMin.Value;
                int edadMax = (int)nudFiltroEdadMax.Value;
                string eps = cmbFiltroEPS.SelectedItem?.ToString() ?? "";

                // Convertir género a código BD
                string generoCodigoFiltro = "";
                if (!string.IsNullOrEmpty(generoFiltro) && generoFiltro != "Todos")
                {
                    if (generoFiltro == "Masculino")
                        generoCodigoFiltro = "M";
                    else if (generoFiltro == "Femenino")
                        generoCodigoFiltro = "F";
                    else if (generoFiltro == "Otro")
                        generoCodigoFiltro = "O";
                }

                List<Paciente> pacientes = new List<Paciente>();

                // Aplicar filtro por EPS primero si está seleccionado
                if (!string.IsNullOrEmpty(eps) && eps != "Todos")
                {
                    var epsList = _unitOfWork.EPS.GetAll();
                    var epsObj = epsList?.FirstOrDefault(e => e.Nombre == eps);
                    
                    if (epsObj != null)
                    {
                        var byEPS = _unitOfWork.Pacientes.BuscarPorEPS(epsObj.EPSId, _paginaActual, 1000);
                        if (byEPS != null)
                            pacientes = byEPS.ToList();
                    }
                }
                else
                {
                    // Si no hay filtro EPS, obtener todos
                    var allPacientes = _unitOfWork.Pacientes.GetAllPaged(_paginaActual, 1000);
                    if (allPacientes != null)
                        pacientes = allPacientes.ToList();
                }

                // Aplicar filtros adicionales en memoria
                var filtered = pacientes.Where(p =>
                {
                    // Filtro por Género
                    if (!string.IsNullOrEmpty(generoCodigoFiltro) && p.Genero != generoCodigoFiltro)
                        return false;

                    // Filtro por Edad
                    if (edadMax > 0 || edadMin > 0)
                    {
                        int edad = DateTime.Now.Year - p.FechaNacimiento.Year;
                        if (edad < edadMin || edad > edadMax)
                            return false;
                    }

                    return true;
                }).ToList();

                dgvPacientes.DataSource = filtered.Count > 0 ? filtered : null;
                
                if (filtered.Count == 0)
                {
                    MostrarMensajeAdverlencia("No se encontraron pacientes con los filtros especificados.\n\nIntenta ajustar los criterios de búsqueda.");
                }
                else
                {
                    MostrarMensajeExito($"Se encontraron {filtered.Count} paciente(s).");
                }
                
                LogHelper.Info($"Filtros aplicados - Género: {generoFiltro}, Edad: {edadMin}-{edadMax}, EPS: {eps}, Resultados: {filtered.Count}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error aplicando filtros: {ex.Message}", ex);
                MessageBox.Show($"Error al aplicar filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler para limpiar filtros en PacientesForm
        /// </summary>
        private void BtnLimpiarFiltrosPac_Click(object sender, EventArgs e)
        {
            try
            {
                cmbFiltroGenero.SelectedIndex = 0;
                nudFiltroEdadMin.Value = 0;
                nudFiltroEdadMax.Value = 120;
                cmbFiltroEPS.SelectedIndex = 0;
                dtpFiltroFechaReg.Value = DateTime.Now.AddYears(-1);
                
                CargarPacientes();
                LogHelper.Info("Filtros de Pacientes limpiados");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error limpiando filtros: {ex.Message}");
            }
        }

        private void PacientesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _unitOfWork?.Dispose();
        }

        private void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarMensajeAdverlencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private DialogResult ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}

