using System.ComponentModel.DataAnnotations;

namespace StoreApp.API.Dtos
{
    public class OrderItemForCreationDto
    {
        [Required]
        public int BookId { get; set; }
        
        [Required]
        [Range(1, 99, ErrorMessage = "Quantity must be between 1 and 99")]
        public int Quantity { get; set; }
    }
}