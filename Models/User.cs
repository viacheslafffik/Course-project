using Course_Project.Database;
using Course_Project.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Course_Project.Models
{
    internal class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string role { get; set; }

        public void Save()
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand($"insert into Users (firstName, lastName, username, passwordHash, role) " +
                    $"VALUES ('{firstName}', '{lastName}', '{username}', '{passwordHash}', '{role}')", connection);
                query.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"delete from Users where userId={id}",
                    connection
                );
                query.ExecuteNonQuery();
            }
        }

        public static void ResetPassword(int id, string password)
        {
            string hash = PasswordManager.Hash(password);
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"UPDATE Users SET passwordHash='{hash}' WHERE userId={id}",
                    connection
                );
                query.ExecuteNonQuery();
            }
        }

        public static DataTable GetAllUsers()
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    "select userId, firstName, lastName, username, role from Users",
                    connection
                );
                var table = new DataTable();
                var adapter = new MySqlDataAdapter(query);
                adapter.Fill(table);
                return table;
            }
        }

        public static bool AdminExists()
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    "select count(*) from Users where role='admin'",
                    connection
                );
                return Convert.ToInt32(query.ExecuteScalar()) > 0;
            }
        }


        public static int GetIdByUsername(string username)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"select userId from Users where username='{username}' limit 1",
                    connection
                );
                var res = query.ExecuteScalar();
                if (res == null) throw new InvalidOperationException("User not found");
                return Convert.ToInt32(res);
            }
        }

        public static void CreateSystemAdminDefault()
        {
            var admin = new User
            {
                firstName = "System",
                lastName = "Admin",
                username = "admin",
                passwordHash = PasswordManager.Hash("admin123"),
                role = "admin"
            };
            admin.Save();
        }
    }
}
