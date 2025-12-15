using Course_Project.Forms.Additional;
using Course_Project.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Course_Project.Forms
{
    public partial class ProductsForm : Form
    {
        private int page = 1;
        private const int pageSize = 10;
        private List<Product.ProductWithNames> allProducts;
        private readonly string currentUserRole;

        public ProductsForm(string role)
        {
            InitializeComponent();
            currentUserRole = role;
            if (currentUserRole == "seller") btnAddCategory.Hide();     
            LoadFilters();
            LoadData();
            flpProducts.Resize += (s, e) =>
            {
                foreach (Control c in flpProducts.Controls) c.Width = flpProducts.ClientSize.Width - 40;                
            };
        }

        private void LoadFilters()
        {
            cbFilterCategory.DataSource = Category.GetAll();
            cbFilterCategory.DisplayMember = "name";
            cbFilterCategory.ValueMember = "categoryId";
            cbFilterBrand.DataSource = Brand.GetAll();
            cbFilterBrand.DisplayMember = "name";
            cbFilterBrand.ValueMember = "brandId";
        }

        private void LoadData()
        {
            allProducts = Product.ProductWithNames.GetAllWithNames();
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            List<Product.ProductWithNames> filtered = allProducts;
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                string search = tbSearch.Text.Trim().ToLower();
                filtered = filtered.FindAll(p => p.name.ToLower().Contains(search));
            }
            if (cbFilterCategory.SelectedValue is int catId && catId > 0) filtered = filtered.FindAll(p => p.categoryId == catId);           
            if (cbFilterBrand.SelectedValue is int brandId && brandId > 0) filtered = filtered.FindAll(p => p.brandId == brandId);       
            if (decimal.TryParse(tbMin.Text, out decimal min)) filtered = filtered.FindAll(p => p.price >= min);
            if (decimal.TryParse(tbMax.Text, out decimal max)) filtered = filtered.FindAll(p => p.price <= max);
            if (chkInStockOnly.Checked) filtered = filtered.FindAll(p => p.quantity > 0);
            ShowPage(filtered);
        }


        private void ShowPage(List<Product.ProductWithNames> products)
        {
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();
            int start = (page - 1) * pageSize;
            int end = Math.Min(start + pageSize, products.Count);
            for (int i = start; i < end; i++)
            {
                var card = new ProductCard(products[i]);
                card.Width = flpProducts.ClientSize.Width - 40;
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                card.Margin = new Padding(0, 0, 0, 15);

                flpProducts.Controls.Add(card);
            }
            lblPage.Text = $"Сторінка {page}";
            flpProducts.ResumeLayout();
        }


        private void BtnApplyFilters_Click(object sender, EventArgs e)
        {
            page = 1;
            ApplyFilter();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            page++;
            ApplyFilter();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (page > 1) page--;
            ApplyFilter();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
            LoadData();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            new AddCategoryForm().ShowDialog();
            LoadFilters(); LoadData();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            page = 1;
            ApplyFilter();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            page = 1;
            ApplyFilter();
        }

        private void ChkInStockOnly_CheckedChanged(object sender, EventArgs e)
        {
            page = 1;
            ApplyFilter();
        }
    }
}
