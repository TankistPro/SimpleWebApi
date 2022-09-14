using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Test { get; set; }
    }
}
