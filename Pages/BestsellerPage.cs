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

            LoadData();
            dgv.Columns["productId"].Visible = false;
            dgv.Columns["name"].HeaderText = "Книга";
            dgv.Columns["price"].HeaderText = "Ціна";
            dgv.Columns["soldQty"].HeaderText = "Продано (шт)";
            dgv.Columns["revenue"].HeaderText = "Оборот";

        }

        private void LoadData()
        {
            dgv.DataSource = repo.GetTop25LastWeek();
        }
    }
}
