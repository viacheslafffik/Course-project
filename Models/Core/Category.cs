using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models.Core
{
    internal class Category
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string productType { get; set; }

        public static List<Category> GetAll()
        {
            var list = new List<Category>();

            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand("select * from Category", connection);

                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Category
                        {
                            categoryId = Convert.ToInt32(r["categoryId"]),
                            name = r["name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static int Create(string name)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"insert into Category (name) values ('{name}'); SELECT LAST_INSERT_ID();",
                    connection
                );
                var id = query.ExecuteScalar();
                return Convert.ToInt32(id);
            }
        }

        public static void AddAttribute(int categoryId, string attributeName)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"INSERT INTO CategoryAttribute (categoryId, name) " +
                    $"VALUES ({categoryId}, '{attributeName}');",
                    connection
                );
                query.ExecuteNonQuery();
            }
        }
    }
}
