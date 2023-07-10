using BlazorServer.Models;
using BlazorServer.Service;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class GetProductBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected Product Product { get; set; }

        protected override async Task OnParametersSetAsync()
        {
             Product = await ProductService.GetProduct((int)Id);
        }

        protected void ShowProduct(int id)
        {
            NavigationManager.NavigateTo($"updateproduct/{id}");
        }

        protected void DeleteProduct(int id)
        {
            ProductService.DeleteProduct((int)Id);

            NavigationManager.NavigateTo("products");
        }
    }
}
