using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Entities
{
    public class ShoppingCartItemEntity : ProductEntity
    {
        public int ShoppingCartItemId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductEntity")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCartEntity ShoppingCart { get; set; }
    }
}
