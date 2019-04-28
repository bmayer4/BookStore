using System.ComponentModel.DataAnnotations;

namespace StoreApp.API.Dtos
{
    public class ReviewForCreationDto
    {
        [Required]
        public string Content { get; set; }

        [Range(1, 5)]  //cant do required since int
        public int Rating { get; set; }
    }
}