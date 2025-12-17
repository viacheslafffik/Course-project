namespace Course_Project.Models.Books
{
    public class Book
    {
        public int productId { get; set; }
        public string isbn { get; set; }
        public int? publisherId { get; set; }
        public int? seriesId { get; set; }
        public int? languageId { get; set; }
        public int? ageMin { get; set; }
        public bool hasIllustrations { get; set; }
        public string shortDescription { get; set; }
        public int? pages { get; set; }
        public int? publishYear { get; set; }
    }
}
