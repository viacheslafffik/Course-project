using Course_Project.Pages;
using Course_Project.Pages.Products;
using Course_Project.Pages.Supplies;
using Course_Project.Utils;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblHello.Text = $"Привіт, {Session.FirstName}!";

            if (!Session.IsAdmin)
                btnUsers.Hide();

            LoadPage(new ProductsPage3());
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            LoadPage(new UsersPage());
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            LoadPage(new ProductsPage3());
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            LoadPage(new OrdersPage());
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            LoadPage(new ClientsPage());
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            LoadPage(new OrdersHistoryPage());
        }

        private void BtnSupply_Click(object sender, EventArgs e)
        {
            LoadPage(new SuppliesPage());
        }

        private void BtnBestsellers_Click(object sender, EventArgs e)
        {
            LoadPage(new BestsellersPage());
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Hide();
            new LoginForm().Show();
        }
    }
}
