using Course_Project.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void BtnAddAtribute_Click(object sender, EventArgs e)
        {
            var panel = new Panel
            {
                Width = flowAttributes.ClientSize.Width - 25,
                Height = 32
            };
            var txt = new TextBox
            {
                Width = panel.Width - 40,
                Left = 0,
                Top = 4,
                Name = "attr_" + Guid.NewGuid().ToString("N")
            };
            var btnRemove = new Button
            {
                Text = "X",
                Width = 30,
                Left = txt.Right + 6,
                Top = 2,
                Height = txt.Height
            };
            btnRemove.Click += (s, ev) => flowAttributes.Controls.Remove(panel);
            panel.Controls.Add(txt);
            panel.Controls.Add(btnRemove);
            flowAttributes.Controls.Add(panel);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCatogoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Введіть назву категорії");
                return;
            }
            int categoryId = Category.Create(categoryName);
            foreach (Control c in flowAttributes.Controls)
            {
                var tb = c.Controls.OfType<TextBox>().FirstOrDefault();
                if (tb != null)
                {
                    var attr = tb.Text.Trim();
                    if (!string.IsNullOrEmpty(attr))
                    {
                        CategoryAttribute.Add(categoryId, attr);
                    }
                }
            }
            MessageBox.Show("Категорію створено");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
