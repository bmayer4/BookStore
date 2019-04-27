using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using StoreApp.API.Models;

namespace StoreApp.API.Dtos
{
    public class OrderForCreationDto
    {
        public OrderForCreationDto()
        {
            OrderDate = DateTime.UtcNow;

            OrderNumber = new Random().Next(0, 1000) * DateTime.Now.Millisecond;
        }
    
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }

        [Required]
        public bool Guest { get; set; }
        public ICollection<OrderItemForCreationDto> OrderItems { get; set; } = new List<OrderItemForCreationDto>();

        // Below properties are for guest user
        [RequiredIf("Guest")]
        public string FirstName { get; set; }

        [RequiredIf("Guest")]
        public string LastName { get; set; }

        [RequiredIf("Guest")]
        public string Street { get; set; }

        [RequiredIf("Guest")]
        public string City { get; set; }

        [RequiredIf("Guest")]
        public string State { get; set; }

        [RequiredIf("Guest")]
        public string Zip { get; set; }

        [RequiredIf("Guest")]
        public string Country { get; set; }
    }
}