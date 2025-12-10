namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.RichTextBox txtReporte;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnExportar;

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
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.txtReporte = new System.Windows.Forms.RichTextBox();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Location = new System.Drawing.Point(12, 12);
            this.cmbTipoReporte.Size = new System.Drawing.Size(200, 23);

            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Location = new System.Drawing.Point(220, 12);
            this.dtpFechaInicio.Size = new System.Drawing.Size(150, 23);

            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Location = new System.Drawing.Point(378, 12);
            this.dtpFechaFin.Size = new System.Drawing.Size(150, 23);

            this.txtReporte.Name = "txtReporte";
            this.txtReporte.Location = new System.Drawing.Point(12, 43);
            this.txtReporte.Size = new System.Drawing.Size(760, 300);

            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.Location = new System.Drawing.Point(12, 351);
            this.btnGenerarReporte.Size = new System.Drawing.Size(150, 30);

            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Location = new System.Drawing.Point(170, 351);
            this.btnExportar.Size = new System.Drawing.Size(100, 30);

            this.Controls.Add(this.cmbTipoReporte);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.txtReporte);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.btnExportar);

            this.Name = "ReportesForm";
            this.Text = "Reportes";
            this.Size = new System.Drawing.Size(800, 400);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
