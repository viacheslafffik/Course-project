using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Addictional
{
    public partial class PasswordPromptForm : Form
    {
        public string PasswordText { get => txtbPassword.Text; }

        public PasswordPromptForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbPassword.Text))
            {
                MessageBox.Show("Пароль не може бути порожнім.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
