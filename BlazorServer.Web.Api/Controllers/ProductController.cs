using BlazorServer.Web.Api.Data;
using BlazorServer.Web.Api.Models;
using BlazorServer.Web.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
           var entities = await service.GetAll();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var entity = await service.GetProduct(id);

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePraduct(Product product)
        {
            var entity = await service.CreateProduct(product);

            return Ok(entity);
        }

        [HttpPut("updateproduct/{id}")]
        public async Task<IActionResult> UpdatePraduct(int id,Product product)
        {
            var entity = await service.UpdateProduct(id, product);

            return Ok(entity);
        }

        [HttpDelete("deleteproduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var entity = await service.DeleteProduct(id);

            return Ok(entity);
        }
    }
}
