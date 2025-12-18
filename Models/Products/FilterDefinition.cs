namespace Course_Project.Models.Products
{
    public class FilterDefinition
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public FilterType Type { get; set; }
        public string[] Options { get; set; }
        public bool IsBookOnly { get; set; }
    }
}
