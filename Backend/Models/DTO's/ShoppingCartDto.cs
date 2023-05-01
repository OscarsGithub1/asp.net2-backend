using Backend.Models.Entities;

namespace Backend.Models.DTO_s
{
    public class ShoppingCartDto : ShoppingCartEntity
    {
        public Guid Id { get; set; }
        public List<ShoppingCartDto> Items { get; set; }

    }
}
