using PS.Produc.API.Models;
using System.ComponentModel.DataAnnotations;

namespace PS.Produc.API.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
