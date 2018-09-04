using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerChat.Models
{
    public class RequestModel
    {
        public int IdRequestCustomer { get; set; }
        public string CustomerName  { get; set; }
        public string  Document { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public int idDocumentType { get; set; }
    }
}