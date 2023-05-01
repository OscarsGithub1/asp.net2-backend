using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IdentityContext _dbContext;

        public ShoppingCartRepository(IdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShoppingCartEntity> GetShoppingCartByIdAsync(int shoppingCartId)
        {
            return await _dbContext.ShoppingCarts.FindAsync(shoppingCartId);
        }

        public async Task AddShoppingCartAsync(ShoppingCartEntity shoppingCart)
        {
            await _dbContext.ShoppingCarts.AddAsync(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateShoppingCartAsync(ShoppingCartEntity shoppingCart)
        {
            _dbContext.Entry(shoppingCart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartAsync(int shoppingCartId)
        {
            var shoppingCart = await GetShoppingCartByIdAsync(shoppingCartId);
            _dbContext.ShoppingCarts.Remove(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingCartItemEntity>> GetShoppingCartItemsAsync(int shoppingCartId)
        {
            return await _dbContext.ShoppingCartItems.Where(i => i.ShoppingCartId == shoppingCartId).ToListAsync();
        }

        public async Task AddShoppingCartItemAsync(ShoppingCartItemEntity shoppingCartItem)
        {
            await _dbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateShoppingCartItemAsync(ShoppingCartItemEntity shoppingCartItem)
        {
            _dbContext.Entry(shoppingCartItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartItemAsync(int shoppingCartItemId)
        {
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FindAsync(shoppingCartItemId);
            _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}

