using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Resources.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            return await _orderService.GetAllAsync();
        }

        [HttpPost]
        public async Task<OrderDTO> Post([FromBody] OrderModel
            model)
        {
            return await _orderService.AddAsync(new OrderDTO()
            {
                Id=model.Id, 
                ProductId=model.ProductId,
                Count=model.Count,
                Date=model.Date
            });
        }

        [HttpPut("{id}")]
        public async Task<OrderDTO> Put(int id, [FromBody] OrderModel model)
        {
            OrderDTO r = new OrderDTO()
            {
                Id = id,
                ProductId = model.ProductId,
                Count = model.Count,
                Date = model.Date
            };
            return await _orderService.UpdateAsync(r);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _orderService.DeleteAsync(id);
        }
    }
}
