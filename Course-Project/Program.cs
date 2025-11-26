using System;
using System.Windows.Forms;
using Course_Project.Forms;
using Course_Project.Models;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!User.AdminExists())
            {
                User.CreateSystemAdminDefault();
                MessageBox.Show(
                    "Створено системного адміністратора:\n\n" +
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
