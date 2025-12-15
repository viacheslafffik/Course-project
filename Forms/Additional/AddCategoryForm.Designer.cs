namespace Course_Project.Forms.Additional
{
    partial class AddCategoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCatogoryName = new System.Windows.Forms.TextBox();
            this.flowAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddAtribute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва категорії";
            // 
            // txtCatogoryName
            // 
            this.txtCatogoryName.Location = new System.Drawing.Point(64, 72);
            this.txtCatogoryName.Name = "txtCatogoryName";
            this.txtCatogoryName.Size = new System.Drawing.Size(141, 20);
            this.txtCatogoryName.TabIndex = 1;
            // 
            // flowAttributes
            // 
            this.flowAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowAttributes.AutoScroll = true;
            this.flowAttributes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowAttributes.Location = new System.Drawing.Point(64, 98);
            this.flowAttributes.Name = "flowAttributes";
            this.flowAttributes.Size = new System.Drawing.Size(350, 308);
            this.flowAttributes.TabIndex = 2;
            this.flowAttributes.WrapContents = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(64, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddAtribute
            // 
            this.btnAddAtribute.Location = new System.Drawing.Point(64, 429);
            this.btnAddAtribute.Name = "btnAddAtribute";
            this.btnAddAtribute.Size = new System.Drawing.Size(188, 23);
            this.btnAddAtribute.TabIndex = 4;
            this.btnAddAtribute.Text = "Додати характеристику";
            this.btnAddAtribute.Click += new System.EventHandler(this.btnAddAtribute_Click);
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 498);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddAtribute);
            this.Controls.Add(this.flowAttributes);
            this.Controls.Add(this.txtCatogoryName);
            this.Controls.Add(this.label1);
            this.Name = "AddCategoryForm";
            this.Text = "AddCategoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCatogoryName;
        private System.Windows.Forms.FlowLayoutPanel flowAttributes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddAtribute;
    }
}