using Backend.Models.DTO_s;
using Backend.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> CreateAsync(CreateProductDto productDto);
        Task<ProductDto> UpdateAsync(Guid id, ProductDto productDto);
        Task DeleteAsync(Guid id);
    }
}
