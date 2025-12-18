namespace Course_Project.Models.Supplies
{
    internal class SupplierModel
    {
        public int supplierId { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public override string ToString() => name;
    }
}
