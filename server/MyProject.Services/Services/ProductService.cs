using AutoMapper;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Resources.DTOs;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDTO> AddAsync(ProductDTO productDTO)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.AddAsync(_mapper.Map<Product>(productDTO)));
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            return _mapper.Map<List<ProductDTO>>(await _productRepository.GetAllAsync());
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        }
        public List<ProductOrdersCountDTO> GetProductOrdersCounts()
        {
            return _mapper.Map<List<ProductOrdersCountDTO>>(_productRepository.GetProductsOrdersCount());
        }
        public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.UpdateAsync(_mapper.Map<Product>(productDTO)));
        }
    }
}
