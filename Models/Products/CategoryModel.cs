namespace Course_Project.Models.Products
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public override string ToString() { return Name; }
    }
}
