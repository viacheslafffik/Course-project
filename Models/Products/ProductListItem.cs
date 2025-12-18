using System.Collections.Generic;

namespace Course_Project.Models.Products
{
    public class ProductListItem
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductType { get; set; } // "generic"/"book"
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // для відображення в картці (динамічно)
        public Dictionary<string, string> Attributes { get; set; }

        // книжкові поля (для відображення, якщо треба)
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string Series { get; set; }
        public string Authors { get; set; }
        public int? AgeMin { get; set; }
        public bool? HasIllustrations { get; set; }
        public int? Pages { get; set; }
        public int? PublishYear { get; set; }

        public ProductListItem()
        {
            Attributes = new Dictionary<string, string>();
        }
    }
}
