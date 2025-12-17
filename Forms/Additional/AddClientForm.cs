using Course_Project.Models.Users;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Additional
{
    public partial class AddClientForm : Form
    {
        public int CreatedClientId { get; private set; }

        public AddClientForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show(
                    "Введіть номер телефону",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var result = Client.GetOrCreateWithInfo(
                tbFirstName.Text.Trim(),
                tbLastName.Text.Trim(),
                tbPhone.Text.Trim()
            );

            CreatedClientId = result.clientId;

            if (result.alreadyExists)
            {
                MessageBox.Show(
                    "Клієнт з таким номером телефону вже існує.",
                    "Інформація",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
