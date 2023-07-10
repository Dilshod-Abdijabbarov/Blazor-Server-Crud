using BlazorServer.Web.Api.Models;

namespace BlazorServer.Web.Api.Service
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProduct(int id);
        Task<Product> UpdateProduct(int id,Product product);
        Task<Product> DeleteProduct(int id);

    }
}
