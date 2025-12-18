namespace Course_Project.Pages.Products
{
    partial class ProductsPage3
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.Panel pnlHeader;

        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Button btnLoad;

        private System.Windows.Forms.TableLayoutPanel content;
        private FiltersPanel filtersPanel;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.content = new System.Windows.Forms.TableLayoutPanel();
            this.filtersPanel = new Course_Project.Pages.Products.FiltersPanel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.root.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.content.SuspendLayout();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this.pnlHeader, 0, 0);
            this.root.Controls.Add(this.content, 0, 1);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 2;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(150, 150);
            this.root.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.cbCategory);
            this.pnlHeader.Controls.Add(this.tbSearch);
            this.pnlHeader.Controls.Add(this.cbSort);
            this.pnlHeader.Controls.Add(this.btnLoad);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12);
            this.pnlHeader.Size = new System.Drawing.Size(144, 58);
            this.pnlHeader.TabIndex = 0;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Location = new System.Drawing.Point(12, 20);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(220, 21);
            this.cbCategory.TabIndex = 0;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(244, 20);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(280, 20);
            this.tbSearch.TabIndex = 1;
            // 
            // cbSort
            // 
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.Location = new System.Drawing.Point(536, 20);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(220, 21);
            this.cbSort.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(768, 19);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Оновити";
            // 
            // content
            // 
            this.content.ColumnCount = 2;
            this.content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.content.Controls.Add(this.filtersPanel, 0, 0);
            this.content.Controls.Add(this.flpProducts, 1, 0);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(3, 67);
            this.content.Name = "content";
            this.content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.content.Size = new System.Drawing.Size(144, 80);
            this.content.TabIndex = 1;
            // 
            // filtersPanel
            // 
            this.filtersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersPanel.Location = new System.Drawing.Point(3, 3);
            this.filtersPanel.MaximumSize = new System.Drawing.Size(380, 0);
            this.filtersPanel.MinimumSize = new System.Drawing.Size(320, 0);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(334, 74);
            this.filtersPanel.TabIndex = 0;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(340, 0);
            this.flpProducts.Margin = new System.Windows.Forms.Padding(0);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(20);
            this.flpProducts.Size = new System.Drawing.Size(1, 80);
            this.flpProducts.TabIndex = 1;
            // 
            // ProductsPage3
            // 
            this.Controls.Add(this.root);
            this.Name = "ProductsPage3";
            this.root.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.content.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}