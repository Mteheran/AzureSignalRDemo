using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs.Models
{
    public class ChatMessage
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
