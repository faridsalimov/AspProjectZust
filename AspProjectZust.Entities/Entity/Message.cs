using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class Message
    {
        public int id { get; set; }
        public string? Content { get; set; }
        public bool IsImage { get; set; }
        public DateTime WriteTime { get; set; }
        public string? ReceiverId { get; set; }
        public string? SenderId { get; set; }
        public int ChatId { get; set; }
        public virtual Chat? Chat { get; set; }
        public bool HasSeen { get; set; }
    }
}