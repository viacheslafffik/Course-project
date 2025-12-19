using Course_Project.Data.Supplies;
using Course_Project.Models.Supplies;
using System;
using System.Windows.Forms;

namespace Course_Project.Forms.Supplies
{
    public partial class SupplyItemsForm : Form
    {
        private readonly SuppliesRepository repo = new SuppliesRepository();
        private readonly int supplyId;

        public SupplyItemsForm(int supplyId)
        {
            InitializeComponent();
            this.supplyId = supplyId;

            Text = "Склад накладної №" + supplyId;
            LoadItems();
        }

        private void LoadItems()
        {
            dgvItems.DataSource = repo.GetItems(supplyId);

            if (dgvItems.Columns.Count == 0) return;

            dgvItems.Columns["itemId"].Visible = false;
            dgvItems.Columns["supplyId"].Visible = false;
            dgvItems.Columns["productId"].Visible = false;

            dgvItems.Columns["productName"].HeaderText = "Товар";
            dgvItems.Columns["quantity"].HeaderText = "Кількість";
            dgvItems.Columns["purchasePrice"].HeaderText = "Закупівельна ціна";
            dgvItems.Columns["salePrice"].HeaderText = "Ціна продажу";
            dgvItems.Columns["currentStock"].HeaderText = "Залишок";

            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            decimal total = 0;
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                if (r.Cells["purchasePrice"].Value == null) continue;
                total +=
                    Convert.ToDecimal(r.Cells["purchasePrice"].Value) *
                    Convert.ToInt32(r.Cells["quantity"].Value);
            }

            lblTotal.Text = "Загальна сума: " + total.ToString("0.00") + " грн";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
