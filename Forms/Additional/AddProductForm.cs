using Course_Project.Models.Core;
using Course_Project.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddProductForm : Form
    {
        private readonly string currentUserRole;

        public AddProductForm(string role = "seller")
        {
            InitializeComponent();
            currentUserRole = role;
            LoadData();
            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            if (!string.Equals(currentUserRole, "admin", StringComparison.OrdinalIgnoreCase)) 
                if (Controls.ContainsKey("btnEditCategoryAttributes")) Controls["btnEditCategoryAttributes"].Visible = false;
            
        }

        private void LoadData()
        {
            // Категорії
            cbCategory.DataSource = Category.GetAll();
            cbCategory.DisplayMember = "name";
            cbCategory.ValueMember = "categoryId";
            // Бренди
            cbBrand.DataSource = Brand.GetAll();
            cbBrand.DisplayMember = "name";
            cbBrand.ValueMember = "brandId";
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue == null) return;
            if (!int.TryParse(cbCategory.SelectedValue.ToString(), out int categoryId)) return;
            LoadAttributesForCategory(categoryId);
        }

        private void LoadAttributesForCategory(int categoryId)
        {
            pnlAttributes.Controls.Clear();
            var templates = CategoryAttribute.GetByCategory(categoryId);
            int y = 10;
            foreach (var t in templates)
            {
                var lbl = new Label
                {
                    Text = t.name + ":",
                    Location = new System.Drawing.Point(8, y + 4),
                    Width = 120
                };
                pnlAttributes.Controls.Add(lbl);
                var tb = new TextBox
                {
                    Name = "attr_" + t.name.Replace(" ", "_"),
                    Tag = t.attributeId,
                    Location = new System.Drawing.Point(140, y),
                    Width = 120
                };
                pnlAttributes.Controls.Add(tb);
                y += 32;
            }
            var btnManual = new Button
            {
                Name = "btnAddManualAttr",
                Text = "Додати атрибут вручну",
                AutoSize = true,
                Location = new System.Drawing.Point(8, y + 8)
            };
            btnManual.Click += BtnManual_Click;
            pnlAttributes.Controls.Add(btnManual);
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            int y = 10;
            foreach (Control c in pnlAttributes.Controls) y = Math.Max(y, c.Bottom + 6);
            var tbName = new TextBox
            {
                Name = "manual_name_" + Guid.NewGuid().ToString("N"),
                Location = new System.Drawing.Point(8, y),
                Width = 140
            };
            tbName.PlaceholderTextSafe("Назва");
            pnlAttributes.Controls.Add(tbName);
            var tbValue = new TextBox
            {
                Name = "manual_value_" + Guid.NewGuid().ToString("N"),
                Location = new System.Drawing.Point(160, y),
                Width = 140
            };
            tbValue.PlaceholderTextSafe("Значення");
            pnlAttributes.Controls.Add(tbValue);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введіть назву товару");
                return;
            }
            if (!decimal.TryParse(tbPrice.Text, out decimal price))
            {
                MessageBox.Show("Невірний формат ціни");
                return;
            }
            if (!int.TryParse(tbQty.Text, out int qty))
            {
                MessageBox.Show("Невірний формат кількості");
                return;
            }
            int categoryId = cbCategory.SelectedValue == null 
                ? 0 
                : Convert.ToInt32(cbCategory.SelectedValue);
            int brandId = cbBrand.SelectedValue == null 
                ? 0 
                : Convert.ToInt32(cbBrand.SelectedValue);
            int newProductId = Product.Create(tbName.Text.Trim(), price, qty, categoryId, brandId);
            foreach (Control c in pnlAttributes.Controls)
            {
                if (c is TextBox tb)
                {
                    string attrName = null;
                    string attrValue = tb.Text?.Trim();
                    if (tb.Tag is int attrId)
                    {
                        ProductAttributeValue.Add(newProductId, attrId, attrValue ?? "");
                        continue;
                    }
                    if (tb.Name.StartsWith("manual_name_"))
                    {
                        attrName = tb.Text.Trim();
                        if (string.IsNullOrEmpty(attrName)) continue;
                        var valueControl = pnlAttributes.Controls
                            .OfType<TextBox>()
                            .Where(t => t.Name.StartsWith("manual_value_"))
                            .FirstOrDefault(t => Math.Abs(t.Top - tb.Top) < 6);
                        var manualValue = valueControl?.Text?.Trim() ?? "";
                        int newAttrId = CategoryAttribute.AddAndGetId(categoryId, attrName);
                        ProductAttributeValue.Add(newProductId, newAttrId, manualValue);
                    }
                }
            }
            MessageBox.Show("Товар додано!");
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    static class TextBoxExtensions
    {
        public static void PlaceholderTextSafe(this TextBox tb, string text)
        {
            try
            {
                tb.Text = text;
            }
            catch
            {
                tb.Text = text;
                tb.ForeColor = System.Drawing.Color.Gray;
                tb.GotFocus += (s, e) =>
                {
                    if (tb.ForeColor == System.Drawing.Color.Gray)
                    {
                        tb.Text = "";
                        tb.ForeColor = System.Drawing.Color.Black;
                    }
                };
                tb.LostFocus += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        tb.Text = text;
                        tb.ForeColor = System.Drawing.Color.Gray;
                    }
                };
            }
        }
    }
}
