using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class ClientsOrdersForm : Form
    {
        private readonly int clientId;

        public ClientsOrdersForm(int clientId, string clientName)
        {
            InitializeComponent();
            this.clientId = clientId;
            Text = $"Історія покупок: {clientName}";
            LoadOrders();
        }

        private void LoadOrders()
        {
            var table = new DataTable();
            table.Columns.Add("Дата");
            table.Columns.Add("Сума (грн)");

            using (var conn = Db.Connection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    @"SELECT orderDate, totalPrice 
                      FROM Orders 
                      WHERE clientId = @cid
                      ORDER BY orderDate DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@cid", clientId);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            table.Rows.Add(
                                Convert.ToDateTime(r["orderDate"]).ToString("dd.MM.yyyy HH:mm"),
                                Convert.ToDecimal(r["totalPrice"]).ToString("0.00")
                            );
                        }
                    }
                }
            }

            dgvOrders.DataSource = table;
        }
    }
}
