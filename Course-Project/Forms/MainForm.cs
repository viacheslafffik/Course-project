using System;
using Course_Project.Forms;
using System.Windows.Forms;

namespace Course_Project.Forms
{
    public partial class MainForm : Form
    {
        private string _username;
        private string _role;
        private string _firstName;

        public MainForm(string username, string role, string firstName)
        {
            InitializeComponent();
            _username = username;
            _role = role;
            _firstName = firstName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Показуємо привітання
            lblHello.Text = $"Привіт, {_firstName}!";

            // Касир НЕ може керувати користувачами
            if (_role != "admin")
            {
                btnUsers.Enabled = false;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new Forms.UsersForm().ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут буде форма товарів.");
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут буде форма продажів.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().Show();
        }
    }
}
