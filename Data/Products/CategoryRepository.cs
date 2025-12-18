using Course_Project.Database;
using Course_Project.Models.Products;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Course_Project.Data.Products
{
    public class CategoryRepository
    {
        public List<CategoryModel> GetAll()
        {
            var list = new List<CategoryModel>();
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand("SELECT categoryId, name, productType FROM Category " +
                    "ORDER BY name", connection))
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var c = new CategoryModel
                        {
                            CategoryId = r.GetInt32("categoryId"),
                            Name = r.GetString("name"),
                            ProductType = r.GetString("productType")
                        };
                        list.Add(c);
                    }
                }
            }
            return list;
        }

        public CategoryModel GetById(int categoryId)
        {
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand("SELECT categoryId, name, productType FROM Category " +
                    $"WHERE categoryId={categoryId}", connection))
                {
                    using (var r = query.ExecuteReader())
                    {
                        if (!r.Read()) return null;
                        var c = new CategoryModel
                        {
                            CategoryId = r.GetInt32("categoryId"),
                            Name = r.GetString("name"),
                            ProductType = r.GetString("productType")
                        };
                        return c;
                    }
                }
            }
        }
    }
}
