namespace AspProjectZust.WebUI.Models
{
    public class UserInfoViewModel
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public IFormFile? File { get; set; }
        public string? ImageUrl { get; set; }
        public int userRequestCount { get; set; }
    }
}
