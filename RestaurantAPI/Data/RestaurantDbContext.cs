using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {

        }

        protected RestaurantDbContext()
        {
        }

        public DbSet<Product> Product {  get; set; }
    }
}
