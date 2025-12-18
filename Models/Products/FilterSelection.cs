using System.Collections.Generic;

namespace Course_Project.Models.Products
{
    public class FilterSelection
    {
        public int CategoryId { get; set; }
        public string ProductType { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public bool InStockOnly { get; set; }

        // Key -> value:
        // dropdown: string
        // multiselect: List<string>
        // checkbox: bool
        // text: string
        // rangeint: int?[] {from,to}
        public Dictionary<string, object> Dynamic { get; set; }

        public FilterSelection()
        {
            Dynamic = new Dictionary<string, object>();
        }
    }
}
