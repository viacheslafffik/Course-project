using Course_Project.Models;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddClientForm : Form
    {
        public int CreatedClientId { get; private set; }

        public AddClientForm() => InitializeComponent();      

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Введіть номер телефону");
                return;
            }
            CreatedClientId = Client.Add(
                tbFirstName.Text.Trim(),
                tbLastName.Text.Trim(),
                tbPhone.Text.Trim()
            );
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();       
    }
}
