namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class MainForm
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnEPS = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlMenu
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.lblTitulo);
            this.pnlMenu.Controls.Add(this.lblSubtitulo);
            this.pnlMenu.Controls.Add(this.btnPacientes);
            this.pnlMenu.Controls.Add(this.btnMedicos);
            this.pnlMenu.Controls.Add(this.btnCitas);
            this.pnlMenu.Controls.Add(this.btnUsuarios);
            this.pnlMenu.Controls.Add(this.btnEspecialidades);
            this.pnlMenu.Controls.Add(this.btnEPS);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(800, 520);
            this.pnlMenu.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblTitulo.Location = new System.Drawing.Point(0, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Panel de Control - Administrador";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 75);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(800, 25);
            this.lblSubtitulo.TabIndex = 8;
            this.lblSubtitulo.Text = "Seleccione una opción para gestionar";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnPacientes
            this.btnPacientes.BackColor = System.Drawing.Color.White;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnPacientes.FlatAppearance.BorderSize = 2;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPacientes.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnPacientes.Location = new System.Drawing.Point(100, 163);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(150, 58);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "Gestionar Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);

            // btnMedicos
            this.btnMedicos.BackColor = System.Drawing.Color.White;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnMedicos.FlatAppearance.BorderSize = 2;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMedicos.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnMedicos.Location = new System.Drawing.Point(305, 163);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(150, 58);
            this.btnMedicos.TabIndex = 2;
            this.btnMedicos.Text = "Gestionar Médicos";
            this.btnMedicos.UseVisualStyleBackColor = false;
            this.btnMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);

            // btnCitas
            this.btnCitas.BackColor = System.Drawing.Color.White;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnCitas.FlatAppearance.BorderSize = 2;
            this.btnCitas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCitas.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnCitas.Location = new System.Drawing.Point(510, 163);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(150, 58);
            this.btnCitas.TabIndex = 3;
            this.btnCitas.Text = "Gestionar Citas";
            this.btnCitas.UseVisualStyleBackColor = false;
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);

            // btnUsuarios
            this.btnUsuarios.BackColor = System.Drawing.Color.White;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnUsuarios.FlatAppearance.BorderSize = 2;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnUsuarios.Location = new System.Drawing.Point(100, 248);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(150, 58);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "Administrar Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);

            // btnEspecialidades
            this.btnEspecialidades.BackColor = System.Drawing.Color.White;
            this.btnEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecialidades.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnEspecialidades.FlatAppearance.BorderSize = 2;
            this.btnEspecialidades.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEspecialidades.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnEspecialidades.Location = new System.Drawing.Point(305, 248);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(150, 58);
            this.btnEspecialidades.TabIndex = 5;
            this.btnEspecialidades.Text = "Especialidades";
            this.btnEspecialidades.UseVisualStyleBackColor = false;
            this.btnEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);

            // btnEPS
            this.btnEPS.BackColor = System.Drawing.Color.White;
            this.btnEPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEPS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEPS.FlatAppearance.BorderSize = 2;
            this.btnEPS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEPS.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnEPS.Location = new System.Drawing.Point(510, 248);
            this.btnEPS.Name = "btnEPS";
            this.btnEPS.Size = new System.Drawing.Size(150, 58);
            this.btnEPS.TabIndex = 6;
            this.btnEPS.Text = "Gestionar EPS";
            this.btnEPS.UseVisualStyleBackColor = false;
            this.btnEPS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEPS.Click += new System.EventHandler(this.btnEPS_Click);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblUsuario);
            this.pnlFooter.Controls.Add(this.btnCerrarSesion);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 460);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 60);
            this.pnlFooter.TabIndex = 1;

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblUsuario.Location = new System.Drawing.Point(20, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 15);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";

            // btnCerrarSesion
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(640, 12);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(135, 35);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMenu);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLINICA SAN MANOTAS - Panel Administrativo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnEPS;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
