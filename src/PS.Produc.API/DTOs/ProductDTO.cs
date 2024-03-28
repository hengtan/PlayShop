using PS.Produc.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PS.Produc.API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The price is required")]        
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The description is required")]
        [MaxLength(200)]
        [MinLength(5)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 9999)]        
        public long Stock { get; set; }

        public string? ImageURL { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        public int CategoryId { get; set; }
    }
}
