using System;
using Course_Project.Utils;
using Course_Project.Database;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Course_Project.Forms;

namespace Course_Project.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = PasswordManager.Hash(txtPassword.Text);

            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    "SELECT * FROM Users WHERE username=@u AND passwordHash=@p",
                    connection
                    );

                query.Parameters.AddWithValue("@u", username);
                query.Parameters.AddWithValue("@p", password);

                var reader = query.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Невірний логін або пароль");
                    return;
                }
                string role = reader["role"].ToString();
                string firstName = reader["firstName"].ToString();

                Hide();
                new MainForm(username, role, firstName).Show();
            }
        }
    }
}
