using System;
using System.Collections.Generic;

namespace StoreApp.API.Dtos
{
    public class OrderForGuestToReturnDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public bool Shipped { get; set; }
        public ICollection<OrderItemToReturnDto> OrderItems { get; set; } = new List<OrderItemToReturnDto>();
        public decimal TotalOrderPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}