using MyProject.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> AddAsync(ProductDTO productDTO);
        List<ProductOrdersCountDTO> GetProductOrdersCounts();
        Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
        Task DeleteAsync(int id);
    }
}
