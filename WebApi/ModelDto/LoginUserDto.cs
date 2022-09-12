using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelDto
{
    public class LoginUserDto
    {
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
