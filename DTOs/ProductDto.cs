using ShoppingNet.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ShoppingNet.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required!")]
        [MaxLength(100)]
        [MinLength(1)]
        public string? Name { get; set; }

        [Required(ErrorMessage ="The price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The stock is required")]
        [Range(1,9999)]
        public long Stock { get; set; }
        public string? ImagemUrl { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

    }
}
