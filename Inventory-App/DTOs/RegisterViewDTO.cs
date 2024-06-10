using System.ComponentModel.DataAnnotations;

namespace Inventory_App.DTOs
{
    public class RegisterViewDTO
    {
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
