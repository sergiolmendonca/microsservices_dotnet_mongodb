using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.API.Entities;

namespace catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<IEnumerable<Product>> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);
        Task CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(string id);
    }
}