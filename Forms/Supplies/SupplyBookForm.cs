using Course_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Course_Project.Forms.Supplies
{
    public partial class SupplyBookForm : Form
    {
        public int CreatedProductId { get; private set; } = 0;

        public SupplyBookForm()
        {
            InitializeComponent();
            LoadLookups();
        }

        private void LoadLookups()
        {
            cbLanguage.Items.Clear();
            cbPublisher.Items.Clear();
            cbSeries.Items.Clear();

            using (var conn = Db.Connection())
            {
                conn.Open();
                FillCombo(conn, cbLanguage, "SELECT languageId, name FROM Language ORDER BY name", "languageId", "name");
                FillCombo(conn, cbPublisher, "SELECT publisherId, name FROM Publisher ORDER BY name", "publisherId", "name");
                FillCombo(conn, cbSeries, "SELECT seriesId, name FROM Series ORDER BY name", "seriesId", "name");
            }
        }

        private void FillCombo(MySqlConnection conn, ComboBox cb, string sql, string idField, string textField)
        {
            using (var cmd = new MySqlCommand(sql, conn))
            using (var r = cmd.ExecuteReader())
            {
                var items = new List<ComboItem>();
                while (r.Read())
                    items.Add(new ComboItem(r.GetInt32(idField), r.GetString(textField)));

                cb.DisplayMember = "Text";
                cb.ValueMember = "Id";
                cb.DataSource = items;
            }
        }

        private int GetBookCategoryId(MySqlConnection conn, MySqlTransaction tr)
        {
            using (var cmd = new MySqlCommand(
                "SELECT categoryId FROM Category WHERE productType='book' LIMIT 1",
                conn, tr))
            {
                var id = cmd.ExecuteScalar();
                if (id == null || id == DBNull.Value)
                    throw new Exception("Не знайдена книжкова категорія (productType='book').");

                return Convert.ToInt32(id);
            }
        }

        private int GetOrCreateSimple(MySqlConnection conn, MySqlTransaction tr, string table, string col, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;

            var sel = $"SELECT {table.ToLower()}Id FROM {table} WHERE {col}=@v LIMIT 1";
            using (var s = new MySqlCommand(sel, conn, tr))
            {
                s.Parameters.AddWithValue("@v", value.Trim());
                var ex = s.ExecuteScalar();
                if (ex != null && ex != DBNull.Value) return Convert.ToInt32(ex);
            }

            var ins = $"INSERT INTO {table} ({col}) VALUES (@v); SELECT LAST_INSERT_ID();";
            using (var i = new MySqlCommand(ins, conn, tr))
            {
                i.Parameters.AddWithValue("@v", value.Trim());
                return Convert.ToInt32(i.ExecuteScalar());
            }
        }

        private int GetOrCreateAuthor(MySqlConnection conn, MySqlTransaction tr, string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return 0;

            var sel = "SELECT authorId FROM Author WHERE fullName=@n LIMIT 1";
            using (var s = new MySqlCommand(sel, conn, tr))
            {
                s.Parameters.AddWithValue("@n", fullName.Trim());
                var ex = s.ExecuteScalar();
                if (ex != null && ex != DBNull.Value) return Convert.ToInt32(ex);
            }

            var ins = "INSERT INTO Author (fullName) VALUES (@n); SELECT LAST_INSERT_ID();";
            using (var i = new MySqlCommand(ins, conn, tr))
            {
                i.Parameters.AddWithValue("@n", fullName.Trim());
                return Convert.ToInt32(i.ExecuteScalar());
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbSalePrice.Text) ||
                string.IsNullOrWhiteSpace(tbQty.Text))
            {
                MessageBox.Show("Заповни назву, ціну продажу і кількість.");
                return;
            }

            if (!decimal.TryParse(
                tbSalePrice.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out var salePrice))
            {
                MessageBox.Show("Ціна продажу некоректна.");
                return;
            }

            if (!int.TryParse(tbQty.Text, out var qty) || qty <= 0)
            {
                MessageBox.Show("Кількість некоректна.");
                return;
            }

            int publisherId = cbPublisher.SelectedValue is int ? (int)cbPublisher.SelectedValue : 0;
            int seriesId = cbSeries.SelectedValue is int ? (int)cbSeries.SelectedValue : 0;
            int languageId = cbLanguage.SelectedValue is int ? (int)cbLanguage.SelectedValue : 0;

            using (var conn = Db.Connection())
            {
                conn.Open();
                using (var tr = conn.BeginTransaction())
                {
                    if (!string.IsNullOrWhiteSpace(tbPublisherNew.Text))
                        publisherId = GetOrCreateSimple(conn, tr, "Publisher", "name", tbPublisherNew.Text);

                    if (!string.IsNullOrWhiteSpace(tbSeriesNew.Text))
                        seriesId = GetOrCreateSimple(conn, tr, "Series", "name", tbSeriesNew.Text);

                    if (!string.IsNullOrWhiteSpace(tbLanguageNew.Text))
                        languageId = GetOrCreateSimple(conn, tr, "Language", "name", tbLanguageNew.Text);

                    int categoryId = GetBookCategoryId(conn, tr);

                    int productId;
                    var insProd =
                        @"INSERT INTO Product (name, price, quantity, categoryId, brandId)
                          VALUES (@n, @p, 0, @cid, NULL);
                          SELECT LAST_INSERT_ID();";

                    using (var p = new MySqlCommand(insProd, conn, tr))
                    {
                        p.Parameters.AddWithValue("@n", tbName.Text.Trim());
                        p.Parameters.AddWithValue("@p", salePrice);
                        p.Parameters.AddWithValue("@cid", categoryId);
                        productId = Convert.ToInt32(p.ExecuteScalar());
                    }

                    var insBook =
                        @"INSERT INTO Book
                          (productId, isbn, publisherId, seriesId, languageId, ageMin,
                           hasIllustrations, shortDescription, pages, publishYear)
                          VALUES
                          (@pid, @isbn, @pub, @ser, @lang, @age, @ill, @desc, @pages, @year)";

                    using (var b = new MySqlCommand(insBook, conn, tr))
                    {
                        b.Parameters.AddWithValue("@pid", productId);
                        b.Parameters.AddWithValue("@isbn", string.IsNullOrWhiteSpace(tbIsbn.Text) ? (object)DBNull.Value : tbIsbn.Text.Trim());
                        b.Parameters.AddWithValue("@pub", publisherId == 0 ? (object)DBNull.Value : publisherId);
                        b.Parameters.AddWithValue("@ser", seriesId == 0 ? (object)DBNull.Value : seriesId);
                        b.Parameters.AddWithValue("@lang", languageId == 0 ? (object)DBNull.Value : languageId);
                        b.Parameters.AddWithValue("@age", int.TryParse(tbAgeMin.Text, out var a) ? a : (object)DBNull.Value);
                        b.Parameters.AddWithValue("@ill", cbIllustrations.Checked ? 1 : 0);
                        b.Parameters.AddWithValue("@desc", string.IsNullOrWhiteSpace(tbDesc.Text) ? (object)DBNull.Value : tbDesc.Text.Trim());
                        b.Parameters.AddWithValue("@pages", int.TryParse(tbPages.Text, out var pgs) ? pgs : (object)DBNull.Value);
                        b.Parameters.AddWithValue("@year", int.TryParse(tbYear.Text, out var y) ? y : (object)DBNull.Value);
                        b.ExecuteNonQuery();
                    }

                    var authors = tbAuthors.Text
                        .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .Distinct();

                    foreach (var a in authors)
                    {
                        int authorId = GetOrCreateAuthor(conn, tr, a);
                        if (authorId == 0) continue;

                        using (var l = new MySqlCommand(
                            "INSERT IGNORE INTO BookAuthor (productId, authorId) VALUES (@p, @a)",
                            conn, tr))
                        {
                            l.Parameters.AddWithValue("@p", productId);
                            l.Parameters.AddWithValue("@a", authorId);
                            l.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();
                    CreatedProductId = productId;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private class ComboItem
        {
            public int Id { get; }
            public string Text { get; }
            public ComboItem(int id, string text) { Id = id; Text = text; }
            public override string ToString() => Text;
        }
    }
}