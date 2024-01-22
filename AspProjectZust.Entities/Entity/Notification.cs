using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class Notification
    {
        public int Id { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        //public virtual CustomIdentityUser? Sender { get; set; }
        public virtual CustomIdentityUser? Receiver { get; set; }
    }
}
