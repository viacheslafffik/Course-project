using Course_Project.Database;
using Course_Project.Models.Supplies;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Course_Project.Data.Supplies
{
    internal class SupplierRepository
    {
        public List<SupplierModel> GetAll()
        {
            var list = new List<SupplierModel>();

            using (var connection = Db.Connection())
            {
                connection.Open();
                var sql = "SELECT supplierId, name, phone, email, address FROM Supplier ORDER BY name";
                using (var query = new MySqlCommand(sql, connection))
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new SupplierModel
                        {
                            supplierId = r.GetInt32("supplierId"),
                            name = r.GetString("name"),
                            phone = r.IsDBNull(r.GetOrdinal("phone")) ? "" : r.GetString("phone"),
                            email = r.IsDBNull(r.GetOrdinal("email")) ? "" : r.GetString("email"),
                            address = r.IsDBNull(r.GetOrdinal("address")) ? "" : r.GetString("address")
                        });
                    }
                }
            }
            return list;
        }

        public int Create(string name, string phone, string email, string address)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();

                phone = string.IsNullOrWhiteSpace(phone) ? "NULL" : $"'{phone}'";
                email = string.IsNullOrWhiteSpace(email) ? "NULL" : $"'{email}'";
                address = string.IsNullOrWhiteSpace(address) ? "NULL" : $"'{address}'";

                var sql = $"INSERT INTO Supplier (name, phone, email, address) " +
                    $"VALUES ('{name}', {phone}, {email}, {address}); " +
                    $"SELECT LAST_INSERT_ID();";
                using (var query = new MySqlCommand(sql, connection)) return System.Convert.ToInt32(query.ExecuteScalar());
            }
        }
    }
}
