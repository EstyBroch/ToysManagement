using MyProject.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(int id);
        Task<OrderDTO>AddAsync(OrderDTO orderDTO);
        Task<OrderDTO> UpdateAsync(OrderDTO orderDTO);
        Task DeleteAsync(int id);
    }
}
