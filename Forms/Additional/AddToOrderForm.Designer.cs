namespace Course_Project.Forms.Additional
{
    partial class AddToOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.lblPriceCaption = new System.Windows.Forms.Label();
            this.lblAvailableCaption = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblQtyCaption = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Додати у замовлення";
            // 
            // lblNameCaption
            // 
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Location = new System.Drawing.Point(19, 55);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(41, 13);
            this.lblNameCaption.TabIndex = 1;
            this.lblNameCaption.Text = "Товар:";
            // 
            // lblPriceCaption
            // 
            this.lblPriceCaption.AutoSize = true;
            this.lblPriceCaption.Location = new System.Drawing.Point(19, 79);
            this.lblPriceCaption.Name = "lblPriceCaption";
            this.lblPriceCaption.Size = new System.Drawing.Size(32, 13);
            this.lblPriceCaption.TabIndex = 2;
            this.lblPriceCaption.Text = "Ціна:";
            // 
            // lblAvailableCaption
            // 
            this.lblAvailableCaption.AutoSize = true;
            this.lblAvailableCaption.Location = new System.Drawing.Point(19, 103);
            this.lblAvailableCaption.Name = "lblAvailableCaption";
            this.lblAvailableCaption.Size = new System.Drawing.Size(61, 13);
            this.lblAvailableCaption.TabIndex = 3;
            this.lblAvailableCaption.Text = "Наявність:";
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.Location = new System.Drawing.Point(90, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(292, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "-";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(90, 79);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(10, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "-";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(90, 103);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(10, 13);
            this.lblAvailable.TabIndex = 6;
            this.lblAvailable.Text = "-";
            // 
            // lblQtyCaption
            // 
            this.lblQtyCaption.AutoSize = true;
            this.lblQtyCaption.Location = new System.Drawing.Point(19, 135);
            this.lblQtyCaption.Name = "lblQtyCaption";
            this.lblQtyCaption.Size = new System.Drawing.Size(56, 13);
            this.lblQtyCaption.TabIndex = 7;
            this.lblQtyCaption.Text = "Кількість:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(93, 133);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 176);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(132, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AddToOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 221);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQtyCaption);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAvailableCaption);
            this.Controls.Add(this.lblPriceCaption);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddToOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додати у замовлення";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblPriceCaption;
        private System.Windows.Forms.Label lblAvailableCaption;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblQtyCaption;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}
