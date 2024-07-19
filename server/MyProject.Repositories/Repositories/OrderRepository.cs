using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    internal class OrderRepository:IOrderRepository
    {
        private readonly IContext _context;
        public OrderRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            var newOrder = _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return newOrder.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Orders.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
        public async Task<Order> UpdateAsync(Order order)
        {
            var update = _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return update.Entity;
        }
    }
}

