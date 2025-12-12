using ClinicaSanManotas.UI.Forms;
using System.Windows.Forms;

namespace CLINICA_SAN_MANOTAS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal al iniciar la aplicación:\n\n{ex.Message}\n\nTipo: {ex.GetType().Name}\n\nStack:\n{ex.StackTrace}", 
                    "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
