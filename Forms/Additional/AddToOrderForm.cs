using Course_Project.Models.Core;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddToOrderForm : Form
    {
        private Product.ProductWithNames product;

        public int SelectedQuantity { get; private set; } = 1;

        public AddToOrderForm(Product.ProductWithNames p)
        {
            InitializeComponent();
            product = p;

            lblName.Text = p.name;
            lblPrice.Text = p.price.ToString("0.00") + " грн";
            lblAvailable.Text = "Доступно: " + p.quantity;

            numQuantity.Minimum = 1;
            numQuantity.Maximum = p.quantity > 0 ? p.quantity : 1;
            numQuantity.Value = 1;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SelectedQuantity = (int)numQuantity.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
