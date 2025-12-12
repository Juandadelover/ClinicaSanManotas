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
            pnlMenu = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnPacientes = new Button();
            btnMedicos = new Button();
            btnCitas = new Button();
            btnUsuarios = new Button();
            btnEspecialidades = new Button();
            btnEPS = new Button();
            pnlFooter = new Panel();
            lblUsuario = new Label();
            btnCerrarSesion = new Button();
            pnlMenu.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.White;
            pnlMenu.BackgroundImage = CLINICA_SAN_MANOTAS.Properties.Resources.fondo_de_pasillo_vacio;
            pnlMenu.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(lblSubtitulo);
            pnlMenu.Controls.Add(btnPacientes);
            pnlMenu.Controls.Add(btnMedicos);
            pnlMenu.Controls.Add(btnCitas);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(btnEspecialidades);
            pnlMenu.Controls.Add(btnEPS);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(4, 3, 4, 3);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(1026, 600);
            pnlMenu.TabIndex = 0;
            pnlMenu.Paint += pnlMenu_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(244, 66);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(933, 78);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel de Control - Administrador";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(244, 144);
            lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(923, 29);
            lblSubtitulo.TabIndex = 8;
            lblSubtitulo.Text = "Seleccione una opción para gestionar";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPacientes
            // 
            btnPacientes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPacientes.BackColor = Color.DarkSlateGray;
            btnPacientes.Cursor = Cursors.Hand;
            btnPacientes.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnPacientes.FlatAppearance.BorderSize = 0;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPacientes.ForeColor = Color.White;
            btnPacientes.Location = new Point(351, 230);
            btnPacientes.Margin = new Padding(4, 3, 4, 3);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(175, 67);
            btnPacientes.TabIndex = 1;
            btnPacientes.Text = "Gestionar Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnMedicos
            // 
            btnMedicos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMedicos.BackColor = Color.DarkSlateGray;
            btnMedicos.Cursor = Cursors.Hand;
            btnMedicos.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnMedicos.FlatAppearance.BorderSize = 0;
            btnMedicos.FlatStyle = FlatStyle.Flat;
            btnMedicos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnMedicos.ForeColor = Color.White;
            btnMedicos.Location = new Point(590, 230);
            btnMedicos.Margin = new Padding(4, 3, 4, 3);
            btnMedicos.Name = "btnMedicos";
            btnMedicos.Size = new Size(175, 67);
            btnMedicos.TabIndex = 2;
            btnMedicos.Text = "Gestionar Médicos";
            btnMedicos.UseVisualStyleBackColor = false;
            btnMedicos.Click += btnMedicos_Click;
            // 
            // btnCitas
            // 
            btnCitas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCitas.BackColor = Color.DarkSlateGray;
            btnCitas.Cursor = Cursors.Hand;
            btnCitas.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnCitas.FlatAppearance.BorderSize = 0;
            btnCitas.FlatStyle = FlatStyle.Flat;
            btnCitas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCitas.ForeColor = Color.White;
            btnCitas.Location = new Point(829, 230);
            btnCitas.Margin = new Padding(4, 3, 4, 3);
            btnCitas.Name = "btnCitas";
            btnCitas.Size = new Size(175, 67);
            btnCitas.TabIndex = 3;
            btnCitas.Text = "Gestionar Citas";
            btnCitas.UseVisualStyleBackColor = false;
            btnCitas.Click += btnCitas_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUsuarios.BackColor = Color.DarkSlateGray;
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.FlatAppearance.BorderColor = Color.FromArgb(155, 89, 182);
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(351, 328);
            btnUsuarios.Margin = new Padding(4, 3, 4, 3);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(175, 67);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "Administrar Usuarios";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnEspecialidades
            // 
            btnEspecialidades.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEspecialidades.BackColor = Color.DarkSlateGray;
            btnEspecialidades.Cursor = Cursors.Hand;
            btnEspecialidades.FlatAppearance.BorderColor = Color.FromArgb(46, 204, 113);
            btnEspecialidades.FlatAppearance.BorderSize = 0;
            btnEspecialidades.FlatStyle = FlatStyle.Flat;
            btnEspecialidades.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEspecialidades.ForeColor = Color.White;
            btnEspecialidades.Location = new Point(590, 328);
            btnEspecialidades.Margin = new Padding(4, 3, 4, 3);
            btnEspecialidades.Name = "btnEspecialidades";
            btnEspecialidades.Size = new Size(175, 67);
            btnEspecialidades.TabIndex = 5;
            btnEspecialidades.Text = "Especialidades";
            btnEspecialidades.UseVisualStyleBackColor = false;
            btnEspecialidades.Click += btnEspecialidades_Click;
            // 
            // btnEPS
            // 
            btnEPS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEPS.BackColor = Color.DarkSlateGray;
            btnEPS.Cursor = Cursors.Hand;
            btnEPS.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnEPS.FlatAppearance.BorderSize = 0;
            btnEPS.FlatStyle = FlatStyle.Flat;
            btnEPS.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEPS.ForeColor = Color.White;
            btnEPS.Location = new Point(829, 328);
            btnEPS.Margin = new Padding(4, 3, 4, 3);
            btnEPS.Name = "btnEPS";
            btnEPS.Size = new Size(175, 67);
            btnEPS.TabIndex = 6;
            btnEPS.Text = "Gestionar EPS";
            btnEPS.UseVisualStyleBackColor = false;
            btnEPS.Click += btnEPS_Click;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(236, 240, 241);
            pnlFooter.BorderStyle = BorderStyle.FixedSingle;
            pnlFooter.Controls.Add(lblUsuario);
            pnlFooter.Controls.Add(btnCerrarSesion);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 531);
            pnlFooter.Margin = new Padding(4, 3, 4, 3);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1026, 69);
            pnlFooter.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Location = new Point(23, 23);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(1114, 10);
            btnCerrarSesion.Margin = new Padding(4, 3, 4, 3);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(158, 40);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = CLINICA_SAN_MANOTAS.Properties.Resources.fondo_de_pasillo_vacio;
            ClientSize = new Size(1026, 600);
            Controls.Add(pnlFooter);
            Controls.Add(pnlMenu);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLINICA SAN MANOTAS - Panel Administrativo";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            pnlMenu.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
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
