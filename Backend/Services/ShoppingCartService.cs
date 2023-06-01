using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.DTO_s;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<ShoppingCartDto> GetShoppingCartByIdAsync(int shoppingCartId)
        {
            var shoppingCartEntity = await _shoppingCartRepository.GetShoppingCartByIdAsync(shoppingCartId);

            if (shoppingCartEntity == null)
            {
                throw new ArgumentException($"Shopping cart with id {shoppingCartId} not found");
            }

            var shoppingCartDto = new ShoppingCartDto
            {
                Id = shoppingCartEntity.Id,
                UserId = shoppingCartEntity.UserId,
                ShoppingCartItems = new List<ShoppingCartItemDto>()
            };

            var shoppingCartItems = await _shoppingCartRepository.GetShoppingCartItemsAsync(shoppingCartId);

            foreach (var shoppingCartItemEntity in shoppingCartItems)
            {
                var productEntity = await _productRepository.GetByIdAsync(shoppingCartItemEntity.ProductId);

                var shoppingCartItemDto = new ShoppingCartItemDto
                {
                    Id = shoppingCartItemEntity.Id,
                    Product = new ProductDto
                    {
                        Id = productEntity.Id,
                        Name = productEntity.Name,
                        Description = productEntity.Description,
                        size = productEntity.size,
                        price = productEntity.price,
                        rating = productEntity.rating,
                        Category = productEntity.Category
                    },
                    Quantity = shoppingCartItemEntity.Quantity
                };

                shoppingCartDto.ShoppingCartItems.Add(shoppingCartItemDto);
            }

            return shoppingCartDto;
        }

        public async Task AddShoppingCartItemAsync(int shoppingCartId, Guid productId, int quantity)
        {
            var shoppingCartEntity = await _shoppingCartRepository.GetShoppingCartByIdAsync(shoppingCartId);

            if (shoppingCartEntity == null)
            {
                throw new ArgumentException($"Shopping cart with id {shoppingCartId} not found");
            }

            var productEntity = await _productRepository.GetByIdAsync(productId);

            if (productEntity == null)
            {
                throw new ArgumentException($"Product with id {productId} not found");
            }

            var shoppingCartItemEntity = new ShoppingCartItemEntity
            {
                ShoppingCartId = shoppingCartId,
                ProductId = productId,
                Quantity = quantity
            };

            await _shoppingCartRepository.AddShoppingCartItemAsync(shoppingCartItemEntity);
        }

        public async Task UpdateShoppingCartItemAsync(int shoppingCartItemId, int quantity)
        {
            var shoppingCartItemEntity = await _shoppingCartRepository.GetShoppingCartItemByIdAsync(shoppingCartItemId);

            if (shoppingCartItemEntity == null)
            {
                throw new ArgumentException($"Shopping cart item with id {shoppingCartItemId} not found");
            }

            shoppingCartItemEntity.Quantity = quantity;

            await _shoppingCartRepository.UpdateShoppingCartItemAsync(shoppingCartItemEntity);
        }

        public async Task DeleteShoppingCartItemAsync(int shoppingCartItemId)
        {
            var shoppingCartItemEntity = await _shoppingCartRepository.GetShoppingCartItemByIdAsync(shoppingCartItemId);

            if (shoppingCartItemEntity == null)
            {
                throw new ArgumentException($"Shopping cart item with id {shoppingCartItemId} not found");
            }

            await _shoppingCartRepository.DeleteShoppingCartItemAsync(shoppingCartItemId);
        }
    }
}

