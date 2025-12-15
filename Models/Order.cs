using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;

namespace Course_Project.Models
{
    internal class Order
    {
        public static void Create(int userId)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var tx = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlOrder =
                            "INSERT INTO Orders (clientId, userId, status, totalPrice) " +
                            $"VALUES (NULL, {userId}, 'new', {OrderCart.Total()}); " +
                            "SELECT LAST_INSERT_ID();";

                        int orderId;
                        using (var query = new MySqlCommand(sqlOrder, connection, tx)) orderId = Convert.ToInt32(query.ExecuteScalar());                       

                        foreach (var i in OrderCart.Items)
                        {
                            string sqlItem =
                                "INSERT INTO OrderItem (orderId, productId, quantity, price) " +
                                $"VALUES ({orderId}, {i.productId}, {i.quantity}, {i.price});";

                            using (var queryItem = new MySqlCommand(sqlItem, connection, tx)) queryItem.ExecuteNonQuery();

                            string sqlUpdate =
                                "UPDATE Product SET quantity = quantity - " + i.quantity +
                                " WHERE productId = " + i.productId + ";";

                            using (var queryUpd = new MySqlCommand($@"UPDATE Product SET quantity = quantity - " + i.quantity +
                                " WHERE productId = " + i.productId + ";", 
                                connection, tx))
                                queryUpd.ExecuteNonQuery();
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
