using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestaurantAPI.Model.DTO;

namespace RestaurantAPI.Model.Entities
{
    public class Basket
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("dishId")]
        public int DishId { get; set; }

        [Column("price")]
        public int Price { get; set; } // Dish.Price * Quantity

        [Column("quantity")]
        public int Quantity { get; set; }
    }

    //public class BasketDto
    //{
    //    public List<BasketsDto> Items { get; set; } = new List<BasketsDto>();

    //    public int TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    //}
}