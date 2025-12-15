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

        private void btnAddAtribute_Click(object sender, EventArgs e)
        {
            var panel = new Panel();
            panel.Width = flowAttributes.ClientSize.Width - 25;
            panel.Height = 32;
            var txt = new TextBox();
            txt.Width = panel.Width - 40;
            txt.Left = 0;
            txt.Top = 4;
            txt.Name = "attr_" + Guid.NewGuid().ToString("N");
            var btnRemove = new Button();
            btnRemove.Text = "X";
            btnRemove.Width = 30;
            btnRemove.Left = txt.Right + 6;
            btnRemove.Top = 2;
            btnRemove.Height = txt.Height;
            btnRemove.Click += (s, ev) => flowAttributes.Controls.Remove(panel);
            panel.Controls.Add(txt);
            panel.Controls.Add(btnRemove);
            flowAttributes.Controls.Add(panel);
        }

        private void btnSave_Click(object sender, EventArgs e)
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
