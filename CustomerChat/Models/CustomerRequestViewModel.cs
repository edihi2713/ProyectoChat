using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerChat.Models
{
    public class CustomerRequestViewModel
    {
        public string CustomerName { get; set; }
        public int RequestId { get; set; }
        public int? IdAgent { get; set; }
    }
}