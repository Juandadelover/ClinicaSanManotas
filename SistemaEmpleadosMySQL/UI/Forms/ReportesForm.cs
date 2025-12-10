using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.Helpers;
using SistemaEmpleadosMySQL.Model;
using SistemaEmpleadosMySQL.DAO;
using SistemaEmpleadosMySQL.Repositories;

namespace SistemaEmpleadosMySQL.UI.Forms
{
    /// <summary>
    /// Formulario de Reportes - Análisis y estadísticas
    /// </summary>
    public partial class ReportesForm : Form
    {
        private UnitOfWork _unitOfWork;

        public ReportesForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Reportes y Estadísticas";
                ConfigurarControles();
                GenerarReporteGeneral();
                LogHelper.Info("Formulario de reportes cargado exitosamente");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al cargar formulario de reportes: {ex.Message}");
                MessageBox.Show($"Error al cargar los reportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Resumen General");
            cmbTipoReporte.Items.Add("Pacientes");
            cmbTipoReporte.Items.Add("Médicos");
            cmbTipoReporte.Items.Add("Citas");
            cmbTipoReporte.Items.Add("Especialidades");
            cmbTipoReporte.Items.Add("Usuarios");
            cmbTipoReporte.SelectedIndex = 0;

            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoReporte = cmbTipoReporte.SelectedItem.ToString();

                switch (tipoReporte)
                {
                    case "Resumen General":
                        GenerarReporteGeneral();
                        break;
                    case "Pacientes":
                        GenerarReportePacientes();
                        break;
                    case "Médicos":
                        GenerarReporteMedicos();
                        break;
                    case "Citas":
                        GenerarReporteCitas();
                        break;
                    case "Especialidades":
                        GenerarReporteEspecialidades();
                        break;
                    case "Usuarios":
                        GenerarReporteUsuarios();
                        break;
                }

                LogHelper.Info($"Reporte '{tipoReporte}' generado por {SessionManager.UsuarioActual?.Username}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte: {ex.Message}");
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporteGeneral()
        {
            try
            {
                txtReporte.Clear();
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
                txtReporte.AppendText("REPORTE GENERAL - CLÍNICA SAN MANOTAS\n");
                txtReporte.AppendText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n");
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n\n");

                // Estadísticas de Pacientes
                var pacientes = _unitOfWork.Pacientes.GetAll();
                int totalPacientes = pacientes?.Count() ?? 0;
                int pacientesActivos = pacientes?.Where(p => p.Estado == "Activo").Count() ?? 0;

                txtReporte.AppendText("📋 ESTADÍSTICAS DE PACIENTES\n");
                txtReporte.AppendText($"  Total de Pacientes: {totalPacientes}\n");
                txtReporte.AppendText($"  Pacientes Activos: {pacientesActivos}\n");
                txtReporte.AppendText($"  Pacientes Inactivos: {totalPacientes - pacientesActivos}\n\n");

                // Estadísticas de Médicos
                var medicos = _unitOfWork.Medicos.GetAll();
                int totalMedicos = medicos?.Count() ?? 0;
                int medicosActivos = medicos?.Where(m => m.Estado == "Activo").Count() ?? 0;

                txtReporte.AppendText("👨‍⚕️ ESTADÍSTICAS DE MÉDICOS\n");
                txtReporte.AppendText($"  Total de Médicos: {totalMedicos}\n");
                txtReporte.AppendText($"  Médicos Activos: {medicosActivos}\n");
                txtReporte.AppendText($"  Médicos Inactivos: {totalMedicos - medicosActivos}\n\n");

                // Estadísticas de Citas
                var citas = _unitOfWork.Citas.GetAll();
                int totalCitas = citas?.Count() ?? 0;
                int citasPendientes = citas?.Where(c => c.Estado == "Pendiente").Count() ?? 0;
                int citasConfirmadas = citas?.Where(c => c.Estado == "Confirmada").Count() ?? 0;
                int citasRealizadas = citas?.Where(c => c.Estado == "Realizada").Count() ?? 0;
                int citasCanceladas = citas?.Where(c => c.Estado == "Cancelada").Count() ?? 0;

                txtReporte.AppendText("📅 ESTADÍSTICAS DE CITAS\n");
                txtReporte.AppendText($"  Total de Citas: {totalCitas}\n");
                txtReporte.AppendText($"  Citas Pendientes: {citasPendientes}\n");
                txtReporte.AppendText($"  Citas Confirmadas: {citasConfirmadas}\n");
                txtReporte.AppendText($"  Citas Realizadas: {citasRealizadas}\n");
                txtReporte.AppendText($"  Citas Canceladas: {citasCanceladas}\n\n");

                // Estadísticas de Especialidades
                var especialidades = _unitOfWork.Especialidades.GetAll();
                int totalEspecialidades = especialidades?.Count() ?? 0;

                txtReporte.AppendText("🏥 ESTADÍSTICAS DE ESPECIALIDADES\n");
                txtReporte.AppendText($"  Total de Especialidades: {totalEspecialidades}\n\n");

                // Estadísticas de Usuarios
                var usuarios = _unitOfWork.Usuarios.GetAll();
                int totalUsuarios = usuarios?.Count() ?? 0;
                int admins = usuarios?.Where(u => u.Role == "Admin").Count() ?? 0;
                int recepcionistas = usuarios?.Where(u => u.Role == "Recepcionista").Count() ?? 0;
                int doctores = usuarios?.Where(u => u.Role == "Doctor").Count() ?? 0;

                txtReporte.AppendText("👥 ESTADÍSTICAS DE USUARIOS\n");
                txtReporte.AppendText($"  Total de Usuarios: {totalUsuarios}\n");
                txtReporte.AppendText($"  Administradores: {admins}\n");
                txtReporte.AppendText($"  Recepcionistas: {recepcionistas}\n");
                txtReporte.AppendText($"  Doctores: {doctores}\n\n");

                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte general: {ex.Message}");
                txtReporte.Text = $"Error al generar el reporte: {ex.Message}";
            }
        }

