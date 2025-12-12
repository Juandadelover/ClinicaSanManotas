namespace SistemaEmpleadosMySQL.UI.Forms
{
    partial class RecepcionForm
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
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            btnPacientes = new Button();
            btnCitas = new Button();
            pnlFooter = new Panel();
            lblUsuario = new Label();
            btnCerrarSesion = new Button();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.White;
            pnlMenu.Controls.Add(pictureBox1);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(btnPacientes);
            pnlMenu.Controls.Add(btnCitas);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(4, 3, 4, 3);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(933, 600);
            pnlMenu.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(487, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(449, 506);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(-278, 36);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(933, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel de Recepción";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = Color.White;
            btnPacientes.Cursor = Cursors.Hand;
            btnPacientes.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnPacientes.FlatAppearance.BorderSize = 2;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 11F);
            btnPacientes.ForeColor = Color.Black;
            btnPacientes.Location = new Point(77, 158);
            btnPacientes.Margin = new Padding(4, 3, 4, 3);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(210, 75);
            btnPacientes.TabIndex = 1;
            btnPacientes.Text = "Gestionar Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnCitas
            // 
            btnCitas.BackColor = Color.White;
            btnCitas.Cursor = Cursors.Hand;
            btnCitas.FlatAppearance.BorderColor = Color.FromArgb(46, 204, 113);
            btnCitas.FlatAppearance.BorderSize = 2;
            btnCitas.FlatStyle = FlatStyle.Flat;
            btnCitas.Font = new Font("Segoe UI", 11F);
            btnCitas.ForeColor = Color.Black;
            btnCitas.Location = new Point(77, 288);
            btnCitas.Margin = new Padding(4, 3, 4, 3);
            btnCitas.Name = "btnCitas";
            btnCitas.Size = new Size(210, 75);
            btnCitas.TabIndex = 2;
            btnCitas.Text = "Gestionar Citas";
            btnCitas.UseVisualStyleBackColor = false;
            btnCitas.Click += btnCitas_Click;
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
            // RecepcionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(933, 600);
            Controls.Add(pnlFooter);
            Controls.Add(pnlMenu);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RecepcionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLINICA SAN MANOTAS - Panel de Recepción";
            FormClosing += RecepcionForm_FormClosing;
            Load += RecepcionForm_Load;
            pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private PictureBox pictureBox1;
    }
}
