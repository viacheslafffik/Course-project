using Course_Project.Data.Products;
using Course_Project.Models.Products;
using System;
using System.Windows.Forms;

namespace Course_Project.Pages.Products
{
    public partial class ProductsPage3 : UserControl
    {
        private CategoryRepository categoryRepo = new CategoryRepository();
        private FiltersRepository filtersRepo = new FiltersRepository();
        private ProductsRepository productsRepo = new ProductsRepository();

        private CategoryModel currentCategory;

        private int pageSize = 30;
        private int currentOffset = 0;
        private bool isLoading = false;
        private bool hasMore = true;

        public ProductsPage3()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            btnLoad.Click += BtnLoad_Click;
            filtersPanel.ApplyClicked += FiltersPanel_ApplyClicked;
            filtersPanel.ResetClicked += FiltersPanel_ResetClicked;
            cbSort.SelectedIndexChanged += (_, __) => ReloadProducts(reset: true);
            tbSearch.TextChanged += (_, __) => ReloadProducts(reset: true);
            flpProducts.Scroll += FlpProducts_Scroll;
            InitSort();
            LoadCategories();
            RestoreFilters();
        }

        private void InitSort()
        {
            cbSort.Items.Clear();

            cbSort.Items.Add(new ComboItem("За назвою (А–Я)", "name_asc"));
            cbSort.Items.Add(new ComboItem("За назвою (Я–А)", "name_desc"));
            cbSort.Items.Add(new ComboItem("За ціною (зростання)", "price_asc"));
            cbSort.Items.Add(new ComboItem("За ціною (спадання)", "price_desc"));

            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }
        private void LoadCategories()
        {
            var cats = categoryRepo.GetAll();
            cbCategory.Items.Clear();

            for (int i = 0; i < cats.Count; i++)
                cbCategory.Items.Add(cats[i]);

            if (cbCategory.Items.Count > 0)
                cbCategory.SelectedIndex = 0;
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCategory = cbCategory.SelectedItem as CategoryModel;
            if (currentCategory == null) return;

            var defs = filtersRepo.GetFiltersForCategory(
                currentCategory.CategoryId,
                currentCategory.ProductType
            );

            filtersPanel.BuildDynamicFilters(defs);

            ReloadProducts(reset: true);
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            ReloadProducts(reset: true);
        }

        private void FiltersPanel_ApplyClicked(object sender, EventArgs e)
        {
            ReloadProducts(reset: true);
        }

        private void FiltersPanel_ResetClicked(object sender, EventArgs e)
        {
            ReloadProducts(reset: true);
        }

        private void ReloadProducts(bool reset = true)
        {
            if (isLoading) return;
            if (currentCategory == null) return;

            if (reset)
            {
                flpProducts.Controls.Clear();
                currentOffset = 0;
                hasMore = true;
                Properties.Settings.Default.LastCategoryId = currentCategory.CategoryId;
                Properties.Settings.Default.LastSort = (cbSort.SelectedItem as ComboItem)?.Value;
                Properties.Settings.Default.LastSearch = tbSearch.Text;
                Properties.Settings.Default.Save();
            }

            if (!hasMore) return;
            isLoading = true;

            string sort = (cbSort.SelectedItem as ComboItem)?.Value ?? "name_asc";

            var sel = filtersPanel.CollectSelection(
                currentCategory.CategoryId,
                currentCategory.ProductType,
                tbSearch.Text,
                sort
            );

            var items = productsRepo.Search(sel, pageSize, currentOffset);

            if (items.Count < pageSize)
                hasMore = false;

            for (int i = 0; i < items.Count; i++)
            {
                var card = new ProductCard();
                card.Bind(items[i]);
                flpProducts.Controls.Add(card);
            }

            currentOffset += items.Count;
            isLoading = false;
        }

        private void FlpProducts_Scroll(object sender, ScrollEventArgs e)
        {
            var v = flpProducts.VerticalScroll;
            if (v.Value + v.LargeChange >= v.Maximum - 50) ReloadProducts(reset: false);     
        }

        private void RestoreFilters()
        {
            tbSearch.Text = Properties.Settings.Default.LastSearch ?? "";

            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastSort))
            {
                for (int i = 0; i < cbSort.Items.Count; i++)
                {
                    if ((cbSort.Items[i] as ComboItem)?.Value == Properties.Settings.Default.LastSort)
                    {
                        cbSort.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (Properties.Settings.Default.LastCategoryId > 0)
            {
                for (int i = 0; i < cbCategory.Items.Count; i++)
                {
                    if ((cbCategory.Items[i] as CategoryModel)?.CategoryId == Properties.Settings.Default.LastCategoryId)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }

    class ComboItem
    {
        public string Text { get; }
        public string Value { get; }

        public ComboItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
    }
}