        private void GenerarReportePacientes()
        {
            try
            {
                txtReporte.Clear();
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
                txtReporte.AppendText("REPORTE DE PACIENTES\n");
                txtReporte.AppendText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n");
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n\n");

                var pacientes = _unitOfWork.Pacientes.GetAll();

                if (pacientes == null || pacientes.Count() == 0)
                {
                    txtReporte.AppendText("No hay pacientes registrados.\n");
                    return;
                }

                txtReporte.AppendText("ID\tNombre\t\t\tEmail\t\t\tEstado\n");
                txtReporte.AppendText("─────────────────────────────────────────────────────────────\n");

                foreach (var paciente in pacientes)
                {
                    string estado = paciente.Estado ?? "Desconocido";
                    txtReporte.AppendText($"{paciente.PacienteId}\t{paciente.Nombres} {paciente.Apellidos}\t{paciente.Email}\t{estado}\n");
                }

                txtReporte.AppendText("\n═══════════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte de pacientes: {ex.Message}");
                txtReporte.Text = $"Error: {ex.Message}";
            }
        }

        private void GenerarReporteMedicos()
        {
            try
            {
                txtReporte.Clear();
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
                txtReporte.AppendText("REPORTE DE MÉDICOS\n");
                txtReporte.AppendText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n");
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n\n");

                var medicos = _unitOfWork.Medicos.GetAll();

                if (medicos == null || medicos.Count() == 0)
                {
                    txtReporte.AppendText("No hay médicos registrados.\n");
                    return;
                }

                txtReporte.AppendText("ID\tMédico\t\t\tEspecialidad\t\tLicencia\tEstado\n");
                txtReporte.AppendText("─────────────────────────────────────────────────────────────\n");

                foreach (var medico in medicos)
                {
                    var especialidad = _unitOfWork.Especialidades.GetById(medico.EspecialidadId);
                    string especialidadNombre = especialidad?.Nombre ?? "Desconocida";
                    string estado = medico.Estado ?? "Desconocido";

                    txtReporte.AppendText($"{medico.MedicoId}\t{medico.Nombres} {medico.Apellidos}\t{especialidadNombre}\t{medico.Licencia}\t{estado}\n");
                }

                txtReporte.AppendText("\n═══════════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte de médicos: {ex.Message}");
                txtReporte.Text = $"Error: {ex.Message}";
            }
        }

