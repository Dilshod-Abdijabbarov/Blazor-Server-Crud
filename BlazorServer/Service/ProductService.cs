using BlazorServer.Models;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorServer.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await httpClient.PostAsJsonAsync<Product>("api/product",product);

            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await httpClient.DeleteFromJsonAsync<Product>($"api/Product/deleteproduct/{id}");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<List<Product>>("api/Product");
        }

        public async Task<Product> GetProduct(int id)
        {
            var resualt = await httpClient.GetAsync($"api/product/{id}");

            if (resualt.StatusCode == HttpStatusCode.OK)
            {
                return await resualt.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
            return null;
            }
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            await httpClient.PutAsJsonAsync($"api/Product/updateproduct/{id}", product);
            
            return product;
        }
    }
}
