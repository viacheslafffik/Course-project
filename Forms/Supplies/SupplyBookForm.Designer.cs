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
            this.cbSeries = new System.Windows.Forms.ComboBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.tbPublisherNew = new System.Windows.Forms.TextBox();
            this.tbSeriesNew = new System.Windows.Forms.TextBox();
            this.tbLanguageNew = new System.Windows.Forms.TextBox();
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.tbAgeMin = new System.Windows.Forms.TextBox();
            this.tbPages = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.cbIllustrations = new System.Windows.Forms.CheckBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.root.SuspendLayout();
            this.SuspendLayout();

            this.root.ColumnCount = 2;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 10;
            for (int i = 0; i < 9; i++) this.root.RowStyles.
                    Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Text = "Назва книги";
            this.root.Controls.Add(this.tbName, 0, 0);
            this.root.SetColumnSpan(this.tbName, 2);

            this.tbSalePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSalePrice.Text = "Ціна продажу";
            this.root.Controls.Add(this.tbSalePrice, 0, 1);

            this.tbQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQty.Text = "К-сть у накладній";
            this.root.Controls.Add(this.tbQty, 1, 1);

            this.tbCategoryId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCategoryId.Text = "categoryId (книжкова)";
            this.root.Controls.Add(this.tbCategoryId, 0, 2);
            this.root.SetColumnSpan(this.tbCategoryId, 2);

            this.tbIsbn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIsbn.Text = "ISBN";
            this.root.Controls.Add(this.tbIsbn, 0, 3);
            this.root.SetColumnSpan(this.tbIsbn, 2);

            this.cbPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Controls.Add(this.cbPublisher, 0, 4);

            this.tbPublisherNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPublisherNew.Text = "Новий видавець (опц.)";
            this.root.Controls.Add(this.tbPublisherNew, 1, 4);

            this.cbSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Controls.Add(this.cbSeries, 0, 5);

            this.tbSeriesNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSeriesNew.Text = "Нова серія (опц.)";
            this.root.Controls.Add(this.tbSeriesNew, 1, 5);

            this.cbLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Controls.Add(this.cbLanguage, 0, 6);

            this.tbLanguageNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLanguageNew.Text = "Нова мова (опц.)";
            this.root.Controls.Add(this.tbLanguageNew, 1, 6);

            this.tbAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAuthors.Text = "Автори (через кому)";
            this.root.Controls.Add(this.tbAuthors, 0, 7);
            this.root.SetColumnSpan(this.tbAuthors, 2);

            this.tbAgeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAgeMin.Text = "AgeMin";
            this.root.Controls.Add(this.tbAgeMin, 0, 8);

            this.cbIllustrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIllustrations.Text = "Ілюстрації";
            this.root.Controls.Add(this.cbIllustrations, 1, 8);

            this.tbDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDesc.Multiline = true;
            this.tbDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDesc.Text = "Короткий опис";
            this.root.Controls.Add(this.tbDesc, 0, 9);
            this.root.SetColumnSpan(this.tbDesc, 2);

            this.btnCreate.Text = "Створити книгу";
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreate.Height = 36;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            this.btnCancel.Text = "Скасувати";
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.Height = 36;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.root);

            this.AcceptButton = this.btnCreate;
            this.CancelButton = this.btnCancel;

            this.Text = "Додати книгу з поставки";
            this.MinimumSize = new System.Drawing.Size(560, 520);

            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
