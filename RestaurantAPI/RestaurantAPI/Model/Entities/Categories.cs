using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Model.Entities
{
    public class Categories
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
