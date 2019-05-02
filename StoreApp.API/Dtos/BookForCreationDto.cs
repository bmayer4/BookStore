using StoreApp.API.Data;

namespace StoreApp.API.Dtos
{
    public class BookForCreationDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
    }
}