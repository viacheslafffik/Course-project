using System.Windows.Forms;

namespace Course_Project.Pages.Products
{
    partial class ProductCard
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flpMain;
        private FlowLayoutPanel flpText;

        private Label lblTitle;
        private Label lblPrice;
        private Label lblMeta;

        private Button btnToggle;
        private Button btnAddToOrder;

        private FlowLayoutPanel flpAttrs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flpMain = new FlowLayoutPanel();
            this.flpText = new FlowLayoutPanel();
            this.lblTitle = new Label();
            this.lblPrice = new Label();
            this.lblMeta = new Label();
            this.btnToggle = new Button();
            this.btnAddToOrder = new Button();
            this.flpAttrs = new FlowLayoutPanel();

            this.flpMain.SuspendLayout();
            this.flpText.SuspendLayout();
            this.SuspendLayout();
            //
            // flpMain
            //
            this.flpMain.FlowDirection = FlowDirection.TopDown;
            this.flpMain.WrapContents = false;
            this.flpMain.AutoSize = true;
            this.flpMain.Padding = new Padding(10);
            this.flpMain.Dock = DockStyle.Fill;
            //
            //  flpText 
            //
            this.flpText.FlowDirection = FlowDirection.TopDown;
            this.flpText.WrapContents = false;
            this.flpText.AutoSize = true;
            this.flpText.MaximumSize = new System.Drawing.Size(190, 0);
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.MaximumSize = new System.Drawing.Size(180, 0);
            //
            // lblPrice
            //
            this.lblPrice.AutoSize = true;
            //
            // lblMeta 
            //
            this.lblMeta.AutoSize = true;
            this.lblMeta.MaximumSize = new System.Drawing.Size(180, 0);
            //
            // btnToggle 
            //
            this.btnToggle.Text = "Характеристики ▾";
            this.btnToggle.Width = 160;
            this.btnToggle.Height = 23;
            this.btnToggle.Margin = new Padding(0, 6, 0, 0);
            this.btnToggle.Click += new System.EventHandler(this.BtnToggle_Click);
            //
            // btnAddToOrder
            //
            this.btnAddToOrder.Text = "Додати до замовлення";
            this.btnAddToOrder.Width = 160;
            this.btnAddToOrder.Height = 23;
            this.btnAddToOrder.Margin = new Padding(0, 4, 0, 0);
            //
            // flpAttrs
            //
            this.flpAttrs.FlowDirection = FlowDirection.TopDown;
            this.flpAttrs.WrapContents = false;
            this.flpAttrs.AutoSize = true;
            this.flpAttrs.MaximumSize = new System.Drawing.Size(190, 0);
            this.flpAttrs.Margin = new Padding(0, 6, 0, 0);
            this.flpAttrs.Visible = false;
            //
            // hierarchy 
            //
            this.flpText.Controls.Add(this.lblTitle);
            this.flpText.Controls.Add(this.lblPrice);
            this.flpText.Controls.Add(this.lblMeta);

            this.flpMain.Controls.Add(this.flpText);
            this.flpMain.Controls.Add(this.btnToggle);
            this.flpMain.Controls.Add(this.btnAddToOrder);
            this.flpMain.Controls.Add(this.flpAttrs);

            this.Controls.Add(this.flpMain);
            //
            // ProductCard
            //
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(217, 120);
            this.Margin = new Padding(10);

            this.flpMain.ResumeLayout(false);
            this.flpMain.PerformLayout();
            this.flpText.ResumeLayout(false);
            this.flpText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
