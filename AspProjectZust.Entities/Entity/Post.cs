using AspProjectZust.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string? Images { get; set; }
        public string? Videos { get; set; }
        public ICollection<Friend>? TaggedFriends { get; set; }
        public string? Content { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual CustomIdentityUser? User { get; set; }
        public string? UserId { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
