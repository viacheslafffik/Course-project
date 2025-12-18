using Course_Project.Database;
using Course_Project.Models.Products;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Course_Project.Data.Products
{
    public class FiltersRepository
    {
        public List<FilterDefinition> GetFiltersForCategory(int categoryId, string productType)
        {
            var result = new List<FilterDefinition>
            {
                new FilterDefinition { Key = "price", Title = "Ціна", Type = FilterType.RangeDecimal, Options = null, IsBookOnly = false },
                new FilterDefinition { Key = "inStock", Title = "В наявності", Type = FilterType.Checkbox, Options = null, IsBookOnly = false }
            };

            var attrs = GetCategoryAttributes(categoryId);
            for (int i = 0; i < attrs.Count; i++)
            {
                var opts = GetDistinctAttributeValues(attrs[i].Item1, 50);
                var def = new FilterDefinition
                {
                    Key = "attr_" + attrs[i].Item1,
                    Title = attrs[i].Item2,
                    IsBookOnly = false
                };
                if (opts != null && opts.Length > 0)
                {
                    def.Type = FilterType.MultiSelect;
                    def.Options = opts;
                }
                else
                {
                    def.Type = FilterType.Text;
                    def.Options = null;
                }
                result.Add(def);
            }

            if (productType == "book")
            {
                result.Add(new FilterDefinition { Key = "book_author", Title = "Автор", Type = FilterType.MultiSelect, Options = GetAuthors(80), IsBookOnly = true });
                result.Add(new FilterDefinition { Key = "book_publisher", Title = "Видавництво", Type = FilterType.MultiSelect, Options = GetPublishers(80), IsBookOnly = true });
                result.Add(new FilterDefinition { Key = "book_series", Title = "Серія", Type = FilterType.MultiSelect, Options = GetSeries(80), IsBookOnly = true });
                result.Add(new FilterDefinition { Key = "book_language", Title = "Мова", Type = FilterType.MultiSelect, Options = GetLanguages(40), IsBookOnly = true });

                result.Add(new FilterDefinition { Key = "book_age", Title = "Вік (мін.)", Type = FilterType.RangeInt, Options = null, IsBookOnly = true });
                result.Add(new FilterDefinition { Key = "book_illustr", Title = "Ілюстрації", Type = FilterType.Checkbox, Options = null, IsBookOnly = true });
                result.Add(new FilterDefinition { Key = "book_year", Title = "Рік видання", Type = FilterType.RangeInt, Options = null, IsBookOnly = true });
                result.Add(new FilterDefinition { Key = "book_pages", Title = "Сторінок", Type = FilterType.RangeInt, Options = null, IsBookOnly = true });
            }

            return result;
        }

        private List<System.Tuple<int, string>> GetCategoryAttributes(int categoryId)
        {
            var list = new List<System.Tuple<int, string>>();
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand("SELECT attributeId, name FROM CategoryAttribute WHERE categoryId=@cid ORDER BY name", connection))
                {
                    query.Parameters.AddWithValue("@cid", categoryId);
                    using (var r = query.ExecuteReader())
                    {
                        while (r.Read()) list.Add(new System.Tuple<int, string>(r.GetInt32("attributeId"), 
                            r.GetString("name")));               
                    }
                }
            }
            return list;
        }

        private string[] GetDistinctAttributeValues(int attributeId, int limit)
        {
            var list = new List<string>();
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand(
                    "SELECT DISTINCT value FROM ProductAttributeValue " +
                    $"WHERE attributeId={attributeId} ORDER BY value LIMIT " + limit, connection))
                {
                    using (var r = query.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var v = r.GetString("value");
                            if (!string.IsNullOrWhiteSpace(v)) list.Add(v);
                        }
                    }
                }
            }
            return list.ToArray();
        }

        private string[] GetAuthors(int limit)
        {
            return SimpleLookup("SELECT fullName AS n FROM Author ORDER BY fullName LIMIT " + limit);
        }
        private string[] GetPublishers(int limit)
        {
            return SimpleLookup("SELECT name AS n FROM Publisher ORDER BY name LIMIT " + limit);
        }
        private string[] GetSeries(int limit)
        {
            return SimpleLookup("SELECT name AS n FROM Series ORDER BY name LIMIT " + limit);
        }
        private string[] GetLanguages(int limit)
        {
            return SimpleLookup("SELECT name AS n FROM Language ORDER BY name LIMIT " + limit);
        }

        private string[] SimpleLookup(string sql)
        {
            var list = new List<string>();
            using (var connection = Db.Connection())
            {
                connection.Open();
                using (var query = new MySqlCommand(sql, connection))
                using (var r = query.ExecuteReader()) while (r.Read()) list.Add(r.GetString("n"));                                
            }
            return list.ToArray();
        }
    }
}
