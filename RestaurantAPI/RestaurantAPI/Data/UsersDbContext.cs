using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Model;

namespace RestaurantAPI.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected UsersDbContext()
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
