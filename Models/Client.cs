using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models
{
    internal class Client
    {
        public int clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int discount { get; set; }

        public static List<Client> GetAll()
        {
            var list = new List<Client>();

            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand("SELECT * FROM Clients", connection);

                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Client
                        {
                            clientId = Convert.ToInt32(r["clientId"]),
                            firstName = r["firstName"].ToString(),
                            lastName = r["lastName"].ToString(),
                            phone = r["phone"].ToString(),
                            discount = Convert.ToInt32(r["discount"])
                        });
                    }
                }
            }
            return list;
        }

        public static int Add(string firstName, string lastName, string phone, int discount)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"INSERT INTO Clients (firstName, lastName, phone, discount) " +
                    $"VALUES ('{firstName}', '{lastName}', '{phone}', {discount}); " +
                    $"SELECT LAST_INSERT_ID();",
                    connection);

                return Convert.ToInt32(query.ExecuteScalar());
            }
        }
    }
}
