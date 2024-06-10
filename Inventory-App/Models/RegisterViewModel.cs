using System.ComponentModel.DataAnnotations;

namespace Inventory_App.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y su confirmacion no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
