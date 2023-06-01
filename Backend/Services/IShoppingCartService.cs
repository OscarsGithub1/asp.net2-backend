using Backend.Models.DTO_s;
using Backend.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDto> GetShoppingCartByIdAsync(int shoppingCartId);
        Task AddShoppingCartAsync(CreateShoppingCartDto shoppingCart);
        Task UpdateShoppingCartAsync(int shoppingCartId, UpdateShoppingCartDto shoppingCart);
        Task DeleteShoppingCartAsync(int shoppingCartId);
        Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsAsync(int shoppingCartId);
        Task AddShoppingCartItemAsync(CreateShoppingCartItemDto shoppingCartItem);
        Task UpdateShoppingCartItemAsync(int shoppingCartItemId, UpdateShoppingCartItemDto shoppingCartItem);
        Task DeleteShoppingCartItemAsync(int shoppingCartItemId);
    }
}
