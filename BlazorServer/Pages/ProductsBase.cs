using BlazorServer.Models;
using BlazorServer.Service;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }
        protected List<Product> Products { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Products = (await ProductService.GetProducts()).ToList();           
        }

        protected void ShowProduct(int id)
        {
            NavigationManager.NavigateTo($"Product/{id}");
        }
    }
}
