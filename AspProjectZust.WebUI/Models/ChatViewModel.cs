using AspProjectZust.Entities.Entity;

namespace AspProjectZust.WebUI.Models
{
    public class ChatViewModel
    {
        public Chat? CurrentChat { get; set; }
        public CustomIdentityUser? Sender { get; set; }
        public string? CurrentUserId { get; set; }
    }
}
