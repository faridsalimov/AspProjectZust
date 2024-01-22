using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class Chat
    {
        public int id { get; set; }
        public string? ReceiverId { get; set; }
        public string? SenderId { get; set; }

        public virtual CustomIdentityUser? Receiver { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
    }
}
