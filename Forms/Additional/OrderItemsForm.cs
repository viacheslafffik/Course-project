using Course_Project.Models.Orders;
using System;
using System.Data;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class OrderItemsForm : Form
    {
        private readonly int orderId;

        public OrderItemsForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadItems();
        }

        private void LoadItems()
        {
            var items = Order.GetItems(orderId);

            var table = new DataTable();
            table.Columns.Add("Товар");
            table.Columns.Add("Ціна, грн", typeof(decimal));
            table.Columns.Add("Кількість", typeof(int));
            table.Columns.Add("Сума, грн", typeof(decimal));

            foreach (var i in items)
            {
                table.Rows.Add(
                    i.name,
                    i.price,
                    i.quantity,
                    i.price * i.quantity
                );
            }
            dgvItems.DataSource = table;
        }
    }
}
