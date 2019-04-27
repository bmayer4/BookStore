using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.API.Models
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public ICollection<Order> Orders { get; set;} = new List<Order>();
    }
}