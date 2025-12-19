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
        private int CurrentUserId { get { return Session.UserId; } }
        private bool _uiReady = false;

        public SuppliesPage()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            pnlFilters.Dock = DockStyle.Top;
            pnlContent.Dock = DockStyle.Fill;
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Width = 520;

            dgvSupplies.Dock = DockStyle.Fill;
            dgvItems.Dock = DockStyle.Fill;

            SetupGrids();
            BindEvents();

            LoadSuppliers();
            ResetFilters();

            LockItems(true);

            _uiReady = true;
            LoadSupplies();
        }

        // =========================
        // GRID SETUP
        // =========================
        private void SetupGrids()
        {
            dgvSupplies.ReadOnly = true;
            dgvSupplies.AllowUserToAddRows = false;
            dgvSupplies.MultiSelect = false;
            dgvSupplies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =========================
        // EVENTS
        // =========================
        private void BindEvents()
        {
            dgvSupplies.SelectionChanged += DgvSupplies_SelectionChanged;

            btnCreateSupply.Click += BtnCreateSupply_Click;
            btnAddExisting.Click += BtnAddExisting_Click;
            btnAddBook.Click += BtnAddBook_Click;
            btnApply.Click += BtnApply_Click;
            btnResetFilters.Click += BtnResetFilters_Click;

            tbInvoiceSearch.TextChanged += delegate { if (_uiReady) LoadSupplies(); };
            cbSupplierFilter.SelectedIndexChanged += delegate { if (_uiReady) LoadSupplies(); };

            cbFrom.CheckedChanged += delegate
            {
                dtFrom.Enabled = cbFrom.Checked;
                if (_uiReady) LoadSupplies();
            };

            cbTo.CheckedChanged += delegate
            {
                dtTo.Enabled = cbTo.Checked;
                if (_uiReady) LoadSupplies();
            };

            dtFrom.ValueChanged += delegate
            {
                if (_uiReady && cbFrom.Checked) LoadSupplies();
            };

            dtTo.ValueChanged += delegate
            {
                if (_uiReady && cbTo.Checked) LoadSupplies();
            };
        }

        // =========================
        // LOAD DATA
        // =========================
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
            int? supplierId = cbSupplierFilter.SelectedValue is int
                ? (int?)cbSupplierFilter.SelectedValue
                : null;

            DateTime? from = cbFrom.Checked ? (DateTime?)dtFrom.Value.Date : null;
            DateTime? to = cbTo.Checked
                ? (DateTime?)dtTo.Value.Date.AddDays(1).AddSeconds(-1)
                : null;

            string invoice = tbInvoiceSearch.Text.Trim();

            int? userFilter = Session.IsAdmin ? (int?)null : (int?)Session.UserId;

            dgvSupplies.DataSource =
                suppliesRepo.GetSupplies(invoice, supplierId, from, to, userFilter);

            if (dgvSupplies.Columns.Count == 0) return;

            dgvSupplies.Columns["supplyId"].HeaderText = "№";
            dgvSupplies.Columns["invoiceNumber"].HeaderText = "Накладна";
            dgvSupplies.Columns["supplyDate"].HeaderText = "Дата";
            dgvSupplies.Columns["totalCost"].HeaderText = "Сума, грн";
            dgvSupplies.Columns["supplierName"].HeaderText = "Постачальник";
            dgvSupplies.Columns["userName"].HeaderText = "Користувач";

            dgvSupplies.Columns["supplierId"].Visible = false;
            dgvSupplies.Columns["userId"].Visible = false;
            dgvSupplies.Columns["note"].Visible = false;

            if (!Session.IsAdmin && dgvSupplies.Columns.Contains("userName"))
                dgvSupplies.Columns["userName"].Visible = false;
        }

        private void LoadItems()
        {
            if (currentSupplyId <= 0)
            {
                dgvItems.DataSource = null;
                return;
            }

            dgvItems.DataSource = suppliesRepo.GetItems(currentSupplyId);

            if (dgvItems.Columns.Count == 0) return;

            dgvItems.Columns["itemId"].Visible = false;
            dgvItems.Columns["supplyId"].Visible = false;
            dgvItems.Columns["productId"].Visible = false;

            dgvItems.Columns["productName"].HeaderText = "Товар";
            dgvItems.Columns["quantity"].HeaderText = "Кількість";
            dgvItems.Columns["purchasePrice"].HeaderText = "Закупівельна ціна";
            dgvItems.Columns["salePrice"].HeaderText = "Ціна продажу";
            dgvItems.Columns["currentStock"].HeaderText = "Залишок";
        }

        // =========================
        // SELECTION
        // =========================
        private void DgvSupplies_SelectionChanged(object sender, EventArgs e)
        {
            if (!_uiReady) return;
            if (dgvSupplies.CurrentRow == null) return;

            var s = dgvSupplies.CurrentRow.DataBoundItem as SupplyModel;
            if (s == null) return;

            if (!Session.IsAdmin && s.userId != Session.UserId)
            {
                LockItems(true);
                currentSupplyId = 0;
                dgvItems.DataSource = null;
                return;
            }

            currentSupplyId = s.supplyId;
            LockItems(false);
            LoadItems();
        }

        // =========================
        // HELPERS
        // =========================
        private void LockItems(bool locked)
        {
            dgvItems.Enabled = !locked;
            btnAddExisting.Enabled = !locked;
            btnAddBook.Enabled = !locked;
            btnApply.Enabled = !locked;
        }

        private void ResetFilters()
        {
            tbInvoiceSearch.Clear();
            cbSupplierFilter.SelectedIndex = -1;

            cbFrom.Checked = false;
            cbTo.Checked = false;
            dtFrom.Enabled = false;
            dtTo.Enabled = false;
        }

        private string GenerateInvoiceNumber()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff");
        }

        // =========================
        // BUTTONS
        // =========================
        private void BtnCreateSupply_Click(object sender, EventArgs e)
        {
            if (!(cbSupplier.SelectedValue is int))
            {
                MessageBox.Show("Обери постачальника.");
                return;
            }

            int supplierId = (int)cbSupplier.SelectedValue;

            currentSupplyId = suppliesRepo.CreateSupply(
                supplierId,
                CurrentUserId,
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
            ResetFilters();
            LoadSupplies();
        }
    }
}