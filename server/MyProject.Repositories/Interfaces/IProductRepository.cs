using MyProject.Repositories.Entities;
using MyProject.Repositories.LocalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        List<ProductOrdersCount> GetProductsOrdersCount();

        Task DeleteAsync(int id);
    }
}
