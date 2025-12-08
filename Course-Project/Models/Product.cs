using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        public int brandId { get; set; }

        public static List<Product> GetAll()
        {
            var list = new List<Product>();
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    "select * from Product",
                    connection
                );
                using (var reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product
                        {
                            productId = Convert.ToInt32(reader["productId"]),
                            name = reader["name"].ToString(),
                            price = Convert.ToDecimal(reader["price"]),
                            quantity = Convert.ToInt32(reader["quantity"]),
                            categoryId = reader["categoryId"] == DBNull.Value 
                            ? 0 
                            : Convert.ToInt32(reader["categoryId"]),
                            brandId = reader["brandId"] == DBNull.Value 
                            ? 0 
                            : Convert.ToInt32(reader["brandId"])
                        });
                    }
                }
            }
            return list;
        }

        public List<(string Name, string Value)> GetAttributes()
        {
            var list = new List<(string Name, string Value)>();

            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand(
                    $@"SELECT ca.name AS attributeName, pav.value AS attributeValue
                    FROM ProductAttributeValue pav
                    JOIN CategoryAttribute ca ON pav.attributeId = ca.attributeId
                    WHERE pav.productId = {productId}",
                    connection))
                {
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add((
                                reader["attributeName"].ToString(),
                                reader["attributeValue"].ToString()
                            ));
                        }
                    }
                }
            }
            return list;
        }

        public static int Create(string name, decimal price, int qty, int categoryId, int brandId)
        {
            using (var conn = Db.Connection())
            {
                conn.Open();
                string escName = MySqlHelper.EscapeString(name);
                string catPart = categoryId == 0 
                    ? "NULL" 
                    : categoryId.ToString();
                string brandPart = brandId == 0 
                    ? "NULL" 
                    : brandId.ToString();
                string sql = $"INSERT INTO Product (name, price, quantity, categoryId, brandId) " +
                             $"VALUES ('{escName}', {price}, {qty}, '{catPart}', '{brandPart}'); " +
                             $"SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var id = cmd.ExecuteScalar();
                    return Convert.ToInt32(id);
                }
            }
        }

        public class ProductWithNames : Product
        {
            public string CategoryName { get; set; }
            public string BrandName { get; set; }

            public static List<ProductWithNames> GetAllWithNames()
            {
                var list = new List<ProductWithNames>();
                using (var connection = Db.Connection())
                {
                    connection.Open();
                    var query = new MySqlCommand(@"
                        SELECT p.*, 
                               c.name AS categoryName,
                               b.name AS brandName
                        FROM Product p
                        LEFT JOIN Category c ON p.categoryId = c.categoryId
                        LEFT JOIN Brand b ON p.brandId = b.brandId", 
                        connection);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductWithNames
                            {
                                productId = Convert.ToInt32(reader["productId"]),
                                name = reader["name"].ToString(),
                                price = Convert.ToDecimal(reader["price"]),
                                quantity = Convert.ToInt32(reader["quantity"]),
                                categoryId = reader["categoryId"] == DBNull.Value 
                                ? 0 
                                : Convert.ToInt32(reader["categoryId"]),
                                brandId = reader["brandId"] == DBNull.Value 
                                ? 0 
                                : Convert.ToInt32(reader["brandId"]),
                                CategoryName = reader["categoryName"]?.ToString(),
                                BrandName = reader["brandName"]?.ToString()
                            });
                        }
                    }
                }
                return list;
            }
        }
    }

    public static class ProductAttribute
    {
        public static void Add(int productId, string name, string value)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var tx = connection.BeginTransaction())
                {
                    // category
                    var queryCat = new MySqlCommand(
                        $"select categoryId from Product where productId = {productId}",
                        connection, tx);
                    var catObj = queryCat.ExecuteScalar();
                    if (catObj == null) throw new InvalidOperationException("Product not found");
                    int categoryId = Convert.ToInt32(catObj);

                    // 2) attribute
                    var queryFind = new MySqlCommand(
                        $"select attributeId from CategoryAttribute " +
                        $"where name = '{name}' " +
                        $"and categoryId = {categoryId} limit 1",
                        connection, tx);
                    var attrObj = queryFind.ExecuteScalar();
                    int attributeId;
                    if (attrObj == null)
                    {
                        var queryInsAttr = new MySqlCommand(
                            "insert into CategoryAttribute (categoryId, name) " +
                            $"values ({categoryId}, '{name}'); select LAST_INSERT_ID();",
                            connection, tx);
                        attributeId = Convert.ToInt32(queryInsAttr.ExecuteScalar());
                    }
                    else attributeId = Convert.ToInt32(attrObj);

                    // 3) insert
                    var queryUpsert = new MySqlCommand(
                        $@"insert into ProductAttributeValue (productId, attributeId, value)
                        values ({categoryId},{attributeId}, '{value}')
                        ON DUPLICATE KEY UPDATE value = '{value}'",
                        connection, tx);
                    queryUpsert.ExecuteNonQuery();
                    tx.Commit();
                }
            }
        }
    }
}
