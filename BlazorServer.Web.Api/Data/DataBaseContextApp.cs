using BlazorServer.Web.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Web.Api.Data
{
    public class DataBaseContextApp : DbContext
    {
        public DataBaseContextApp(DbContextOptions<DataBaseContextApp> options) :base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
