namespace Course_Project.Models.Supplies
{
    internal class SupplyItemModel
    {
        public int itemId { get; set; }
        public int supplyId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal purchasePrice { get; set; }

        public string productName { get; set; }
        public decimal salePrice { get; set; }
        public int currentStock { get; set; }
    }
}
