using Course_Project.Data.Products; 
using System.Windows.Forms;

namespace Course_Project.Pages
{
    public partial class BestsellersPage : UserControl
    {
        private readonly BestsellersRepository repo = new BestsellersRepository();

        public BestsellersPage()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = true;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //LoadData();
            //dgv.Columns["productId"].Visible = false;
            //dgv.Columns["name"].HeaderText = "Книга";
            //dgv.Columns["price"].HeaderText = "Ціна";
            //dgv.Columns["soldQty"].HeaderText = "Продано (шт)";
            //dgv.Columns["revenue"].HeaderText = "Оборот";

            LoadData();

            if (dgv.Columns.Count == 0) return;

            if (dgv.Columns.Contains("productId"))
                dgv.Columns["productId"].Visible = false;

            if (dgv.Columns.Contains("name"))
                dgv.Columns["name"].HeaderText = "Книга";

            if (dgv.Columns.Contains("price"))
                dgv.Columns["price"].HeaderText = "Ціна";

            if (dgv.Columns.Contains("soldQty"))
                dgv.Columns["soldQty"].HeaderText = "Продано (шт)";

            if (dgv.Columns.Contains("revenue"))
                dgv.Columns["revenue"].HeaderText = "Оборот";


        }

        private void LoadData()
        {
            try
            {
                dgv.DataSource = repo.GetTop25LastWeek();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
