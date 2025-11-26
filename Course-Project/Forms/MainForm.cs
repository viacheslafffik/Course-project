using System;
using System.Windows.Forms;

namespace Course_Project.Forms
{
    public partial class MainForm : Form
    {
        private readonly string _username;
        private readonly string _role;
        private readonly string _firstName;

        public MainForm(string username, string role, string firstName)
        {
            InitializeComponent();
            _username = username;
            _role = role;
            _firstName = firstName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblHello.Text = $"Привіт, {_firstName}!";
            if (_role != "admin") btnUsers.Hide();  
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new UsersForm().ShowDialog();
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
