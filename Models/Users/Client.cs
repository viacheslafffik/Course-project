using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models.Users
{
    internal class Client
    {
        public int clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int discount { get; set; }

        /// <summary>
        /// Повертає clientId:
        /// - якщо клієнт існує — існуючий
        /// - якщо ні — створює нового
        /// </summary>
        public static int GetOrCreate(string firstName, string lastName, string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Телефон не може бути порожнім");
            var existing = GetByPhone(phone);
            if (existing != null) return existing.clientId;
            using (var conn = Db.Connection())
            {
                conn.Open();
                string sql =
                $"INSERT INTO Clients (firstName, lastName, phone, discount) " +
                $"VALUES ('{firstName}', '{lastName}', '{phone}', 0); " +
                $"SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        public static Client GetByPhone(string phone)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();

                using (var cmd = new MySqlCommand(
                    "SELECT * FROM Clients WHERE phone = @phone", connection))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return null;

                        return new Client
                        {
                            clientId = Convert.ToInt32(r["clientId"]),
                            firstName = r["firstName"].ToString(),
                            lastName = r["lastName"].ToString(),
                            phone = r["phone"].ToString(),
                            discount = Convert.ToInt32(r["discount"])
                        };
                    }
                }
            }
        }

        public static List<Client> GetAll()
        {
            var list = new List<Client>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                using (var cmd = new MySqlCommand(
                    "SELECT * FROM Clients ORDER BY lastName", connection))
                using (var r = cmd.ExecuteReader())
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
         
        public static ClientCreateResult GetOrCreateWithInfo( string firstName, string lastName, string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Телефон не може бути порожнім");
            var existing = GetByPhone(phone);
            if (existing != null)
            {
                return new ClientCreateResult
                {
                    clientId = existing.clientId,
                    alreadyExists = true
                };
            }
            using (var conn = Db.Connection())
            {
                conn.Open();

                string sql =
                $"INSERT INTO Clients (firstName, lastName, phone, discount) " +
                $"VALUES ('{firstName}', '{lastName}', '{phone}', 0); " +
                $"SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return new ClientCreateResult
                    {
                        clientId = Convert.ToInt32(cmd.ExecuteScalar()),
                        alreadyExists = false
                    };
                }
            }
        }
        public static Client GetById(int id)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();

                string sql = $"SELECT * FROM Clients WHERE clientId = {id}";

                using (var cmd = new MySqlCommand(sql, connection))
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new Client
                    {
                        clientId = Convert.ToInt32(r["clientId"]),
                        firstName = r["firstName"].ToString(),
                        lastName = r["lastName"].ToString(),
                        phone = r["phone"].ToString(),
                        discount = Convert.ToInt32(r["discount"])
                    };
                }
            }
        }
    }
    internal class ClientCreateResult
    {
        public int clientId { get; set; }
        public bool alreadyExists { get; set; }
    }
}
