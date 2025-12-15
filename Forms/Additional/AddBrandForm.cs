using Course_Project.Models;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddBrandForm : Form
    {
        public AddBrandForm() => InitializeComponent();
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введіть назву бренду");
                return;
            }
            Brand.Add(tbName.Text.Trim(), tbCountry.Text.Trim());
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
        
    }
}
