using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Model.DTO
{
    public class CategoriesDto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
