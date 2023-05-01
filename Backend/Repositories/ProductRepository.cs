using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IdentityContext _dbContext;

        public ProductRepository(IdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task CreateAsync(ProductEntity product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await GetByIdAsync(id);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
