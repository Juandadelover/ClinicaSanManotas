namespace ClinicaSanManotas.UI.Forms
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
            pnlMenu = new Panel();
            lblTitulo = new Label();
            btnMisCitas = new Button();
            btnPacientes = new Button();
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
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(btnMisCitas);
            pnlMenu.Controls.Add(btnPacientes);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(4, 3, 4, 3);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(933, 600);
            pnlMenu.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(4, 77);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(933, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel del Doctor";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // btnMisCitas
            // 
            btnMisCitas.BackColor = Color.White;
            btnMisCitas.Cursor = Cursors.Hand;
            btnMisCitas.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnMisCitas.FlatAppearance.BorderSize = 2;
            btnMisCitas.FlatStyle = FlatStyle.Flat;
            btnMisCitas.Font = new Font("Segoe UI", 11F);
            btnMisCitas.ForeColor = Color.Black;
            btnMisCitas.Location = new Point(233, 173);
            btnMisCitas.Margin = new Padding(4, 3, 4, 3);
            btnMisCitas.Name = "btnMisCitas";
            btnMisCitas.Size = new Size(210, 75);
            btnMisCitas.TabIndex = 1;
            btnMisCitas.Text = "Mis Citas";
            btnMisCitas.UseVisualStyleBackColor = false;
            btnMisCitas.Click += btnMisCitas_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = Color.White;
            btnPacientes.Cursor = Cursors.Hand;
            btnPacientes.FlatAppearance.BorderColor = Color.FromArgb(46, 204, 113);
            btnPacientes.FlatAppearance.BorderSize = 2;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 11F);
            btnPacientes.ForeColor = Color.Black;
            btnPacientes.Location = new Point(490, 173);
            btnPacientes.Margin = new Padding(4, 3, 4, 3);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(210, 75);
            btnPacientes.TabIndex = 2;
            btnPacientes.Text = "Mis Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            btnPacientes.Click += btnPacientes_Click;
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
            pnlFooter.Size = new Size(933, 69);
            pnlFooter.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.ForeColor = Color.FromArgb(44, 62, 80);
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
            btnCerrarSesion.Location = new Point(747, 14);
            btnCerrarSesion.Margin = new Padding(4, 3, 4, 3);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(158, 40);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(933, 600);
            Controls.Add(pnlFooter);
            Controls.Add(pnlMenu);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DoctorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLINICA SAN MANOTAS - Panel del Doctor";
            FormClosing += DoctorForm_FormClosing;
            Load += DoctorForm_Load;
            pnlMenu.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
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
