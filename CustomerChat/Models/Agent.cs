using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerChat.Models
{
    public class Agent
    {
        public string AgentId { get; set; }
        public string AgentUser { get; set; }
        public string AgentDocument { get; set; }
        public string AgentName { get; set; }
        public bool isAvailable { get; set; }
    }
}