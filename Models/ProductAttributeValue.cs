using Course_Project.Database;
using MySql.Data.MySqlClient;

namespace Course_Project.Models
{
    internal class ProductAttributeValue
    {
        public static void Add(int productId, int attributeId, string value)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                var query = new MySqlCommand(
                    "insert into ProductAttributeValue (productId, attributeId, value) " +
                    $"values ({productId}, {attributeId}, {value})",
                    connection);
                query.ExecuteNonQuery();
            }
        }
    }
}
