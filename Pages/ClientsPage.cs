using Course_Project.Forms.Additional;
using Course_Project.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Course_Project.Pages
{
    public partial class ClientsPage : UserControl
    {
        private List<Client> currentClients;

        public ClientsPage()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients(List<Client> data = null)
        {
            currentClients = data ?? Client.GetAll();

            var table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Імʼя");
            table.Columns.Add("Прізвище");
            table.Columns.Add("Телефон");
            table.Columns.Add("Знижка (%)");
            foreach (var c in currentClients) table.Rows.Add(c.clientId, c.firstName, c.lastName, c.phone, c.discount);
            dgvClients.DataSource = table;
            dgvClients.Columns["ID"].Visible = false;
            lblInfo.Text = $"Клієнтів: {currentClients.Count}";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                LoadClients();
                return;
            }

            var c = Client.GetByPhone(tbPhone.Text.Trim());
            if (c == null)
            {
                MessageBox.Show("Клієнта не знайдено");
                return;
            }

            LoadClients(new List<Client> { c });
        }

        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            new AddClientForm().ShowDialog();
            LoadClients();
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null) return;
            string phone = dgvClients.CurrentRow.Cells["Телефон"].Value.ToString();
            var client = Client.GetByPhone(phone);
            if (client == null)
            {
                MessageBox.Show("Клієнта не знайдено");
                return;
            }
            string fullName = $"{client.firstName} {client.lastName}";
            new ClientsOrdersForm(client.clientId, fullName).ShowDialog();
        }

    }
}
