using System.ComponentModel.DataAnnotations;

namespace SimpleProductApi.Models
{
    public class CreateProductRequestModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
