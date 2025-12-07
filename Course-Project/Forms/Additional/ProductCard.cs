using Course_Project.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class ProductCard : UserControl
    {
        private bool expanded = false;
        private Product product;
        private string role;

        public ProductCard(Product.ProductWithNames p, string userRole)
        {
            InitializeComponent();
            product = p;
            role = userRole;
            lblName.Text = $"Назва: {p.name}";
            lblPrice.Text = $"Ціна: {p.price} грн";
            lblQty.Text = $"Кількість: {p.quantity}";
            lblCategory.Text = $"Категорія: {p.CategoryName}";
            lblBrand.Text = $"Бренд: {p.BrandName}";
            ApplyRole();
            SetupAttributePanel();
            LoadAttributes();
            pnlAttributes.Visible = false;
        }

        private void ApplyRole() => btnEdit.Visible = (role == "admin");       

        private void SetupAttributePanel()
        {
            pnlAttributes.Height = 100;
            flpAttributes.Height = 100;
            flpAttributes.AutoScroll = true;
            pnlAttributes.AutoSize = false;
            flpAttributes.AutoSize = false;
        }

        private void LoadAttributes()
        {
            flpAttributes.Controls.Clear();
            foreach (var a in product.GetAttributes())
            {
                var lbl = new Label
                {
                    Text = $"{a.Name}: {a.Value}",
                    AutoSize = true,
                    ForeColor = Color.Gray
                };
                flpAttributes.Controls.Add(lbl);
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            expanded = !expanded;
            pnlAttributes.Visible = expanded;
            btnToggle.Text = expanded ?
                "Сховати ▲" :
                "Показати характеристики ▼";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //var form = new EditProductForm(product.productId);
            //form.ShowDialog();
        }
    }
}