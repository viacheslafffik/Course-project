using Course_Project.Utils;
using MySql.Data.MySqlClient;
using System;

namespace Course_Project.Database
{
    internal static class DataInitializer
    {
        public static bool AdminExists()
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE role='admin'",
                    connection
                );
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public static void CreateSystemAdminDefault()
        {
            string username = "admin";
            string password = PasswordManager.Hash("admin123");

            using (var connection = Db.Connection())
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "INSERT INTO Users (firstName, lastName, username, passwordHash, role) " +
                    "VALUES ('System', 'Admin', @u, @p, 'admin')",
                    connection
                );
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
