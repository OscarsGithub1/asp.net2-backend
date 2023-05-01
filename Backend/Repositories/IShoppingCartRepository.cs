using Backend.Models.Entities;

namespace Backend.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCartEntity> GetShoppingCartByIdAsync(int shoppingCartId);
        Task AddShoppingCartAsync(ShoppingCartEntity shoppingCart);
        Task UpdateShoppingCartAsync(ShoppingCartEntity shoppingCart);
        Task DeleteShoppingCartAsync(int shoppingCartId);
        Task<IEnumerable<ShoppingCartItemEntity>> GetShoppingCartItemsAsync(int shoppingCartId);
        Task AddShoppingCartItemAsync(ShoppingCartItemEntity shoppingCartItem);
        Task UpdateShoppingCartItemAsync(ShoppingCartItemEntity shoppingCartItem);
        Task DeleteShoppingCartItemAsync(int shoppingCartItemId);
    }
}
