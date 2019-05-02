using System;
using StoreApp.API.Data;

namespace StoreApp.API.Dtos
{
    public class BookForDetailDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public string GenreName { 
            get {
                return Enum.GetName(typeof(Genre), Genre);
            } 
        }
        public decimal Price { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}