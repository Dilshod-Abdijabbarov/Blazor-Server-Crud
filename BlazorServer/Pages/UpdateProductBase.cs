using BlazorServer.Models;
using BlazorServer.Service;
using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace BlazorServer.Pages
{
    public class UpdateProductBase : ComponentBase
    {
        [Inject]
        protected IProductService ProductService { get; set; }
      
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Product Product { get; set; }
        public  List<Product> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductService.GetProduct(Id);
            Products =(List<Product>) await ProductService.GetProducts();
        }

        public void Updateproduct()
        {
            ProductService.UpdateProduct(Id, Product);
           
            NavigationManager.NavigateTo($"product/{Id}");
        }
    }
}
