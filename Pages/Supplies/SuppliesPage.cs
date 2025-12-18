using Course_Project.Data.Supplies;
using Course_Project.Forms.Additional;
using Course_Project.Forms.Supplies;
using Course_Project.Models.Supplies;
using Course_Project.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Course_Project.Pages.Supplies
{
    public partial class SuppliesPage : UserControl
    {
        private readonly SupplierRepository supplierRepo = new SupplierRepository();
        private readonly SuppliesRepository suppliesRepo = new SuppliesRepository();

        private int currentSupplyId = 0;
        private int currentUserId => Session.UserId;
        private bool _uiReady = false;

        public SuppliesPage()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
            pnlFilters.Dock = DockStyle.Top;
            pnlContent.Dock = DockStyle.Fill;
            dgvSupplies.Dock = DockStyle.Fill;
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Width = 520;

            btnApply.Dock = DockStyle.Top;
            btnAddBook.Dock = DockStyle.Top;
            btnAddExisting.Dock = DockStyle.Top;

            dgvItems.Dock = DockStyle.Fill;

            btnCreateSupply.Click += BtnCreateSupply_Click;
            btnAddExisting.Click += BtnAddExisting_Click;
            btnAddBook.Click += BtnAddBook_Click;
            btnApply.Click += BtnApply_Click;
            btnResetFilters.Click += BtnResetFilters_Click;

            dgvSupplies.SelectionChanged += DgvSupplies_SelectionChanged;

            LoadSuppliers();

            cbFrom.Checked = false;
            cbTo.Checked = false;
            dtFrom.Enabled = false;
            dtTo.Enabled = false;

            tbInvoiceSearch.Clear();
            cbSupplierFilter.SelectedIndex = -1;

            LockItems(true);

            _uiReady = true;
            LoadSupplies();
        }

        private void LockItems(bool locked)
        {
            dgvItems.Enabled = !locked;
            btnAddExisting.Enabled = !locked;
            btnAddBook.Enabled = !locked;
            btnApply.Enabled = !locked;
        }

        private void LoadSuppliers()
        {
            var list = supplierRepo.GetAll();

            cbSupplier.DisplayMember = "name";
            cbSupplier.ValueMember = "supplierId";
            cbSupplier.DataSource = list;

            cbSupplierFilter.DisplayMember = "name";
            cbSupplierFilter.ValueMember = "supplierId";
            cbSupplierFilter.DataSource = new List<SupplierModel>(list);
            cbSupplierFilter.SelectedIndex = -1;
        }

        private void LoadSupplies()
        {
            int? supplierId = cbSupplierFilter.SelectedValue as int?;

            DateTime? from = cbFrom.Checked 
                ? dtFrom.Value.Date 
                : (DateTime?)null;
            DateTime? to = cbTo.Checked 
                ? (DateTime?)dtTo.Value.Date.AddDays(1).AddSeconds(-1) 
                : (DateTime?)null;


            string invoice = tbInvoiceSearch.Text.Trim();

            int? userFilter = Session.IsAdmin 
                ? (int?)null 
                : (int?)Session.UserId;


            dgvSupplies.DataSource =
                suppliesRepo.GetSupplies(invoice, supplierId, from, to, userFilter);

            if (dgvSupplies.Columns.Count == 0) return;

            dgvSupplies.Columns["supplierId"].Visible = false;
            dgvSupplies.Columns["userId"].Visible = false;
            dgvSupplies.Columns["note"].Visible = false;

            if (!Session.IsAdmin)
                dgvSupplies.Columns["userName"].Visible = false;
        }

        private void DgvSupplies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSupplies.CurrentRow?.DataBoundItem is SupplyModel s)
            {
                if (!Session.IsAdmin && s.userId != Session.UserId)
                {
                    LockItems(true);
                    currentSupplyId = 0;
                    return;
                }

                currentSupplyId = s.supplyId;
                LockItems(false);
                LoadItems();
            }
        }

        private void LoadItems()
        {
            if (currentSupplyId <= 0)
            {
                dgvItems.DataSource = null;
                return;
            }

            dgvItems.DataSource = suppliesRepo.GetItems(currentSupplyId);
        }

        private string GenerateInvoiceNumber()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff");
        }

        private void BtnCreateSupply_Click(object sender, EventArgs e)
        {
            if (!(cbSupplier.SelectedValue is int supplierId))
            {
                MessageBox.Show("Обери постачальника.");
                return;
            }

            currentSupplyId = suppliesRepo.CreateSupply(
                supplierId,
                currentUserId,
                GenerateInvoiceNumber(),
                DateTime.Now,
                ""
            );

            LockItems(false);
            LoadSupplies();
            LoadItems();
        }

        private void BtnAddExisting_Click(object sender, EventArgs e)
        {
            if (currentSupplyId <= 0) return;

            using (var f = new AddProductForm())
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                if (f.CreatedProductId <= 0) return;

                suppliesRepo.AddItem(currentSupplyId, f.CreatedProductId, 1, 0);
                LoadItems();
            }
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            if (currentSupplyId <= 0) return;

            using (var f = new SupplyBookForm())
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                if (f.CreatedProductId <= 0) return;

                suppliesRepo.AddItem(currentSupplyId, f.CreatedProductId, 1, 0);
                LoadItems();
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (currentSupplyId <= 0) return;

            suppliesRepo.ApplySupplyToStock(currentSupplyId);
            MessageBox.Show("Поставка застосована.");

            LoadSupplies();
            LoadItems();
        }

        private void BtnResetFilters_Click(object sender, EventArgs e)
        {
            tbInvoiceSearch.Clear();
            cbSupplierFilter.SelectedIndex = -1;
            cbFrom.Checked = false;
            cbTo.Checked = false;
            dtFrom.Enabled = false;
            dtTo.Enabled = false;

            LoadSupplies();
        }
    }
}
