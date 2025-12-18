using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Course_Project.Database;
using Course_Project.Utils;

namespace Course_Project.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string passwordHash = PasswordManager.Hash(txtPassword.Text);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(passwordHash))
            {
                MessageBox.Show("Введіть логін і пароль");
                return;
            }

            using (var connection = Db.Connection())
            {
                connection.Open();

                var sql =
                    "SELECT userId, username, role, firstName " +
                    "FROM Users " +
                    $"WHERE username='{username}' AND passwordHash='{passwordHash}'";

                using (var cmd = new MySqlCommand(sql, connection))
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read())
                    {
                        MessageBox.Show("Невірний логін або пароль");
                        return;
                    }

                    Session.UserId = r.GetInt32("userId");
                    Session.Username = r.GetString("username");
                    Session.Role = r.GetString("role");
                    Session.FirstName = r.GetString("firstName");
                }
            }

            Hide();
            new MainForm().Show();
        }
    }
}
