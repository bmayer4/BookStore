using System;
using System.Collections.Generic;

namespace StoreApp.API.Dtos
{
    public class OrderForUserToReturnDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public ICollection<OrderItemToReturnDto> OrderItems { get; set; } = new List<OrderItemToReturnDto>();
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserStreet { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public string UserZip { get; set; }
        public string UserCountry { get; set; }
    }
}