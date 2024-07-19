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
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderDTO> AddAsync(OrderDTO orderDTO)
        {
            return _mapper.Map<OrderDTO>(await _orderRepository.AddAsync(_mapper.Map<Order>(orderDTO)));
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            return _mapper.Map<List<OrderDTO>>(await _orderRepository.GetAllAsync());
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<OrderDTO>(await _orderRepository.GetByIdAsync(id));
        }
       
        public async Task<OrderDTO> UpdateAsync(OrderDTO orderDTO)
        {
            return _mapper.Map<OrderDTO>(await _orderRepository.UpdateAsync(_mapper.Map<Order>(orderDTO)));
        }

       
    }
}
