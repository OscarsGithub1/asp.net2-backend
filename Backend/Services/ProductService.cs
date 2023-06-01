using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.DTO_s;
using Backend.Models.Entities;
using Backend.Repositories;

namespace Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => MapProductEntityToDto(p));
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }
            return MapProductEntityToDto(product);
        }

        public async Task CreateAsync(CreateProductDto productDto)
        {
            var product = MapProductDtoToEntity(productDto);
            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(Guid id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Category = productDto.Category;
            existingProduct.Size = productDto.Size;
            existingProduct.Price = productDto.Price;
            existingProduct.Rating = productDto.Rating;

            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }

            await _productRepository.DeleteAsync(id);
        }

        private static ProductDto MapProductEntityToDto(ProductEntity product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Size = product.Size,
                Price = product.Price,
                Rating = product.Rating
            };
        }

        private static ProductEntity MapProductDtoToEntity(CreateProductDto productDto)
        {
            return new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Description = productDto.Description,
                Category = productDto.Category,
                Size = productDto.Size,
                Price = productDto.Price,
                Rating = productDto.Rating
            };
        }
    }
}
