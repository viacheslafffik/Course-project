using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Data.Products
{
    internal class BestsellersRepository
    {
        internal class BestsellerRow
        {
            public int productId { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public int soldQty { get; set; }
            public decimal revenue { get; set; }
        }

        public List<BestsellerRow> GetTop25LastWeek()
        {
            var list = new List<BestsellerRow>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                var sql =
                @"SELECT 
                      p.productId,
                      p.name,
                      p.price,
                      SUM(oi.quantity) AS soldQty,
                      SUM(oi.quantity * oi.price) AS revenue
                  FROM OrderItem oi
                  JOIN Orders o ON o.orderId = oi.orderId
                  JOIN Product p ON p.productId = oi.productId
                  JOIN Book b ON b.productId = p.productId
                  JOIN Category c ON c.categoryId = p.categoryId
                  WHERE c.productType = 'book'
                    AND o.orderDate >= NOW() - INTERVAL 7 DAY
                  GROUP BY p.productId, p.name, p.price
                  ORDER BY soldQty DESC, revenue DESC
                  LIMIT 25;";

                using (var query = new MySqlCommand(sql, connection))
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new BestsellerRow
                        {
                            productId = Convert.ToInt32(r["productId"]),
                            name = Convert.ToString(r["name"]),
                            price = Convert.ToDecimal(r["price"]),
                            soldQty = Convert.ToInt32(r["soldQty"]),
                            revenue = Convert.ToDecimal(r["revenue"])
                        });
                    }
                }
            }

            return list;
        }
    }
}
