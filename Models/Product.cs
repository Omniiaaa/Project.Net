namespace Project.Net.Models
{
    public class Product
    {
        public int ProductId {  get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity {  get; set; }
        public string? ImagePath {  get; set; }
        public int CategoryId {  get; set; }
        public virtual Category? Category { get; set; }

    }
}
