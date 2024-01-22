using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class Friend
    {
        public int Id { get; set; }
        public string? OwnId { get; set; }
        public string? YourFriendId { get; set; }
        public virtual CustomIdentityUser? YourFriend { get; set; }
    }
}
