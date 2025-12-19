namespace Course_Project.Forms.Supplies
{
    partial class SupplyBookForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSalePrice;
        private System.Windows.Forms.TextBox tbQty;

        private System.Windows.Forms.TextBox tbCategoryId;

        private System.Windows.Forms.TextBox tbIsbn;
        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.ComboBox cbSeries;
        private System.Windows.Forms.ComboBox cbLanguage;

        private System.Windows.Forms.TextBox tbPublisherNew;
        private System.Windows.Forms.TextBox tbSeriesNew;
        private System.Windows.Forms.TextBox tbLanguageNew;

        private System.Windows.Forms.TextBox tbAuthors;
        private System.Windows.Forms.TextBox tbAgeMin;
        private System.Windows.Forms.TextBox tbPages;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.CheckBox cbIllustrations;
        private System.Windows.Forms.TextBox tbDesc;

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSalePrice = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.tbCategoryId = new System.Windows.Forms.TextBox();
            this.tbIsbn = new System.Windows.Forms.TextBox();
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.tbPublisherNew = new System.Windows.Forms.TextBox();
            this.cbSeries = new System.Windows.Forms.ComboBox();
            this.tbSeriesNew = new System.Windows.Forms.TextBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.tbLanguageNew = new System.Windows.Forms.TextBox();
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.tbAgeMin = new System.Windows.Forms.TextBox();
            this.cbIllustrations = new System.Windows.Forms.CheckBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbPages = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.root.SuspendLayout();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnCount = 2;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.root.Controls.Add(this.tbName, 0, 0);
            this.root.Controls.Add(this.tbSalePrice, 0, 1);
            this.root.Controls.Add(this.tbQty, 1, 1);
            this.root.Controls.Add(this.tbCategoryId, 0, 2);
            this.root.Controls.Add(this.tbIsbn, 0, 3);
            this.root.Controls.Add(this.cbPublisher, 0, 4);
            this.root.Controls.Add(this.tbPublisherNew, 1, 4);
            this.root.Controls.Add(this.cbSeries, 0, 5);
            this.root.Controls.Add(this.tbSeriesNew, 1, 5);
            this.root.Controls.Add(this.cbLanguage, 0, 6);
            this.root.Controls.Add(this.tbLanguageNew, 1, 6);
            this.root.Controls.Add(this.tbAuthors, 0, 7);
            this.root.Controls.Add(this.tbAgeMin, 0, 8);
            this.root.Controls.Add(this.cbIllustrations, 1, 8);
            this.root.Controls.Add(this.tbDesc, 0, 9);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 10;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(544, 481);
            this.root.TabIndex = 2;
            // 
            // tbName
            // 
            this.root.SetColumnSpan(this.tbName, 2);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(538, 20);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "Назва книги";
            // 
            // tbSalePrice
            // 
            this.tbSalePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSalePrice.Location = new System.Drawing.Point(3, 37);
            this.tbSalePrice.Name = "tbSalePrice";
            this.tbSalePrice.Size = new System.Drawing.Size(266, 20);
            this.tbSalePrice.TabIndex = 1;
            this.tbSalePrice.Text = "Ціна продажу";
            // 
            // tbQty
            // 
            this.tbQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQty.Location = new System.Drawing.Point(275, 37);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(266, 20);
            this.tbQty.TabIndex = 2;
            this.tbQty.Text = "К-сть у накладній";
            // 
            // tbCategoryId
            // 
            this.root.SetColumnSpan(this.tbCategoryId, 2);
            this.tbCategoryId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCategoryId.Location = new System.Drawing.Point(3, 71);
            this.tbCategoryId.Name = "tbCategoryId";
            this.tbCategoryId.Size = new System.Drawing.Size(538, 20);
            this.tbCategoryId.TabIndex = 3;
            this.tbCategoryId.Text = "categoryId (книжкова)";
            // 
            // tbIsbn
            // 
            this.root.SetColumnSpan(this.tbIsbn, 2);
            this.tbIsbn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIsbn.Location = new System.Drawing.Point(3, 105);
            this.tbIsbn.Name = "tbIsbn";
            this.tbIsbn.Size = new System.Drawing.Size(538, 20);
            this.tbIsbn.TabIndex = 4;
            this.tbIsbn.Text = "ISBN";
            // 
            // cbPublisher
            // 
            this.cbPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPublisher.Location = new System.Drawing.Point(3, 139);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(266, 21);
            this.cbPublisher.TabIndex = 5;
            // 
            // tbPublisherNew
            // 
            this.tbPublisherNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPublisherNew.Location = new System.Drawing.Point(275, 139);
            this.tbPublisherNew.Name = "tbPublisherNew";
            this.tbPublisherNew.Size = new System.Drawing.Size(266, 20);
            this.tbPublisherNew.TabIndex = 6;
            this.tbPublisherNew.Text = "Новий видавець (опц.)";
            // 
            // cbSeries
            // 
            this.cbSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSeries.Location = new System.Drawing.Point(3, 173);
            this.cbSeries.Name = "cbSeries";
            this.cbSeries.Size = new System.Drawing.Size(266, 21);
            this.cbSeries.TabIndex = 7;
            // 
            // tbSeriesNew
            // 
            this.tbSeriesNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSeriesNew.Location = new System.Drawing.Point(275, 173);
            this.tbSeriesNew.Name = "tbSeriesNew";
            this.tbSeriesNew.Size = new System.Drawing.Size(266, 20);
            this.tbSeriesNew.TabIndex = 8;
            this.tbSeriesNew.Text = "Нова серія (опц.)";
            // 
            // cbLanguage
            // 
            this.cbLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLanguage.Location = new System.Drawing.Point(3, 207);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(266, 21);
            this.cbLanguage.TabIndex = 9;
            // 
            // tbLanguageNew
            // 
            this.tbLanguageNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLanguageNew.Location = new System.Drawing.Point(275, 207);
            this.tbLanguageNew.Name = "tbLanguageNew";
            this.tbLanguageNew.Size = new System.Drawing.Size(266, 20);
            this.tbLanguageNew.TabIndex = 10;
            this.tbLanguageNew.Text = "Нова мова (опц.)";
            // 
            // tbAuthors
            // 
            this.root.SetColumnSpan(this.tbAuthors, 2);
            this.tbAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAuthors.Location = new System.Drawing.Point(3, 241);
            this.tbAuthors.Name = "tbAuthors";
            this.tbAuthors.Size = new System.Drawing.Size(538, 20);
            this.tbAuthors.TabIndex = 11;
            this.tbAuthors.Text = "Автори (через кому)";
            // 
            // tbAgeMin
            // 
            this.tbAgeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAgeMin.Location = new System.Drawing.Point(3, 275);
            this.tbAgeMin.Name = "tbAgeMin";
            this.tbAgeMin.Size = new System.Drawing.Size(266, 20);
            this.tbAgeMin.TabIndex = 12;
            this.tbAgeMin.Text = "AgeMin";
            // 
            // cbIllustrations
            // 
            this.cbIllustrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIllustrations.Location = new System.Drawing.Point(275, 275);
            this.cbIllustrations.Name = "cbIllustrations";
            this.cbIllustrations.Size = new System.Drawing.Size(266, 28);
            this.cbIllustrations.TabIndex = 13;
            this.cbIllustrations.Text = "Ілюстрації";
            // 
            // tbDesc
            // 
            this.root.SetColumnSpan(this.tbDesc, 2);
            this.tbDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDesc.Location = new System.Drawing.Point(3, 309);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDesc.Size = new System.Drawing.Size(538, 169);
            this.tbDesc.TabIndex = 14;
            this.tbDesc.Text = "Короткий опис";
            // 
            // tbPages
            // 
            this.tbPages.Location = new System.Drawing.Point(0, 0);
            this.tbPages.Name = "tbPages";
            this.tbPages.Size = new System.Drawing.Size(100, 20);
            this.tbPages.TabIndex = 0;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(0, 0);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(100, 20);
            this.tbYear.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreate.Location = new System.Drawing.Point(0, 409);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(544, 36);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Створити книгу";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(0, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(544, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Скасувати";
            // 
            // SupplyBookForm
            // 
            this.AcceptButton = this.btnCreate;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(544, 481);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.root);
            this.MinimumSize = new System.Drawing.Size(560, 520);
            this.Name = "SupplyBookForm";
            this.Text = "Додати книгу з поставки";
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
