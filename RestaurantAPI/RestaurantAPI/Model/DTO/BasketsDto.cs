using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Model.DTO
{
    public class BasketsDto
    {
        [Key]
        [Column("dishId")]
        public int DishId { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
