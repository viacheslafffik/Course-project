namespace Course_Project.Forms.Additional
{
    partial class ProductCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.flpAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAttributes
            // 
            this.pnlAttributes.AutoSize = true;
            this.pnlAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAttributes.Controls.Add(this.flpAttributes);
            this.pnlAttributes.Location = new System.Drawing.Point(20, 182);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.pnlAttributes.Size = new System.Drawing.Size(340, 231);
            this.pnlAttributes.TabIndex = 13;
            this.pnlAttributes.Visible = false;
            // 
            // flpAttributes
            // 
            this.flpAttributes.AutoScroll = true;
            this.flpAttributes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAttributes.Location = new System.Drawing.Point(4, 3);
            this.flpAttributes.Name = "flpAttributes";
            this.flpAttributes.Size = new System.Drawing.Size(333, 220);
            this.flpAttributes.TabIndex = 0;
            // 
            // btnToggle
            // 
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Location = new System.Drawing.Point(24, 153);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(158, 23);
            this.btnToggle.TabIndex = 12;
            this.btnToggle.Text = "Показати характеристики";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(21, 126);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 11;
            this.lblBrand.Text = "label5";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(21, 103);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(35, 13);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "label4";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(21, 80);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(35, 13);
            this.lblQty.TabIndex = 9;
            this.lblQty.Text = "label3";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(21, 55);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "label2";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(21, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "label1";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(199, 153);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(158, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlAttributes);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(363, 416);
            this.pnlAttributes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAttributes;
        private System.Windows.Forms.FlowLayoutPanel flpAttributes;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnEdit;
    }
}
