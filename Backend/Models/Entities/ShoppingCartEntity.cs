namespace Backend.Models.Entities
{
    public class ShoppingCartEntity
    {
        public int ShoppingCartId { get; set; }
        public List<ShoppingCartItemEntity> Items { get; set; } = new List<ShoppingCartItemEntity>();
    }
}
