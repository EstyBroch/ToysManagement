using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Resources.DTOs;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;
using MyProject.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _ProductService;

        public ProductsController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await _ProductService.GetAllAsync();
        }
        [HttpGet("productsOrdersCount")]
        public  List<ProductOrdersCountDTO> GetProductsOrdersCount()
        {
            return  _ProductService.GetProductOrdersCounts();
        }
        [HttpPost]
        public async Task<ProductDTO> Post([FromBody] ProductModel
            model)
        {
            return await _ProductService.AddAsync(new ProductDTO()
            {
                Name = model.Name,
                Id = model.Id,
                Description=model.Description,
                Title=model.Title,
                Makat=model.Makat,
                Picture=model.Picture,
                Price=model.Price
       });
        }

        [HttpPut("{id}")]
        public async Task<ProductDTO> Put(int id, [FromBody] ProductModel model)
        {
            ProductDTO r = new ProductDTO()
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                Title = model.Title,
                Makat = model.Makat,
                Picture = model.Picture,
                Price = model.Price
            };
            return await _ProductService.UpdateAsync(r);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ProductService.DeleteAsync(id);
        }
    }
}
