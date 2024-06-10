using System.ComponentModel.DataAnnotations;

namespace Inventory_App.DTOs
{
    public class LoginViewDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
