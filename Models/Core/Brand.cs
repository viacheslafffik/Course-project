using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models.Core
{
    internal class Brand
    {
        public int brandId { get; set; }
        public string name { get; set; }
        public string country { get; set; }

        public static void Add(string name, string country)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    $@"INSERT INTO Brand (name, country) 
                    VALUES ('{MySqlHelper.EscapeString(name)}', '{country}')", 
                    connection);
                query.ExecuteNonQuery();
            }
        }


        public static List<Brand> GetAll()
        {
            var list = new List<Brand>();
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand("select * from Brand", connection);
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Brand
                        {
                            brandId = Convert.ToInt32(r["brandId"]),
                            name = r["name"].ToString(),
                            country = r["country"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
