namespace Course_Project.Pages.Products
{
    partial class FiltersPanel
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbPriceFrom;
        private System.Windows.Forms.TextBox tbPriceTo;
        private System.Windows.Forms.CheckBox cbInStock;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.FlowLayoutPanel flpDynamic;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tbPriceFrom = new System.Windows.Forms.TextBox();
            this.tbPriceTo = new System.Windows.Forms.TextBox();
            this.cbInStock = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.flpDynamic = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblPrice);
            this.pnlTop.Controls.Add(this.tbPriceFrom);
            this.pnlTop.Controls.Add(this.tbPriceTo);
            this.pnlTop.Controls.Add(this.cbInStock);
            this.pnlTop.Controls.Add(this.btnApply);
            this.pnlTop.Controls.Add(this.btnReset);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(280, 140);
            this.pnlTop.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(10, 10);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(55, 13);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Ціна (грн)";
            // 
            // tbPriceFrom
            // 
            this.tbPriceFrom.Location = new System.Drawing.Point(10, 35);
            this.tbPriceFrom.Name = "tbPriceFrom";
            this.tbPriceFrom.Size = new System.Drawing.Size(90, 20);
            this.tbPriceFrom.TabIndex = 1;
            // 
            // tbPriceTo
            // 
            this.tbPriceTo.Location = new System.Drawing.Point(110, 35);
            this.tbPriceTo.Name = "tbPriceTo";
            this.tbPriceTo.Size = new System.Drawing.Size(90, 20);
            this.tbPriceTo.TabIndex = 2;
            // 
            // cbInStock
            // 
            this.cbInStock.AutoSize = true;
            this.cbInStock.Location = new System.Drawing.Point(10, 65);
            this.cbInStock.Name = "cbInStock";
            this.cbInStock.Size = new System.Drawing.Size(85, 17);
            this.cbInStock.TabIndex = 3;
            this.cbInStock.Text = "В наявності";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(10, 95);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Застосувати";
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(115, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Скинути";
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // flpDynamic
            // 
            this.flpDynamic.AutoScroll = true;
            this.flpDynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDynamic.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDynamic.Location = new System.Drawing.Point(0, 140);
            this.flpDynamic.Name = "flpDynamic";
            this.flpDynamic.Padding = new System.Windows.Forms.Padding(8, 8, 8, 80);
            this.flpDynamic.Size = new System.Drawing.Size(280, 10);
            this.flpDynamic.TabIndex = 0;
            this.flpDynamic.WrapContents = false;
            // 
            // FiltersPanel
            // 
            this.Controls.Add(this.flpDynamic);
            this.Controls.Add(this.pnlTop);
            this.Name = "FiltersPanel";
            this.Size = new System.Drawing.Size(280, 150);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
