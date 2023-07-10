using BlazorServer.Web.Api.Data;
using BlazorServer.Web.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Web.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContextApp data;

        public ProductService(DataBaseContextApp data)
        {
            this.data = data;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await data.Products.AddAsync(product);
            await data.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
           var entity=await data.Products.FirstOrDefaultAsync(x => x.Id == id);           
           data.Products.Remove(entity);
           await data.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           var entities=await data.Products.ToListAsync();

            return entities;
        }

        public async Task<Product> GetProduct(int id)
        {
            var entity = await data.Products.FirstOrDefaultAsync(x=>x.Id==id);

            return entity;
        }

        public async  Task<Product> UpdateProduct(int id, Product product)
        {
            var entity = await data.Products.FirstOrDefaultAsync(x => x.Id == id);
            entity.Name=product.Name;
            entity.Description=product.Description;
            entity.Price=product.Price;
            data.Products.Update(entity);
            await data.SaveChangesAsync();

            return entity;

        }
    }
}
