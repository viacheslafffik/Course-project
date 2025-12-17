using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Course_Project.Models.Users;

namespace Course_Project.Models.Orders
{
    internal class Order
    {
        public static int Create(int userId, Client client)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var tx = connection.BeginTransaction())
                {
                    try
                    {
                        decimal total = OrderCart.Total();
                        decimal totalWithDiscount = total;

                        int? clientId = null;

                        if (client != null)
                        {
                            clientId = client.clientId;
                            if (client.discount > 0) totalWithDiscount -= total * client.discount / 100m;
                        }

                        string sqlOrder = "INSERT INTO Orders (clientId, userId, totalPrice, totalPriceWithDiscount) " +
                            "VALUES (" + (clientId.HasValue ? clientId.Value.ToString() : "NULL") + ", " + userId + ", " +
                            total.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " +
                            totalWithDiscount.ToString(System.Globalization.CultureInfo.InvariantCulture) +
                            "); SELECT LAST_INSERT_ID();";
                        int orderId;
                        using (var cmd = new MySqlCommand(sqlOrder, connection, tx)) orderId = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach (var i in OrderCart.Items)
                        {
                            string sqlItem = "INSERT INTO OrderItem (orderId, productId, quantity, price) VALUES (" +
                                orderId + ", " +
                                i.productId + ", " +
                                i.quantity + ", " +
                                i.price.ToString(System.Globalization.CultureInfo.InvariantCulture) +
                                ");";

                            using (var queryItem = new MySqlCommand(sqlItem, connection, tx)) queryItem.ExecuteNonQuery();
                            string sqlUpd = "UPDATE Product SET quantity = quantity - " + i.quantity +
                                " WHERE productId = " + i.productId + ";";
                            using (var queryUpd = new MySqlCommand(sqlUpd, connection, tx)) queryUpd.ExecuteNonQuery();
                        }
                        tx.Commit();
                        return orderId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public static DataTable GetOrders(string role, int userId, string phone = null)
        {
            var table = new DataTable();

            using (var connection = Db.Connection())
            {
                connection.Open();

                string sql =
                    @"SELECT o.orderId, o.orderDate, o.totalPrice,
                    c.phone, u.username
                    FROM Orders o
                    LEFT JOIN Clients c ON o.clientId = c.clientId
                    JOIN Users u ON o.userId = u.userId
                    WHERE 1=1 ";

                if (role != "admin") sql += $" AND o.userId = {userId}";
                if (!string.IsNullOrWhiteSpace(phone)) sql += $" AND c.phone = '{MySqlHelper.EscapeString(phone)}'";
                using (var da = new MySqlDataAdapter(sql, connection)) da.Fill(table);
            }

            return table;
        }

        public static List<OrderHistoryRow> GetHistory(string role, string username, string phone = null)
        {
            var list = new List<OrderHistoryRow>();

            using (var conn = Db.Connection())
            {
                conn.Open();

                string sql = @"
                SELECT 
                o.orderDate,
                c.phone,
                u.username,
                o.totalPrice,
                o.totalPriceWithDiscount,
                GROUP_CONCAT(CONCAT(p.name, ' x', oi.quantity) SEPARATOR ', ') AS items
                FROM Orders o
                LEFT JOIN Clients c ON o.clientId = c.clientId
                JOIN Users u ON o.userId = u.userId
                JOIN OrderItem oi ON oi.orderId = o.orderId
                JOIN Product p ON p.productId = oi.productId
                WHERE 1=1";

                if (role != "admin") sql += $" AND u.username = '{MySqlHelper.EscapeString(username)}'";
                if (!string.IsNullOrWhiteSpace(phone)) sql += $" AND c.phone = '{MySqlHelper.EscapeString(phone)}'";
                sql += " GROUP BY o.orderId ORDER BY o.orderDate DESC";

                using (var query = new MySqlCommand(sql, conn))
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new OrderHistoryRow
                        {
                            orderDate = Convert.ToDateTime(r["orderDate"]),
                            clientPhone = r["phone"]?.ToString() ?? "-",
                            seller = r["username"].ToString(),
                            total = Convert.ToDecimal(r["totalPrice"]),
                            totalWithDiscount = Convert.ToDecimal(r["totalPriceWithDiscount"]),
                            items = r["items"].ToString()
                        });
                    }
                }
            }
            return list;
        }


        public static List<OrderItemInfo> GetItems(int orderId)
        {
            var list = new List<OrderItemInfo>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                string sql = $@"SELECT p.name, oi.price, oi.quantity
                               FROM OrderItem oi
                               JOIN Product p ON p.productId = oi.productId
                               WHERE oi.orderId = {orderId}";

                using (var query = new MySqlCommand(sql, connection))
                {
                    using (var r = query.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new OrderItemInfo
                            {
                                name = r["name"].ToString(),
                                price = Convert.ToDecimal(r["price"]),
                                quantity = Convert.ToInt32(r["quantity"])
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
