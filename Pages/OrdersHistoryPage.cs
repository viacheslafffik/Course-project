using Course_Project.Models.Orders;
using Course_Project.Forms.Additional;
using System;
using System.Data;
using System.Windows.Forms;

namespace Course_Project.Pages
{
    public partial class OrdersHistoryPage : UserControl
    {
        private readonly string username;
        private readonly string role;

        public OrdersHistoryPage(string username, string role)
        {
            InitializeComponent();
            this.username = username;
            this.role = role;

            LoadOrders();
        }

        private void LoadOrders(string phone = null)
        {
            var orders = OrderInfo.GetOrders(role, username, phone);

            var table = new DataTable();
            table.Columns.Add("orderId", typeof(int));
            table.Columns.Add("Дата");
            table.Columns.Add("Телефон клієнта");
            table.Columns.Add("Продавець");
            table.Columns.Add("Сума без знижки");
            table.Columns.Add("Сума зі знижкою");

            foreach (var o in orders)
            {
                table.Rows.Add(
                    o.orderId,
                    o.orderDate.ToString("dd.MM.yyyy HH:mm"),
                    o.clientPhone ?? "-",
                    o.seller,
                    o.totalPrice.ToString("0.00"),
                    o.totalPriceWithDiscount.ToString("0.00")
                );
            }

            dgvOrders.DataSource = table;
            dgvOrders.Columns["orderId"].Visible = false;
        }

        private void DgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orderId = Convert.ToInt32(
                dgvOrders.Rows[e.RowIndex].Cells["orderId"].Value
            );

            new OrderItemsForm(orderId).ShowDialog();
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadOrders(tbPhone.Text.Trim());
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            tbPhone.Clear();
            LoadOrders();
        }
    }
}
