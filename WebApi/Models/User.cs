using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set;}
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