        private void GenerarReporteCitas()
        {
            try
            {
                txtReporte.Clear();
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
                txtReporte.AppendText("REPORTE DE CITAS\n");
                txtReporte.AppendText($"Período: {dtpFechaInicio.Value:dd/MM/yyyy} a {dtpFechaFin.Value:dd/MM/yyyy}\n");
                txtReporte.AppendText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n");
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n\n");

                var citas = _unitOfWork.Citas.GetAll();

                if (citas == null || citas.Count() == 0)
                {
                    txtReporte.AppendText("No hay citas registradas.\n");
                    return;
                }

                var citasFiltradas = citas.Where(c => c.Fecha >= dtpFechaInicio.Value && c.Fecha <= dtpFechaFin.Value).ToList();

                txtReporte.AppendText($"Citas en el período: {citasFiltradas.Count}\n\n");
                txtReporte.AppendText("ID\tPaciente\t\tMédico\t\tFecha\t\tEstado\n");
                txtReporte.AppendText("─────────────────────────────────────────────────────────────\n");

                foreach (var cita in citasFiltradas)
                {
                    var paciente = _unitOfWork.Pacientes.GetById(cita.PacienteId);
                    var medico = _unitOfWork.Medicos.GetById(cita.MedicoId);
                    string estado = cita.Estado ?? "Desconocido";

                    txtReporte.AppendText($"{cita.CitaId}\t{paciente?.Nombres}\t{medico?.Nombres}\t{cita.Fecha:dd/MM/yyyy}\t{estado}\n");
                }

                txtReporte.AppendText("\n═══════════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte de citas: {ex.Message}");
                txtReporte.Text = $"Error: {ex.Message}";
            }
        }

        private void GenerarReporteEspecialidades()
        {
            try
            {
                txtReporte.Clear();
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
                txtReporte.AppendText("REPORTE DE ESPECIALIDADES\n");
                txtReporte.AppendText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n");
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n\n");

                var especialidades = _unitOfWork.Especialidades.GetAll();
                var medicos = _unitOfWork.Medicos.GetAll();

                if (especialidades == null || especialidades.Count() == 0)
                {
                    txtReporte.AppendText("No hay especialidades registradas.\n");
                    return;
                }

                txtReporte.AppendText("Especialidad\t\tMédicos Asignados\tDescripción\n");
                txtReporte.AppendText("─────────────────────────────────────────────────────────────\n");

                foreach (var especialidad in especialidades)
                {
                    int medicosAsignados = medicos?.Where(m => m.EspecialidadId == especialidad.EspecialidadId).Count() ?? 0;
                    string descripcion = especialidad.Descripcion ?? "Sin descripción";

                    txtReporte.AppendText($"{especialidad.Nombre}\t\t{medicosAsignados}\t\t\t{descripcion}\n");
                }

                txtReporte.AppendText("\n═══════════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte de especialidades: {ex.Message}");
                txtReporte.Text = $"Error: {ex.Message}";
            }
        }

        private void GenerarReporteUsuarios()
        {
            try
            {
                txtReporte.Clear();
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n");
                txtReporte.AppendText("REPORTE DE USUARIOS\n");
                txtReporte.AppendText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n");
                txtReporte.AppendText("═══════════════════════════════════════════════════════════════\n\n");

                var usuarios = _unitOfWork.Usuarios.GetAll();

                if (usuarios == null || usuarios.Count() == 0)
                {
                    txtReporte.AppendText("No hay usuarios registrados.\n");
                    return;
                }

                txtReporte.AppendText("ID\tUsuario\t\t\tRol\t\t\tEstado\t\tÚltimo Login\n");
                txtReporte.AppendText("─────────────────────────────────────────────────────────────\n");

                foreach (var usuario in usuarios)
                {
                    string rol = usuario.Role ?? "Desconocido";
                    string estado = usuario.Estado ?? "Desconocido";
                    string ultimoLogin = usuario.FechaUltimoLogin?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Nunca";

                    txtReporte.AppendText($"{usuario.UserId}\t{usuario.Username}\t\t{rol}\t\t{estado}\t\t{ultimoLogin}\n");
                }

                txtReporte.AppendText("\n═══════════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al generar reporte de usuarios: {ex.Message}");
                txtReporte.Text = $"Error: {ex.Message}";
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de texto (*.txt)|*.txt|Archivos CSV (*.csv)|*.csv",
                    DefaultExt = "txt"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, txtReporte.Text);
                    LogHelper.Info($"Reporte exportado a {saveFileDialog.FileName} por {SessionManager.UsuarioActual?.Username}");
                    MessageBox.Show("Reporte exportado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error al exportar reporte: {ex.Message}");
                MessageBox.Show($"Error al exportar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

