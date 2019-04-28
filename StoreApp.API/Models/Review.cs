namespace StoreApp.API.Models
{
    public class Review
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}