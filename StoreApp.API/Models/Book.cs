using StoreApp.API.Data;

namespace StoreApp.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}