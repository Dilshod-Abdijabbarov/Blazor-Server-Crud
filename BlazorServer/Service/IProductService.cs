

using BlazorServer.Models;

namespace BlazorServer.Service
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> UpdateProduct(int id, Product product);
        Task<Product> DeleteProduct(int id);
    }
}
