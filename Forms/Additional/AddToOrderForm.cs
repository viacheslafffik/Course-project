using Course_Project.Models.Products;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddToOrderForm : Form
    {
        private ProductListItem product;

        public int SelectedQuantity { get; private set; } = 1;

        public AddToOrderForm(ProductListItem p)
        {
            InitializeComponent();
            product = p;

            lblName.Text = p.Name;
            lblPrice.Text = p.Price.ToString("0.00") + " грн";
            lblAvailable.Text = "Доступно: " + p.Quantity;

            numQuantity.Minimum = 1;
            numQuantity.Maximum = p.Quantity > 0 ? p.Quantity : 1;
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