using Course_Project.Models.Core;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddBrandForm : Form
    {
        public AddBrandForm() => InitializeComponent();
       
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введіть назву бренду");
                return;
            }
            Brand.Add(tbName.Text.Trim(), tbCountry.Text.Trim());
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();
        
    }
}
