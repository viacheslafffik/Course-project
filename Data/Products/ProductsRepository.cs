using Course_Project.Database;
using Course_Project.Models.Products;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_Project.Data.Products
{
    public class ProductsRepository
    {
        public List<ProductListItem> Search(FilterSelection sel, int limit, int offset)
        {
            var list = new List<ProductListItem>();

            using (var connection = Db.Connection())
            {
                connection.Open();

                var sb = new StringBuilder();
                sb.Append(@" SELECT 
                             p.productId,
                             p.name,
                             p.price,
                             p.quantity,
                             p.categoryId,
                             c.name AS categoryName,
                             c.productType ");
                if (sel.ProductType == "book")
                {
                    sb.Append(@", l.name AS langName,
                                  pub.name AS pubName,
                                  s.name AS seriesName,
                                  b.ageMin,
                                  b.hasIllustrations,
                                  b.pages,
                                  b.publishYear,
                                  (
                                  SELECT GROUP_CONCAT(a.fullName SEPARATOR ', ')
                                  FROM BookAuthor ba
                                  JOIN Author a ON a.authorId = ba.authorId
                                  WHERE ba.productId = p.productId
                                  ) AS authors ");
                }

                sb.Append(@" FROM Product p JOIN Category c ON c.categoryId = p.categoryId ");

                if (sel.ProductType == "book")
                {
                    sb.Append(@" LEFT JOIN Book b ON b.productId = p.productId
                                 LEFT JOIN Language l ON l.languageId = b.languageId
                                 LEFT JOIN Publisher pub ON pub.publisherId = b.publisherId
                                 LEFT JOIN Series s ON s.seriesId = b.seriesId ");
                }
                sb.Append("WHERE p.categoryId = @catId ");
                if (!string.IsNullOrWhiteSpace(sel.Search)) sb.Append("AND p.name LIKE @search ");
                if (sel.InStockOnly) sb.Append("AND p.quantity > 0 ");
                if (sel.PriceFrom.HasValue) sb.Append("AND p.price >= @priceFrom ");
                if (sel.PriceTo.HasValue) sb.Append("AND p.price <= @priceTo ");
                if (sel.ProductType == "book")
                {
                    if (HasBool(sel.Dynamic, "book_illustr", true)) sb.Append("AND b.hasIllustrations = 1 ");
                    AppendRangeInt(sb, sel.Dynamic, "book_age", "b.ageMin");
                    AppendRangeInt(sb, sel.Dynamic, "book_year", "b.publishYear");
                    AppendRangeInt(sb, sel.Dynamic, "book_pages", "b.pages");
                    AppendMultiSelect(sb, sel.Dynamic, "book_language", "l.name", "@bl");
                    AppendMultiSelect(sb, sel.Dynamic, "book_series", "s.name", "@bs");
                    AppendMultiSelect(sb, sel.Dynamic, "book_publisher", "pub.name", "@bp");
                    AppendAuthorMultiSelect(sb, sel.Dynamic, "@ba");
                }

                AppendAttributeFilters(sb, sel.Dynamic);

                sb.Append("ORDER BY ");

                if (sel.Sort == "price_asc") sb.Append("p.price ASC ");
                else if (sel.Sort == "price_desc") sb.Append("p.price DESC ");
                else if (sel.Sort == "name_desc") sb.Append("p.name DESC ");
                else sb.Append("p.name ASC ");

                sb.Append("LIMIT @limit OFFSET @offset");

                using (var query = new MySqlCommand(sb.ToString(), connection))
                {
                    query.Parameters.Add("@catId", MySqlDbType.Int32).Value = sel.CategoryId;
                    query.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;
                    query.Parameters.Add("@offset", MySqlDbType.Int32).Value = offset;

                    if (!string.IsNullOrWhiteSpace(sel.Search))
                        query.Parameters.Add("@search", MySqlDbType.VarChar).Value = "%" + sel.Search.Trim() + "%";

                    if (sel.PriceFrom.HasValue)
                        query.Parameters.Add("@priceFrom", MySqlDbType.Decimal).Value = sel.PriceFrom.Value;

                    if (sel.PriceTo.HasValue)
                        query.Parameters.Add("@priceTo", MySqlDbType.Decimal).Value = sel.PriceTo.Value;

                    AddMultiSelectParams(query, sel.Dynamic, "book_language", "@bl");
                    AddMultiSelectParams(query, sel.Dynamic, "book_series", "@bs");
                    AddMultiSelectParams(query, sel.Dynamic, "book_publisher", "@bp");
                    AddAuthorParams(query, sel.Dynamic, "@ba");
                    AddAttributeParams(query, sel.Dynamic);
                    AddRangeParams(query, sel.Dynamic);

                    using (var r = query.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var p = new ProductListItem
                            {
                                ProductId = Convert.ToInt32(r["productId"]),
                                Name = r["name"].ToString(),
                                Price = Convert.ToDecimal(r["price"]),
                                Quantity = Convert.ToInt32(r["quantity"]),
                                CategoryId = Convert.ToInt32(r["categoryId"]),
                                CategoryName = r["categoryName"].ToString(),
                                ProductType = r["productType"].ToString()
                            };

                            if (p.ProductType == "book")
                            {
                                p.Language = r["langName"] as string;
                                p.Publisher = r["pubName"] as string;
                                p.Series = r["seriesName"] as string;
                                p.Authors = r["authors"] as string;
                                p.AgeMin = r["ageMin"] as int?;
                                p.Pages = r["pages"] as int?;
                                p.PublishYear = r["publishYear"] as int?;
                                p.HasIllustrations = r["hasIllustrations"] != DBNull.Value && 
                                    Convert.ToInt32(r["hasIllustrations"]) == 1;
                            }

                            list.Add(p);
                        }
                    }
                }
                LoadAttributeMap(connection, list);
            }
            return list;
        }

        private void LoadAttributeMap(MySqlConnection connection, List<ProductListItem> items)
        {
            if (items.Count == 0) return;
            var sb = new StringBuilder();
            sb.Append(@"  SELECT pav.productId, ca.name, pav.value
                          FROM ProductAttributeValue pav
                          JOIN CategoryAttribute ca ON ca.attributeId = pav.attributeId
                          WHERE pav.productId IN (");

            for (int i = 0; i < items.Count; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append("@p" + i);
            }
            sb.Append(")");

            using (var query = new MySqlCommand(sb.ToString(), connection))
            {
                for (int i = 0; i < items.Count; i++) query.Parameters.Add("@p" + i, MySqlDbType.Int32).Value = items[i].ProductId;
                var map = new Dictionary<int, ProductListItem>();
                foreach (var it in items) map[it.ProductId] = it;
                using (var r = query.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int pid = Convert.ToInt32(r["productId"]);
                        string name = r["name"].ToString();
                        string value = r["value"].ToString();
                        if (map.TryGetValue(pid, out var item)) item.Attributes[name] = value;
                    }
                }
            }
        }

        private bool HasBool(Dictionary<string, object> d, string key, bool expected)
        {
            return d.ContainsKey(key) && d[key] is bool b && b == expected;
        }

        private void AppendRangeInt(StringBuilder sb, Dictionary<string, object> d, string key, string column)
        {
            if (!d.ContainsKey(key)) return;
            if (!(d[key] is int[] arr) || arr.Length != 2) return;
            if (arr[0] > 0) sb.Append($"AND {column} >= @{key}From ");
            if (arr[1] > 0) sb.Append($"AND {column} <= @{key}To ");
        }

        private void AppendMultiSelect(StringBuilder sb, Dictionary<string, object> d, string key, string column, string prefix)
        {
            if (!d.ContainsKey(key)) return;
            if (!(d[key] is List<string> list) || list.Count == 0) return;

            sb.Append($"AND {column} IN (");
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append(prefix + i);
            }
            sb.Append(") ");
        }

        private void AppendAuthorMultiSelect(StringBuilder sb, Dictionary<string, object> d, string prefix)
        {
            if (!d.ContainsKey("book_author")) return;
            if (!(d["book_author"] is List<string> list) || list.Count == 0) return;

            sb.Append(@" AND EXISTS ( SELECT 1
                         FROM BookAuthor ba
                         JOIN Author a ON a.authorId = ba.authorId
                         WHERE ba.productId = p.productId
                         AND a.fullName IN (");
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append(prefix + i);
            }

            sb.Append(")) ");
        }

        private void AppendAttributeFilters(StringBuilder sb, Dictionary<string, object> d)
        {
            foreach (var kv in d)
            {
                if (!kv.Key.StartsWith("attr_")) continue;
                if (!(kv.Value is List<string> list) || list.Count == 0) continue;
                if (!int.TryParse(kv.Key.Substring(5), out int aid)) continue;

                sb.Append(@" AND EXISTS ( SELECT 1 FROM ProductAttributeValue pav ю
                             WHERE pav.productId = p.productId
                             AND pav.attributeId = " + aid + " AND pav.value IN (");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0) sb.Append(",");
                    sb.Append("@a" + aid + "_" + i);
                }
                sb.Append(")) ");
            }
        }

        private void AddMultiSelectParams(MySqlCommand query, Dictionary<string, object> d, string key, string prefix)
        {
            if (!d.ContainsKey(key)) return;
            if (!(d[key] is List<string> list)) return;
            for (int i = 0; i < list.Count; i++) query.Parameters.Add(prefix + i, MySqlDbType.VarChar).Value = list[i];
        }

        private void AddAuthorParams(MySqlCommand query, Dictionary<string, object> d, string prefix)
        {
            if (!d.ContainsKey("book_author")) return;
            if (!(d["book_author"] is List<string> list)) return;
            for (int i = 0; i < list.Count; i++) query.Parameters.Add(prefix + i, MySqlDbType.VarChar).Value = list[i];
        }

        private void AddAttributeParams(MySqlCommand query, Dictionary<string, object> d)
        {
            foreach (var kv in d)
            {
                if (!kv.Key.StartsWith("attr_")) continue;
                if (!(kv.Value is List<string> list)) continue;
                if (!int.TryParse(kv.Key.Substring(5), out int aid)) continue;
                for (int i = 0; i < list.Count; i++) query.Parameters.Add("@a" + aid + "_" + i, MySqlDbType.VarChar).Value = list[i];
            }
        }

        private void AddRangeParams(MySqlCommand query, Dictionary<string, object> d)
        {
            AddRange(query, d, "book_age");
            AddRange(query, d, "book_year");
            AddRange(query, d, "book_pages");
        }

        private void AddRange(MySqlCommand query, Dictionary<string, object> d, string key)
        {
            if (!d.ContainsKey(key)) return;
            if (!(d[key] is int[] arr) || arr.Length != 2) return;
            if (arr[0] > 0) query.Parameters.Add("@" + key + "From", MySqlDbType.Int32).Value = arr[0];
            if (arr[1] > 0) query.Parameters.Add("@" + key + "To", MySqlDbType.Int32).Value = arr[1];
        }
    }
}
