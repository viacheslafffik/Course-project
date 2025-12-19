using Course_Project.Data.Products;
using Course_Project.Models.Products;
using System;
using System.Windows.Forms;
using System.Drawing;


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
        private SplitContainer _split;

        public ProductsPage3()
        {
            InitializeComponent();

            RebuildLayoutRuntime();

            Dock = DockStyle.Fill;

            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            btnLoad.Click += BtnLoad_Click;

            filtersPanel.ApplyClicked += FiltersPanel_ApplyClicked;
            filtersPanel.ResetClicked += FiltersPanel_ResetClicked;

            cbSort.SelectedIndexChanged += (_, __) => ReloadProducts(true);
            tbSearch.TextChanged += (_, __) => ReloadProducts(true);

            flpProducts.MouseEnter += (_, __) => flpProducts.Focus();
            flpProducts.MouseWheel += FlpProducts_MouseWheel;
            flpProducts.TabStop = true;
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
            cbSort.Items.Add(new ComboItem("За ціною (↑)", "price_asc"));
            cbSort.Items.Add(new ComboItem("За ціною (↓)", "price_desc"));
            cbSort.DisplayMember = "Text";
            cbSort.ValueMember = "Value";
            cbSort.SelectedIndex = 0;
        }
        private void RebuildLayoutRuntime()
        {
            if (content == null) return;

            content.SuspendLayout();

            content.Controls.Clear();
            content.ColumnStyles.Clear();
            content.RowStyles.Clear();

            _split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                FixedPanel = FixedPanel.Panel1,
                IsSplitterFixed = false,
                SplitterWidth = 6
            };

            filtersPanel.Dock = DockStyle.Fill;
            flpProducts.Dock = DockStyle.Fill;

            _split.Panel1.Controls.Add(filtersPanel);
            _split.Panel2.Controls.Add(flpProducts);

            content.ColumnCount = 1;
            content.RowCount = 1;
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Controls.Add(_split, 0, 0);

            content.ResumeLayout(true);

            HandleCreated += ProductsPage3_HandleCreated;
        }

        private void ProductsPage3_HandleCreated(object sender, EventArgs e)
        {
            HandleCreated -= ProductsPage3_HandleCreated;

            if (_split == null) return;

            _split.Panel1MinSize = 320;
            _split.Panel2MinSize = 300;

            if (_split.Width > _split.Panel2MinSize + 340)
                _split.SplitterDistance = 340;
        }



        private void Content_Layout(object sender, LayoutEventArgs e)
        {
            if (content.ColumnStyles.Count < 2) return;

            const int filtersWidth = 340;

            var col = content.ColumnStyles[0];

            col.SizeType = SizeType.Absolute;
            col.Width = filtersWidth;

            filtersPanel.MinimumSize = new System.Drawing.Size(filtersWidth, 0);
            filtersPanel.Visible = true;
        }



        private void FlpProducts_MouseWheel(object sender, MouseEventArgs e)
        {
            var v = flpProducts.VerticalScroll;
            if (e.Delta < 0 && v.Value + v.LargeChange >= v.Maximum - 50)
                ReloadProducts(false);
        }

        private void RestoreFilters()
        {
            tbSearch.Text = Properties.Settings.Default.LastSearch ?? "";

            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastSort))
            {
                for (int i = 0; i < cbSort.Items.Count; i++)
                {
                    if ((cbSort.Items[i] as ComboItem)?.Value ==
                        Properties.Settings.Default.LastSort)
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
                    if ((cbCategory.Items[i] as CategoryModel)?.CategoryId ==
                        Properties.Settings.Default.LastCategoryId)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void LoadCategories()
        {
            var cats = categoryRepo.GetAll();
            cbCategory.Items.Clear();
            foreach (var c in cats) cbCategory.Items.Add(c);
            if (cbCategory.Items.Count > 0) cbCategory.SelectedIndex = 0;
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
            ReloadProducts(true);
        }

        private void BtnLoad_Click(object sender, EventArgs e) => ReloadProducts(true);

        private void FiltersPanel_ApplyClicked(object sender, EventArgs e) => ReloadProducts(true);
        private void FiltersPanel_ResetClicked(object sender, EventArgs e) => ReloadProducts(true);

        private void ReloadProducts(bool reset)
        {
            if (isLoading || currentCategory == null) return;

            if (reset)
            {
                flpProducts.Controls.Clear();
                currentOffset = 0;
                hasMore = true;
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

            if (items.Count < pageSize) hasMore = false;

            foreach (var p in items)
            {
                var card = new ProductCard
                {
                    Width = 220,
                    Height = 280,
                    Margin = new Padding(10)
                };
                card.Bind(p);
                flpProducts.Controls.Add(card);
            }

            currentOffset += items.Count;
            isLoading = false;
        }

        private void FlpProducts_Scroll(object sender, ScrollEventArgs e)
        {
            var v = flpProducts.VerticalScroll;
            if (v.Value + v.LargeChange >= v.Maximum - 50)
                ReloadProducts(false);
        }

        private void ProductsPage3_Resize(object sender, EventArgs e)
        {
            if (content.ColumnStyles.Count < 2) return;

            if (Width < 900)
            {
                content.ColumnStyles[0].Width = 340;
                filtersPanel.Visible = true;
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
