using System.ComponentModel.DataAnnotations;

namespace Inventory_App.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Cuantity { get; set; }

    }
}
