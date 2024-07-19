using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.LocalEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var newProduct = _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return newProduct.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Products.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public List<ProductOrdersCount> GetProductsOrdersCount()
        {
            var result = new List<ProductOrdersCount>();
            var products = _context.Products.ToList();
            foreach (var product in products)
            {
                var p = new ProductOrdersCount
                {
                    Product = product,
                    OrdersCount = _context.Orders.Count(o => o.ProductId == product.Id)
                };
                p.Product.Picture = ConvertImageToBase64(p.Product.Picture);
                result.Add(p);
            }
            return result;
            
        }

        private string ConvertImageToBase64(string imagePath)
        {
            if (!File.Exists(imagePath))
            { return string.Empty; }

            byte[] imageArray = File.ReadAllBytes(imagePath);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var update = _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return update.Entity;
        }
    }
}

