using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Model.DTO
{
    public class UserDto
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;
    }
}
