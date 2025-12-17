using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Models.Orders
{
    internal class OrderInfo
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public decimal totalPrice { get; set; }
        public decimal totalPriceWithDiscount { get; set; }
        public string seller { get; set; }
        public string clientPhone { get; set; }

        public static List<OrderInfo> GetOrders(
            string role,
            string sellerUsername,
            string phone = null)
        {
            var list = new List<OrderInfo>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                string sql =
                @"SELECT 
                    o.orderId,
                    o.orderDate,
                    o.totalPrice,
                    o.totalPriceWithDiscount,
                    u.username AS seller,
                    c.phone AS clientPhone
                FROM Orders o
                JOIN Users u ON o.userId = u.userId
                LEFT JOIN Clients c ON o.clientId = c.clientId
                WHERE 1 = 1 ";

                if (role != "admin")
                    sql += " AND u.username = @seller";

                if (!string.IsNullOrWhiteSpace(phone))
                    sql += " AND c.phone LIKE CONCAT('%', @phone, '%')";

                sql += " ORDER BY o.orderDate DESC";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    if (role != "admin")
                        cmd.Parameters.AddWithValue("@seller", sellerUsername);

                    if (!string.IsNullOrWhiteSpace(phone))
                        cmd.Parameters.AddWithValue("@phone", phone);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new OrderInfo
                            {
                                orderId = Convert.ToInt32(r["orderId"]),
                                orderDate = Convert.ToDateTime(r["orderDate"]),
                                totalPrice = Convert.ToDecimal(r["totalPrice"]),
                                totalPriceWithDiscount = Convert.ToDecimal(r["totalPriceWithDiscount"]),
                                seller = r["seller"].ToString(),
                                clientPhone = r["clientPhone"] == DBNull.Value
                                    ? "-"
                                    : r["clientPhone"].ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }
    }

    internal class OrderHistoryRow
    {
        public DateTime orderDate { get; set; }
        public string clientPhone { get; set; }
        public string seller { get; set; }
        public decimal total { get; set; }
        public decimal totalWithDiscount { get; set; }
        public string items { get; set; }
    }

    internal class OrderItemInfo
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
