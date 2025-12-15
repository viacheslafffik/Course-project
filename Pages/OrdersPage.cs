using Course_Project.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Course_Project.Pages
{
    public partial class OrdersPage : UserControl
    {
        private readonly string username;

        public OrdersPage(string username)
        {
            InitializeComponent();
            this.username = username;

            dgvCart.AutoGenerateColumns = true;
            OrderCart.Changed += RefreshCart;

            RefreshCart();
        }

        private void RefreshCart()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshCart));
                return;
            }

            var table = new DataTable();

            table.Columns.Add("productId", typeof(int));

            table.Columns.Add("Назва товару", typeof(string));
            table.Columns.Add("Ціна, грн", typeof(decimal));
            table.Columns.Add("Кількість", typeof(int));
            table.Columns.Add("Сума, грн", typeof(decimal));

            foreach (var i in OrderCart.Items)
            {
                table.Rows.Add(
                    i.productId,
                    i.name,
                    i.price,
                    i.quantity,
                    i.price * i.quantity
                );
            }

            dgvCart.DataSource = table;
            dgvCart.Columns["productId"].Visible = false;
            lblTotal.Text = "Разом: " + OrderCart.Total().ToString("0.00") + " грн";
        }


        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCart.CurrentRow.Cells["productId"].Value);
            OrderCart.Remove(id);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            OrderCart.Clear();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (OrderCart.Items.Count == 0)
            {
                MessageBox.Show("Кошик порожній.");
                return;
            }

            try
            {
                int userId = User.GetIdByUsername(username);
                Order.Create(userId);

                MessageBox.Show("Замовлення оформлено!");
                OrderCart.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося зберегти замовлення.\n" + ex.Message);
            }
        }
    }
}
