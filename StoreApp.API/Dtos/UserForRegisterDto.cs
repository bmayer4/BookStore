using System.ComponentModel.DataAnnotations;

namespace StoreApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 14 characters.")]
        public string Password { get; set; }

        // UserName is unique in Identity, and required
        public string  UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }
    }
}