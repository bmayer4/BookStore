using System;
using StoreApp.API.Data;

namespace StoreApp.API.Dtos
{
    public class OrderItemToReturnDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string BookTitle { get; set; }
        public string BookPages { get; set; }
        public Genre BookGenre { get; set; }
        public string GenreName { 
            get {
                return Enum.GetName(typeof(Genre), BookGenre);
            } 
        }
    }
}