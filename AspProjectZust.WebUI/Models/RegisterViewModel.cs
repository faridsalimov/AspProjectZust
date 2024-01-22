using System.ComponentModel.DataAnnotations;

namespace AspProjectZust.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        //public IFormFile? File { get; set; }
        public bool IsAcceptThePrivacy { get; set; }
        //public string? ImageUrl { get; set; } = "person.jpg";
    }
}
