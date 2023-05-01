using Backend.Models.Entities;

namespace Backend.Models.DTO_s
{
    public class ShoppingCartItemDto : ProductEntity
    {
        public Guid Id { get; set; }
        //Id ska vara samma som produkt Id så det går att söka efter den samma med name
        public string name { get; set; }
        public string size { get; set; } = null!;
        public decimal price { get; set; }
        public string price2 { get; set; } = null!;
        public int quantity { get; set; }

    }
}
