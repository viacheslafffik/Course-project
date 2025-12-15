using Course_Project.Pages;
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

            LoadPage(new ProductsPage(_role));
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadPage(new UsersPage());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadPage(new ProductsPage(_role));
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadPage(new OrdersPage(_username));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().Show();
        }
    }
}
