using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerChat.Models
{
    public class RequestAgentModel
    {
        public int idRequestAgent { get; set; }
        public int idCustomerRequest { get; set; }
        public int idAgent { get; set; }
        public bool isFinished { get; set; }
    }
}