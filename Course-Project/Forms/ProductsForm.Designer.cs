namespace Course_Project.Forms
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFilters = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.cbFilterBrand = new System.Windows.Forms.ComboBox();
            this.cbFilterCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelFilters.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.tbSearch);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.btnSearch);
            this.panelFilters.Controls.Add(this.button1);
            this.panelFilters.Controls.Add(this.tbMax);
            this.panelFilters.Controls.Add(this.tbMin);
            this.panelFilters.Controls.Add(this.cbFilterBrand);
            this.panelFilters.Controls.Add(this.cbFilterCategory);
            this.panelFilters.Controls.Add(this.label4);
            this.panelFilters.Controls.Add(this.label3);
            this.panelFilters.Controls.Add(this.label2);
            this.panelFilters.Controls.Add(this.label1);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(800, 93);
            this.panelFilters.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(584, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Застосувати";
            this.button1.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // tbMax
            // 
            this.tbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMax.Location = new System.Drawing.Point(451, 26);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(98, 20);
            this.tbMax.TabIndex = 2;
            // 
            // tbMin
            // 
            this.tbMin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMin.Location = new System.Drawing.Point(329, 26);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(98, 20);
            this.tbMin.TabIndex = 2;
            // 
            // cbFilterBrand
            // 
            this.cbFilterBrand.FormattingEnabled = true;
            this.cbFilterBrand.Location = new System.Drawing.Point(183, 25);
            this.cbFilterBrand.Name = "cbFilterBrand";
            this.cbFilterBrand.Size = new System.Drawing.Size(121, 21);
            this.cbFilterBrand.TabIndex = 1;
            // 
            // cbFilterCategory
            // 
            this.cbFilterCategory.FormattingEnabled = true;
            this.cbFilterCategory.Location = new System.Drawing.Point(25, 25);
            this.cbFilterCategory.Name = "cbFilterCategory";
            this.cbFilterCategory.Size = new System.Drawing.Size(121, 21);
            this.cbFilterCategory.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ціна до";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ціна від";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Бренд";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Категорія";
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProducts.Location = new System.Drawing.Point(0, 93);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(20);
            this.flpProducts.Size = new System.Drawing.Size(800, 357);
            this.flpProducts.TabIndex = 1;
            this.flpProducts.WrapContents = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblPage);
            this.panelBottom.Controls.Add(this.btnAddCategory);
            this.panelBottom.Controls.Add(this.btnAddProduct);
            this.panelBottom.Controls.Add(this.btnNext);
            this.panelBottom.Controls.Add(this.btnPrev);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 402);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 48);
            this.panelBottom.TabIndex = 2;
            // 
            // lblPage
            // 
            this.lblPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(392, 18);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(51, 13);
            this.lblPage.TabIndex = 2;
            this.lblPage.Text = "Сторінка";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCategory.Location = new System.Drawing.Point(479, 13);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(172, 23);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Додати категорію";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddProduct.Location = new System.Drawing.Point(168, 13);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(172, 23);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "Додати товар";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(713, 13);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Вперед";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Location = new System.Drawing.Point(35, 13);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(25, 53);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Пошук";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(28, 70);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(521, 20);
            this.tbSearch.TabIndex = 4;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(584, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(175, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Знайти";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.flpProducts);
            this.Controls.Add(this.panelFilters);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.ComboBox cbFilterBrand;
        private System.Windows.Forms.ComboBox cbFilterCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}