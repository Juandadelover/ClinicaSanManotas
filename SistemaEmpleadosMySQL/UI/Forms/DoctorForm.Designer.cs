namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class DoctorForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMisCitas = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlMenu
            this.pnlMenu.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMenu.Controls.Add(this.lblTitulo);
            this.pnlMenu.Controls.Add(this.btnMisCitas);
            this.pnlMenu.Controls.Add(this.btnPacientes);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(800, 500);
            this.pnlMenu.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(150, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Panel del Doctor";

            // btnMisCitas
            this.btnMisCitas.Location = new System.Drawing.Point(100, 100);
            this.btnMisCitas.Name = "btnMisCitas";
            this.btnMisCitas.Size = new System.Drawing.Size(150, 40);
            this.btnMisCitas.TabIndex = 1;
            this.btnMisCitas.Text = "Mis Citas";
            this.btnMisCitas.UseVisualStyleBackColor = true;
            this.btnMisCitas.Click += new System.EventHandler(this.btnMisCitas_Click);

            // btnPacientes
            this.btnPacientes.Location = new System.Drawing.Point(350, 100);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(150, 40);
            this.btnPacientes.TabIndex = 2;
            this.btnPacientes.Text = "Mis Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFooter.Controls.Add(this.lblUsuario);
            this.pnlFooter.Controls.Add(this.btnCerrarSesion);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 420);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 80);
            this.pnlFooter.TabIndex = 1;

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(20, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";

            // btnCerrarSesion
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Red;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(650, 15);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 35);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // DoctorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMenu);
            this.Name = "DoctorForm";
            this.Text = "CLINICA SAN MANOTAS - Panel del Doctor";
            this.Load += new System.EventHandler(this.DoctorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoctorForm_FormClosing);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMisCitas;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
