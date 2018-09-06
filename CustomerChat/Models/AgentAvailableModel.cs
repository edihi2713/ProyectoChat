using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerChat.Models
{
    public class AgentAvailableModel
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public bool Available { get; set; }
    }
}