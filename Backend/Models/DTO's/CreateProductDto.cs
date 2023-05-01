namespace Backend.Models.DTO_s
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
