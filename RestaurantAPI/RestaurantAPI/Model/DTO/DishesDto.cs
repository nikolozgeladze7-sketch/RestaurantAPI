using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Model.DTO
{
    public class DishesDto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("nuts")]
        public bool Nuts { get; set; }
        [Column("image")]
        public string? Image { get; set; }
        [Column("vegetarian")]
        public bool Vegetarian { get; set; }
        [Column("spiciness")]
        public int Spiciness { get; set; }
        [Column("categoryId")]
        public int CategoryId { get; set; }
    }
}
