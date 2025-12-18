using Course_Project.Forms.Additional;
using Course_Project.Models.Orders;
using Course_Project.Models.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Course_Project.Pages.Products
{
    public partial class ProductCard : UserControl
    {
        private bool expanded = false;
        private ProductListItem product;

        //public ProductCard()
        //{
        //    InitializeComponent();
        //    btnToggle.Click += BtnToggle_Click;
        //    btnAddToOrder.Click += BtnAddToOrder_Click;
        //}

        public ProductCard()
        {
            InitializeComponent();

            btnToggle.Click -= BtnToggle_Click;
            btnToggle.Click += BtnToggle_Click;

            btnAddToOrder.Click -= BtnAddToOrder_Click;
            btnAddToOrder.Click += BtnAddToOrder_Click;

            flpAttrs.Visible = false;
        }


        //public void Bind(ProductListItem p)
        //{
        //    product = p;

        //    lblTitle.Text = p.Name;
        //    lblPrice.Text = p.Price.ToString("0.00") + " грн";
        //    lblMeta.Text = (p.Quantity > 0 ? "В наявності" : "Немає") + " • " + p.CategoryName;

        //    flpAttrs.Controls.Clear();

        //    if (p.ProductType == "book")
        //    {
        //        AddAttr("Автор(и)", p.Authors);
        //        AddAttr("Мова", p.Language);
        //        AddAttr("Видавництво", p.Publisher);
        //        AddAttr("Серія", p.Series);
        //        AddAttr("Вік", p.AgeMin.HasValue ? p.AgeMin + "+" : null);
        //        AddAttr("Ілюстрації", p.HasIllustrations.HasValue ? (p.HasIllustrations.Value ? "Так" : "Ні") : null);
        //        AddAttr("Сторінок", p.Pages?.ToString());
        //        AddAttr("Рік", p.PublishYear?.ToString());
        //    }

        //    foreach (KeyValuePair<string, string> kv in p.Attributes)
        //        AddAttr(kv.Key, kv.Value);

        //    RecalcLayout();
        //}

        public void Bind(ProductListItem p)
        {
            product = p;

            lblTitle.Text = p.Name;
            lblPrice.Text = p.Price.ToString("0.00") + " грн";
            lblMeta.Text =
                (p.Quantity > 0 ? "В наявності" : "Немає") +
                " • " + p.CategoryName;

            if (p.Quantity > 0)
            {
                btnAddToOrder.Enabled = true;
                btnAddToOrder.Text = "Додати до замовлення";
            }
            else
            {
                btnAddToOrder.Enabled = false;
                btnAddToOrder.Text = "Немає в наявності";
            }

            flpAttrs.Controls.Clear();

            if (p.ProductType == "book")
            {
                AddAttr("Автор(и)", p.Authors);
                AddAttr("Мова", p.Language);
                AddAttr("Видавництво", p.Publisher);
                AddAttr("Серія", p.Series);
                AddAttr("Вік", p.AgeMin.HasValue ? p.AgeMin + "+" : null);
                AddAttr("Ілюстрації", p.HasIllustrations.HasValue
                    ? (p.HasIllustrations.Value ? "Так" : "Ні")
                    : null);
                AddAttr("Сторінок", p.Pages?.ToString());
                AddAttr("Рік", p.PublishYear?.ToString());
            }

            foreach (KeyValuePair<string, string> kv in p.Attributes)
                AddAttr(kv.Key, kv.Value);

            RecalcLayout();
        }


        private void BtnToggle_Click(object sender, EventArgs e)
        {
            expanded = !expanded;
            flpAttrs.Visible = expanded;
            btnToggle.Text = expanded ? "Характеристики ▴" : "Характеристики ▾";
            RecalcLayout();
        }

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            if (product == null) return;

            if (product.Quantity <= 0)
            {
                MessageBox.Show("Товар відсутній на складі.");
                return;
            }

            using (var form = new AddToOrderForm(product))
            {
                if (form.ShowDialog() != DialogResult.OK) return;

                OrderCart.AddOrUpdate(
                    product.ProductId,
                    product.Name,
                    product.Price,
                    form.SelectedQuantity,
                    product.Quantity
                );

                MessageBox.Show("Додано у замовлення.");
            }
        }

        private void AddAttr(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;

            var lbl = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(180, 0),
                Text = $"{name}: {value}"
            };

            flpAttrs.Controls.Add(lbl);
        }

        private void RecalcLayout()
        {
            btnToggle.Left = (this.Width - btnToggle.Width) / 2;
            btnToggle.Top = flpText.Bottom + 6;

            btnAddToOrder.Left = (this.Width - btnAddToOrder.Width) / 2;
            btnAddToOrder.Top = btnToggle.Bottom + 6;

            flpAttrs.Top = btnAddToOrder.Bottom + 6;

            int h = btnAddToOrder.Bottom + 8;

            if (expanded)
            {
                foreach (Control c in flpAttrs.Controls)
                    h += c.Height + 4;
            }

            this.Height = Math.Max(h, 120);
        }
    }
}
