namespace Course_Project.Pages.Supplies
{
    partial class SuppliesPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer

        private void InitializeComponent()
        {
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvSupplies = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnAddExisting = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbInvoiceSearch = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cbSupplierFilter = new System.Windows.Forms.ComboBox();
            this.cbFrom = new System.Windows.Forms.CheckBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.cbTo = new System.Windows.Forms.CheckBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnCreateSupply = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.pnlRoot.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplies)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.pnlContent);
            this.pnlRoot.Controls.Add(this.pnlFilters);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(900, 500);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvSupplies);
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Location = new System.Drawing.Point(0, 99);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(900, 401);
            this.pnlContent.TabIndex = 0;
            // 
            // dgvSupplies
            // 
            this.dgvSupplies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplies.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplies.MultiSelect = false;
            this.dgvSupplies.Name = "dgvSupplies";
            this.dgvSupplies.ReadOnly = true;
            this.dgvSupplies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplies.Size = new System.Drawing.Size(475, 401);
            this.dgvSupplies.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvItems);
            this.pnlRight.Controls.Add(this.btnAddExisting);
            this.pnlRight.Controls.Add(this.btnAddBook);
            this.pnlRight.Controls.Add(this.btnApply);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(475, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(425, 401);
            this.pnlRight.TabIndex = 1;
            // 
            // dgvItems
            // 
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 69);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(425, 332);
            this.dgvItems.TabIndex = 0;
            // 
            // btnAddExisting
            // 
            this.btnAddExisting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddExisting.Location = new System.Drawing.Point(0, 46);
            this.btnAddExisting.Name = "btnAddExisting";
            this.btnAddExisting.Size = new System.Drawing.Size(425, 23);
            this.btnAddExisting.TabIndex = 1;
            this.btnAddExisting.Text = "Додати існуючий товар";
            this.btnAddExisting.Click += new System.EventHandler(this.BtnAddExisting_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddBook.Location = new System.Drawing.Point(0, 23);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(425, 23);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Додати книгу";
            this.btnAddBook.Click += new System.EventHandler(this.BtnAddBook_Click);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApply.Location = new System.Drawing.Point(0, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(425, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Застосувати";
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.cbSupplier);
            this.pnlFilters.Controls.Add(this.label1);
            this.pnlFilters.Controls.Add(this.lblSearch);
            this.pnlFilters.Controls.Add(this.tbInvoiceSearch);
            this.pnlFilters.Controls.Add(this.lblSupplier);
            this.pnlFilters.Controls.Add(this.cbSupplierFilter);
            this.pnlFilters.Controls.Add(this.cbFrom);
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Controls.Add(this.dtFrom);
            this.pnlFilters.Controls.Add(this.cbTo);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtTo);
            this.pnlFilters.Controls.Add(this.btnCreateSupply);
            this.pnlFilters.Controls.Add(this.btnResetFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(900, 99);
            this.pnlFilters.TabIndex = 1;
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(10, 70);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(121, 21);
            this.cbSupplier.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Постачальник";
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(7, 6);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Пошук";
            // 
            // tbInvoiceSearch
            // 
            this.tbInvoiceSearch.Location = new System.Drawing.Point(10, 26);
            this.tbInvoiceSearch.Name = "tbInvoiceSearch";
            this.tbInvoiceSearch.Size = new System.Drawing.Size(120, 20);
            this.tbInvoiceSearch.TabIndex = 1;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(147, 6);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(100, 17);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Постачальник";
            // 
            // cbSupplierFilter
            // 
            this.cbSupplierFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierFilter.Location = new System.Drawing.Point(150, 25);
            this.cbSupplierFilter.Name = "cbSupplierFilter";
            this.cbSupplierFilter.Size = new System.Drawing.Size(160, 21);
            this.cbSupplierFilter.TabIndex = 3;
            // 
            // cbFrom
            // 
            this.cbFrom.BackColor = System.Drawing.Color.Transparent;
            this.cbFrom.Location = new System.Drawing.Point(313, 22);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(42, 24);
            this.cbFrom.TabIndex = 4;
            this.cbFrom.Text = "від";
            this.cbFrom.UseVisualStyleBackColor = false;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(361, 3);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(100, 17);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "від";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(364, 23);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 20);
            this.dtFrom.TabIndex = 6;
            // 
            // cbTo
            // 
            this.cbTo.Location = new System.Drawing.Point(570, 19);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(49, 24);
            this.cbTo.TabIndex = 7;
            this.cbTo.Text = "до";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(567, 3);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(100, 17);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "до";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(625, 22);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 20);
            this.dtTo.TabIndex = 9;
            // 
            // btnCreateSupply
            // 
            this.btnCreateSupply.Location = new System.Drawing.Point(594, 68);
            this.btnCreateSupply.Name = "btnCreateSupply";
            this.btnCreateSupply.Size = new System.Drawing.Size(134, 23);
            this.btnCreateSupply.TabIndex = 10;
            this.btnCreateSupply.Text = "Додати постачальника";
            this.btnCreateSupply.Click += new System.EventHandler(this.BtnCreateSupply_Click);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(745, 68);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(90, 23);
            this.btnResetFilters.TabIndex = 10;
            this.btnResetFilters.Text = "Скинути";
            this.btnResetFilters.Click += new System.EventHandler(this.BtnResetFilters_Click);
            // 
            // SuppliesPage
            // 
            this.Controls.Add(this.pnlRoot);
            this.Name = "SuppliesPage";
            this.Size = new System.Drawing.Size(900, 500);
            this.pnlRoot.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplies)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlRight;

        private System.Windows.Forms.TextBox tbInvoiceSearch;
        private System.Windows.Forms.ComboBox cbSupplierFilter;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.CheckBox cbFrom;
        private System.Windows.Forms.CheckBox cbTo;
        private System.Windows.Forms.Button btnResetFilters;

        private System.Windows.Forms.DataGridView dgvSupplies;
        private System.Windows.Forms.DataGridView dgvItems;

        private System.Windows.Forms.Button btnAddExisting;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnApply;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateSupply;
    }
}
