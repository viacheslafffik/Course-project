using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models.Core
{
    internal class CategoryAttribute
    {
        public int attributeId { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }

        public static List<CategoryAttribute> GetByCategory(int categoryId)
        {
            var list = new List<CategoryAttribute>();

            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $"SELECT * FROM CategoryAttribute WHERE categoryId = {categoryId}",
                    connection);
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new CategoryAttribute
                        {
                            attributeId = Convert.ToInt32(r["attributeId"]),
                            categoryId = Convert.ToInt32(r["categoryId"]),
                            name = r["name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void Add(int categoryId, string attrName)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    "INSERT INTO CategoryAttribute (categoryId, name) " +
                    $"VALUES ({categoryId}, '{attrName}')",
                    connection);
                query.ExecuteNonQuery();
            }
        }

        public static int AddAndGetId(int categoryId, string attrName)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand(
                    "INSERT INTO CategoryAttribute (categoryId, name) " +
                    $"VALUES ({categoryId}, '{attrName}'); SELECT LAST_INSERT_ID();",
                    connection))
                {
                    var res = query.ExecuteScalar();
                    return Convert.ToInt32(res);
                }
            }
        }
    }
}
