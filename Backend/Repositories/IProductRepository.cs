using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models.Entities;

namespace Backend.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task CreateAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        Task DeleteAsync(Guid id);
    }
}
