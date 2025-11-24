using System;
using System.Windows.Forms;
using Course_Project.Database;
using Course_Project.Forms;

namespace Course_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if NET6_0_OR_GREATER
            ApplicationConfiguration.Initialize();
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#endif
            if (!DataInitializer.AdminExists())
            {
                DataInitializer.CreateSystemAdminDefault();
                MessageBox.Show(
                    "Створено системного адміністратора!\n\n" +
                    "Логін: admin\n" +
                    "Пароль: admin123",
                    "Перший запуск",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            Application.Run(new LoginForm());
        }
    }
}
