using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;

namespace Course_Project.Models
{
    internal class Order
    {
        public static void Create(int userId)
        {
            using (var conn = Db.Connection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlOrder =
                            "INSERT INTO Orders (clientId, userId, status, totalPrice) " +
                            $"VALUES (NULL, {userId}, 'new', {OrderCart.Total()}); " +
                            "SELECT LAST_INSERT_ID();";

                        int orderId;
                        using (var cmd = new MySqlCommand(sqlOrder, conn, tx))
                        {
                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        foreach (var i in OrderCart.Items)
                        {
                            string sqlItem =
                                "INSERT INTO OrderItem (orderId, productId, quantity, price) " +
                                $"VALUES ({orderId}, {i.productId}, {i.quantity}, {i.price});";

                            using (var cmdItem = new MySqlCommand(sqlItem, conn, tx)) cmdItem.ExecuteNonQuery();

                            string sqlUpdate =
                                "UPDATE Product SET quantity = quantity - " + i.quantity +
                                " WHERE productId = " + i.productId + ";";

                            using (var cmdUpd = new MySqlCommand($@"UPDATE Product SET quantity = quantity - " + i.quantity +
                                " WHERE productId = " + i.productId + ";", 
                                conn, tx))
                                cmdUpd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
