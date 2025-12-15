namespace Course_Project.Forms.Additional
{
    partial class AddProductForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAttr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(48, 57);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(130, 20);
            this.tbName.TabIndex = 0;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(48, 120);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(130, 20);
            this.tbPrice.TabIndex = 1;
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(48, 185);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(130, 20);
            this.tbQty.TabIndex = 2;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(48, 237);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(130, 21);
            this.cbCategory.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(48, 390);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати товар";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(45, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Назва";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(45, 92);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(29, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Ціна";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(45, 158);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(53, 13);
            this.lblQty.TabIndex = 7;
            this.lblQty.Text = "Кількість";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(48, 218);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 13);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Категорія";
            // 
            // pnlAttributes
            // 
            this.pnlAttributes.AutoScroll = true;
            this.pnlAttributes.Location = new System.Drawing.Point(213, 57);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(176, 288);
            this.pnlAttributes.TabIndex = 9;
            // 
            // cbBrand
            // 
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(48, 299);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(130, 21);
            this.cbBrand.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Бренд";
            // 
            // lblAttr
            // 
            this.lblAttr.AutoSize = true;
            this.lblAttr.Location = new System.Drawing.Point(213, 29);
            this.lblAttr.Name = "lblAttr";
            this.lblAttr.Size = new System.Drawing.Size(90, 13);
            this.lblAttr.TabIndex = 12;
            this.lblAttr.Text = "Характеристики";
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAttr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.pnlAttributes);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.Name = "AddProductForm";
            this.Text = "AddProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.FlowLayoutPanel pnlAttributes;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAttr;
    }
}