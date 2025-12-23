using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.API.Data;
using catalog.API.Entities;
using MongoDB.Driver;

namespace catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Products.DeleteOneAsync(id);

            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return await _context.Products.Find(_ => _.Category == category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await _context.Products.Find(_ => _.Name == name).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var result = await _context.Products.ReplaceOneAsync(_ => _.Id == product.Id, product);

            return result.ModifiedCount > 0;
        }
    }
}