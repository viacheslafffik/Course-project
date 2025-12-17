using System.Collections.Generic;

namespace Course_Project.Models.Books
{
    public class BookFilter
    {
        public int? categoryId { get; set; }
        public decimal? priceFrom { get; set; }
        public decimal? priceTo { get; set; }
        public bool? inStock { get; set; }

        public int? languageId { get; set; }
        public int? publisherId { get; set; }
        public int? seriesId { get; set; }
        public int? ageMin { get; set; }
        public bool? hasIllustrations { get; set; }

        public List<int> authorIds { get; set; } = new List<int>();
        public Dictionary<int, string> categoryAttributes { get; set; } = new Dictionary<int, string>();

    }
}
