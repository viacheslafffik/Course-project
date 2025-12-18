using Course_Project.Models.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Course_Project.Pages.Products
{
    public partial class FiltersPanel : UserControl
    {
        public event EventHandler ApplyClicked;
        public event EventHandler ResetClicked;

        private Dictionary<string, Control> ctrlByKey = new Dictionary<string, Control>();
        private Dictionary<string, FilterDefinition> defByKey = new Dictionary<string, FilterDefinition>();

        public FiltersPanel()
        {
            InitializeComponent();

            //flpDynamic.SizeChanged += FlpDynamic_SizeChanged;
        }

        //private void FlpDynamic_SizeChanged(object sender, EventArgs e)
        //{
        //    foreach (Control c in flpDynamic.Controls)
        //    {
        //        c.Width = flpDynamic.ClientSize.Width - 20;
        //    }
        //}


        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (ApplyClicked != null) ApplyClicked(this, EventArgs.Empty);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            tbPriceFrom.Clear();
            tbPriceTo.Clear();
            cbInStock.Checked = false;

            foreach (var kv in ctrlByKey)
            {
                var c = kv.Value;
                if (c is TextBox) ((TextBox)c).Clear();
                else if (c is CheckBox) ((CheckBox)c).Checked = false;
                else if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;
                else if (c is ListBox) ((ListBox)c).ClearSelected();
                else if (c is Panel)
                {
                    var p = (Panel)c;
                    for (int i = 0; i < p.Controls.Count; i++)
                    {
                        if (p.Controls[i] is TextBox) ((TextBox)p.Controls[i]).Clear();
                    }
                }
            }

            if (ResetClicked != null) ResetClicked(this, EventArgs.Empty);
        }

        public void BuildDynamicFilters(List<FilterDefinition> defs)
        {
            flpDynamic.Controls.Clear();
            ctrlByKey.Clear();
            defByKey.Clear();

            for (int i = 0; i < defs.Count; i++)
            {
                var d = defs[i];
                defByKey[d.Key] = d;

                var gb = new GroupBox();
                gb.Text = d.Title;
                gb.AutoSize = true;
                //gb.Width = Width - 35;
                gb.MaximumSize = new Size(300, 0);
                gb.Padding = new Padding(10);

                Control input = CreateControl(d, 260);
                input.Left = 10;
                input.Top = 20;

                gb.Controls.Add(input);
                flpDynamic.Controls.Add(gb);

                ctrlByKey[d.Key] = input;
            }
        }

        private Control CreateControl(FilterDefinition d, int width)
        {
            if (d.Type == FilterType.Text)
            {
                var tb = new TextBox();
                tb.Width = Math.Min(width, 260);
                return tb;
            }

            if (d.Type == FilterType.Checkbox)
            {
                var cb = new CheckBox();
                cb.Text = "Так";
                cb.AutoSize = true;
                cb.Font = new Font("Segoe UI", 10.5f);
                cb.MaximumSize = new Size(280, 0);
                return cb;
            }

            if (d.Type == FilterType.Dropdown)
            {
                var combo = new ComboBox();
                combo.Width = width;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                if (d.Options != null) combo.Items.AddRange(d.Options);
                combo.Width = Math.Min(width, 260);
                return combo;
            }

            if (d.Type == FilterType.MultiSelect)
            {
                var lb = new ListBox();
                lb.Width = Math.Min(width, 260);
                lb.Height = 90;
                lb.SelectionMode = SelectionMode.MultiExtended;
                if (d.Options != null) lb.Items.AddRange(d.Options);
                return lb;
            }

            if (d.Type == FilterType.RangeInt || d.Type == FilterType.RangeDecimal)
            {
                var p = new Panel();
                p.Width = Math.Min(width, 260);
                p.Height = 26;

                var from = new TextBox();
                from.Width = 75;
                from.Left = 0;

                var to = new TextBox();
                to.Width = 75;
                to.Left = 95;

                p.Controls.Add(from);
                p.Controls.Add(to);
                return p;
            }

            return new TextBox { Width = width };
        }

        public FilterSelection CollectSelection(int categoryId, string productType, string search, string sort)
        {
            var sel = new FilterSelection();
            sel.CategoryId = categoryId;
            sel.ProductType = productType;
            sel.Search = search;
            sel.Sort = sort;

            decimal pf, pt;
            if (decimal.TryParse(tbPriceFrom.Text.Trim(), out pf)) sel.PriceFrom = pf;
            if (decimal.TryParse(tbPriceTo.Text.Trim(), out pt)) sel.PriceTo = pt;
            sel.InStockOnly = cbInStock.Checked;

            foreach (var kv in ctrlByKey)
            {
                string key = kv.Key;
                Control c = kv.Value;

                if (c is TextBox)
                {
                    var v = ((TextBox)c).Text.Trim();
                    if (v.Length > 0) sel.Dynamic[key] = v;
                }
                else if (c is CheckBox)
                {
                    bool v = ((CheckBox)c).Checked;
                    if (v) sel.Dynamic[key] = true;
                }
                else if (c is ComboBox)
                {
                    var combo = (ComboBox)c;
                    if (combo.SelectedItem != null) sel.Dynamic[key] = combo.SelectedItem.ToString();
                }
                else if (c is ListBox)
                {
                    var lb = (ListBox)c;
                    if (lb.SelectedItems != null && lb.SelectedItems.Count > 0)
                    {
                        var list = new List<string>();
                        for (int i = 0; i < lb.SelectedItems.Count; i++)
                            list.Add(lb.SelectedItems[i].ToString());
                        sel.Dynamic[key] = list;
                    }
                }
                else if (c is Panel)
                {
                    var p = (Panel)c;
                    if (p.Controls.Count >= 2 && p.Controls[0] is TextBox && p.Controls[1] is TextBox)
                    {
                        var a = ((TextBox)p.Controls[0]).Text.Trim();
                        var b = ((TextBox)p.Controls[1]).Text.Trim();

                        // для int range
                        if (defByKey.ContainsKey(key) && defByKey[key].Type == FilterType.RangeInt)
                        {
                            int x = 0, y = 0;
                            if (a.Length > 0) int.TryParse(a, out x);
                            if (b.Length > 0) int.TryParse(b, out y);
                            if (x > 0 || y > 0) sel.Dynamic[key] = new int[] { x, y };
                        }
                    }
                }
            }

            return sel;
        }
    }
}
