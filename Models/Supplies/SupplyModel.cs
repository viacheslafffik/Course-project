using System;

namespace Course_Project.Models.Supplies
{
    internal class SupplyModel
    {
        public int supplyId { get; set; }
        public int supplierId { get; set; }
        public int userId { get; set; }
        public string invoiceNumber { get; set; }
        public DateTime supplyDate { get; set; }
        public string note { get; set; }
        public decimal totalCost { get; set; }

        public string supplierName { get; set; }
        public string userName { get; set; }
    }
}
