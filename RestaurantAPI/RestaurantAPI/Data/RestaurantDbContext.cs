using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Model;
using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dishes> Dishes { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Categories>().HasData(
                new Categories { Id = 1, Name = "Pizza" },
                new Categories { Id = 2, Name = "Burgers" },
                new Categories { Id = 3, Name = "Drinks" },
                new Categories { Id = 4, Name = "Desserts" },
                new Categories { Id = 5, Name = "Salads" }
            );

            builder.Entity<Dishes>().HasData(
                new Dishes { Id = 1, Name = "Margherita", Price = 15.5m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 1, Image = "pizza1.jpg" },
                new Dishes { Id = 2, Name = "Pepperoni", Price = 18m, Nuts = false, Vegetarian = false, Spiciness = 1, CategoryId = 1, Image = "pizza2.jpg" },
                new Dishes { Id = 3, Name = "BBQ Chicken Pizza", Price = 20m, Nuts = false, Vegetarian = false, Spiciness = 2, CategoryId = 1, Image = "pizza3.jpg" },

                new Dishes { Id = 4, Name = "Classic Burger", Price = 12m, Nuts = false, Vegetarian = false, Spiciness = 1, CategoryId = 2, Image = "burger1.jpg" },
                new Dishes { Id = 5, Name = "Cheeseburger", Price = 13.5m, Nuts = false, Vegetarian = false, Spiciness = 1, CategoryId = 2, Image = "burger2.jpg" },
                new Dishes { Id = 6, Name = "Veggie Burger", Price = 11m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 2, Image = "burger3.jpg" },

                new Dishes { Id = 7, Name = "Coca Cola", Price = 3m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 3, Image = "drink1.jpg" },
                new Dishes { Id = 8, Name = "Orange Juice", Price = 4m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 3, Image = "drink2.jpg" },
                new Dishes { Id = 9, Name = "Lemonade", Price = 3.5m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 3, Image = "drink3.jpg" },

                new Dishes { Id = 10, Name = "Chocolate Cake", Price = 6m, Nuts = true, Vegetarian = true, Spiciness = 0, CategoryId = 4, Image = "dessert1.jpg" },
                new Dishes { Id = 11, Name = "Cheesecake", Price = 6.5m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 4, Image = "dessert2.jpg" },
                new Dishes { Id = 12, Name = "Ice Cream", Price = 5m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 4, Image = "dessert3.jpg" },

                new Dishes { Id = 13, Name = "Caesar Salad", Price = 9m, Nuts = false, Vegetarian = false, Spiciness = 0, CategoryId = 5, Image = "salad1.jpg" },
                new Dishes { Id = 14, Name = "Greek Salad", Price = 8.5m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 5, Image = "salad2.jpg" },
                new Dishes { Id = 15, Name = "Avocado Salad", Price = 10m, Nuts = true, Vegetarian = true, Spiciness = 0, CategoryId = 5, Image = "salad3.jpg" },

                new Dishes { Id = 16, Name = "Spicy Pizza", Price = 19m, Nuts = false, Vegetarian = false, Spiciness = 3, CategoryId = 1, Image = "pizza4.jpg" },
                new Dishes { Id = 17, Name = "Double Burger", Price = 15m, Nuts = false, Vegetarian = false, Spiciness = 2, CategoryId = 2, Image = "burger4.jpg" },
                new Dishes { Id = 18, Name = "Mojito", Price = 5m, Nuts = false, Vegetarian = true, Spiciness = 0, CategoryId = 3, Image = "drink4.jpg" },
                new Dishes { Id = 19, Name = "Brownie", Price = 5.5m, Nuts = true, Vegetarian = true, Spiciness = 0, CategoryId = 4, Image = "dessert4.jpg" },
                new Dishes { Id = 20, Name = "Chicken Salad", Price = 11m, Nuts = false, Vegetarian = false, Spiciness = 1, CategoryId = 5, Image = "salad4.jpg" }
            );
        }
    }
}
