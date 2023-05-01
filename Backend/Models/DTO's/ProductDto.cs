using Backend.Models.Entities;

namespace Backend.Models.DTO_s
{
    public class ProductDto : ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int rating { get; set; }
        public string Category { get; set; } = null!;
        public string size { get; set; } = null!;
        public decimal price { get; set; } 
        public string description { get; set; }
       
    }
}
