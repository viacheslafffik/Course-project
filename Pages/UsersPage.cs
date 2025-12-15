using Course_Project.Forms.Additional;
using Course_Project.Models;
using Course_Project.Utils;
using System;
using System.Windows.Forms;

namespace Course_Project.Pages
{
    public partial class UsersPage : UserControl
    {

        public UsersPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers() => dgvUsers.DataSource = User.GetAllUsers();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // validate methods are needed here
            if (txtFirstname.Text.Length == 0 
                || txtLastName.Text.Length == 0
                || txtUsername.Text.Length == 0
                || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Заповніть всі поля.");
                return;
            }
            var user = new User
            {
                firstName = txtFirstname.Text,
                lastName = txtLastName.Text,
                username = txtUsername.Text,
                passwordHash = PasswordManager.Hash(txtPassword.Text),
                role = "seller"
            };
            user.Save();
            LoadUsers();
            MessageBox.Show("Користувача додано.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Виберіть користувача.");
                return;
            }
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["userId"].Value);
            User.Delete(id); LoadUsers();
            MessageBox.Show("Користувача видалено.");
        }


        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Виберіть користувача!");
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["userId"].Value);

            using (var prompt = new PasswordPromptForm())
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string newPass = prompt.PasswordText;
                    User.ResetPassword(id, newPass);
                    MessageBox.Show($"Пароль успішно змінено на: {newPass}");
                }
            }
        }

    }
}
