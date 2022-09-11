using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelDto
{
    public class RegistrationUserDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public int? Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
