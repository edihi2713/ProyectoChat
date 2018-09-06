using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerChat.Models
{
    public class MessagesModel
    {
        public int IdMessage { get; set; }
        public int IdConversation { get; set; }
        public string Message { get; set; }
        public string from { get; set; }
        public bool Read { get; set; }
    }
}