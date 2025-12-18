using Course_Project.Database;
using Course_Project.Models.Supplies;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course_Project.Data.Supplies
{
    internal class SuppliesRepository
    {
        public int CreateSupply(int supplierId, int userId, string invoiceNumber, DateTime date, string note)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                note = string.IsNullOrWhiteSpace(note) ? "NULL" : $"'{note.Replace("'", "''")}'";

                var sql =
                    $"INSERT INTO Supply (supplierId, userId, invoiceNumber, supplyDate, note) " +
                    $"VALUES ({supplierId}, {userId}, '{invoiceNumber}', '{date:yyyy-MM-dd HH:mm:ss}', {note}); " +
                    $"SELECT LAST_INSERT_ID();";

                using (var query = new MySqlCommand(sql, connection))
                    return Convert.ToInt32(query.ExecuteScalar());
            }
        }

        public void AddItem(int supplyId, int productId, int qty, decimal purchasePrice)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var sql =
                    $"INSERT INTO SupplyItem (supplyId, productId, quantity, purchasePrice) " +
                    $"VALUES ({supplyId}, {productId}, {qty}, {purchasePrice})";

                using (var query = new MySqlCommand(sql, connection))
                    query.ExecuteNonQuery();
            }
        }

        public List<SupplyModel> GetSupplies(
            string invoiceLike,
            int? supplierId,
            DateTime? from,
            DateTime? to,
            int? userId
        )
        {
            var list = new List<SupplyModel>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                var sql =
                    @"SELECT s.supplyId, s.supplierId, s.userId, s.invoiceNumber, s.supplyDate, s.note, s.totalCost,
                             sup.name AS supplierName, u.username AS userName
                      FROM Supply s
                      JOIN Supplier sup ON sup.supplierId = s.supplierId
                      JOIN Users u ON u.userId = s.userId
                      WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(invoiceLike))
                    sql += $" AND s.invoiceNumber LIKE '%{invoiceLike}%'";

                if (supplierId.HasValue)
                    sql += $" AND s.supplierId = {supplierId.Value}";

                if (from.HasValue)
                    sql += $" AND s.supplyDate >= '{from.Value:yyyy-MM-dd HH:mm:ss}'";

                if (to.HasValue)
                    sql += $" AND s.supplyDate <= '{to.Value:yyyy-MM-dd HH:mm:ss}'";

                if (userId.HasValue)
                    sql += $" AND s.userId = {userId.Value}";

                sql += " ORDER BY s.supplyDate DESC";

                using (var query = new MySqlCommand(sql, connection))
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new SupplyModel
                        {
                            supplyId = r.GetInt32("supplyId"),
                            supplierId = r.GetInt32("supplierId"),
                            userId = r.GetInt32("userId"),
                            invoiceNumber = r.GetString("invoiceNumber"),
                            supplyDate = r.GetDateTime("supplyDate"),
                            note = r.IsDBNull(r.GetOrdinal("note")) ? "" : r.GetString("note"),
                            totalCost = r.IsDBNull(r.GetOrdinal("totalCost")) ? 0 : r.GetDecimal("totalCost"),
                            supplierName = r.GetString("supplierName"),
                            userName = r.GetString("userName")
                        });
                    }
                }
            }

            return list;
        }

        public List<SupplyItemModel> GetItems(int supplyId)
        {
            var list = new List<SupplyItemModel>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                var sql =
                    @"SELECT si.itemId, si.supplyId, si.productId, si.quantity, si.purchasePrice,
                             p.name AS productName, p.price AS salePrice, p.quantity AS currentStock
                      FROM SupplyItem si
                      JOIN Product p ON p.productId = si.productId
                      WHERE si.supplyId = " + supplyId;

                using (var query = new MySqlCommand(sql, connection))
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new SupplyItemModel
                        {
                            itemId = r.GetInt32("itemId"),
                            supplyId = r.GetInt32("supplyId"),
                            productId = r.GetInt32("productId"),
                            quantity = r.GetInt32("quantity"),
                            purchasePrice = r.GetDecimal("purchasePrice"),
                            productName = r.GetString("productName"),
                            salePrice = r.GetDecimal("salePrice"),
                            currentStock = r.GetInt32("currentStock")
                        });
                    }
                }
            }

            return list;
        }

        public void ApplySupplyToStock(int supplyId)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var tr = connection.BeginTransaction())
                {
                    decimal total = 0;

                    var readSql =
                        $"SELECT productId, quantity, purchasePrice FROM SupplyItem WHERE supplyId={supplyId}";

                    using (var query = new MySqlCommand(readSql, connection, tr))
                    using (var r = query.ExecuteReader())
                    {
                        var items = new List<(int pid, int qty, decimal pp)>();

                        while (r.Read())
                            items.Add((r.GetInt32(0), r.GetInt32(1), r.GetDecimal(2)));

                        r.Close();

                        foreach (var it in items)
                        {
                            var updSql =
                                $"UPDATE Product SET quantity = quantity + {it.qty} WHERE productId={it.pid}";
                            using (var uq = new MySqlCommand(updSql, connection, tr))
                                uq.ExecuteNonQuery();

                            total += it.pp * it.qty;
                        }
                    }

                    var totalSql = $"UPDATE Supply SET totalCost={total} WHERE supplyId={supplyId}";
                    using (var tq = new MySqlCommand(totalSql, connection, tr))
                        tq.ExecuteNonQuery();

                    tr.Commit();
                }
            }
        }
    }
}
