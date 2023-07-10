using BlazorServer.Models;
using BlazorServer.Service;
using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace BlazorServer.Pages
{
    public class AddProductBase : ComponentBase
    {
        [Inject]
        protected IProductService ProductService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Product Product { get; set; }
        private List<Product> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = new Product();
            Products = (List<Product>)await ProductService.GetProducts();
        }

        public async void SubmitPlayer()
        {
            await ProductService.CreateProduct(Product);

            NavigationManager.NavigateTo("/products");
        }
    }
}
