using System.ComponentModel.DataAnnotations;

namespace StoreApp.API.Dtos
{
    public class OrderItemForCreationDto
    {
        [Required]
        public int BookId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}